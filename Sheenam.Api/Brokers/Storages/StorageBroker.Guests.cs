using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Sheenam.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Guset> Gusets { get; set; }

        public async ValueTask<Guset> InsertGuestAsync(Guset guset)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Guset> guestEntityEntry =
                await broker.Gusets.AddAsync(guset);

            await broker.SaveChangesAsync();

            return guestEntityEntry.Entity;

        }
    }
}
