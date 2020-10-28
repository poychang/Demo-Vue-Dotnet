using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoVueDotnet.ClientApp.Models;

namespace DemoVueDotnet.Data
{
    public class DemoVueDotnetContext : DbContext
    {
        public DemoVueDotnetContext (DbContextOptions<DemoVueDotnetContext> options)
            : base(options)
        {
        }

        public DbSet<DemoVueDotnet.ClientApp.Models.Contact> Contact { get; set; }
    }
}
