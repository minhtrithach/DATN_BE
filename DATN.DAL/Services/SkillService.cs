﻿using DATN.DAL.Context;
using DATN.DAL.Models;
using DATN.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DAL.Services
{
    public class SkillService : BaseService
    {
        public SkillService(DatabaseContext context) : base(context)
        {
        }

        public List<string> GetSuggesstion_Skill(string q)
        {
            var skills = new List<string>();

            try
            {
                var query = (from p in context.skill
                            where p.ten_skill != null
                            select new Skill { ten_skill = p.ten_skill }
                            ).Distinct().ToList();

                foreach (Skill item in query)
                {
                    if ((skills.Count() < 5) && (StringUtils.RemoveVietnameseUnicode(item.ten_skill).StartsWith(StringUtils.RemoveVietnameseUnicode(q)) == true))

                        skills.Add(item.ten_skill);
                }
                skills.Sort();

                return skills;

            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
