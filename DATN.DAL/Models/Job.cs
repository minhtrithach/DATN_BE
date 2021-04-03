using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DATN.DAL.Models
{
    public class Job
    {
        [Key]
        public int ma_cong_viec { get; set; }
        public string ten_cong_viec { get; set; }
        public double luong_toi_thieu { get; set; }
        public double luong_toi_da { get; set; }
        public string mo_ta_cong_viec { get; set; }
        public string don_vi_tien_te { get; set; }
        [Required]
        public int ma_doanh_nghiep { get; set; }
        public DateTime? ngay_bat_dau { get; set; }
        public DateTime? ngay_ket_thuc { get; set; }
        
     }
}
