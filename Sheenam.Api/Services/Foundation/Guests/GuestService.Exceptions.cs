using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
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
            catch(InvalidGuestException invalidGuestException)
            {
                throw CreateAndLogValidationException(invalidGuestException);
            }
            catch(SqlException sqlException)
            {
                var failedGuestStorageException = new FailedGuestStorageException(sqlException);
                throw CreateAndLogCriticalDependencyException(failedGuestStorageException);
            }
            catch(DuplicateKeyException duplicateKeyException)
            {
                var alreadExistGuestException = 
                    new AlreadyExistGuestException(duplicateKeyException);

                throw CreateAndLogDependencyValidationExeption(alreadExistGuestException);
            }
        }

        private GuestValidationExeption CreateAndLogValidationException(Xeption xeption)
        {
            var guestValidationException =
                    new GuestValidationExeption(xeption);

            this.loggingBroker.LogError(guestValidationException);
            
            return guestValidationException;
        }

        private GuestDependencyException CreateAndLogCriticalDependencyException(Xeption xeption)
        {
            var guestDependencyException = new GuestDependencyException(xeption);
            this.loggingBroker.LogCritical(guestDependencyException);

            return guestDependencyException;
        }

        private GuestDependencyValidationException CreateAndLogDependencyValidationExeption(Xeption xeption)
        {
            var guestDependencyValidationException = 
                new GuestDependencyValidationException(xeption);

            this.loggingBroker.LogError(guestDependencyValidationException);

            return guestDependencyValidationException;
        }
    }
}
