using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Guests { get; set; }

        public async ValueTask<Guest> InsertGuestAsync(Guest guset)
        {
            using var broker = new StorageBroker(this.configuration);

            broker.Entry(guset).State = EntityState.Added;

            await broker.SaveChangesAsync();

            return guset;

        }
    }
}
