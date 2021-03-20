using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DATN.DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Password{ get; set; }
        public int IsAdmin { get; set; }
        public DateTime CreateDate { get; set; }
       
    }
}
