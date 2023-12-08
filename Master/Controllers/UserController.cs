using Master.Models;
using Master.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<MasterUser>> PostUser(MasterUser user)
        {
            try
            {
                if (user == null)
                { 
                    return BadRequest();
                }

                var created = await userRepository.PostUser(user);

                return CreatedAtAction(nameof(PostUser),
                    new { id = created.MID }, created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new user record!");
            }
        }

        [HttpPut("{User_Id}")]
        public async Task<ActionResult<MasterUser>> UpdateUser(MasterUser user, string User_Id)
        {
            try
            {
                if (User_Id.ToUpper() != user.User_Id.ToUpper())
                { 
                    return BadRequest("User_Id mismatch!");
                }

                var dataUser = await userRepository.SearchId(User_Id);

                if (dataUser.Count() == 0)
                { 
                    return NotFound();
                }
                return await userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data!");
            }
        }

        [HttpDelete("{User_Id}")]
        public async Task<ActionResult<MasterUser>> DeleteUser(string User_Id)
        {
            try
            {
                var result = await userRepository.SearchId(User_Id);

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return await userRepository.DeleteUser(User_Id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data!");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterUser>>> GetUsers()
        {
            try
            { 
                var result = await userRepository.GetUsers();
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }

        [HttpGet("{User_Id}")]
        public async Task<ActionResult<IEnumerable<MasterUser>>> Search(string User_Id)
        {
            try
            {
                var result = await userRepository.SearchId(User_Id);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }

        [HttpGet("{User_Id}/{Password}")]
        public async Task<ActionResult<IEnumerable<MasterUser>>> Login(string User_Id, string Password)
        {
            try
            {
                var result = await userRepository.Login(User_Id, Password);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }

    }

}
