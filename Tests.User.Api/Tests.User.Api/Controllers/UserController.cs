using Microsoft.AspNetCore.Mvc;
using Tests.User.Api.Services;

namespace Tests.User.Api.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        /// <summary>
        ///     Gets a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/users")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        ///     Create a new user
        /// </summary>
        /// <param name="user">The user object containing information such as first name, last name, and age</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/users")]
        public IActionResult Create(Models.User user)
        {
            try
            {
                _userService.CreateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Updates a user
        /// </summary>
        /// <param name="user">The user object containing information such as first name, last name, and age</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/users")]
        public IActionResult Update(Models.User user)
        {
            try
            {
                _userService.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Delets a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/users")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
