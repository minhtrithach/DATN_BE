using DATN.DAL.Context;
using DATN.DAL.Models;
using DATN.DAL.Repository;
using DATN.DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : Controller
    {
        private JobRepository jobRepository;

        public JobController(JobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }
        [HttpGet]
        public Job Get()
        {
            return jobRepository.Get(w=>w.ma_cong_viec == 1);
            
        }
    }
    
}
