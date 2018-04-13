using JH.BuyShiny.Database;
using System;
using System.Collections.Generic;

namespace JH.BuyShiny.Contracts
{
    public interface IPostRepository
    {
        List<Post> List(int maxRecords = 100, int offset = 0);
        List<Post> List(PostTypes postType, int maxRecords = 100, int offset = 0);
        Post Add(Post post);
        Post Update(Post post);
    }
}
