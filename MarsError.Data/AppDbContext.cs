using System;
using System.Collections.Generic;
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
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Child> Kids { get; set; }

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

                const int count = 2000;

                List<Thing> things = new List<Thing>();
                if (false == Things.Any())
                {
                    Faker<Thing> faker = new Faker<Thing>().Rules((f, thing) =>
                    {
                        thing.Bar = f.Hacker.Noun();
                        thing.Foo = f.Hacker.Verb();
                    });

                    things = faker.Generate(count).ToList();
                    Things.AddRange(things);
                }

                if (false == Kids.Any())
                {
                    Faker<Child> faker = new Faker<Child>().Rules((f, child) =>
                    {
                        child.Name = f.Person.FullName;
                        child.Parent = f.PickRandom(things);
                    });
                    Kids.AddRange(faker.Generate(count));
                }

                SaveChanges();
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