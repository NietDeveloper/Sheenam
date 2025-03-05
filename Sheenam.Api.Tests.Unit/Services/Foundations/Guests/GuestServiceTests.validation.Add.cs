using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;
using Xunit;

namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGuestNullAndLogItAsync()
        {
            //give
            Guest nullGuest = null;
            var nullGuestException = new NullGuestExceptioncs();

            var expectedGuestValidationException = 
                new GuestValidationExeption(nullGuestException);

            //when
            ValueTask <Guest> addGuestTask =
                this.guestService.AddGuestAsync(nullGuest);

            //then
            await Assert.ThrowsAsync<GuestValidationExeption>(() =>
            addGuestTask.AsTask());
        }
    }
}
