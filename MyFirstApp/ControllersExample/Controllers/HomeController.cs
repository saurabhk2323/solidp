using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    // below two things need to be performed to create a controller
    // add this class as service
    // add routing
    public class HomeController
    {
        [Route("/")]
        [Route("/home")]
        public string Home()
        {
            return "hello from Home page";
        }

        [Route("/about")]
        public string About()
        {
            return "hello from about page";
        }

        [Route("/contact")]
        public string Contact()
        {
            return "hello from contact page";
        }
    }
}
