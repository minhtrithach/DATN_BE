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

namespace DATN.API.Controllers
{
    [Route("api/jobs")]
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

        // GET: api/jobs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id.ToString() == null)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "id is not null"
                }) ;
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Job job = await jobRepository.Get(w=>w.ma_cong_viec == id);
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

        public IActionResult GetAll([FromQuery] PageCommand pageCommand,[FromHeader] string q)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ListResponse<Job> jobs = this.jobRepository.GetList(pageCommand.PageIndex, pageCommand.PageSize, m => m.ten_cong_viec.Contains(q));
                
                if (jobs == null)
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
                    data = jobs
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
