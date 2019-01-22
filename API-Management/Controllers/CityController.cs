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
    [Route("cities")]
    public class CityController : Controller
    {

        [Inject]
        public ICityAppService CityAppService { get; set; }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CityCreateViewModel newCity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var city = Mapper.Map<City>(newCity);
                    await CityAppService.Create(city);

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
                var cities = await CityAppService.FindAllAsync();

                if (cities == null) return NotFound();

                var citiesViewModel = Mapper.Map<List<CityViewModel>>(cities);

                return Ok(citiesViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetByCityIdAsync")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var city = await CityAppService.GetAsync(id);

                if (city == null)
                {
                    return NotFound();
                }

                var cityViewModel = Mapper.Map<CityViewModel>(city);

                return Ok(cityViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] CityViewModel updatedCity)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var city = await CityAppService.GetAsync(updatedCity.Id);
                    city.Name = updatedCity.Name;
                    city.State = updatedCity.State;
                    city.UF = updatedCity.UF;
                    city.TimeZone = updatedCity.TimeZone;
                    city.Enabled = updatedCity.Enabled;
                    await CityAppService.UpdateAsync(city);

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