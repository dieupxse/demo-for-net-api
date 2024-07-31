using DemoForNetAPI.Entities;

namespace DemoForNetAPI.Mocks;

public static class UserData
{
    public static List<Users> GetUsers()
    {
        return new List<Users>()
        {
            new()
            {
                Created = DateTime.Now,
                Email = "johnwick@gmail.com",
                Id = 1,
                Name = "John Wick",
                Password = "12345678",
            },
            new()
            {
                Created = DateTime.Now,
                Email = "willsmith@gmail.com",
                Id = 2,
                Name = "Will Smith",
                Password = "12345678",
            },
            new()
            {
                Created = DateTime.Now,
                Email = "donaltrump@gmail.com",
                Id = 3,
                Name = "Donal Trump",
                Password = "12345678",
            }
            
        };
    }
}