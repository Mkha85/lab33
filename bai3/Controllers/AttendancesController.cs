using bai3.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bai3.Controllers
{
    public class AttendanceController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public AttendanceController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(Attendance attendanceDto) 
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The attendance already exists!");
            var attendace = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };
            _dbContext.Attendances.Add(attendace);
            _dbContext.SaveChanges();

            return Ok();
        }
    }

}
