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

        //[HttpGet]
        //public DoanhNghiep Get()
        //{
        //    return doanhNghiepRepository.Get(w => w.ma_doanh_nghiep==1);

        //}
    }
}
