using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDcars.Data
{
    public class Manufacturers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MID { get; set; }
        [Display(Name="Manufacturers Id")]
        public string Mname { get; set; }
        [Display (Name = "Manufactuers location")]
        public string Mlocation { get; set; }

    }
}
