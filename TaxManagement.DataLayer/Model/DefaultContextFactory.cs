using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManagement.DataLayer.Interfaces;

namespace TaxManagement.DataLayer.Model
{
    internal class DefaultContextFactory : IDefaultContextFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public DefaultContextFactory(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }


        public TaxDBContext CreateContext()
        {
            var signedInUser = _httpContextAccessor.HttpContext.User ?? null;

            var options = new DbContextOptionsBuilder<TaxDBContext>()
                    .UseSqlServer(_configuration.GetConnectionString("DefaultConnectionString"))
                    .Options;

            return new TaxDBContext(options, signedInUser?.Identity?.Name, signedInUser?.IsInRole("admin") ?? false);
        }
    }
}
