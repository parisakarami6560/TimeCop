using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCop.TimeSheet.Models
{
    public class BankHoliday
    {
        public int Id { get; set; }
        [Required]
        public  string? Name { get; set; }
        public LocalDate Date { get; set; }
       
       
    }
}


