using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc_identity.Models;

namespace mvc_identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // connect
            string roleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            // create roles
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            });

            // put entities together
            modelBuilder.Entity<PersonLanguage>().HasKey(x => new {x.PersonId, x.LanguageId});
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Language)
                .WithMany(p => p.People)
                .HasForeignKey(pl => pl.LanguageId);
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Person)
                .WithMany(p => p.Languages)
                .HasForeignKey(pl => pl.PersonId);
            modelBuilder.Entity<Person>()
                .HasOne(p => p.City)
                .WithMany(p => p.People)
                .HasForeignKey(p => p.CurrentCityId);

            // add languages
            modelBuilder.Entity<Language>().HasData(new Language {LanguageId = 001, LanguageName = "Swedish"});
            modelBuilder.Entity<Language>().HasData(new Language {LanguageId = 002, LanguageName = "Finnish"});
            modelBuilder.Entity<Language>().HasData(new Language {LanguageId = 003, LanguageName = "Danish"});
            modelBuilder.Entity<Language>().HasData(new Language {LanguageId = 004, LanguageName = "Simlish"});
            modelBuilder.Entity<Language>().HasData(new Language {LanguageId = 005, LanguageName = "Greek"});
            modelBuilder.Entity<Language>().HasData(new Language {LanguageId = 006, LanguageName = "Norwegian"});
            modelBuilder.Entity<Language>().HasData(new Language {LanguageId = 007, LanguageName = "Japanese"});

            // add countries
            modelBuilder.Entity<Country>().HasData(new Country {CountryId = 001, CountryName = "Sweden"});
            modelBuilder.Entity<Country>().HasData(new Country {CountryId = 002, CountryName = "United States"});
            modelBuilder.Entity<Country>().HasData(new Country {CountryId = 003, CountryName = "Germany"});
            modelBuilder.Entity<Country>().HasData(new Country {CountryId = 004, CountryName = "Spain"});
            modelBuilder.Entity<Country>().HasData(new Country {CountryId = 005, CountryName = "Italy"});
            modelBuilder.Entity<Country>().HasData(new Country {CountryId = 006, CountryName = "France"});
            modelBuilder.Entity<Country>().HasData(new Country {CountryId = 007, CountryName = "Austria"});

            // add cities
            modelBuilder.Entity<City>().HasData(new City {CityId = 001, CityName = "Stockholm"});
            modelBuilder.Entity<City>().HasData(new City {CityId = 002, CityName = "New York City"});
            modelBuilder.Entity<City>().HasData(new City {CityId = 003, CityName = "Berlin"});
            modelBuilder.Entity<City>().HasData(new City {CityId = 004, CityName = "Madrid"});
            modelBuilder.Entity<City>().HasData(new City {CityId = 005, CityName = "Rome"});
            modelBuilder.Entity<City>().HasData(new City {CityId = 006, CityName = "Paris"});
            modelBuilder.Entity<City>().HasData(new City {CityId = 007, CityName = "Vienna"});

            // add people
            modelBuilder.Entity<Person>().HasData(new Person
                {Id = 001, Name = "Rebecca Pettersson", PhoneNumber = "0942-4546168", CurrentCityId = 001, CurrentCountryId = 001});
            modelBuilder.Entity<Person>().HasData(new Person
                {Id = 002, Name = "Valentino Engström", PhoneNumber = "08-5156261", CurrentCityId = 002, CurrentCountryId = 002});
            modelBuilder.Entity<Person>().HasData(new Person
                {Id = 003, Name = "Engla Holmgren", PhoneNumber = "042-5365682", CurrentCityId = 003, CurrentCountryId = 003});
            modelBuilder.Entity<Person>().HasData(new Person
                {Id = 004, Name = "Oliwer Gunnarsson", PhoneNumber = "0680-3146934", CurrentCityId = 004, CurrentCountryId = 004});
            modelBuilder.Entity<Person>().HasData(new Person
                {Id = 005, Name = "Brandon Eriksson", PhoneNumber = "342345345", CurrentCityId = 005, CurrentCountryId = 005});
            modelBuilder.Entity<Person>().HasData(new Person
                {Id = 006, Name = "Wilda Lundin", PhoneNumber = "11231425", CurrentCityId = 006, CurrentCountryId = 006});
            modelBuilder.Entity<Person>().HasData(new Person
                {Id = 007, Name = "Madicken Lindqvist", PhoneNumber = "234242534", CurrentCityId = 007, CurrentCountryId = 007});


            var hasher = new PasswordHasher<ApplicationUser?>();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "steve@apple.com",
                NormalizedEmail = "steve@apple.com".ToUpper(),
                UserName = "steve@apple.com",
                NormalizedUserName = "steve@apple.com",
                PasswordHash = hasher.HashPassword(null, "applelover"),
                FirstName = "Steve",
                LastName = "Jobs",
                BirthDate = "1955-02-24"
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });
        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        public DbSet<Language> Languages { get; set; }
        public override DbSet<ApplicationUser> Users { get; set; }
    }
}