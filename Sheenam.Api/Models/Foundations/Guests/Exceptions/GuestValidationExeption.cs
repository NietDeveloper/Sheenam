using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exceptions
{
    public class GuestValidationExeption : Xeption
    {
        public GuestValidationExeption(Xeption innerException)
            : base(message: "Guest validation error occurred, fix the errors and try again",
                 innerException)
        { }
    }
}
