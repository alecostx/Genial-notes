﻿using GenialNotes.src.Interfaces;
using GenialNotes.src.Models;
using GenialNotes.src.Models.Requests;
using GenialNotes.src.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenialNotes.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsuarioController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Retorna todos os usuários na base
        /// </summary>
        [HttpGet("Usuario")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await _userRepository.GetUsers();
            return Ok(result);
        }

        /// <summary>
        /// Registra um usuário na base
        /// </summary>
        /// <param name="request">Registro de um usuário</param>
        [HttpPost("RegistrarUsuario")]
        public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
        {
            var result = await _userRepository.RegisterUser(request);
            return Ok(result);
        }

        /// <summary>
        /// Valida um usuário na base
        /// /// <param name="senha">Código de identificação da conta na Genial</param>
        /// /// <param name="email">Código de identificação da conta na Genial</param>
        /// </summary>
        [HttpGet("ValidarLogin")]
        public async Task<IActionResult> LoginValidate(string senha, string email)
        {
            var result = await _userRepository.LoginValidate(senha, email);
            return Ok(result);
        }

    }
}
