using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class LocationController : ApiController
    {
        [HttpGet]
        [Route("api/locations")]
        public IHttpActionResult Get()
        {
            try
            {
                var locations = LocationService.Get();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/locations/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var location = LocationService.Get(id);
                if (location == null) return NotFound();
                return Ok(location);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/locations")]
        public IHttpActionResult Post([FromBody] LocationDTO dto)
        {
            try
            {
                var location = LocationService.Add(dto);
                if (location == null) return BadRequest("Location creation failed");
                return Created($"api/locations/{location.LocationId}", location);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("api/locations")]
        public IHttpActionResult Put([FromBody] LocationDTO dto)
        {
            try
            {
                var location = LocationService.Update(dto);
                if (location == null) return BadRequest("Location update failed");
                return Ok(location);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("api/locations/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var success = LocationService.Delete(id);
                if (!success) return NotFound();
                return Ok("Location deleted successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/locations/warehouse/{warehouseId}")]
        public IHttpActionResult GetByWarehouse(int warehouseId)
        {
            try
            {
                var locations = LocationService.GetByWarehouse(warehouseId);
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/locations/utilization")]
        public IHttpActionResult GetUtilizationReport()
        {
            try
            {
                var report = LocationService.GetUtilizationReport();
                return Ok(report);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}