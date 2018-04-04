using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Model.Core;
using Model.Domain;

namespace AngularWorkshop.Controllers
{
    [RoutePrefix("articles")]
    public class ArticleController : ApiController
    {
        private IRepository<Article> _articleRepo;

        public ArticleController(IRepository<Article> articleRepo)
        {
            _articleRepo = articleRepo;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetLIst()
        {
            return Ok(_articleRepo.Items.ToList());
        }
    }
}
