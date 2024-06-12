using Microsoft.EntityFrameworkCore;


namespace DemoRestAPI.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlDBContext _context;

        public UserRepository(SqlDBContext context)
        {
            _context = context;
        }

        public async Task<User> SearchByEmail(string? email)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) { return null; }
            return user;
        }

        public async Task<User> SearchById(int? userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) { return null; }
            return user;
        }

        public async Task<User> SearchByUserNameAndDeviceId(string? username, int? deviceId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username && u.DeviceId == deviceId);

            if (user == null) { return null; }
            return user;
        }
    }
}
