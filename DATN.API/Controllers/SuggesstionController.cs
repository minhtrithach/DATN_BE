using DATN.API.Services;
using DATN.DAL.Models;
using DATN.DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/v1/suggesstion")]
    [ApiController]
    public class SuggesstionController : Controller
    {
        private LevenshteinService levenshteinService;
        private JobService jobService;

        public SuggesstionController(LevenshteinService levenshteinService, JobService jobService)
        {
            this.levenshteinService = levenshteinService;
            this.jobService = jobService;
        }


        //GET: api/v1/suggesstion/p
        public List<string> Get_word_related(string p)
        {
            return jobService.GetSuggesstion(p);
           // return levenshteinService.calcDictDistance(p, 1);
        }

    }
}
