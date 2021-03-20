using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DATN.DAL.Models
{
    public class Job
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Ma_Job   { get; set; }
        public string Ten_Job { get; set; }
        public float  Luong_Min { get; set; }
        public float Luong_Max { get; set; }
        public string Mo_ta { get; set; }
        public string Li_do { get; set; }
        public DateTime Ngay_Start { get; set; }
        public DateTime Ngay_End { get; set; }
        public string Ghi_Chu { get; set; }
    }
}
