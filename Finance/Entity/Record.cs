using System;
using System.ComponentModel.DataAnnotations;

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

        public int UserId { get; set; }
    }
}
