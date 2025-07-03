using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OtherNames = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IndexNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CountryOfResidence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsProfileVerified = table.Column<bool>(type: "bit", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMode",
                columns: table => new
                {
                    DeliveryModeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Mode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMode", x => x.DeliveryModeId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyId = table.Column<int>(type: "int", maxLength: 255, nullable: true),
                    CollegeId = table.Column<int>(type: "int", maxLength: 255, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DepartmentHead = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneExt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationCard",
                columns: table => new
                {
                    IdentificationCardId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    IdentificationCardType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IdentificationCardNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IdentificationCardFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationCard", x => x.IdentificationCardId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammeRead",
                columns: table => new
                {
                    ProgrammeReadId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    FullNameOnCertificate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StudentNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IndexNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProgrammeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProgrammeId = table.Column<int>(type: "int", nullable: true),
                    AdmissionYear = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GraduationYear = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ThesisTopic = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GraduateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeRead", x => x.ProgrammeReadId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "RequestedReferees",
                columns: table => new
                {
                    RequestedRefereeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefereeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecommendationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    RejectedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedReferees", x => x.RequestedRefereeId);
                });

            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    RequestTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    RoutingtoView = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Steps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => x.RequestTypeId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentSettings",
                columns: table => new
                {
                    DepartmentSettingsId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Logo = table.Column<byte[]>(type: "binary(255)", fixedLength: true, maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CurrentHOD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Office = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ThankYouMessage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    WorkingHours = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PortalStatus = table.Column<bool>(type: "bit", nullable: false),
                    PortalStatusMessage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSettings", x => x.DepartmentSettingsId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_DepartmentSettings_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentRequestType",
                columns: table => new
                {
                    DepartmentRequestType = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    AcceptPayment = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SISDeptId = table.Column<int>(type: "int", nullable: true),
                    RequestTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentRequestType", x => x.DepartmentRequestType)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_DepartmentRequestType_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_DepartmentRequestType_RequestType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestType",
                        principalColumn: "RequestTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestTypeFormStep",
                columns: table => new
                {
                    RequestTypeFormStepId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    RequestTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypeFormStep", x => x.RequestTypeFormStepId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_RequestTypeFormStep_RequestType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestType",
                        principalColumn: "RequestTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentDeliveryMode",
                columns: table => new
                {
                    DepartmentDeliveryModeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DepartmentRequestTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true),
                    DeliveryModeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentDeliveryMode", x => x.DepartmentDeliveryModeId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_DeliveryMode_DepartmentDeliveryMode",
                        column: x => x.DeliveryModeId,
                        principalTable: "DeliveryMode",
                        principalColumn: "DeliveryModeId");
                    table.ForeignKey(
                        name: "FK_DepartmentRequestType_DepartmentDeliveryMode",
                        column: x => x.DepartmentRequestTypeId,
                        principalTable: "DepartmentRequestType",
                        principalColumn: "DepartmentRequestType");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentRequestPaymentChannel",
                columns: table => new
                {
                    DepartmentRequestPaymentChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentRequestTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true),
                    PaymentChannelId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentRequestPaymentChannel", x => x.DepartmentRequestPaymentChannelId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_DepartmentRequestPaymentChannel_DepartmentRequestType_DepartmentRequestTypeId",
                        column: x => x.DepartmentRequestTypeId,
                        principalTable: "DepartmentRequestType",
                        principalColumn: "DepartmentRequestType");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageID = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    DepartmentEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PaymentInvoice = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DepartmentRequestTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Message_DepartmentRequestType_DepartmentRequestTypeId",
                        column: x => x.DepartmentRequestTypeId,
                        principalTable: "DepartmentRequestType",
                        principalColumn: "DepartmentRequestType");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscribedDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NotificationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotficationLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentRequestTypeNavigationDepartmentRequestTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notification_DepartmentRequestType_DepartmentRequestTypeNavigationDepartmentRequestTypeId",
                        column: x => x.DepartmentRequestTypeNavigationDepartmentRequestTypeId,
                        principalTable: "DepartmentRequestType",
                        principalColumn: "DepartmentRequestType");
                    table.ForeignKey(
                        name: "FK_Notification_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId");
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    CanEditRequest = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DepartmentRequestTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_DepartmentRequestType_Requ14",
                        column: x => x.DepartmentRequestTypeId,
                        principalTable: "DepartmentRequestType",
                        principalColumn: "DepartmentRequestType");
                });

            migrationBuilder.CreateTable(
                name: "FormFields",
                columns: table => new
                {
                    FormFieldsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestTypeFormStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    InputType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Placeholder = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Width = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FieldTips = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFields", x => x.FormFieldsId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_FormFields_RequestTypeFormStep_RequestTypeFormStepId",
                        column: x => x.RequestTypeFormStepId,
                        principalTable: "RequestTypeFormStep",
                        principalColumn: "RequestTypeFormStepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestTransaction",
                columns: table => new
                {
                    RequestTransactionId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProcessingStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TransactionPaymentRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryModeOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgrammeOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTransaction", x => x.RequestTransactionId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Request_RequestTransaction",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormSelectOptions",
                columns: table => new
                {
                    FormSelectOptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormFieldsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSelectOptions", x => x.FormSelectOptionsId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_FormSelectOptions_FormFields_FormFieldsId",
                        column: x => x.FormFieldsId,
                        principalTable: "FormFields",
                        principalColumn: "FormFieldsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDeliveryMode_DeliveryModeId",
                table: "DepartmentDeliveryMode",
                column: "DeliveryModeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDeliveryMode_DepartmentRequestTypeId",
                table: "DepartmentDeliveryMode",
                column: "DepartmentRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRequestPaymentChannel_DepartmentRequestTypeId",
                table: "DepartmentRequestPaymentChannel",
                column: "DepartmentRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRequestType_DepartmentId",
                table: "DepartmentRequestType",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRequestType_RequestTypeId",
                table: "DepartmentRequestType",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSettings_DepartmentId",
                table: "DepartmentSettings",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFields_RequestTypeFormStepId",
                table: "FormFields",
                column: "RequestTypeFormStepId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSelectOptions_FormFieldsId",
                table: "FormSelectOptions",
                column: "FormFieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_DepartmentRequestTypeId",
                table: "Message",
                column: "DepartmentRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_DepartmentId",
                table: "Notification",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_DepartmentRequestTypeNavigationDepartmentRequestTypeId",
                table: "Notification",
                column: "DepartmentRequestTypeNavigationDepartmentRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_DepartmentRequestTypeId",
                table: "Request",
                column: "DepartmentRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTransaction_RequestId",
                table: "RequestTransaction",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTypeFormStep_RequestTypeId",
                table: "RequestTypeFormStep",
                column: "RequestTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DepartmentDeliveryMode");

            migrationBuilder.DropTable(
                name: "DepartmentRequestPaymentChannel");

            migrationBuilder.DropTable(
                name: "DepartmentSettings");

            migrationBuilder.DropTable(
                name: "FormSelectOptions");

            migrationBuilder.DropTable(
                name: "IdentificationCard");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ProgrammeRead");

            migrationBuilder.DropTable(
                name: "RequestedReferees");

            migrationBuilder.DropTable(
                name: "RequestTransaction");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DeliveryMode");

            migrationBuilder.DropTable(
                name: "FormFields");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "RequestTypeFormStep");

            migrationBuilder.DropTable(
                name: "DepartmentRequestType");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "RequestType");
        }
    }
}
