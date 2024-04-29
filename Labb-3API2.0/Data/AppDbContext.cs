using Labb_3API2._0.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Labb_3API2._0.Data
{
    
    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }

            public DbSet<Person> Persons { get; set; }
            public DbSet<Link> Links { get; set; }
            public DbSet<Interest> Interests { get; set; }
            public DbSet<PersonInterest> PersonInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {



                base.OnModelCreating(modelBuilder);


                modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonId);

                modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);



                modelBuilder.Entity<Link>()
                .HasOne(l => l.PersonInterest)
                .WithMany(pi => pi.Links)
                .HasForeignKey(l => l.PersonInterestId);


                modelBuilder.Entity<Person>().HasData(
                    new Person { Id = 1, Name = "Anna Svensson", PhoneNumber = "0701234567" },
                    new Person { Id = 2, Name = "Johan Karlsson", PhoneNumber = "0722345678" },
                    new Person { Id = 3, Name = "Christian Rapp", PhoneNumber = "0722345678" },
                    new Person { Id = 4, Name = "Fredrik Rapp", PhoneNumber = "0721344677" }
                );
                modelBuilder.Entity<Interest>().HasData(
                    new Interest { Id = 1, Title = "Fotografering", Description = "Konsten att fånga ögonblick." },
                    new Interest { Id = 2, Title = "Bergsklättring", Description = "Utmaningen att nå toppen." },
                    new Interest { Id = 3, Title = "Programering", Description = "CRUD4LIFE." },
                    new Interest { Id = 4, Title = "Ridning", Description = "Utmaningen att hoppa med hästt." }
                );

                modelBuilder.Entity<PersonInterest>().HasData(
                    new PersonInterest { Id = 1, PersonId = 1, InterestId = 1 },
                    new PersonInterest { Id = 2, PersonId = 2, InterestId = 2 },
                    new PersonInterest { Id = 3, PersonId = 3, InterestId = 3 },
                    new PersonInterest { Id = 4, PersonId = 4, InterestId = 4 }
                );

                modelBuilder.Entity<Link>().HasData(
                    new Link { Id = 1, Url = "http://example.com/foto", PersonInterestId = 1 },
                    new Link { Id = 2, Url = "http://example.com/bergsbestigning", PersonInterestId = 2 },
                    new Link { Id = 3, Url = "http://example.com/Microsoft", PersonInterestId = 3 },
                    new Link { Id = 4, Url = "http://example.com/Ridsport", PersonInterestId = 4 }
                );
            }

        }
    
}