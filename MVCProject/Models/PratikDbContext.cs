using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models;

public partial class PratikDbContext : DbContext
{
    public PratikDbContext()
    {
    }

    public PratikDbContext(DbContextOptions<PratikDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=PRATIK\\SQLEXPRESS;Database=PratikDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927C0A483DF59");

            entity.ToTable("Class");

            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("employee");

            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Depart)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPART");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Empid)
                .ValueGeneratedOnAdd()
                .HasColumnName("EMPID");
            entity.Property(e => e.Empname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMPNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GENDER");
            entity.Property(e => e.Salary).HasColumnName("SALARY");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exam__297521C7780F82EE");

            entity.ToTable("Exam");

            entity.Property(e => e.RollNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Exams)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Exam__ClassId__5EBF139D");

            entity.HasOne(d => d.Subject).WithMany(p => p.Exams)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Exam__SubjectId__5FB337D6");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK__Expense__1445CFD3BD67E801");

            entity.ToTable("Expense");

            entity.HasOne(d => d.Class).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Expense__ClassId__628FA481");

            entity.HasOne(d => d.Subject).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Expense__Subject__6383C8BA");
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.FeeId).HasName("PK__Fees__B387B22987C6FA95");

            entity.HasOne(d => d.Class).WithMany(p => p.Fees)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Fees__ClassId__5BE2A6F2");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99751D5FB5");

            entity.ToTable("Student");

            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RollNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Student__ClassId__4E88ABD4");
        });

        modelBuilder.Entity<StudentAttendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentA__3214EC07EBED8E46");

            entity.ToTable("StudentAttendance");

            entity.Property(e => e.RollNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.StudentAttendances)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__StudentAt__Class__5812160E");

            entity.HasOne(d => d.Subject).WithMany(p => p.StudentAttendances)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__StudentAt__Subje__59063A47");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subject__AC1BA3A8C5C09118");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Subject__ClassId__4BAC3F29");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF259643EAAF8DC");

            entity.ToTable("Teacher");

            entity.Property(e => e.Adderss).IsUnicode(false);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TeacherSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeacherS__3214EC070104F03A");

            entity.ToTable("TeacherSubject");

            entity.HasOne(d => d.Class).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__TeacherSu__Class__534D60F1");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__TeacherSu__Subje__5441852A");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__TeacherSu__Teach__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
