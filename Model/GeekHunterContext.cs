using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GeekHunter.Model
{
    public partial class GeekHunterContext : DbContext
    {
        public GeekHunterContext()
        {
        }

        public GeekHunterContext(DbContextOptions<GeekHunterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=GeekHunter.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<CandidateSkill>(entity => {
                entity.HasKey(e => new { e.CandidateId, e.SkillId });

                entity.HasOne(e => e.Candidate).WithMany(e => e.Skills).HasForeignKey(e => e.CandidateId);

                entity.HasOne(e => e.Skill).WithMany(e => e.Candidates).HasForeignKey(e => e.SkillId);
            });
        }
    }
}
