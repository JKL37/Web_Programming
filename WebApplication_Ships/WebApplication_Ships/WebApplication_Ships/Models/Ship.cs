using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Ships.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; } // название
        public string Dlina { get; set; } // длина
        public int Price { get; set; } // цена
    }
}
