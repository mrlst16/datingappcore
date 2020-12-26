using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Validators
{
    public static class Errors
    {
        public static class Codes
        {
            public const string NoEmail = "0000001";
            public const string NoUsername = "0000002";
            public const string NoPassword = "0000003";
            public const string NoBirthday = "0000004";
            public const string NoUserId = "0000005";
            public const string UserExists = "0000006";
        }

        public static class Messages
        {
            public const string NoEmail = "No email was provider";
            public const string NoUsername = "No username was provider";
            public const string NoPassword = "No password was provider";
            public const string NoBirthday = "No birthdate was provided";
            public const string NoUserId = "No user id was provided";
            public const string UserExists = "The user already exists";
        }
    }
}
