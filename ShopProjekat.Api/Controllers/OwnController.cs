using Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopProjekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnController : ControllerBase
    {
        protected UseCaseHandler _handler;
        public OwnController(UseCaseHandler handler)
        {
            _handler= handler;
        }
    }
}
