using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Data
{
    public class FoodAppDbContextFactory : IDesignTimeDbContextFactory<FoodAppContext> 
  
    {
        public FoodAppContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<FoodAppContext>();
            optionBuilder.UseSqlServer("Data Source=.;Initial Catalog=FoodAppDb;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=true;");
            return new FoodAppContext(optionBuilder.Options);
        }
    }
}
