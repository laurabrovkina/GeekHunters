using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekHunter.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeekHunter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly GeekHunterContext _ctx;

        public CandidateController(GeekHunterContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ctx.Candidate.ToArrayAsync());
        }
    }
}
