using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Gusets { get; set; }

        public async ValueTask<Guest> InsertGuestAsync(Guest guset)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Guest> guestEntityEntry =
                await broker.Gusets.AddAsync(guset);

            await broker.SaveChangesAsync();

            return guestEntityEntry.Entity;

        }
    }
}
