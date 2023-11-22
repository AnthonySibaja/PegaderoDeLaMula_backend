using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PegaderoDeLaMula.Models.Dto;
using PegaderoDeLaMula.Models;
using PegaderoDeLaMula.Repository;
using System.Threading.Tasks;

namespace PegaderoDeLaMula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        protected ResponseDto _response;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new ResponseDto();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserDto user)
        {
            var respuesta = await _userRepository.Register(
                new User
                {
                    USUARIO = user.UserName
                }, user.Password);

            if (respuesta == "existe")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El usuario ya existe";
                return BadRequest(_response);
            }

            if (respuesta == "error")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el usuario";
                return BadRequest(_response);
            }

            _response.DisplayMessage = "Usuario creado con exito!";
            JwTPackage jtp = new JwTPackage();
            jtp.UserName = user.UserName;
            jtp.Token = respuesta;
            _response.Result = jtp;

            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDto user)
        {
            var respuesta = await _userRepository.Login(user.UserName, user.Password);

            if (respuesta == "nouser")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario no existe";
                return BadRequest(_response);
            }
            if (respuesta == "wrongpassword")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Contraseña incorrecta";
                return BadRequest(_response);
            }

            JwTPackage jtp = new JwTPackage();
            jtp.UserName = user.UserName;
            jtp.Token = respuesta;
            _response.Result = jtp;

            _response.DisplayMessage = "Usuario Conectado";
            return Ok(_response);
        }
    }


    public class JwTPackage
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}

