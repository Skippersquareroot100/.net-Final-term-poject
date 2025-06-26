using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppApi.Controllers
{
    [RoutePrefix("api/shipments")]
    public class ShipmentController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll()
        {
            var shipments = ShipmentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, shipments);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var shipment = ShipmentService.Get(id);
            if (shipment == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, shipment);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Create([FromBody] ShipmentDTO dto)
        {
            var created = ShipmentService.Add(dto);
            if (created == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            return Request.CreateResponse(HttpStatusCode.Created, created);
        }

       

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var success = ShipmentService.Delete(id);
            if (!success)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
        }

        [HttpGet]
        [Route("status/{status}")]
        public HttpResponseMessage TrackByStatus(string status)
        {
            var shipments = ShipmentService.TrackByStatus(status);
            return Request.CreateResponse(HttpStatusCode.OK, shipments);
        }
    }
}