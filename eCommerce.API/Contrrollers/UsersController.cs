using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Contrrollers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FindUser([FromRoute] Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        var res = await _service.FindUserByID(id);

        return res is null ? NotFound() : Ok(res);
    }

}
