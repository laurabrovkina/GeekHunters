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
    public class CandidatesController : ControllerBase
    {
        private readonly GeekHunterContext _ctx;

        public CandidatesController(GeekHunterContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ctx.Candidate.Include(c => c.Skills).Select(c => new {
                c.Id,
                c.FirstName,
                c.LastName,
                Skills = c.Skills.Select(s => s.Skill.Name),
            }).ToArrayAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateData data)
        {
            var candidate = new Candidate
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
            };

            await _ctx.Candidate.AddAsync(candidate);

            candidate.Skills = data.Skills.Select(s => new CandidateSkill
            {
                CandidateId = candidate.Id,
                SkillId = s,
            }).ToArray();

            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        public class CandidateData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public long[] Skills { get; set; }
        }
    }
}
