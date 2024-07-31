using System.Security.Claims;
using DemoForNetAPI.Helpers;
using Microsoft.AspNetCore.SignalR;

namespace DemoForNetAPI.Hubs;

public class BaseHub: Hub
{
    public long CurrentUserId
    {
        get
        {
            return (Context.User.Identity as ClaimsIdentity).GetUserId();
        }
    }

    public string CurrentUserEmail
    {
        get
        {
            return (Context.User.Identity as ClaimsIdentity).GetEmailAddress();
        }
    }
}