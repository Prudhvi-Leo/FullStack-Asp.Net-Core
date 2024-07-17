using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Entities
{
    public class EFCoreDbContext : DbContext
    {
        //Adding Domain Classes as DbSet Properties
        public DbSet<BaseEntity> BaseEntites { get; set; }

        public EFCoreDbContext() : base()
        {
        }
        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            //Get the Connection String from appsettings.json file
            //Step2: Load the Configuration File.
         //   optionsBuilder.LogTo();
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            // Step3: Get the Section to Read from the Configuration File
            var configSection = configBuilder.GetSection("ConnectionStrings");
            // Step4: Get the Configuration Values based on the Config key.
            var connectionString = configSection["SQLServerConnection"] ?? null;

            //Configuring the Connection String
            optionsBuilder.UseSqlServer(connectionString);
        }
        //OnModelCreating() method is used to configure the model using ModelBuilder Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<BaseEntity>()
                .ToTable("Entities")
                .HasDiscriminator<string>("entity_type")
                .HasValue<DerivedEntityA>("EntityA")
                .HasValue<DerivedEntityB>("EntityB");
        }
     
       
    }
}
