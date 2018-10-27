using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Finance.Entity
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(30)]
        public string UserName { get; set; }

        [Required, StringLength(30)]
        public string Password { get; set; }

        public DateTime LoginTime { get; set; }

        public string Ip { get; set; }

        public int LoginError { get; set; }
    }
}
