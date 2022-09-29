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

    public class ZoneRepoaitory
    {
        private readonly ConnectedOfficeContext _context;


        // GET: Zones
        public async Task<List<Zone>> GetAll()
        {
               return  _context.Zone.ToList();
            
        }
        public async Task<Zone> GetById(Guid? id)
        {


            var zone = await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);


            return zone;
        }

        public async Task<Zone> Edit(Guid? id)
        {

            var zone = await _context.Zone.FindAsync(id);

            return zone;
        }
        public async Task<Zone> Delete(Guid? id)
        {
            
            var zone = await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);
            
            return zone;
        }
        public async Task<Zone> DeleteConfirmed(Guid id)
        {
            var zone = await _context.Zone.FindAsync(id);
            _context.Zone.Remove(zone);
            await _context.SaveChangesAsync();
            return zone;
        }
        public bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }

    }
}
