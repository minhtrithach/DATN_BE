using DATN.API.Commands;
using DATN.DAL.Context;
using DATN.DAL.Models;
using DATN.DAL.Repository;
using DATN.DAL.Services;
using DATN.Infrastructure.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DATN.API.Services;
using System.Linq.Expressions;

namespace DATN.API.Controllers
{
    [Route("api/v1/jobs")]
    [ApiController]
    public class JobController : Controller
    {
        private JobRepository jobRepository;
        private JobService jobService;
        public JobController(JobRepository jobRepository, JobService jobService)
        {
            this.jobRepository = jobRepository;
            this.jobService = jobService;
        }

        // GET: api/v1/jobs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id.ToString() == null)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "id is not null"
                });
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Job job = await jobRepository.Get(w => w.ma_cong_viec == id);
                if (job == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Job not found"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = job
                });
            }
            catch
            {
                return NotFound(new
                {
                    success = false,
                    error = "Job not found"
                });
            }
        }

        //GET: api/jobs/q
        [HttpPost]
        async public Task<IActionResult> SearchByKeyWord([FromBody] string searchKey, int pageIndex)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Expression<Func<Job,bool>> jobInTitleExp = j=>j.ten_cong_viec.Contains(searchKey);
                // Expression<Func<DanhSachJob_Skill,Skill,Job,bool>> jobInSkillExp = j=>j.ten_cong_viec.Contains(searchKey);
                Expression<Func<Job,bool>> jobRelatedExp = j=>j.ten_cong_viec.Contains(searchKey);

                ListResponse<Job> jobsInTitle = await this.jobRepository.GetList(searchKey,pageIndex,jobInTitleExp);
                
                if (jobsInTitle == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Could not find any jobs"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = jobsInTitle
                }); 
            }
            catch
            {
                return NotFound(new
                {
                    success = false,
                    error = "faile"
                });
            }
        }
    }
}
