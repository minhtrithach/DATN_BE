using DATN.DAL.Context;
using DATN.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATN.DAL.Repository
{
    public class JobRepository : BaseRepository<Job>
    {
        public JobRepository(DatabaseContext context) : base(context)
        {
        }



    }
}
