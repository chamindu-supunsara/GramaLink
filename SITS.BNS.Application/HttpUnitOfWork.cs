using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using GramaLink.Entities.Common;
using GramaLink.Entities.Interfaces;
using GramaLink.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GramaLink.Application
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(ApplicationDbContext context, IHostingEnvironment env, IHttpContextAccessor httpAccessor, IOptions<AppSettings> _appSettings, ICurrentUserService iCurrentUserService) : base(context, env, httpAccessor, _appSettings, iCurrentUserService)
        {
            context.CurrentUserId = httpAccessor.HttpContext?.User.FindFirst("ClaimConstants.Subject")?.Value?.Trim();
        }
    }
}
