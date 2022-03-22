﻿namespace Bookshare.Domain.Constants
{
    public static class ErrorConstants
    {
        public const string FieldIsRequired = "Field '{0}' is required!";
        public const string EntityNotFound = "{0} with {1} '{2}' not found!";
        public const string EntityAlreadyExists = "{0} with {1} '{2}' already exists!";
        public const string InvalidCredentials = "Invalid username or password!";
        public const string PasswordsDoNotMatch = "Passwords do not match!";
        public const string InvalidToken = "Invalid token!";
    }
}
