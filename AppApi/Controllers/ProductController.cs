using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppApi.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll()
        {
            var products = ProductService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var product = ProductService.Get(id);
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Create([FromBody] ProductDTO dto)
        {
            var created = ProductService.Add(dto);
            if (created == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            return Request.CreateResponse(HttpStatusCode.Created, created);
        }

      

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var success = ProductService.Delete(id);
            if (!success)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
        }
    }
}