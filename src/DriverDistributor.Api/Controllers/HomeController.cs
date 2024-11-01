using Microsoft.AspNetCore.Mvc;

namespace DriverDistributor.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class HomeController : Controller
{
    private HandleAccessFile _hA = new HandleAccessFile();
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }


    [HttpGet("GetAll")]
    public IActionResult GetDataFromShipment()
    {
       var data= _hA.ReturnAccess();
        return Ok(data);
    }
}