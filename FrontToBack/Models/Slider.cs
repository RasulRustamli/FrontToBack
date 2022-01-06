using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required,StringLength(260),MinLength(5)]
        public string ImageUrl { get; set; }
    }
}
