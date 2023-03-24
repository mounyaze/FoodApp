using FoodApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Data
{

    public class FoodAppContext : DbContext
    {
        public FoodAppContext(DbContextOptions<FoodAppContext> options)
            : base(options)
        {
            

        }
       
            public DbSet<Restaurant> Restaurants { get; set; }
    }
}
