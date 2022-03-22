using System.Threading.Tasks;
using AutoMapper;
using Bookshare.API.Requests.Libraries;
using Bookshare.API.Responses.Libraries;
using Bookshare.ApplicationServices.Commands.LibraryCommands;
using Bookshare.ApplicationServices.Queries.LibraryQueries;
using Bookshare.Domain.General;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookshare.API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/libraries")]

    public class LibraryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LibraryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<OperationResult> Add([FromBody] AddLibraryRequest addLibraryRequest)
        {
            var addLibraryCommand = _mapper.Map<AddLibraryCommand>(addLibraryRequest);
            return await _mediator.Send(addLibraryCommand);
        }

        [HttpGet("{id:int}")]
        public async Task<OperationResult<GetLibraryByIdResponse>> GetLibraryById([FromRoute] GetLibraryByIdRequest getLibraryByIdRequest)
        {
            var getLibraryByIdQuery = _mapper.Map<GetLibraryByIdQuery>(getLibraryByIdRequest);
            var operationResult = await _mediator.Send(getLibraryByIdQuery);

            if (!operationResult.IsSucceeded)
            {
                return OperationResult.Fail<GetLibraryByIdResponse>(operationResult.Errors);
            }

            var response = _mapper.Map<GetLibraryByIdResponse>(operationResult.Result);
            return OperationResult.Ok(response);
        }

        [HttpGet]
        public async Task<OperationResult<GetLibrariesResponse>> GetLibraries()
        {
            var operationResult = await _mediator.Send(new GetLibrariesQuery());

            if (!operationResult.IsSucceeded)
            {
                return OperationResult.Fail<GetLibrariesResponse>(operationResult.Errors);
            }

            var response = _mapper.Map<GetLibrariesResponse>(operationResult.Result);
            return OperationResult.Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<OperationResult<UpdateLibraryResponse>> Update([FromRoute] int id, [FromBody] UpdateLibraryByIdRequest updateLibraryByIdRequest)
        {
            var updateLibraryCommand = _mapper.Map<UpdateLibraryCommand>(updateLibraryByIdRequest);
            updateLibraryCommand.Id = id;
            var operationResult = await _mediator.Send(updateLibraryCommand);

            if (!operationResult.IsSucceeded)
            {
                return OperationResult.Fail<UpdateLibraryResponse>(operationResult.Errors);
            }

            var response = _mapper.Map<UpdateLibraryResponse>(operationResult.Result);
            return OperationResult.Ok(response);
        }
    }
}
