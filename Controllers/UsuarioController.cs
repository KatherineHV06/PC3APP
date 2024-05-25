using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SilliconValley.Integration;
using SilliconValley.Integration.dto;

namespace SilliconValley.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly ListarUsuariosAPIIntegration _listUsers;

        public UsuarioController(ILogger<UsuarioController> logger,
        ListarUsuariosAPIIntegration listUsers)
        {
            _logger = logger;
            _listUsers = listUsers;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Usuario> users = await _listUsers.GetAllUser();
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}