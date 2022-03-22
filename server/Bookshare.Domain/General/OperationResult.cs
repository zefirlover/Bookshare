﻿using System.Collections.Generic;

namespace Bookshare.Domain.General
{
    public class OperationResult
    {
        public bool IsSucceeded { get; set; }
        public List<string>? Errors { get; set; }
        public static OperationResult<TResponse> Ok<TResponse>(TResponse result)
            where TResponse : class
            => new()
            {
                Result = result,
                Errors = null,
                IsSucceeded = true,
            };

        public static OperationResult Ok() => new()
        {
            Errors = null,
            IsSucceeded = true,
        };

        public static OperationResult Fail(string message) => new()
        {
            Errors = new List<string>
            {
                message,
            },
            IsSucceeded = false,
        };

        public static OperationResult<TResponse> Fail<TResponse>(string message)
            where TResponse : class
            => new()
            {
                Result = null,
                Errors = new List<string>
            {
                message,
            },
                IsSucceeded = false,
            };

        public static OperationResult Fail(List<string> messages) => new()
        {
            Errors = messages,
            IsSucceeded = false,
        };

        public static OperationResult<TResponse> Fail<TResponse>(List<string> messages)
            where TResponse : class
            => new()
            {
                Result = null,
                Errors = messages,
                IsSucceeded = false,
            };
    }

    public sealed class OperationResult<TResponse> : OperationResult
        where TResponse : class
    {
        public TResponse? Result { get; set; }
    }
}
