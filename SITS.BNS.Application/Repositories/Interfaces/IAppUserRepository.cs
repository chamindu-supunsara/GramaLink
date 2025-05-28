using GramaLink.Entities.AuthModels;
using GramaLink.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GramaLink.Application.Repositories.Interfaces
{
    public interface IAppUserRepository
    {
        Task<int> SaveAppUser(AppUser appUser);

        Task<AuthResponse> Authenticate(AuthRequest authRequest);

        Task<AppUser> GetAppUserById(int id);


    }
}
