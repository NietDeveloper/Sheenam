using System.Threading.Tasks;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Services.Foundation.Guests
{
    public interface IGuestService
    {
        ValueTask<Guest> AddGuestAsync(Guest guset);
    }
}
