using Common;
using Common.Interfaces;
using Domain;
using System;
using System.Collections.Generic;

namespace Services
{
    public class MovieService : ICRUD<Movie>
    {
        public Movie Get(ID id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> Get()
        {
            throw new NotImplementedException();
        }

        public ID Insert(Movie item)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie item)
        {
            throw new NotImplementedException();
        }
        public void Delete(ID id)
        {
            throw new NotImplementedException();
        }
    }
}
