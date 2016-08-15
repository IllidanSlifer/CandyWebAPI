using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APICandyCrush.Models
{
    public class UserPartida
    {

        [Key]
        public int ID { get; set; }

        
        public int UserID { get; set; }
        public virtual User User { get; set; }

        public int PartidaID { get; set; }
        public virtual Partida Partida { get; set; }

    }
}