using DemoRestAPI;
using Microsoft.EntityFrameworkCore;

namespace DemoRestAPI.Devices
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly SqlDBContext _context;

        public DeviceRepository(SqlDBContext context)
        {
            _context = context;
        }

        public async Task<Device> Add(Device entity)
        {
            var savedDevice = await _context.Devices
                .FirstOrDefaultAsync(w => w.DeviceId == entity.DeviceId);

            if (savedDevice == null)
            {
                await _context.Devices.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<Device> SearchByDeviceId(string? deviceId)
        {
            var searchedDevice = await _context.Devices
                .FirstOrDefaultAsync(u => u.DeviceId == deviceId);

            if (searchedDevice == null) { return null; }
            return searchedDevice;
        }

        public async Task<Device> SearchById(int? deviceId)
        {
            var searchedDevice = await _context.Devices
                .FirstOrDefaultAsync(u => u.Id == deviceId);

            if (searchedDevice == null) { return null; }
            return searchedDevice;
        }
    }
}
