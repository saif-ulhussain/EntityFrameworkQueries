using Entity_Framework_Queries.DTO;
using Entity_Framework_Queries.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Entity_Framework_Queries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DboAuthorController : ControllerBase
    {
        private readonly Linq_QueriesContext linq_QueriesContext;

        public DboAuthorController(Linq_QueriesContext Linq_QueriesContext)
        {
            this.linq_QueriesContext = Linq_QueriesContext;
        }

        [HttpGet("AllAuthors")]

        public async Task<ActionResult<List<AuthorDTO>>> Get()
        {
            var List = await linq_QueriesContext.DboAuthors.Select(
                s => new AuthorDTO
                {
                    Id = s.Id,
                    Name = s.Name
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