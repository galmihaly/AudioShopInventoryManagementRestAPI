
namespace DemoRestAPI.Devices
{
    public interface IDeviceRepository
    {
        Task<Device> Add(Device entity);
        Task<Device> SearchById(int? deviceId);

        Task<Device> SearchByDeviceId(string? deviceId);
    }
}
