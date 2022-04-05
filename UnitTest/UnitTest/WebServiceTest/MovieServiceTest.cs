using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService;
using WebService.Interfaces;
using Xunit;

namespace UnitTest.WebServiceTest
{
    public class MovieServiceTest
    {

        /// <summary>
        /// TestHelper Instance
        /// </summary>
        private readonly TestHelper testHelper;



        /// <summary>
        /// MovieService Instance
        /// </summary>
        private readonly IMovieService movieService;

        public MovieServiceTest() 
        {
            // Assign the Mocked Context object to the private instance
            this.testHelper = new TestHelper();


            // Initialize Service with a the Mock service object
            this.movieService = new MovieService(this.testHelper.GetDBContext());



        }

        [Fact]
        public async Task GetAllMovies_ReturnsMovies()
        {
            // Act(Execute the controller method)
            var result = await this.movieService.GetAll();

            // Assert
            // Assert the value of the return object
            Assert.True(result.Any());
        }

        [Fact]
        public async Task AddMovie_ReturnsMovie()
        {
            // Act
            // use Write Repository to add mock data
            var movie = await movieService.Add(new Movie
            {
                Id = 0,
                Title = "Test Movie 1",
                Genre = "Test Genre",
                PostedBy = "venura"
            });

            // Assert
            Assert.NotNull(movie);
            Assert.True(movie.Id > 0);
        }


        #region Private Methods

       

        #endregion
    }
}
