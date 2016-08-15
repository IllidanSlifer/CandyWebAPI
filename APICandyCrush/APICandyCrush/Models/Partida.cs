using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APICandyCrush.Models
{
    [Table("game") ]
    public class Partida
    {
        [Key]
        public int id { get; set; }
        public double score {get; set;}

    }
}