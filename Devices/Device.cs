using DemoRestAPI.Users;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Devices
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        //One To One Relation
        public User? User { get; set; }

        public string? DeviceId { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public bool? Active { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime CreatedAt { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime ModifiedAt { get; set; }
    }
}
