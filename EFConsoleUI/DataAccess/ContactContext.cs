using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using EFConsoleUI.Models;

namespace EFConsoleUI.DataAccess
{
    public class ContactContext:DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
        public DbSet<Phone> PhoneNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config =builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("Default"));

            //base.OnConfiguring(optionsBuilder);
        }
    }
}
