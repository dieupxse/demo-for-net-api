using System.Security.Claims;
using DemoForNetAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DemoForNetAPI.Controllers;

public class ApiControllerBase: ControllerBase
{
    public long CurrentUserId
    {
        get
        {
            return (User.Identity as ClaimsIdentity).GetUserId();
        }
    }

    public string CurrentUserEmail
    {
        get
        {
            return (User.Identity as ClaimsIdentity).GetEmailAddress();
        }
    }
}