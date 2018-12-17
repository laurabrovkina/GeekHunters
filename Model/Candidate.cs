using System;
using System.Collections.Generic;

namespace GeekHunter.Model
{
    public partial class Candidate
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CandidateSkill> Skills { get; set;}
    }
}
