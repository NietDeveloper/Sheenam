using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exceptions
{
    public class NullGuestExceptioncs : Xeption
    {
        public NullGuestExceptioncs() 
            : base(message: "Guest is null") 
        { }
    }
}
