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
        
        public decimal TotalMoney { get; set; }                

        public int Number { get; set; }

        /// <summary>
        /// 资产或负债 1资产 2 负债
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 大类类别
        /// </summary>
        public int Category { get; set; }

        public string Remark { get; set; }

        public DateTime AddTime { get; set; }

        public int UserId { get; set; }

    }
}
