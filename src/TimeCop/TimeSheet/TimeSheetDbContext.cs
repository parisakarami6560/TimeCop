using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Models;

namespace TimeCop.TimeSheet
{
   public class TimeSheetDbContext :DbContext
    {
        public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext>options):base(options) { }
        public DbSet<BankHoliday> BankHolidays { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankHoliday>().Property(p => p.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<BankHoliday>().Property(p=>p.Date).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

    }
    
}
