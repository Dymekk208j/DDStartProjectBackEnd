using Microsoft.AspNetCore.Mvc;

namespace DDStartProjectBackEnd.Common.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static string GetLoggedUserId(this ControllerBase controllerBase)
        {
            return controllerBase.User.FindFirst("guid").Value;
        }
    }
}
