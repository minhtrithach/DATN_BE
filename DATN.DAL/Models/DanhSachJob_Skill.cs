using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DATN.DAL.Models
{
    public class DanhSachJob_Skill
    {
        [Key]
        public int Ma_Skill { get; set; }
        [Key]
        public int Ma_Job { get; set; }
    }
}
