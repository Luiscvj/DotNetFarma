
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class BaseApiController : ControllerBase
{
    
}
