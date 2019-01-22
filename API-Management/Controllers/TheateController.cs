
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
    [Route("theaters")]
    public class TheateController : Controller
    {
        [Inject]
        public ITheaterAppService TheaterAppService { get; set; }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] TheaterCreateViewModel newTheater)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var theater = Mapper.Map<Theater>(newTheater);
                    await TheaterAppService.Create(theater);

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
                var theaters = await TheaterAppService.FindAllAsync();

                if (theaters == null) return NotFound();

                var theaterViewModel = Mapper.Map<List<TheaterViewModel>>(theaters);

                return Ok(theaterViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetByTheaterIdAsync")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var theater = await TheaterAppService.GetAsync(id);

                if (theater == null)
                {
                    return NotFound();
                }

                var theaterViewModel = Mapper.Map<TheaterViewModel>(theater);

                return Ok(theaterViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] TheaterViewModel updatedTheater)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var theater = await TheaterAppService.GetAsync(updatedTheater.Id);
                    theater.Name = updatedTheater.Name;
                    theater.CNPJ = updatedTheater.CNPJ;
                    theater.Street = updatedTheater.Street;
                    theater.Number = updatedTheater.Number;
                    theater.Complement = updatedTheater.Complement;
                    theater.PostalCode = updatedTheater.PostalCode;
                    theater.Priority = updatedTheater.Priority;
                    theater.Enabled = updatedTheater.Enabled;
                    theater.CityId = updatedTheater.CityId;
                    await TheaterAppService.UpdateAsync(theater);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }
    }
}