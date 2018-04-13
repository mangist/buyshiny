using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JH.BuyShiny.Contracts;
using JH.BuyShiny.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {
        private IPostRepository _repository;

        public PostController(IPostRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("[action]")]
        public IEnumerable<Post> List(int maxRecords, int offset)
        {
            return _repository.List(maxRecords, offset);
        }
    }
}