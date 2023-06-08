using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace StreamApi.Controllers;
[Route("[controller]")]
[ApiController]
public class PathGeneratorController : ControllerBase
{
    public static DateTime UpdateDate { get; set; } = DateTime.Now;

    [HttpGet]
    public IActionResult GetUrlWithUpdateDate()
    {
        var url = $"http://localhost:8080/Stream/image";

        var parameters = new Dictionary<string, string>
        {
            { "updateDate", UpdateDate.Ticks.ToString()},
        };

        var resultUrl = QueryHelpers.AddQueryString(url, parameters!);

        return Ok(resultUrl);
    }
}
