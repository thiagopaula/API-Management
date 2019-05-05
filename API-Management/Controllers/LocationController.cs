using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("locations")]
    public class LocationController : Controller
    {
        [Inject]
        public ILocationAppService LocationAppService { get; set; }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] LocationCreateViewModel newLocation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var location = Mapper.Map<Location>(newLocation);
                    await LocationAppService.Create(location);

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
                var locations = await LocationAppService.FindAllAsync();

                if (locations == null || !locations.Any()) return NotFound();

                var locationsViewModel = Mapper.Map<List<LocationViewModel>>(locations);

                return Ok(locationsViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetByLocationIdAsync")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var location = await LocationAppService.GetAsync(id);

                if (location == null)
                {
                    return NotFound();
                }

                var locationViewModel = Mapper.Map<LocationViewModel>(location);

                return Ok(locationViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] LocationViewModel updatedLocation)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var location = await LocationAppService.GetAsync(updatedLocation.Id);
                    location.Name = updatedLocation.Name;
                    location.ResumeName = updatedLocation.ResumeName;
                    location.TheaterId = updatedLocation.TheaterId;
                    location.Enabled = updatedLocation.Enabled;
                    await LocationAppService.UpdateAsync(location);

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