using DeviceManagement_WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;



namespace DeviceManagement_WebApp.Repository
{
    public class categoryRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
        // GET: Categories
        public async Task<List<Category>> GetAll()
        {
            return _context.Category.ToList();
        }

        // GET: Categories/Details/5
        public async Task<Device> GetById(Guid? id)
        {


            var category = await _context.Device.FirstOrDefaultAsync(m => m.CategoryId == id);


            return category;
        }

        public async Task<Category> Edit(Guid? id)
        {
         
            var category = await _context.Category.FindAsync(id);
            
            return category;
        }

        public async Task<Category> Delete(Guid? id)
        {
           
            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
           
            return category;
        }
        public async Task<Category> DeleteConfirmed(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
