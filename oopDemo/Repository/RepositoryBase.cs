using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oopDemo.Data;
using oopDemo.UnitOfWork;
using System.Collections.Generic;

namespace oopDemo.Repository
{
    public abstract class RepositoryBase<T> : ControllerBase, IRepository<T> where T : class
    {
        protected readonly FoodContext _context;
        protected readonly DbSet<T> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
            _dbSet = unitOfwork.Context.Set<T>();

        }

        public async Task<ActionResult<T>> Create(T entity)
        {
            _dbSet.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _dbSet.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _dbSet.Remove(data);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<ActionResult<T>> Get(int id)
        {
            var existingOrder = await _dbSet.FindAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            return existingOrder;
        }

        public async Task<IActionResult> Update(int id, T entity)
        {
            //if (id != entity)
            //{
            //    return BadRequest();
            //}

            var existingOrder = await _dbSet.FindAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            _unitOfWork.Context.Entry(existingOrder).CurrentValues.SetValues(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
    }
}
