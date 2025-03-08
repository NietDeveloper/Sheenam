using System.Threading.Tasks;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;
using Xeptions;

namespace Sheenam.Api.Services.Foundation.Guests
{
    public partial class GuestService
    {
        private delegate ValueTask<Guest> ReturningGuestFunction();

        private async ValueTask<Guest> TryCach(ReturningGuestFunction function)
        {
            try
            {
                return await function();
            }
            catch (NullGuestException nullGuestException)
            {
                throw CreateAndLogValidationException(nullGuestException);
            }
        }

        private GuestValidationExeption CreateAndLogValidationException(Xeption xeption)
        {
            var guestValidationException =
                    new GuestValidationExeption(xeption);

            this.loggingBroker.LogError(guestValidationException);
            
            return guestValidationException;
        }
    }
}
