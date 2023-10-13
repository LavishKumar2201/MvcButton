using System;
using System.ComponentModel.DataAnnotations;

namespace MvcButton.Models
{
    public class Button
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Colour { get; set; }

        public string Type { get; set; }


        public string Shape { get; set; }

        public decimal Price { get; set; }
    }
}