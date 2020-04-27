using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVCCRUD.Models
{
    public class Superhero
    {
        [Key]
        public int SuperheroId { get; set; }
       [Column("nvarchar(200)")]
        [Required]
        public string Name { get; set; }
      [Column(TypeName = "varchar(100)")]
        public string Power { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Editorial { get; set; }
        
    }
}
