using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppApi.Controllers
{
    [RoutePrefix("api/warehouses")]
    public class WarehouseController : ApiController
    {
       
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var warehouses = WarehouseService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, warehouses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var warehouse = WarehouseService.Get(id);
                if (warehouse == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                return Request.CreateResponse(HttpStatusCode.OK, warehouse);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("")]
        public HttpResponseMessage Create([FromBody] WarehouseDTO dto)
        {
            try
            {
                if (dto == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request body is empty");

                var createdWarehouse = WarehouseService.Add(dto);
                if (createdWarehouse == null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create warehouse");

                return Request.CreateResponse(HttpStatusCode.Created, createdWarehouse);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

     

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var success = WarehouseService.Delete(id);
                if (!success)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Warehouse not found");

                return Request.CreateResponse(HttpStatusCode.OK, "Warehouse deleted successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("utilization-report")]
        public HttpResponseMessage GetUtilizationReport()
        {
            try
            {
                var report = WarehouseService.GetUtilizationReport();
                return Request.CreateResponse(HttpStatusCode.OK, report);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}