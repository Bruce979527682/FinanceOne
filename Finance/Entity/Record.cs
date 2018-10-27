using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Finance.Entity
{
    [Serializable]
    public class Record
    {        
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public decimal Money { get; set; }                

        public int Type { get; set; }

        public int Category { get; set; }

        public string Remarks { get; set; }

        public DateTime AddTime { get; set; }
    }
}
