using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class EFDbContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }
        public EFDbContext() : base("name=EFDbContext")
        {

        }
    }
}
