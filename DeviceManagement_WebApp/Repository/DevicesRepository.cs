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
    public class DevicesRepository

    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        public async Task<List<Device>> GetAll()
        {
            var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return await connectedOfficeContext.ToListAsync();
        }

        public async Task<Device> GetById(Guid? id)
        {
          
            var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
           
            return device;
        }

        public async Task<Device> Edit(Guid? id)
        {
            var device = await _context.Device.FindAsync(id);
          
            return device;
        }

        public async Task<Device> Delete(Guid? id)
        {

            var device = _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone);
           

            return (Device)device;
        }
      

        // POST: Devices/Delete/5

        public async Task<Device> DeleteConfirmed(Guid id)
        {
            var device = await _context.Device.FindAsync(id);
            _context.Device.Remove(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
        

    }
}
