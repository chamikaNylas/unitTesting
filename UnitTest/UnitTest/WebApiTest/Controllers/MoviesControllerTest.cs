using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebService.Interfaces;
using Xunit;

namespace UnitTest.WebApiTest.Controllers
{
    public class MoviesControllerTest
    {
        /// <summary>
        /// MovieService Mock Instance
        /// </summary>
        private readonly Mock<IMovieService> movieService;

        /// <summary>
        /// MoviesController Instance
        /// </summary>
        private readonly MoviesController moviesController;

        public MoviesControllerTest()
        {
            var identity = new GenericIdentity("some name", "test");
            // Assign the Mocked service object to the private instance
            this.movieService = new Mock<IMovieService>();

            // Initialize Controller with a the Mock service object
            this.moviesController = new MoviesController(this.movieService.Object);
        }

        [Fact]
        public async Task GetAllMovies_ReturnsMovies()
        {
            // Arrange(Setup the Mock service)
            this.movieService.Setup(p => p.GetAll()).ReturnsAsync(new List<Movie> {
                new Movie
                {
                    Id = 1,
                    Title = "Test Movie 1",
                    Genre = "Test Genre",
                    PostedBy = "nimal"
                },
                new Movie
                {
                    Id = 2,
                    Title = "Test Movie 2",
                    Genre = "Test Genre",
                    PostedBy = "saman"
                }
            });

            // Act(Execute the controller method)
            var result = await this.moviesController.Get();

            // Assert
            // Assert the type of the return object
            var okObbjectResult = Assert.IsType<OkObjectResult>(result);
            var resultsList = Assert.IsType<List<Movie>>(okObbjectResult.Value);
            // Assert the value of the return object
            Assert.True(resultsList.Any());
        }


    }
}
