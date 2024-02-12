using Microsoft.AspNetCore.Identity;

namespace Arsoude_Backend.Models.Interfaces
{
    public interface ITrailService
    {
        Task<Trail> CreateTrail(Trail trail, IdentityUser user);
    }
}
