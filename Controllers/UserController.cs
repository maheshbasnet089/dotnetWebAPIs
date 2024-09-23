

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;


namespace dotnetAPIS.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private ApplicationDbContext context; 
        public UserController(ApplicationDbContext _context){
            context = _context;
        }
        [HttpGet]
        public List<Users>GetUserList(){
            
            return context.Users.ToList();
        }
        [HttpPost]
        public ActionResult<Users> AddUser(Users u){
            context.Users.Add(u);
            context.SaveChanges();
            return Ok(u);
        }
        [HttpPut]
        public ActionResult<Users> EditStudent(Users u){
            context.Users.Update(u);
            context.SaveChanges();
            return Ok(u);
        }

        [HttpDelete("id")]
        [Microsoft.AspNetCore.Mvc.Route("api/[Controller]/{id}")]
        public ActionResult DeleteUser(int id){
            Users? u = context.Users.Where(u=>u.UserId == id).FirstOrDefault();
            if(u == null)
                return NotFound();
            else
            {
                context.Users.Remove(u);
                context.SaveChanges();
                return Ok();
            }
        }

    }
}