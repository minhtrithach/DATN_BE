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
        private SkillService skillService;

        public SuggesstionController(LevenshteinService levenshteinService, JobService jobService, SkillService skillService)
        {
            this.levenshteinService = levenshteinService;
            this.jobService = jobService;
            this.skillService = skillService;
        }



        //GET: api/v1/suggesstion/p
        public List<string> GetSuggesstionWord(string p)
        {
            var result = new List<string>();
            if (jobService.GetSuggesstion_JobTiltle(p).Count() != 0)
            {
                result = jobService.GetSuggesstion_JobTiltle(p);
            }
            else
            {
                if (skillService.GetSuggesstion_Skill(p).Count() != 0)
                {
                    result = skillService.GetSuggesstion_Skill(p);
                }
                else
                {
                    result = levenshteinService.calcDictDistance(p, 1);
                }
            }

            return result;
           // return levenshteinService.calcDictDistance(p, 1);
        }

    }
}
