using Microsoft.EntityFrameworkCore;
using PetShop.Areas.Customer.Models;
using System;

namespace PetShop.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Pid = 1,
                    FirstName = "Hoang",
                    LastName = "Tu",
                    Zalo = "",
                    Address = "124, N11",
                    Day = 27,
                    Month = 10,
                    Year = 1997,
                    CreatedDate = DateTime.Now,
                    Email = "hoangminhtubeee@gmail.com",
                    Enabled = true,
                    FacebookId = "",
                    GoogleId = "",
                    LinkFaceBook = "",
                    PhoneNumber = "0976743321",
                    Password = BCrypt.Net.BCrypt.HashPassword("123"),
                    Deleted = false,
                    AvatarUrl = "",
                    DeletedDate = null,
                    UpdatedDate = null,
                    District = "",
                    Province = "",
                    Ward = "",
                    ActivationCode = ""
                }
            ) ; 
           
        }

    }
}
