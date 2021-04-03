using DATN.DAL.Context;
using DATN.Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DAL.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected DatabaseContext context { get; set; }
        public BaseRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {

            return await context.Set<T>().FirstOrDefaultAsync(expression);

        }

        public async Task<ListResponse<T>> GetList(int? pageIndex, int? pageSize, Expression<Func<T, bool>> expression)
        {
            int count = context.Set<T>().Count(expression);
            List<T> Data;
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                Data = await context.Set<T>().Where(expression).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();
            }
            else
            {
                Data = await context.Set<T>().Where(expression).ToListAsync();
            }
            return new ListResponse<T> { Data = Data, PageIndex = pageIndex, PageSize = pageSize, TotalRecord = count };
        }

        //public ListView<T> GetList(int? pageIndex, int? pageSize, Expression<Func<T, bool>> expression)
        //{
        //    var count = context.Set<T>().Count(expression);
        //    var maxPageIndex = (count / pageSize) + 1;
        //    int? Pre = 0;
        //    int? Next = 0;
        //    List<T> Data;
        //    if (pageIndex.HasValue && pageSize.HasValue)
        //    {
        //        Data = context.Set<T>().Where(expression).Skip((pageIndex.Value * pageSize.Value) - pageSize.Value).Take(pageSize.Value).ToList();
        //    }
        //    else
        //    {
        //        Data = context.Set<T>().Where(expression).ToList();
        //    }


        //    if (pageIndex >= 1 && pageIndex <= maxPageIndex)
        //    {
        //        Pre = pageIndex - 1;
        //    }
        //    if (pageIndex >= 1 && pageIndex < maxPageIndex)
        //    {
        //        Next = pageIndex + 1;
        //    }

        //    return new ListView<T> { Data = Data, CurrPage = pageIndex, PrePage = Pre, NextPage = Next, LastPage = maxPageIndex };

        //}

        //public List<T> GetAll(Expression<Func<T, bool>> expression)
        //{
        //    return context.Set<T>().Where(expression).ToList();
        //}

        //public void Create(T entity)
        //{
        //    context.Set<T>().Add(entity);
        //    context.SaveChanges();
        //}

        public async Task<T> Update(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Boolean> Create(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;

        }



    }
}
