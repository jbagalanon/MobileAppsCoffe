using System;
using System.Collections.Generic;
using System.Text;

namespace Expresso.Models
{
    public class Reservation
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TotalPeople { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

    }
}
