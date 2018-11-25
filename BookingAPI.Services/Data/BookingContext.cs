using BookingAPI.Services.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPI.Services.Data
{
    public class BookingContext : DbContext
    {
        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=SUVETHAN-PC;Database=BookingDB;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }
    }
}
