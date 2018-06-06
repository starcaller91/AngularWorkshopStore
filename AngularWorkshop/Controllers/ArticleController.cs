using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AngularWorkshop.Models;
using Data;
using Model.Core;
using Model.Domain;

namespace AngularWorkshop.Controllers
{
    [RoutePrefix("articles")]
    public class ArticleController : ApiController
    {
        private readonly IRepository<Article> _articleRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleController(IRepository<Article> articleRepo, IUnitOfWork unitOfWork)
        {
            _articleRepo = articleRepo;
            _unitOfWork = unitOfWork;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetLIst()
        {
            return Ok(_articleRepo.Items.ToList());
        }

        [Route("add-ordered-article")]
        [HttpPut]
        public IHttpActionResult AddOrderedArticle(AddOrderedItemRequest request)
        {
            var article = _articleRepo.Items.First(x => x.Id == request.ArticleId);

            article.Stock += request.RecievedAmount;
            _unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
