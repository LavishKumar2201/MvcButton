using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcButton.Models
{
    public class Button
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        public string Colour { get; set; }


        public string Shape  { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}