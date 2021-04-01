using DATN.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/levenshteins")]
    [ApiController]
    public class LevenshteinController : Controller
    {
        private LevenshteinService levenshteinService;

        public LevenshteinController(LevenshteinService levenshteinService)
        {
            this.levenshteinService = levenshteinService;
        }

        //GET: api/levenshtein/p
        public List<string> Get_word_related([FromHeader]string p)
        {
            return levenshteinService.calcDictDistance(p, 1);
        }

    }
}
