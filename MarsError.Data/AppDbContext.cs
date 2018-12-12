using System;
using System.Linq;
using Bogus;
using IntelliTect.Coalesce;
using MarsError.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarsError.Data
{
    [Coalesce]
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Thing> Things { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Remove cascading deletes.
            foreach (IMutableForeignKey relationship in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        /// <summary>
        ///     Migrates the database and sets up items that need to be set up from scratch.
        /// </summary>
        public void Initialize()
        {
            try
            {
                Database.Migrate();

                if (false == Things.Any())
                {
                    var faker = new Faker<Thing>().Rules((f, thing) =>
                    {
                        thing.Bar = f.Hacker.Noun();
                        thing.Foo = f.Hacker.Verb();
                    });

                    Things.AddRange(faker.Generate(2000));
                    SaveChanges();
                }
            }
            catch (InvalidOperationException e) when (e.Message ==
                                                      "No service for type 'Microsoft.EntityFrameworkCore.Migrations.IMigrator' has been registered."
            )
            {
                // this exception is expected when using an InMemory database
            }
        }
    }
}