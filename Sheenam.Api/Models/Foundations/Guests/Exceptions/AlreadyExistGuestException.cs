using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exceptions
{
    public class AlreadyExistGuestException : Xeption
    {
        public AlreadyExistGuestException(Exception innerException)
            : base(message: "Guest already exist", innerException)
        { }
    }
}
