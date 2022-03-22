using System.Threading.Tasks;
using AutoMapper;
using Bookshare.API.Requests.Books;
using Bookshare.API.Responses.Books;
using Bookshare.ApplicationServices.Commands.BookCommands;
using Bookshare.ApplicationServices.Queries.BookQueries;
using Bookshare.Domain.General;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookshare.API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/books")]

    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<OperationResult> Add([FromBody] AddBookRequest addBookRequest)
        {
            var addBookCommand = _mapper.Map<AddBookCommand>(addBookRequest);
            return await _mediator.Send(addBookCommand);
        }

        [HttpGet("{id:int}")]
        public async Task<OperationResult<GetBookByIdResponse>> GetBookById([FromRoute] GetBookByIdRequest getBookByIdRequest)
        {
            var getBookByIdQuery = _mapper.Map<GetBookByIdQuery>(getBookByIdRequest);
            var operationResult = await _mediator.Send(getBookByIdQuery);

            if (!operationResult.IsSucceeded)
            {
                return OperationResult.Fail<GetBookByIdResponse>(operationResult.Errors);
            }

            var response = _mapper.Map<GetBookByIdResponse>(operationResult.Result);
            return OperationResult.Ok(response);
        }

        [HttpGet]
        public async Task<OperationResult<GetBooksResponse>> GetBooks()
        {
            var operationResult = await _mediator.Send(new GetBooksQuery());

            if (!operationResult.IsSucceeded)
            {
                return OperationResult.Fail<GetBooksResponse>(operationResult.Errors);
            }

            var response = _mapper.Map<GetBooksResponse>(operationResult.Result);
            return OperationResult.Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<OperationResult<UpdateBookResponse>> Update([FromRoute] int id, [FromBody] UpdateBookByIdRequest updateBookByIdRequest)
        {
            var updateBookCommand = _mapper.Map<UpdateBookCommand>(updateBookByIdRequest);
            updateBookCommand.Id = id;
            var operationResult = await _mediator.Send(updateBookCommand);

            if (!operationResult.IsSucceeded)
            {
                return OperationResult.Fail<UpdateBookResponse>(operationResult.Errors);
            }

            var response = _mapper.Map<UpdateBookResponse>(operationResult.Result);
            return OperationResult.Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<OperationResult> Remove([FromRoute] RemoveBookByIdRequest removeBookByIdRequest)
        {
            var removeBookByIdCommand = _mapper.Map<RemoveBookByIdCommand>(removeBookByIdRequest);
            return await _mediator.Send(removeBookByIdCommand);
        }
    }
}
