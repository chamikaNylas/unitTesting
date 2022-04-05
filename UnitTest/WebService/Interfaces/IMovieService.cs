using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAll();
        Task<Movie> Get(int id);
        Task<Movie> Add(Movie entity);
        void Add(List<Movie> entities);
        Task<Movie> Update(Movie entity);
        Task<bool> Delete(int id);
    }
}
