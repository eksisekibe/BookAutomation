﻿using BookAutomation.Data.Abstract;
using BookAutomation.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Data.Concrete
{
    public class PgGenericRepository<TEntity> : IRepository<TEntity>
          where TEntity : BaseEntity
    {
        public readonly PostgreSqlContext _context;
        public PgGenericRepository(PostgreSqlContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync(int limit, int offset)
        {
            return await _context.Set<TEntity>()
                .OrderBy(e => e.Created_at)
                .Skip(offset)
                .Take(limit + offset)
                .ToListAsync();
        }
        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>()
                .OrderBy(e => e.Created_at)
                .ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
