using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppApi.Controllers
{
    [RoutePrefix("api/inventory")]
    public class InventoryController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll()
        {
            var inventory = InventoryService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, inventory);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var item = InventoryService.Get(id);
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Create([FromBody] InventoryDTO dto)
        {
            var created = InventoryService.Add(dto);
            if (created == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            return Request.CreateResponse(HttpStatusCode.Created, created);
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var success = InventoryService.Delete(id);
            if (!success)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
        }

        [HttpGet]
        [Route("search/{query}")]
        public HttpResponseMessage Search(string query)
        {
            var results = InventoryService.Search(query);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}