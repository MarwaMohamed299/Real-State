using Microsoft.EntityFrameworkCore;
using RealState.Application.Contracts.Abstractions;
using RealState.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Infrastructure.Data.Repositories.Generics
{
    public class GenericRepo<T> : Application.Contracts.Abstractions.GenericRepo<T> where T : class
    {
        private readonly RealStateContext _dbContext;
        public GenericRepo(RealStateContext dbContext)
        {
            _dbContext = dbContext;
        }


        //GetAll
        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>()
                .ToListAsync();
        }

        //GetById
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>()
                .FindAsync(id);
        }

        //Add
        public virtual async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>()
                .AddAsync(entity);
        }

        //Update
        public virtual void UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        //Delete
        public virtual void DeleteAsync(T entity)
        {
            _dbContext.Set<T>()
                .Remove(entity);
        }
    }
}
