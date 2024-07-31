using System.Text.Json.Serialization;

namespace DemoForNetAPI.Entities;

public class Users: BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    
    [JsonIgnore]
    public string Password { get; set; }
}