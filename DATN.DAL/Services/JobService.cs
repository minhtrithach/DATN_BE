using DATN.DAL.Context;
using DATN.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DATN.DAL.Services
{
    public class JobService : BaseService
    {
        public JobService(DatabaseContext context) : base(context)
        {
        }
        public Job Get (string q)
        {
            return context.job.FirstOrDefault(w => w.ten_cong_viec.Contains(q));
            //return n;
        }
    }
}
