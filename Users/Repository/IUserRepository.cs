namespace DemoRestAPI.Users.Repository
{
    public interface IUserRepository
    {
        Task<User> SearchByEmail(string? email);
        Task<User> SearchByUserNameAndDeviceId(string? username, int? deviceId);
        Task<User> SearchById(int? userId);
    }
}
