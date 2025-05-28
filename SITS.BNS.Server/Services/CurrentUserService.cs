using GramaLink.Entities.Interfaces;
using System.Security.Claims;

namespace GramaLink.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var identity = httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IList<Claim> cliam = identity.Claims.ToList();
                if (cliam.Count > 0)
                {
                    Name = cliam[0].Value;
                    UserId = cliam[1].Value;
                    AccessType = cliam[2].Value;
                    Email = cliam[3].Value;
                }
            }
        }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string AccessType { get; set; }
        public string Email { get; set; }
    }
}
