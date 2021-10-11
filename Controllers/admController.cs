using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto_RH.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_RH.Controllers
{
    [Authorize(Roles ="ti")]
    public class admController : Controller
    {
        private readonly RoleManager<IdentityRole> RoleManager;

        public admController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
    
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Create(Permissoes role)
        {
            var roleExist = await RoleManager.RoleExistsAsync(role.Permissao);
            if (!roleExist)
            {
                var result = await RoleManager.CreateAsync(new IdentityRole(role.Permissao));
            }
            return View();
        }
    }
}
