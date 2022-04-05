using Core.Context;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebService.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebService
{
    public class MovieService:IMovieService
    {
        /// <summary>
        /// MovieRepository Instance
        /// </summary>
        private readonly DBContext _dBContext;

        /// <summary>
        /// MovieService Constructor
        /// </summary>
        /// <param name="repository">The Dependency Injection for IMovieRepository</param>
        public MovieService(DBContext dBContext)
        {
           
            _dBContext = dBContext;
        }

        /// <summary>
        /// Get all the Movies in the DB
        /// </summary>
        /// <returns>All the Movies</returns>
        public async Task<List<Movie>> GetAll()
        {
            // Get Movies from the Repository
            return await _dBContext.Movies.ToListAsync();
        }

        /// <summary>
        /// Get a Movie by Id
        /// </summary>
        /// <param name="id">The Id of the Movie record</param>
        /// <returns>Movie record related to the given Id</returns>
        public async Task<Movie> Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a new entity record to the DB
        /// </summary>
        /// <param name="entity">The new entity record</param>
        /// <returns></returns>
        public void Add(List<Movie> entity)
        {
            // Add new entity record to the DB
            _dBContext.Set<Movie>().AddRange(entity);
            _dBContext.SaveChanges();
        }

        /// <summary>
        /// Add a new entity record to the DB
        /// </summary>
        /// <param name="entity">The new entity record</param>
        /// <returns>New entity record</returns>
        public async Task<Movie> Add(Movie entity)
        {
            // Add new entity record to the DB
            var savedEntity = _dBContext.Set<Movie>().Add(entity);
            await _dBContext.SaveChangesAsync();
            return savedEntity.Entity;
        }

        public Task<Movie> Update(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
