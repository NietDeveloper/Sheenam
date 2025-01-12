using System;
using System.Threading.Tasks;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Services.Foundation.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;

        public GuestService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public ValueTask<Guest> AddGuestAsync(Guest guset) =>
            throw new NotImplementedException();
    }
}
