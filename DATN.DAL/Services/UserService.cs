using DATN.DAL.Context;
using DATN.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DATN.DAL.Services
{
    public class UserService : BaseService
    {
        public UserService(DatabaseContext context) : base(context)
        {
        }
        
    }
}
