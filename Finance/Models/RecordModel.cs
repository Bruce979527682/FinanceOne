using Finance.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finance.Models
{
    public class RecordModel
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public int CountNum { get; set; }

        public List<Record> Records { get; set; }
    }
}
