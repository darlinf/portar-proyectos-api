using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portar_proyectos_api.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Helpers;
using WebApi.Models;

namespace portar_proyectos_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncognitoController : ControllerBase
    {
        private IincognitoService _incognitoService;
        private IMapper _mapper;

        public IncognitoController(IincognitoService incognitoService, IMapper mapper)
        {
            _mapper = mapper;
            _incognitoService = incognitoService;
        }


        [HttpGet("GetAllFinalProject")]
        public async Task<IActionResult> GetAllFinalProject()
        {
            try
            {
                // save 
                var resurt = await _incognitoService.GetAllFinalProject();
                return Ok(resurt);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetAllFinalProjectByCareer/{Career}")]
        public IActionResult GetAllFinalProjectByCareer(string Career)
        {
            try
            {
                // save 
                var resurt = _incognitoService.GetAllFinalProjectByCareer(Career);
                return Ok(resurt);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetAllProposedProject")]
        public async Task<IActionResult> GetAllProposedProject()
        {
            try
            {
                // save 
                var resurt = await _incognitoService.GetAllProposedProject();
                return Ok(resurt);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetAllProposedProjectByCareer/{Career}")]
        public IActionResult GetAllProposedProjectByCareer(string Career)
        {
            try
            {
                // save 
                  var resurt = _incognitoService.GetAllProposedProjectByCareer(Career);
                return Ok(resurt);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("authenticate")]
        public IActionResult Authentication([FromBody] AuthenticateModel model)
        {
            try
            {
                var user = _incognitoService.Authentication(model.Mail, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Usuario o contrasena incorectos" });
                return Ok(new
                {
                    user.Id,
                    user.Mail,
                    user.Name,
                    user.Role,
                    user.Token
                });
            }
            catch (AppException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost("registerStudent")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            try
            {
                // save 
                await _incognitoService.Register(userDto);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
