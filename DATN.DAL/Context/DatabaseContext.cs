using DATN.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATN.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
       
        public DbSet<Job> job { get; set; }
        public DbSet<DoanhNghiep> doanh_nghiep { get; set; }


       

       
    }
}
