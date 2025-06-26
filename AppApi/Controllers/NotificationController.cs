using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class NotificationController : ApiController
    {
        [HttpGet]
        [Route("api/notifications")]
        public IHttpActionResult Get()
        {
            try
            {
                var notifications = NotificationService.Get();
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/notifications/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var notification = NotificationService.Get(id);
                if (notification == null) return NotFound();
                return Ok(notification);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

   

        [HttpDelete]
        [Route("api/notifications/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var success = NotificationService.Delete(id);
                if (!success) return NotFound();
                return Ok("Notification deleted successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/notifications/warehouse/{warehouseId}")]
        public IHttpActionResult GetByWarehouse(int warehouseId)
        {
            try
            {
                var notifications = NotificationService.GetByWarehouse(warehouseId);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/notifications/recent")]
        public IHttpActionResult GetRecent()
        {
            try
            {
                var notifications = NotificationService.GetRecent();
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}