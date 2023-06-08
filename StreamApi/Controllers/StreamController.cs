using Microsoft.AspNetCore.Mvc;

namespace StreamApi.Controllers;
[Route("[controller]")]
[ApiController]
public class StreamController : ControllerBase
{
    private const string imageName1 = "avatar.jpg";
    private const string imageName2 = "avatar2.jpg";

    private static string _currentImageName = imageName1;

    [HttpGet("image")]
    public IActionResult Image([FromServices] IWebHostEnvironment hostEnv)
    {
        var fullPath = Path.Combine(hostEnv.ContentRootPath, "Files", _currentImageName);

        var stream = new FileStream(fullPath, FileMode.Open);

        return new FileStreamResult(stream, "image/jpg");
    }

    [HttpPost("swapImage")]
    public IActionResult SwapImage() 
    {
        PathGeneratorController.UpdateDate = DateTime.Now;

        if (_currentImageName == imageName1)
        {
            _currentImageName = imageName2;
        }
        else
        {
            _currentImageName = imageName1;
        }

        return Ok(_currentImageName);
    }
}
