using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dlluploaderwebapi.Models;

public partial class UploaderdbContext : DbContext
{
    public UploaderdbContext()
    {
    }

    public UploaderdbContext(DbContextOptions<UploaderdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UploadedDll> UploadedDlls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=LAPTOP-1DLLUR0G;database=uploaderdb;Integrated Security=SSPI;persist security info= True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UploadedDll>(entity =>
        {
            entity.ToTable("uploaded_dll");

            entity.Property(e => e.FileName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FileType)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.UploadedDate)
                .HasComputedColumnSql("(getdate())", false)
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
