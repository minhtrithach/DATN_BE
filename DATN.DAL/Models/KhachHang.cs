using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DATN.DAL.Models
{
    public class KhachHang
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Ma_KH   { get; set; }
        public string Ten_KH { get; set; }
        public string Email { get; set; }
        public string Cmnd { get; set; }
        
    }
}
