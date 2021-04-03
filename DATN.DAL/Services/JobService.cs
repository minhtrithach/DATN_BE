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
        }

        public List<string> GetSuggesstion(string q)
        {
            var jobs = new List<string>();

            try
            {
                var data = (from p in context.job
                            where (p.ten_cong_viec.ToLower().StartsWith(q) == true)
                           
                            //orderby p.ma_cong_viec
                            select new Job { ten_cong_viec = p.ten_cong_viec}
                            
                            
                            ).Take(5).Distinct().ToList();

                foreach (Job item in data)
                {
                    jobs.Add(item.ten_cong_viec);
                }

            }
            catch(Exception e)
            {
                jobs.Add(e.Message);
            }

            return jobs;
        }
    }
}
