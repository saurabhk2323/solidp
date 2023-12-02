using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    // below two things need to be performed to create a controller
    // add this class as service
    // add routing
    public class HomeController
    {
        [Route("/")]
        public string method1()
        {
            return "hello from method1";
        }
    }
}
