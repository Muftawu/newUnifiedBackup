using System;
using Shared.Domain.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shared.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<DeliveryMode> DeliveryModes { get; set; }

    public DbSet<FormFields> FormFields { get; set; }
    public DbSet<RequestTypeFormStep> RequestTypeFormStep { get; set; }

    public DbSet<FormSelectOptions> FormSelectOptions { get; set; }

    public DbSet<DepartmentDeliveryMode> DepartmentDeliveryModes { get; set; }

    public DbSet<DepartmentRequestPaymentChannel> DepartmentRequestPaymentChannel { get; set; }

    public DbSet<DepartmentRequestType> DepartmentRequestTypes { get; set; }

    public DbSet<DepartmentSetting> DepartmentSettings { get; set; }

    public DbSet<Message> Messages { get; set; }

    public DbSet<Request> Requests { get; set; }

    public DbSet<RequestTransaction> RequestTransactions { get; set; }

    public DbSet<RequestType> RequestTypes { get; set; }

    public DbSet<RequestedReferee> RequestedReferees { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<IdentificationCard> IdentificationCards { get; set; }

    public DbSet<ProgrammeRead> ProgrammeReads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<DeliveryMode>(entity =>
        {
            entity.HasKey(e => e.DeliveryModeId).IsClustered(false);

            entity.ToTable("DeliveryMode");

            entity.Property(e => e.DeliveryModeId).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Mode).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DepartmentDeliveryMode>(entity =>
        {
            entity.HasKey(e => e.DepartmentDeliveryModeId).IsClustered(false);

            entity.ToTable("DepartmentDeliveryMode");

            entity.Property(e => e.DepartmentDeliveryModeId).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeliveryModeId).HasMaxLength(255);
            entity.Property(e => e.DepartmentRequestTypeId).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.DeliveryMode).WithMany(p => p.DepartmentDeliveryModes)
                .HasForeignKey(d => d.DeliveryModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeliveryMode_DepartmentDeliveryMode");

            entity.HasOne(d => d.DepartmentRequestTypeNavigation).WithMany(p => p.DepartmentDeliveryModes)
                .HasForeignKey(d => d.DepartmentRequestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentRequestType_DepartmentDeliveryMode");
        });

        modelBuilder.Entity<DepartmentRequestPaymentChannel>(entity =>
        {
            entity.HasKey(e => e.DepartmentRequestPaymentChannelId).IsClustered(false);

            entity.ToTable("DepartmentRequestPaymentChannel");

            entity.Property(e => e.DepartmentRequestTypeId).HasMaxLength(255);
            entity.Property(e => e.PaymentChannelId);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DepartmentRequestType>(entity =>
        {
            entity.HasKey(e => e.DepartmentRequestTypeId).IsClustered(false);

            entity.ToTable("DepartmentRequestType");

            entity.Property(e => e.DepartmentRequestTypeId)
                .HasMaxLength(255)
                .HasColumnName("DepartmentRequestType");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.RequestTypeId).HasMaxLength(255);
            entity.Property(e => e.SISDeptId);
            entity.Property(e => e.UpdatedBy).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DepartmentSetting>(entity =>
        {
            entity.HasKey(e => e.DepartmentSettingsId).IsClustered(false);

            entity.Property(e => e.DepartmentSettingsId).HasMaxLength(255);
            entity.Property(e => e.Color).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CurrentHod)
                .HasMaxLength(255)
                .HasColumnName("CurrentHOD");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.PortalStatusMessage).HasMaxLength(255);
            entity.Property(e => e.DeptId);
            entity.Property(e => e.Telephone).HasMaxLength(255);
            entity.Property(e => e.Office).HasMaxLength(255);
            entity.Property(e => e.ThankYouMessage).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.WorkingHours).HasMaxLength(255);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).IsClustered(false);

            entity.ToTable("Message");

            entity.Property(e => e.MessageId)
                .HasMaxLength(255)
                .HasColumnName("MessageID");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentEmail).HasMaxLength(255);
            entity.Property(e => e.DepartmentRequestTypeId).HasMaxLength(255);
            entity.Property(e => e.PaymentInvoice).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(255);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).IsClustered(false);

            entity.ToTable("Request");

            entity.Property(e => e.RequestId).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentRequestTypeId).HasMaxLength(255);
            entity.Property(e => e.UserId).HasMaxLength(255);
            entity.Property(e => e.IsDeleted)
                .HasMaxLength(255)
                .HasColumnName("isDeleted");
            entity.Property(e => e.UpdatedBy).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.DepartmentRequestTypeNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.DepartmentRequestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentRequestType_Requ14");
        });

        modelBuilder.Entity<RequestTransaction>(entity =>
        {
            entity.HasKey(e => e.RequestTransactionId).IsClustered(false);

            entity.ToTable("RequestTransaction");

            entity.Property(e => e.RequestTransactionId).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PaidDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentStatus).HasMaxLength(255);
            entity.Property(e => e.ProcessingStatus).HasMaxLength(255);
            entity.Property(e => e.RequestId).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestTransactions)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Request_RequestTransaction");
        });

        modelBuilder.Entity<RequestType>(entity =>
        {
            entity.HasKey(e => e.RequestTypeId).IsClustered(false);

            entity.ToTable("RequestType");

            entity.Property(e => e.RequestTypeId).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.RoutingtoView).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).IsClustered(false);

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId);
            entity.Property(e => e.FacultyId).HasMaxLength(255);
            entity.Property(e => e.CollegeId).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.PhoneExt).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Fax).HasMaxLength(255);
            entity.Property(e => e.Website).HasMaxLength(255);
            entity.Property(e => e.DepartmentHead).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentName).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<IdentificationCard>(entity =>
        {
            entity.HasKey(e => e.IdentificationCardId).IsClustered(false);

            entity.ToTable("IdentificationCard");

            entity.Property(e => e.IdentificationCardId).HasMaxLength(255);
            entity.Property(e => e.IdentificationCardType).HasMaxLength(255);
            entity.Property(e => e.IdentificationCardNumber).HasMaxLength(255);
            entity.Property(e => e.IdentificationCardFile).HasColumnType("varbinary(max)");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
        });

        modelBuilder.Entity<ProgrammeRead>(entity =>
        {
            entity.HasKey(e => e.ProgrammeReadId).IsClustered(false);

            entity.ToTable("ProgrammeRead");

            entity.Property(e => e.ProgrammeReadId).HasMaxLength(255);
            entity.Property(e => e.FullNameOnCertificate).HasMaxLength(255);
            entity.Property(e => e.StudentNumber).HasMaxLength(255);
            entity.Property(e => e.IndexNumber).HasMaxLength(255);
            entity.Property(e => e.ProgrammeName).HasMaxLength(255);
            entity.Property(e => e.ProgrammeId);
            entity.Property(e => e.AdmissionYear).HasMaxLength(255);
            entity.Property(e => e.GraduationYear).HasMaxLength(255);
            entity.Property(e => e.ThesisTopic).HasMaxLength(255);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("User");

            entity.Property(e => e.Id).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Surname).HasMaxLength(255);
            entity.Property(e => e.OtherNames).HasMaxLength(255);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.ReferenceNumber).HasMaxLength(255);
            entity.Property(e => e.IndexNumber).HasMaxLength(255);
            entity.Property(e => e.CountryOfResidence).HasMaxLength(255);
            entity.Property(e => e.PassportPicture).HasColumnType("varbinary(max)");
        });




         modelBuilder.Entity<RequestTypeFormStep>(entity =>
        {
            entity.HasKey(e => e.RequestTypeFormStepId).IsClustered(false);

            entity.ToTable("RequestTypeFormStep");

            entity.Property(e => e.RequestTypeFormStepId).HasMaxLength(255);
            
        });


        modelBuilder.Entity<FormFields>(entity =>
{
    entity.HasKey(e => e.FormFieldsId).IsClustered(false);
    entity.ToTable("FormFields");

    // Properties configuration
    entity.Property(e => e.FormFieldsId)
        .HasColumnName("FormFieldsId");


    entity.Property(e => e.Label)
        .IsRequired()
        .HasMaxLength(255);

    entity.Property(e => e.InputType)
        .IsRequired()
        .HasConversion<string>();

    entity.Property(e => e.IsRequired)
        .IsRequired();

    entity.Property(e => e.Placeholder)
        .HasMaxLength(255);

    entity.Property(e => e.Width)
        .HasMaxLength(50);

    entity.Property(e => e.FieldTips)
        .HasMaxLength(500);

    entity.Property(e => e.CreatedDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

    entity.Property(e => e.UpdatedDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

    entity.Property(e => e.CreatedBy)
        .HasMaxLength(255);

    entity.Property(e => e.UpdatedBy)
        .HasMaxLength(255);

   
});

modelBuilder.Entity<FormSelectOptions>(entity =>
{
    entity.HasKey(e => e.FormSelectOptionsId).IsClustered(false);
    entity.ToTable("FormSelectOptions");

    // Properties configuration
    entity.Property(e => e.FormSelectOptionsId)
        .HasColumnName("FormSelectOptionsId");

    entity.Property(e => e.FormFieldsId)
        .HasColumnName("FormFieldsId");

    entity.Property(e => e.OptionName)
        .HasMaxLength(255);

    entity.Property(e => e.CreatedDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

    entity.Property(e => e.UpdatedDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

    entity.Property(e => e.CreatedBy)
        .HasMaxLength(255);

    entity.Property(e => e.UpdatedBy)
        .HasMaxLength(255);

});

        base.OnModelCreating(modelBuilder);
    }

}
