using Master.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        private readonly ApiContext context;
        public ActivityLogController(ApiContext context)
        {
            this.context = context;
        }

        //Create
        [HttpPost]
        public async Task<ActionResult<ActivityLog>> PostLog(ActivityLog log)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                if (FindMID(log.MID))
                {
                    context.ActivityLog.Add(log);
                    await context.SaveChangesAsync();
                    return Created();
                }
                return NotFound();
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error insert activity log");
            }           

        }

        private bool FindMID(int mid)
        {
            return (context.ActivityLog?.Any(e => e.MID == mid)).GetValueOrDefault();
        }


    }
}
