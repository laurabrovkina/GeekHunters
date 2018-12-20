using System;
using System.Collections.Generic;

namespace GeekHunter.Model
{
    public partial class Skill
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<CandidateSkill> Candidates { get; set;}
    }
}
