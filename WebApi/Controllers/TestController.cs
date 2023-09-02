using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts;
using WebApi.Helpers.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("tests")]
    public class TestController : ControllerBase
    {
        [HttpGet(Name = "GetSum")]
        public GetSumResponse Get(decimal a, decimal b)
        {
            return new GetSumResponse()
            {
                NumberA = a,
                NumberB = b,
                Sum = a + b,
            };
        }

        [HttpPost("sort")]
        public string[] Sort(string[] values)
        {
            var arr = values;
            Array.Sort(arr);
            
            return arr;
        }

        [HttpGet("getFamily")]
        public FamilyModel GetFamily(int generation)
        {
            var services = HttpContext.RequestServices;
            var familyHelper = services.GetRequiredService<IFamilyHelper>();

            return familyHelper.GetFamily(generation);
        }
    }
}
