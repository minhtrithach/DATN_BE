using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DATN.DAL.Models
{
    public class DoanhNghiep
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Ma_DN { get; set; }
        public string Ten_DN { get; set; }
        public string Mo_ta { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
    }
}
