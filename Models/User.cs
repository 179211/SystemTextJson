using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SystemTextJson.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public UserType UserRole { get; set; }
        public int UserAge { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime dtCreated { get; set; }
    }

    public enum UserType
    {
        Admin,
        User,
        Guest
    }
}
