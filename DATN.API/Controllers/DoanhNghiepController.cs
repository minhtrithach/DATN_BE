using DATN.DAL.Models;
using DATN.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/companies")]
    public class DoanhNghiepController : Controller
    {
        private DoanhNghiepRepository doanhNghiepRepository;

        public DoanhNghiepController(DoanhNghiepRepository doanhNghiepRepository)
        {
            this.doanhNghiepRepository = doanhNghiepRepository;
        }

        // GET: api/companies/5
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
                DoanhNghiep doanhNghiep = await doanhNghiepRepository.Get(w => w.ma_doanh_nghiep == id);
                if (doanhNghiep == null)
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
                    data = doanhNghiep
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




    }
}
