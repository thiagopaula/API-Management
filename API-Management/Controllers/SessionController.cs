using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Management.ViewModel;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using LightInject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Management.Controllers
{
    [Produces("application/json")]
    [Route("sessions")]
    public class SessionController : Controller
    {
        [Inject]
        public ISessionAppService SessionAppService { get; set; }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] SessionCreateViewModel newSession)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var session = Mapper.Map<Session>(newSession);
                    await SessionAppService.Create(session);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var sessions = await SessionAppService.FindAllAsync();

                if (sessions == null) return NotFound();

                var sessionsViewModel = Mapper.Map<List<SessionViewModel>>(sessions);

                return Ok(sessionsViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetBySessionIdAsync")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var session = await SessionAppService.GetAsync(id);

                if (session == null)
                {
                    return NotFound();
                }

                var sessionViewModel = Mapper.Map<SessionViewModel>(session);

                return Ok(sessionViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}