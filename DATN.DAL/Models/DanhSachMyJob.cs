using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DATN.DAL.Models
{
    public class DanhSachMyJob
    {
        [Key]
        public int Ma_KH { get; set; }
        [Key]
        public int Ma_Job { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual Job Job { get; set; }
    }
}
