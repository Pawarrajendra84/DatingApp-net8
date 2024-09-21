using API.Data;
using API.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
    DataContext _context;
    public UsersController(DataContext context)
{
_context =context;

}
[HttpGet]
public async Task<ActionResult< IEnumerable<AppUser>>> GetUsers()
{
return await _context.Users.ToListAsync();
}

[HttpGet("{Id:int}")]
public async Task< ActionResult<AppUser>> GetUser(int Id)
{
    var  AppUser =await _context.Users.FindAsync(Id);
    if(AppUser== null)
    {
        return NotFound();
    }
    return AppUser;
}


    }   
}
