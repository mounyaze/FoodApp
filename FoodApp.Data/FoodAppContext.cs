using FoodApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Data
{

    public class FoodAppContext : DbContext
    {
        private readonly IConfiguration configuration;

        public FoodAppContext(DbContextOptions<FoodAppContext> options)
            : base(options)
        {
            

        }
       /* private IConfiguration _config;
        public FoodAppContext(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FoodAppDb;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=true;");
            
        }*/


        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
