using JH.BuyShiny.Contracts;
using JH.BuyShiny.Database;
using System;
using System.Collections.Generic;

namespace JH.BuyShiny.DataAccess
{
    public class PostRepository : IPostRepository
    {
        private BuyShinyContext _dbContext;
        public PostRepository(BuyShinyContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Post Add(Post post)
        {
            throw new NotImplementedException();
        }

        public List<Post> List(int maxRecords = 100, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public List<Post> List(PostTypes postType, int maxRecords = 100, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Post Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
