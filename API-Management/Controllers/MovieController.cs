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
    [Route("movies")]
    public class MovieController : Controller
    {
        [Inject]
        public IMovieAppService MovieAppService { get; set; }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] MovieCreateViewModel newMovie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var movie = Mapper.Map<Movie>(newMovie);
                    await MovieAppService.Create(movie);

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
                var movies = await MovieAppService.FindAllAsync();

                if (movies == null) return NotFound();

                var moviesViewModel = Mapper.Map<List<MovieViewModel>>(movies);

                return Ok(moviesViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetByMovieIdAsync")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var movie = await MovieAppService.GetAsync(id);

                if (movie == null)
                {
                    return NotFound();
                }

                var movieViewModel = Mapper.Map<MovieViewModel>(movie);

                return Ok(movieViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] MovieViewModel updatedMovie)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var movie = await MovieAppService.GetAsync(updatedMovie.Id);
                    movie.Title = updatedMovie.Title;
                    movie.Duration = updatedMovie.Duration;
                    movie.Sinopsis = updatedMovie.Sinopsis;
                    movie.Directors = updatedMovie.Directors;
                    movie.Year = updatedMovie.Year;
                    movie.Priority = updatedMovie.Priority;
                    movie.Enabled = updatedMovie.Enabled;
                    await MovieAppService.UpdateAsync(movie);

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