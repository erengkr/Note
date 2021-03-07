using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Note.Core;

#nullable disable

namespace Note.Model
{
    public partial class NotesContext : DbContext
    {
        public NotesContext()
        {
        }

        public NotesContext(DbContextOptions<NotesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblNotess> TblNotesses { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:notesunucu.database.windows.net,1433;Initial Catalog=Notes;Persist Security Info=False;User ID=eren;Password=Pulsarcay291;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

           
            modelBuilder.Entity<TblNotess>(entity =>
            {
                entity.ToTable("tbl_notess");


                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.InsertDate)
                    .HasColumnType("date")
                    .HasColumnName("insert_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NoteContent).IsRequired();

                entity.Property(e => e.UpdateDate)
                    .HasMaxLength(10)
                    .HasColumnName("update_date")
                    .IsFixedLength(true);
            });

            
            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tbl_user");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
