using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dal.Do
{
    public partial class dbcontext : DbContext
    {
        public dbcontext()
        {
        }

        public dbcontext(DbContextOptions<dbcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<GivenCourse> GivenCourses { get; set; } = null!;
        public virtual DbSet<Inscribed> Inscribeds { get; set; } = null!;
        public virtual DbSet<Level> Levels { get; set; } = null!;
        public virtual DbSet<MySubject> MySubjects { get; set; } = null!;
        public virtual DbSet<Time> Times { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=STD-HASH\\PROGB;Initial Catalog=AAAAAAA_Studying_by_miri&brachi;Integrated Security=True ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CodeCourse)
                    .HasName("PK__Course__A0DACEB3DE63B39A");

                entity.ToTable("Course");

                entity.Property(e => e.CodeCourse).HasColumnName("codeCourse");

                entity.Property(e => e.CodeSubject).HasColumnName("codeSubject");

                entity.Property(e => e.DateOfCourseEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfCourseEnd");

                entity.Property(e => e.DateOfCourseStart)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfCourseStart");

                entity.Property(e => e.NameOfCourse)
                    .HasMaxLength(12)
                    .HasColumnName("nameOfCourse");

                entity.Property(e => e.NumQuality).HasColumnName("numQuality");

                entity.Property(e => e.SortCourse)
                    .HasMaxLength(12)
                    .HasColumnName("sortCourse");

                entity.HasOne(d => d.CodeSubjectNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CodeSubject)
                    .HasConstraintName("FK__Course__codeSubj__59FA5E80");

                entity.HasOne(d => d.NumQualityNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.NumQuality)
                    .HasConstraintName("FK__Course__numQuali__5AEE82B9");
            });

            modelBuilder.Entity<GivenCourse>(entity =>
            {
                entity.HasKey(e => e.TzGivenCourses)
                    .HasName("PK__GivenCou__995900414D3D0538");

                entity.Property(e => e.TzGivenCourses)
                    .HasMaxLength(12)
                    .HasColumnName("tzGivenCourses");

                entity.Property(e => e.CodeSubject).HasColumnName("codeSubject");

                entity.Property(e => e.NameOfGivenCourses)
                    .HasMaxLength(12)
                    .HasColumnName("nameOfGivenCourses");

                entity.Property(e => e.PhoneOfGivenCourses).HasMaxLength(12);

                entity.HasOne(d => d.CodeSubjectNavigation)
                    .WithMany(p => p.GivenCourses)
                    .HasForeignKey(d => d.CodeSubject)
                    .HasConstraintName("FK__GivenCour__codeS__5EBF139D");
            });

            modelBuilder.Entity<Inscribed>(entity =>
            {
                entity.HasKey(e => e.TzInscribed)
                    .HasName("PK__Inscribe__837564B06DEE6554");

                entity.ToTable("Inscribed");

                entity.Property(e => e.TzInscribed)
                    .HasMaxLength(9)
                    .HasColumnName("tzInscribed");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.InscribedName)
                    .HasMaxLength(9)
                    .HasColumnName("Inscribed_name");

                entity.Property(e => e.InscribedSubjectCode).HasColumnName("Inscribed_subject_code");

                entity.Property(e => e.PhoneInscribed)
                    .HasMaxLength(12)
                    .HasColumnName("phoneInscribed");

                entity.Property(e => e.SortInscribed)
                    .HasMaxLength(4)
                    .HasColumnName("sortInscribed");

                entity.Property(e => e.Tests)
                    .HasMaxLength(3)
                    .HasColumnName("tests")
                    .HasDefaultValueSql("('no')");

                entity.HasOne(d => d.InscribedSubjectCodeNavigation)
                    .WithMany(p => p.Inscribeds)
                    .HasForeignKey(d => d.InscribedSubjectCode)
                    .HasConstraintName("FK__Inscribed__Inscr__5165187F");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK__Levels__DF908D650E2B1A2C");

                entity.Property(e => e.Num)
                    .ValueGeneratedNever()
                    .HasColumnName("num");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(12)
                    .HasColumnName("descriptions");
            });

            modelBuilder.Entity<MySubject>(entity =>
            {
                entity.HasKey(e => e.CodeSubject)
                    .HasName("PK__MySubjec__17CA65EFF83CFC97");

                entity.ToTable("MySubject");

                entity.Property(e => e.CodeSubject).HasColumnName("codeSubject");

                entity.Property(e => e.Categury)
                    .HasMaxLength(20)
                    .HasColumnName("categury")
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .HasColumnName("city");

                entity.Property(e => e.ContactMan)
                    .HasMaxLength(20)
                    .HasColumnName("contactMan");

                entity.Property(e => e.ContactManPhone)
                    .HasMaxLength(20)
                    .HasColumnName("contactManPhone");

                entity.Property(e => e.LengthOf).HasColumnName("length_of");

                entity.Property(e => e.MaxNumInscribed).HasColumnName("maxNumInscribed");

                entity.Property(e => e.NumInscribed).HasColumnName("numInscribed");

                entity.Property(e => e.Place)
                    .HasMaxLength(20)
                    .HasColumnName("place");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SortStudents)
                    .HasMaxLength(4)
                    .HasColumnName("sortStudents");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(20)
                    .HasColumnName("Subject_name");

                entity.Property(e => e.Tests)
                    .HasMaxLength(20)
                    .HasColumnName("tests");
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.HasKey(e => e.CodeTime)
                    .HasName("PK__Times__7768F44D437DC06F");

                entity.Property(e => e.CodeTime).HasColumnName("codeTime");

                entity.Property(e => e.CodeCourse).HasColumnName("codeCourse");

                entity.Property(e => e.DaysOfCourse)
                    .HasMaxLength(6)
                    .HasColumnName("daysOfCourse");

                entity.Property(e => e.HourOfCourse).HasColumnName("hourOfCourse");

                entity.HasOne(d => d.CodeCourseNavigation)
                    .WithMany(p => p.Times)
                    .HasForeignKey(d => d.CodeCourse)
                    .HasConstraintName("FK__Times__codeCours__619B8048");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
