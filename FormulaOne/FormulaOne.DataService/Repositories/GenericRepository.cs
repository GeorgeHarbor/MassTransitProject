﻿using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
  public readonly ILogger _logger;
  protected AppDbContext _context;
  internal DbSet<T> _dbSet;


  public GenericRepository(AppDbContext context, ILogger logger)
  {
    _context = context;
    _logger = logger;

    _dbSet = context.Set<T>();
  }

  public virtual async Task<bool> Add(T entity)
  {
    await _dbSet.AddAsync(entity);
    return true;
  }

  public virtual async Task<IEnumerable<T>> All()
  {
    return await _dbSet.ToListAsync();
  }

  public virtual Task<bool> Delete(Guid id)
  {
    throw new NotImplementedException();
  }

  public virtual async Task<T?> GetById(Guid id)
  {
    return await _dbSet.FindAsync(id)!;
  }

  public virtual Task<bool> Update(T entity)
  {
    throw new NotImplementedException();
  }
}
