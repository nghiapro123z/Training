using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Training.Models.Training
{
    public partial class TrainingFpt : DbContext
    {
        public TrainingFpt()
            : base("name=TrainingFpt")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<topic> topics { get; set; }
        public virtual DbSet<trainee> trainees { get; set; }
        public virtual DbSet<trainer> trainers { get; set; }
        public virtual DbSet<trainingStaff> trainingStaffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.trainees)
                .WithRequired(e => e.account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.trainers)
                .WithRequired(e => e.account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.trainingStaffs)
                .WithRequired(e => e.account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.roles)
                .WithMany(e => e.accounts)
                .Map(m => m.ToTable("accountRole").MapLeftKey("accountID").MapRightKey("roleID"));

            modelBuilder.Entity<category>()
                .Property(e => e.categoryName)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.courses)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<course>()
                .Property(e => e.courseName)
                .IsUnicode(false);

            modelBuilder.Entity<course>()
                .HasMany(e => e.topics)
                .WithRequired(e => e.course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<course>()
                .HasMany(e => e.trainees)
                .WithMany(e => e.courses)
                .Map(m => m.ToTable("traineeCourse").MapLeftKey("courseID").MapRightKey("traineeID"));

            modelBuilder.Entity<role>()
                .Property(e => e.roleName)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.topicName)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .HasMany(e => e.trainers)
                .WithMany(e => e.topics)
                .Map(m => m.ToTable("trainerTopic").MapLeftKey("topicID").MapRightKey("trainerID"));

            modelBuilder.Entity<trainee>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<trainee>()
                .Property(e => e.education)
                .IsUnicode(false);

            modelBuilder.Entity<trainee>()
                .Property(e => e.programmingLanguage)
                .IsUnicode(false);

            modelBuilder.Entity<trainer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<trainer>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<trainer>()
                .Property(e => e.education)
                .IsUnicode(false);

            modelBuilder.Entity<trainer>()
                .Property(e => e.workingPlace)
                .IsUnicode(false);

            modelBuilder.Entity<trainer>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<trainer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<trainingStaff>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<trainingStaff>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<trainingStaff>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
