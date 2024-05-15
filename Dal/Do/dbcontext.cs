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

        public virtual DbSet<Answor> Answors { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<GivenCourse> GivenCourses { get; set; } = null!;
        public virtual DbSet<Inscribed> Inscribeds { get; set; } = null!;
        public virtual DbSet<MySubject> MySubjects { get; set; } = null!;
        public virtual DbSet<Qrashten> Qrashtens { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<Time> Times { get; set; } = null!;
        public virtual DbSet<ToMatch> ToMatches { get; set; } = null!;
        public virtual DbSet<Yrapholojist> Yrapholojists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=STD-HASH\\PROGB;Initial Catalog=AAAAAAA_Studying_by_miri&brachi;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answor>(entity =>
            {
                entity.HasKey(e => e.CodAnswor)
                    .HasName("PK__Answor__E3F7562A5A1BE34B");

                entity.ToTable("Answor");

                entity.Property(e => e.CodAnswor).HasColumnName("codAnswor");

                entity.Property(e => e.Aswor)
                    .HasMaxLength(50)
                    .HasColumnName("aswor");

                entity.Property(e => e.CodQreshten).HasColumnName("codQreshten");

                entity.Property(e => e.GredToAnswor).HasColumnName("gredToAnswor");

                entity.HasOne(d => d.CodQreshtenNavigation)
                    .WithMany(p => p.Answors)
                    .HasForeignKey(d => d.CodQreshten)
                    .HasConstraintName("FK__Answor__codQresh__05D8E0BE");
            });

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

                entity.Property(e => e.FileToMatch)
                    .HasMaxLength(25)
                    .HasColumnName("fileToMatch");

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

            modelBuilder.Entity<MySubject>(entity =>
            {
                entity.HasKey(e => e.CodeSubject)
                    .HasName("PK__MySubjec__17CA65EFF83CFC97");

                entity.ToTable("MySubject");

                entity.Property(e => e.CodeSubject).HasColumnName("codeSubject");

                entity.Property(e => e.Categury)
                    .HasMaxLength(20)
                    .HasColumnName("categury");

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
                    .HasMaxLength(11)
                    .HasColumnName("sortStudents");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(20)
                    .HasColumnName("Subject_name");
            });

            modelBuilder.Entity<Qrashten>(entity =>
            {
                entity.HasKey(e => e.CodeQrashten)
                    .HasName("PK__tmp_ms_x__CD21B8D1F43DC975");

                entity.Property(e => e.CodeQrashten).HasColumnName("codeQrashten");

                entity.Property(e => e.CodeTest).HasColumnName("codeTest");

                entity.Property(e => e.Qrashten1)
                    .HasMaxLength(50)
                    .HasColumnName("qrashten");

                entity.HasOne(d => d.CodeTestNavigation)
                    .WithMany(p => p.Qrashtens)
                    .HasForeignKey(d => d.CodeTest)
                    .HasConstraintName("FK__Qrashtens__codeT__778AC167");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => e.CodeTest)
                    .HasName("PK__Tests__99CE55DAE9440AA4");

                entity.Property(e => e.CodeTest).HasColumnName("codeTest");

                entity.Property(e => e.CodeSubject).HasColumnName("codeSubject");

                entity.Property(e => e.MoveGred).HasColumnName("moveGred");

                entity.HasOne(d => d.CodeSubjectNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.CodeSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tests__codeSubje__6FE99F9F");
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

            modelBuilder.Entity<ToMatch>(entity =>
            {
                entity.HasKey(e => e.CodToMatch)
                    .HasName("PK__tmp_ms_x__A23571A0705250C6");

                entity.ToTable("ToMatch");

                entity.Property(e => e.CodToMatch).HasColumnName("codToMatch");

                entity.Property(e => e.FileToMatch)
                    .HasMaxLength(25)
                    .HasColumnName("fileToMatch");

                entity.Property(e => e.Sort)
                    .HasMaxLength(10)
                    .HasColumnName("sort");

                entity.Property(e => e.TzInscribed)
                    .HasMaxLength(9)
                    .HasColumnName("tzInscribed");

                entity.Property(e => e.TzYrapholojist)
                    .HasMaxLength(9)
                    .HasColumnName("tzYrapholojist");

                entity.Property(e => e.WoritMatch)
                    .HasMaxLength(200)
                    .HasColumnName("woritMatch");

                entity.HasOne(d => d.TzInscribedNavigation)
                    .WithMany(p => p.ToMatches)
                    .HasForeignKey(d => d.TzInscribed)
                    .HasConstraintName("FK__ToMatch__tzInscr__04E4BC85");

                entity.HasOne(d => d.TzYrapholojistNavigation)
                    .WithMany(p => p.ToMatches)
                    .HasForeignKey(d => d.TzYrapholojist)
                    .HasConstraintName("FK__ToMatch__tzYraph__03F0984C");
            });

            modelBuilder.Entity<Yrapholojist>(entity =>
            {
                entity.HasKey(e => e.TzYrapholojist)
                    .HasName("PK__Yrapholo__B9B24CF97ED8BA77");

                entity.ToTable("Yrapholojist");

                entity.Property(e => e.TzYrapholojist)
                    .HasMaxLength(9)
                    .HasColumnName("tzYrapholojist");

                entity.Property(e => e.Sort)
                    .HasMaxLength(10)
                    .HasColumnName("sort");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
