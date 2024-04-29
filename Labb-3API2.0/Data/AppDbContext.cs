using Microsoft.EntityFrameworkCore;
using System;

namespace Labb_3API2._0.Data
{
    
    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }

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
                    new Person { PersonId = 1, Name = "Anna Svensson", PhoneNumber = "0701234567" },
                    new Person { PersonId = 2, Name = "Johan Karlsson", PhoneNumber = "0722345678" }
                );
                modelBuilder.Entity<Interest>().HasData(
                    new Interest { InterestId = 1, Title = "Fotografering", Description = "Konsten att fånga ögonblick." },
                    new Interest { InterestId = 2, Title = "Bergsklättring", Description = "Utmaningen att nå toppen." }
                );

                modelBuilder.Entity<PersonInterest>().HasData(
                    new PersonInterest { PersonInterestId = 1, PersonId = 1, InterestId = 1 },
                    new PersonInterest { PersonInterestId = 2, PersonId = 1, InterestId = 2 },
                    new PersonInterest { PersonInterestId = 3, PersonId = 2, InterestId = 1 }
                );

                modelBuilder.Entity<Link>().HasData(
                    new Link { LinkId = 1, Url = "http://example.com/foto", PersonInterestId = 1 },
                    new Link { LinkId = 2, Url = "http://example.com/bergsbestigning", PersonInterestId = 2 }
                );
            }

        }
    
}