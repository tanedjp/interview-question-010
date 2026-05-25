using interview_question_010.Modules.Candicate.Models;
using interview_question_010.Modules.Common.Models;
using interview_question_010.Modules.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace interview_question_010.Modules;

public class ContextDb : DbContext

{
    public ContextDb(DbContextOptions<ContextDb> options)
        : base(options)
    {
    }

    public DbSet<t_test> t_test { get; set; }
    public DbSet<v_test> v_test { get; set; }
    public DbSet<t_question> t_question { get; set; }
    public DbSet<v_question> v_question { get; set; }
    public DbSet<t_choice> t_choice { get; set; }
    public DbSet<v_choice> v_choice { get; set; }

    public DbSet<t_candidate> t_candidate { get; set; }
    public DbSet<v_candidate> v_candidate { get; set; }
    public DbSet<t_candidate_question> t_candidate_question { get; set; }
    public DbSet<v_candidate_question> v_candidate_question { get; set; }
    public DbSet<t_candidate_choice> t_candidate_choice { get; set; }
    public DbSet<v_candidate_choice> v_candidate_choice { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<t_test>().ToTable("test");
        modelBuilder.Entity<v_test>().ToView("v_test");

        modelBuilder.Entity<t_question>().ToTable("question");
        modelBuilder.Entity<t_question>()
            .HasOne(c => c.test).WithMany(c => c.questions)
            .HasForeignKey(c => c.test_uid).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<v_question>().ToView("v_question");
        modelBuilder.Entity<v_question>()
            .HasOne(c => c.test).WithMany(c => c.questions)
            .HasForeignKey(c => c.test_uid).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<t_choice>().ToTable("choice");
        modelBuilder.Entity<t_choice>()
            .HasOne(c => c.question).WithMany(c => c.choices)
            .HasForeignKey(c => c.question_uid).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<v_choice>().ToView("v_choice");
        modelBuilder.Entity<v_choice>()
            .HasOne(c => c.question).WithMany(c => c.choices)
            .HasForeignKey(c => c.question_uid).OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<t_candidate>().ToTable("candidate");
        modelBuilder.Entity<v_candidate>().ToView("v_candidate");

        modelBuilder.Entity<t_candidate_question>().ToTable("candidate_question");
        modelBuilder.Entity<t_candidate_question>()
            .HasOne(c => c.candidate).WithMany(c => c.candidate_questions)
            .HasForeignKey(c => c.candidate_uid).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<v_candidate_question>().ToView("v_candidate_question");
        modelBuilder.Entity<v_candidate_question>()
            .HasOne(c => c.candidate).WithMany(c => c.candidate_questions)
            .HasForeignKey(c => c.candidate_uid).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<t_candidate_choice>().ToTable("candidate_choice");
        modelBuilder.Entity<t_candidate_choice>()
            .HasOne(c => c.candidate_question).WithMany(c => c.candidate_choices)
            .HasForeignKey(c => c.candidate_question_uid).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<v_candidate_choice>().ToView("v_candidate_choice");
        modelBuilder.Entity<v_candidate_choice>()
            .HasOne(c => c.candidate_question).WithMany(c => c.candidate_choices)
            .HasForeignKey(c => c.candidate_question_uid).OnDelete(DeleteBehavior.Cascade);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries<base_table>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.created_date = DateTime.UtcNow;
                entry.Entity.created_by = "SYSTEM";
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.updated_date = DateTime.UtcNow;
                entry.Entity.updated_by = "SYSTEM";
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}