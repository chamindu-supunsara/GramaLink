using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GramaLink.Application.Repositories.Interfaces;
using GramaLink.Application.Repositories;
using GramaLink.Entities.Common;
using GramaLink.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GramaLink.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GramaLink.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;
        readonly IHostingEnvironment _env;
        readonly IHttpContextAccessor _httpcontext;
        private readonly AuthConfig _authConfig;
        private readonly ILogger<AppUserRepository> _logger;
        private readonly ICurrentUserService _ICurrentUserService;
        IOptions<AppSettings> _appSettings;

        IAppUserRepository _appUserRepository;


        public UnitOfWork(ApplicationDbContext context, IHostingEnvironment env, IHttpContextAccessor httpcontext, IOptions<AppSettings> appSettings, ICurrentUserService iCurrentUserService)
        {
            _context = context;
            _env = env;
            _httpcontext = httpcontext;
            _appSettings = appSettings;
            _ICurrentUserService = iCurrentUserService;
            //_logger = logger;

        }

        public IAppUserRepository AppUsers
        {
            get
            {
                if (_appUserRepository == null)
                    _appUserRepository = new AppUserRepository(_context, _appSettings);
                return _appUserRepository;
            }
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }



    }
}
