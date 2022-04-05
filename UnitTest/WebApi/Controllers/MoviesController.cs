using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebService.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        /// <summary>
        /// MovieService Instance
        /// </summary>
        private readonly IMovieService _movieService;

        /// <summary>
        /// MoviesController Constructor
        /// </summary>
        /// <param name="movieService">The Dependency Injection for MovieService</param>
        public MoviesController(IMovieService movieService)
        {
            // Assign the Dependency Injected object to the private instance
            _movieService = movieService;
        }

        /// <summary>
        /// Get all the Movies in the DB
        /// GET: api/[controller]
        /// </summary>
        /// <returns>All the Movies</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Get all the Movies in the DB
            var result = await _movieService.GetAll();

            // Return Movie records
            return Ok(result);
        }

        /// <summary>
        /// Get a Movie by Id
        /// GET: api/[controller]/5
        /// </summary>
        /// <param name="id">The Id of the Movie record</param>
        /// <returns>Movie record related to the given Id</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // Validate the Movie Id.
            if (id <= 0)
            {
                return BadRequest();
            }

            // Get movie record related to the Id
            var movie = await _movieService.Get(id);

            // Movie not found on the DB.
            if (movie == default)
            {
                return NotFound();
            }

            // Return Movie record
            return Ok(movie);
        }

        /// <summary>
        /// Add a new Movie record to the DB
        /// POST: api/[controller]
        /// </summary>
        /// <param name="movie">The new Movie record</param>
        /// <returns>New Movie record</returns>
        [HttpPost]
        public async Task<IActionResult> Post(Movie movie)
        {
            // Validate new Movie object
            if (!ModelState.IsValid || movie.Id < 0)
            {
                return BadRequest();
            }

            // Add new Movie record to the DB
            var result = await _movieService.Add(movie);

            // The new Movie record not saved to the DB
            if (result.Id <= 0)
            {
                return BadRequest();
            }

            // Return new Movie record
            return Ok(result);
        }

        /// <summary>
        /// Update existing Movie record to the DB
        /// </summary>
        /// <param name="id">The existing Movie record's Id</param>
        /// <param name="movie">The existing Movie record with the changes</param>
        /// PUT: api/[controller]/5
        /// <returns>Updated Movie record</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Movie movie)
        {
            // Validate Movie object and the Movie Id
            if (!ModelState.IsValid || id <= 0 || movie.Id <= 0 || id != movie.Id)
            {
                return BadRequest();
            }

            // Update existing Movie record to the DB
            var result = await _movieService.Update(movie);

            // Return updated Movie record
            return Ok(result);
        }

        /// <summary>
        /// Delete existing Movie record on the DB
        /// DELETE: api/[controller]/5
        /// </summary>
        /// <param name="id">The existing Movie record's Id</param>
        /// <returns>If the Delete was successfull or not (True / False)</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Validate Movie object
            if (id <= 0)
            {
                return BadRequest();
            }

            // Delete existing Movie record on the DB
            var result = await _movieService.Delete(id);

            // The Movie record not deleted from the DB
            if (!result)
            {
                return BadRequest();
            }

            // Return if the Delete was successfull or not
            return Ok(result);
        }
    }
}
