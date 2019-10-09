using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDcars.Data
{
    public class cars
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CID { get; set; }
        public string mname { get; set; }
        public int MID { get; set; }

        [ForeignKey("MID")]
        public Manufacturers mans { get; set; }
    }
}
