using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace callingCard.Controllers
{
    public class UserController : Controller
    {
       
    [HttpGet]
    [Route("index/{FName}/{LName}/{Age}/{FColor}")]
    public IActionResult GetData(string FName, string LName, int Age, string FColor)
    {
        var AnonObject = new {
                        FirstName = FName,
                        LastName = LName,
                        Age = Age,
                        FavColor= FColor
                    };
    return Json(AnonObject);
    }
    }
}