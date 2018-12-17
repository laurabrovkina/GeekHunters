using System;
using System.Collections.Generic;

namespace GeekHunter.Model
{
    public class CandidateSkill
    {
        public long CandidateId { get; set;}
        public Candidate Candidate { get; set;}
        public long SkillId { get; set;}
        public Skill Skill { get; set;}
    }
}