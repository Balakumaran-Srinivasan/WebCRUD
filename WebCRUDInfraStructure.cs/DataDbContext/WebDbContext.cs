using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUDInfraStructure.cs.Table;

namespace WebCRUDInfraStructure.cs.DataDbContext
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } 
    }
}
