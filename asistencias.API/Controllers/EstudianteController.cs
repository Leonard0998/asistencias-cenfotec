﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ausencias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EstudianteController : Controller
    {
        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Estudiante estudiante)
        {
            estudiante.InsertAsync();
            return Ok(new { Result = "Estudiante created successfully" });
        }

        [HttpGet("GetStudent")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Get()
        {
            var estudiantes = await Estudiante.Get();
            return Ok(new { Result = estudiantes });
        }

        [HttpGet("GetById")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Get(int id)
        {
            var estudiante = new Estudiante();
            var estudiantes = await estudiante.GetByIdAsync<Estudiante>(id);
            return Ok(new { Result = estudiantes });
        }

        [HttpPatch("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(Estudiante estudiante)
        {
            await estudiante.UpdateAsync();
            return Ok(new { Result = "Estudiante updated successfully" });
        }
    }
}