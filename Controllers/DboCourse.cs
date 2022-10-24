using Entity_Framework_Queries.DTO;
using Entity_Framework_Queries.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Entity_Framework_Queries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DboCourseController : ControllerBase
    {
        private readonly Linq_QueriesContext ling_QueriesContext;

        public DboCourseController(Linq_QueriesContext Linq_QueriesContext)
        {
            this.ling_QueriesContext = Linq_QueriesContext;
        }

        [HttpGet("AllCourses")]

        public async Task<ActionResult<List<CourseDTO>>> Get()
        {
            var List = await ling_QueriesContext.DboCourses.Select(
                s => new CourseDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Level = s.Level,
                    FullPrice = s.FullPrice,
                    AuthorId = s.AuthorId
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
    }
}