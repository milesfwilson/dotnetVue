using Keepr.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keepr.Data.Services
{
    public class KeeprDbContext : DbContext
    {
        public DbSet<Keep> Keeps { get; set; }
    }
}