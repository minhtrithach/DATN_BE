using DATN.DAL.Context;
using DATN.DAL.Models;
using DATN.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<string> GetSuggesstion_JobTiltle(string q)
        {
            var jobs = new List<string>();
            
            try
            {
                var data = (from p in context.job
                            where p.ten_cong_viec != null
                            select new Job { ten_cong_viec = p.ten_cong_viec }
                            ).Distinct().ToList();

                foreach (Job item in data)
                {
                    if ((jobs.Count() < 5) && (StringUtils.RemoveVietnameseUnicode(item.ten_cong_viec).StartsWith(StringUtils.RemoveVietnameseUnicode(q)) == true))
                    
                    jobs.Add(item.ten_cong_viec);
                }
                jobs.Sort();                          

                return jobs;

            }
            catch (Exception e)
            {
                
                throw (e);
                
            }
        }     


    }
}
