﻿using System;
using System.Threading.Tasks;
using Sheenam.Api.Brokers.Loggings;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Services.Foundation.Guests
{
    public partial class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public GuestService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }
        public ValueTask<Guest> AddGuestAsync(Guest guest) =>
            TryCach(async () =>
        {
            ValidateGuestOnAdd(guest);

            return await this.storageBroker.InsertGuestAsync(guest);
        });

        public ValueTask<Guest> RetrieveGuestByIdAsync(Guid guestId) =>
            TryCach(async () =>
            {
                ValidateGuestId(guestId);
                Guest maybeGuest = await this.storageBroker.SelectGuestByIdAsync(guestId);
                ValidateStorageClient(maybeGuest, guestId);

                return maybeGuest;
            });
    }
}
