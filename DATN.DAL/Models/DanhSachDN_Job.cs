using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DATN.DAL.Models
{
    public class DanhSachDN_Job
    {
        [Key]
        public int Ma_Job { get; set; }
        [Key]
        public int Ma_DN { get; set; }
        public virtual DoanhNghiep DoanhNghiep { get; set; }
        public virtual  Job Job { get; set; }
    }
}
