/*

 * ER/Studio Data Architect SQL Code Generation

 * Project :      unified self service.DM1

 *

 * Date Created : Thursday, December 19, 2024 16:59:18

 * Target DBMS : Microsoft SQL Server 2019

 */



USE master

go

CREATE DATABASE UnifiedSelfServiceDB

go

USE UnifiedSelfServiceDB

go

/* 

 * TABLE: Applicant 

 */



CREATE TABLE Applicant(

    ApplicantId    nvarchar(255)    NOT NULL,

    FirstName      nvarchar(255)    NOT NULL,

    LastName       nvarchar(255)    NOT NULL,

    Gender         nvarchar(50)     NOT NULL,

    Password       nvarchar(255)    NOT NULL,

    Phone          nvarchar(255)    NOT NULL,

    Department     nvarchar(255)    NOT NULL,

    UserId         nvarchar(255)    NOT NULL,

    CONSTRAINT PK_Applicant PRIMARY KEY NONCLUSTERED (ApplicantId)

)



go





IF OBJECT_ID('Applicant') IS NOT NULL

    PRINT '<<< CREATED TABLE Applicant >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE Applicant >>>'

go



/* 

 * TABLE: DeliveryMode 

 */



CREATE TABLE DeliveryMode(

    DeliveryModeId    nvarchar(255)    NOT NULL,

    Mode              nvarchar(255)    NOT NULL,

    CreatedDate       datetime         NOT NULL,

    UpdatedDate       datetime         NOT NULL,

    UpdatedBy         nvarchar(255)    NOT NULL,

    CreatedBy         nvarchar(255)    NOT NULL,

    CONSTRAINT PK_DeliveryMode PRIMARY KEY NONCLUSTERED (DeliveryModeId)

)



go





IF OBJECT_ID('DeliveryMode') IS NOT NULL

    PRINT '<<< CREATED TABLE DeliveryMode >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE DeliveryMode >>>'

go



/* 

 * TABLE: DepartementDeliveryMode 

 */



CREATE TABLE DepartementDeliveryMode(

    DepartmentDeliveryModeId    nvarchar(255)    NOT NULL,

    CreatedBy                   nvarchar(255)    NOT NULL,

    UpdatedBy                   nvarchar(255)    NOT NULL,

    CreatedDate                 datetime         NOT NULL,

    UpdatedDate                 datetime         NOT NULL,

    DepartmentRequestType       nvarchar(255)    NOT NULL,

    DeliveryModeId              nvarchar(255)    NOT NULL,

    CONSTRAINT PK_DepartementDeliveryMode PRIMARY KEY NONCLUSTERED (DepartmentDeliveryModeId)

)



go





IF OBJECT_ID('DepartementDeliveryMode') IS NOT NULL

    PRINT '<<< CREATED TABLE DepartementDeliveryMode >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE DepartementDeliveryMode >>>'

go



/* 

 * TABLE: DepartmentManualPaymentSettings 

 */



CREATE TABLE DepartmentManualPaymentSettings(

    DeliveryManualPaymentSettingsId    nvarchar(255)    NOT NULL,

    PaymentNumber                      nvarchar(255)    NOT NULL,

    CreatedDate                        datetime         NOT NULL,

    UpdatedDate                        datetime         NOT NULL,

    PaymentServiceName                 nvarchar(255)    NOT NULL,

    CreatedBy                          nvarchar(255)    NOT NULL,

    UpdatedBy                          nvarchar(255)    NOT NULL,

    SubscribedDepartmentId             nvarchar(255)    NOT NULL,

    CONSTRAINT PK_DepartmentManualPaymentSettings PRIMARY KEY NONCLUSTERED (DeliveryManualPaymentSettingsId)

)



go





IF OBJECT_ID('DepartmentManualPaymentSettings') IS NOT NULL

    PRINT '<<< CREATED TABLE DepartmentManualPaymentSettings >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE DepartmentManualPaymentSettings >>>'

go



/* 

 * TABLE: DepartmentPaymentType 

 */



CREATE TABLE DepartmentPaymentType(

    DepartmentPaymentTypeId    nvarchar(255)    NOT NULL,

    CreatedDate                datetime         NOT NULL,

    UpdatedDate                datetime         NOT NULL,

    CreatedBy                  nvarchar(255)    NOT NULL,

    UpdatedBy                  nvarchar(255)    NOT NULL,

    PaymentTypeId              nvarchar(255)    NOT NULL,

    CONSTRAINT PK_DepartmentPaymentType PRIMARY KEY NONCLUSTERED (DepartmentPaymentTypeId)

)



go





IF OBJECT_ID('DepartmentPaymentType') IS NOT NULL

    PRINT '<<< CREATED TABLE DepartmentPaymentType >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE DepartmentPaymentType >>>'

go



/* 

 * TABLE: DepartmentRequestType 

 */



CREATE TABLE DepartmentRequestType(

    DepartmentRequestType     nvarchar(255)     NOT NULL,

    AcceptPayment             bit               NOT NULL,

    Amount                    decimal(10, 2)    NOT NULL,

    CreatedDate               datetime          NOT NULL,

    UpdatedDate               datetime          NOT NULL,

    UpdatedBy                 nvarchar(255)     NOT NULL,

    CreatedBy                 nvarchar(255)     NOT NULL,

    SubscribedDepartmentId    nvarchar(255)     NOT NULL,

    RequestTypeId             nvarchar(255)     NOT NULL,

    CONSTRAINT PK_DepartmentRequestType PRIMARY KEY NONCLUSTERED (DepartmentRequestType)

)



go





IF OBJECT_ID('DepartmentRequestType') IS NOT NULL

    PRINT '<<< CREATED TABLE DepartmentRequestType >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE DepartmentRequestType >>>'

go



/* 

 * TABLE: DepartmentSettings 

 */



CREATE TABLE DepartmentSettings(

    DepartmentSettingsId      nvarchar(255)    NOT NULL,

    Color                     nvarchar(255)    NOT NULL,

    Logo                      binary(255)      NOT NULL,

    CreatedDate               datetime         NOT NULL,

    UpdatedDate               datetime         NOT NULL,

    CurrentHOD                nvarchar(255)    NOT NULL,

    ThankYouMessage           nvarchar(255)    NOT NULL,

    Telephone                 nvarchar(255)    NOT NULL,

    Email                     nvarchar(255)    NOT NULL,

    WorkingHours              nvarchar(255)    NOT NULL,

    PortalStatus              bit              NOT NULL,

    PortalStatusMessage       nvarchar(255)    NOT NULL,

    CreatedBy                 nvarchar(255)    NOT NULL,

    UpdatedBy                 nvarchar(255)    NOT NULL,

    SubscribedDepartmentId    nvarchar(255)    NOT NULL,

    CONSTRAINT PK_DepartmentSettings PRIMARY KEY NONCLUSTERED (DepartmentSettingsId)

)



go





IF OBJECT_ID('DepartmentSettings') IS NOT NULL

    PRINT '<<< CREATED TABLE DepartmentSettings >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE DepartmentSettings >>>'

go



/* 

 * TABLE: Internship 

 */



CREATE TABLE Internship(

    InternshipId                nvarchar(255)      NOT NULL,

    Reference                   nvarchar(255)      NOT NULL,

    WrittenDate                 datetime           NOT NULL,

    ReceiverAddress             nvarchar(255)      NOT NULL,

    Salutation                  nvarchar(255)      NOT NULL,

    Title                       nvarchar(255)      NOT NULL,

    CreatedDate                 datetime           NOT NULL,

    UpdatedDate                 datetime           NOT NULL,

    Conetnt                     nvarchar(255)      NOT NULL,

    Subscription                nvarchar(255)      NOT NULL,

    Signature                   nvarchar(255)      NOT NULL,

    WrittenFullName             nvarchar(255)      NOT NULL,

    WriterPosition              nvarchar(255)      NOT NULL,

    AmountToPay                 decimal(38, 2)    NOT NULL,

    AddedDate                   datetime           NOT NULL,

    CreatedBy                   nvarchar(255)      NOT NULL,

    UpdatedBy                   nvarchar(255)      NOT NULL,

    RequestId                   nvarchar(255)      NOT NULL,

    DepartmentDeliveryModeId    nvarchar(255)      NOT NULL,

    DepartmentPaymentTypeId     nvarchar(255)      NOT NULL,

    CONSTRAINT PK_Internship PRIMARY KEY NONCLUSTERED (InternshipId)

)



go





IF OBJECT_ID('Internship') IS NOT NULL

    PRINT '<<< CREATED TABLE Internship >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE Internship >>>'

go



/* 

 * TABLE: Message 

 */



CREATE TABLE Message(

    MessageID                nvarchar(255)    NOT NULL,

    DepartmentEmail          nvarchar(255)    NOT NULL,

    PaymentInvoice           nvarchar(255)    NOT NULL,

    CreatedBy                nvarchar(255)    NOT NULL,

    UpdatedBy                nvarchar(255)    NOT NULL,

    UpdatedDate              datetime         NOT NULL,

    CreatedDate              datetime         NOT NULL,

    UserId                   nvarchar(255)    NOT NULL,

    DepartmentRequestType    nvarchar(255)    NOT NULL,

    CONSTRAINT PK_Message PRIMARY KEY NONCLUSTERED (MessageID)

)



go





IF OBJECT_ID('Message') IS NOT NULL

    PRINT '<<< CREATED TABLE Message >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE Message >>>'

go



/* 

 * TABLE: PaymentType 

 */



CREATE TABLE PaymentType(

    PaymentTypeId    nvarchar(255)    NOT NULL,

    PaymentMode      nvarchar(255)    NOT NULL,

    CreatedDate      datetime         NOT NULL,

    UpdatedDate      datetime         NOT NULL,

    CreatedBy        nvarchar(255)    NOT NULL,

    UpdatedBy        nvarchar(255)    NOT NULL,

    CONSTRAINT PK_PaymentType PRIMARY KEY NONCLUSTERED (PaymentTypeId)

)



go





IF OBJECT_ID('PaymentType') IS NOT NULL

    PRINT '<<< CREATED TABLE PaymentType >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE PaymentType >>>'

go



/* 

 * TABLE: Recommendation 

 */



CREATE TABLE Recommendation(

    RecommendationId            nvarchar(255)     NOT NULL,

    ReceipientAddress           nvarchar(255)     NOT NULL,

    NumberOfRequest             int               NOT NULL,

    PurposeOfRequest            nvarchar(255)     NOT NULL,

    PaymentStatus               nvarchar(255)     NOT NULL,

    AmountPaid                  decimal(10, 2)    NOT NULL,

    CreatedDate                 datetime          NOT NULL,

    UpdatedDate                 datetime          NOT NULL,

    CreatedBy                   nvarchar(255)     NOT NULL,

    UpdatedBy                   nvarchar(255)     NOT NULL,

    DepartmentDeliveryModeId    nvarchar(255)     NOT NULL,

    RequestId                   nvarchar(255)     NOT NULL,

    DepartmentPaymentTypeId     nvarchar(255)     NOT NULL,

    CONSTRAINT PK_Recommendation PRIMARY KEY NONCLUSTERED (RecommendationId)

)



go





IF OBJECT_ID('Recommendation') IS NOT NULL

    PRINT '<<< CREATED TABLE Recommendation >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE Recommendation >>>'

go



/* 

 * TABLE: RecommendationReferee 

 */



CREATE TABLE RecommendationReferee(

    RefereeId      nvarchar(255)    NOT NULL,

    FullName       nvarchar(255)    NOT NULL,

    Email          nvarchar(255)    NOT NULL,

    IsAvailable    bit              NOT NULL,

    IsDeleted      bit              NOT NULL,

    CreatedBy      nvarchar(255)    NOT NULL,

    UpdatedBy      nvarchar(255)    NOT NULL,

    CreatedDate    datetime         NOT NULL,

    UpdatedDate    datetime         NOT NULL,

    CONSTRAINT PK_RecommendationReferee PRIMARY KEY NONCLUSTERED (RefereeId)

)



go





IF OBJECT_ID('RecommendationReferee') IS NOT NULL

    PRINT '<<< CREATED TABLE RecommendationReferee >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE RecommendationReferee >>>'

go



/* 

 * TABLE: Request 

 */



CREATE TABLE Request(

    RequestId                nvarchar(255)    NOT NULL,

    ProcessingStatus         nvarchar(255)    NOT NULL,

    CreatedDate              datetime         NOT NULL,

    UpdatedDate              datetime         NOT NULL,

    IsRejected               bit              NOT NULL,

    CanEditRequest           bit              NOT NULL,

    isDeleted                nvarchar(255)    NOT NULL,

    CreatedBy                nvarchar(255)    NOT NULL,

    UpdatedBy                nvarchar(255)    NOT NULL,

    DepartmentRequestType    nvarchar(255)    NOT NULL,

    ApplicantId              nvarchar(255)    NOT NULL,

    CONSTRAINT PK_Request PRIMARY KEY NONCLUSTERED (RequestId)

)



go





IF OBJECT_ID('Request') IS NOT NULL

    PRINT '<<< CREATED TABLE Request >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE Request >>>'

go



/* 

 * TABLE: RequestedReferee 

 */



CREATE TABLE RequestedReferee(

    RequestedRefereeId    nvarchar(255)    NOT NULL,

    RefereeId             nvarchar(255)    NOT NULL,

    RecommendationId      nvarchar(255)    NOT NULL,

    IsRejected            bit              NOT NULL,

    RejectedDate          datetime         NOT NULL,

    UpdatedBy             nvarchar(255)    NOT NULL,

    CreatedBy             nvarchar(255)    NOT NULL,

    CreatedDate           datetime         NOT NULL,

    UpdatedDate           datetime         NOT NULL,

    CONSTRAINT PK_RequestedReferee PRIMARY KEY NONCLUSTERED (RequestedRefereeId)

)



go





IF OBJECT_ID('RequestedReferee') IS NOT NULL

    PRINT '<<< CREATED TABLE RequestedReferee >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE RequestedReferee >>>'

go



/* 

 * TABLE: RequestTransaction 

 */



CREATE TABLE RequestTransaction(

    RequestTransactionId    nvarchar(255)    NOT NULL,

    PaymentStatus           nvarchar(255)    NOT NULL,

    TransactionId           nvarchar(255)    NOT NULL,

    PaidDate                datetime         NOT NULL,

    CreatedDate             datetime         NOT NULL,

    UpdatedDate             datetime         NOT NULL,

    CreatedBy               nvarchar(255)    NOT NULL,

    UpdatedBy               nvarchar(255)    NOT NULL,

    RequestId               nvarchar(255)    NOT NULL,

    CONSTRAINT PK_RequestTransaction PRIMARY KEY NONCLUSTERED (RequestTransactionId)

)



go





IF OBJECT_ID('RequestTransaction') IS NOT NULL

    PRINT '<<< CREATED TABLE RequestTransaction >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE RequestTransaction >>>'

go



/* 

 * TABLE: RequestType 

 */



CREATE TABLE RequestType(

    RequestTypeId    nvarchar(255)    NOT NULL,

    RoutingtoView    nvarchar(255)    NOT NULL,

    Name             nvarchar(255)    NOT NULL,

    Steps            int              NOT NULL,

    CreatedDate      datetime         NOT NULL,

    UpdatedDate      datetime         NOT NULL,

    CreatedBy        nvarchar(255)    NOT NULL,

    UpdatedBy        nvarchar(255)    NOT NULL,

    CONSTRAINT PK_RequestType PRIMARY KEY NONCLUSTERED (RequestTypeId)

)



go





IF OBJECT_ID('RequestType') IS NOT NULL

    PRINT '<<< CREATED TABLE RequestType >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE RequestType >>>'

go



/* 

 * TABLE: SubscribedDepartment 

 */



CREATE TABLE SubscribedDepartment(

    SubscribedDepartmentId    nvarchar(255)    NOT NULL,

    DepartmentName            nvarchar(255)    NOT NULL,

    CreatedDate               datetime         NOT NULL,

    UpdatedDate               datetime         NOT NULL,

    CreatedBy                 nvarchar(255)    NOT NULL,

    UpdatedBy                 nvarchar(255)    NOT NULL,

    CONSTRAINT PK_SubscribedDepartment PRIMARY KEY NONCLUSTERED (SubscribedDepartmentId)

)



go





IF OBJECT_ID('SubscribedDepartment') IS NOT NULL

    PRINT '<<< CREATED TABLE SubscribedDepartment >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE SubscribedDepartment >>>'

go



/* 

 * TABLE: User 

 */



CREATE TABLE [User](

    UserId       nvarchar(255)    NOT NULL,

    FirstName    nvarchar(255)    NOT NULL,

    LastName     nvarchar(255)    NOT NULL,

    Email        nvarchar(255)    NOT NULL,

    Password     nvarchar(255)    NOT NULL,

    CONSTRAINT PK_User PRIMARY KEY NONCLUSTERED (UserId)

)



go





IF OBJECT_ID('[User]') IS NOT NULL

    PRINT '<<< CREATED TABLE User >>>'

ELSE

    PRINT '<<< FAILED CREATING TABLE User >>>'

go



/* 

 * TABLE: Applicant 

 */



ALTER TABLE Applicant ADD CONSTRAINT FK_User_Applicant 

    FOREIGN KEY (UserId)

    REFERENCES [User](UserId)

go





/* 

 * TABLE: DepartementDeliveryMode 

 */



ALTER TABLE DepartementDeliveryMode ADD CONSTRAINT FK_DeliveryMode_DepartementDeliveryMode 

    FOREIGN KEY (DeliveryModeId)

    REFERENCES DeliveryMode(DeliveryModeId)

go



ALTER TABLE DepartementDeliveryMode ADD CONSTRAINT FK_DepartmentRequestType_DepartementDeliveryMode 

    FOREIGN KEY (DepartmentRequestType)

    REFERENCES DepartmentRequestType(DepartmentRequestType)

go





/* 

 * TABLE: DepartmentManualPaymentSettings 

 */



ALTER TABLE DepartmentManualPaymentSettings ADD CONSTRAINT FK_SubscribedDepartment_DepartmentManualPaymentSettings 

    FOREIGN KEY (SubscribedDepartmentId)

    REFERENCES SubscribedDepartment(SubscribedDepartmentId)

go





/* 

 * TABLE: DepartmentPaymentType 

 */



ALTER TABLE DepartmentPaymentType ADD CONSTRAINT FK_PaymentType_DepartmentPaymentType 

    FOREIGN KEY (PaymentTypeId)

    REFERENCES PaymentType(PaymentTypeId)

go





/* 

 * TABLE: DepartmentRequestType 

 */



ALTER TABLE DepartmentRequestType ADD CONSTRAINT FK_RequestType_DepartmentRequestType 

    FOREIGN KEY (RequestTypeId)

    REFERENCES RequestType(RequestTypeId)

go



ALTER TABLE DepartmentRequestType ADD CONSTRAINT FK_SubscribedDepartment_DepartmentRequestType 

    FOREIGN KEY (SubscribedDepartmentId)

    REFERENCES SubscribedDepartment(SubscribedDepartmentId)

go





/* 

 * TABLE: DepartmentSettings 

 */



ALTER TABLE DepartmentSettings ADD CONSTRAINT FK_SubscribedDepartment_DepartmentSettings 

    FOREIGN KEY (SubscribedDepartmentId)

    REFERENCES SubscribedDepartment(SubscribedDepartmentId)

go





/* 

 * TABLE: Internship 

 */



ALTER TABLE Internship ADD CONSTRAINT FK_DepartementDeliveryMode_Internship 

    FOREIGN KEY (DepartmentDeliveryModeId)

    REFERENCES DepartementDeliveryMode(DepartmentDeliveryModeId)

go



ALTER TABLE Internship ADD CONSTRAINT FK_DepartmentPaymentType_Internship 

    FOREIGN KEY (DepartmentPaymentTypeId)

    REFERENCES DepartmentPaymentType(DepartmentPaymentTypeId)

go



ALTER TABLE Internship ADD CONSTRAINT FK_Request_Internship 

    FOREIGN KEY (RequestId)

    REFERENCES Request(RequestId)

go





/* 

 * TABLE: Message 

 */



ALTER TABLE Message ADD CONSTRAINT FK_DepartmentRequestType_Message 

    FOREIGN KEY (DepartmentRequestType)

    REFERENCES DepartmentRequestType(DepartmentRequestType)

go



ALTER TABLE Message ADD CONSTRAINT FK_User_Message 

    FOREIGN KEY (UserId)

    REFERENCES [User](UserId)

go





/* 

 * TABLE: Recommendation 

 */



ALTER TABLE Recommendation ADD CONSTRAINT FK_DepartementDeliveryMode_Recommendation 

    FOREIGN KEY (DepartmentDeliveryModeId)

    REFERENCES DepartementDeliveryMode(DepartmentDeliveryModeId)

go



ALTER TABLE Recommendation ADD CONSTRAINT FK_DepartmentPaymentType_Recommendation 

    FOREIGN KEY (DepartmentPaymentTypeId)

    REFERENCES DepartmentPaymentType(DepartmentPaymentTypeId)

go



ALTER TABLE Recommendation ADD CONSTRAINT FK_Request_Recommendation 

    FOREIGN KEY (RequestId)

    REFERENCES Request(RequestId)

go





/* 

 * TABLE: Request 

 */



ALTER TABLE Request ADD CONSTRAINT FK_Applicant_Request 

    FOREIGN KEY (ApplicantId)

    REFERENCES Applicant(ApplicantId)

go



ALTER TABLE Request ADD CONSTRAINT FK_DepartmentRequestType_Requ14 

    FOREIGN KEY (DepartmentRequestType)

    REFERENCES DepartmentRequestType(DepartmentRequestType)

go



ALTER TABLE Request ADD CONSTRAINT FK_DepartmentRequestType_Request 

    FOREIGN KEY (DepartmentRequestType)

    REFERENCES DepartmentRequestType(DepartmentRequestType)

go





/* 

 * TABLE: RequestedReferee 

 */



ALTER TABLE RequestedReferee ADD CONSTRAINT FK_Recommendation_RequestedReferee 

    FOREIGN KEY (RecommendationId)

    REFERENCES Recommendation(RecommendationId)

go



ALTER TABLE RequestedReferee ADD CONSTRAINT FK_RecommendationReferee_RequestedReferee 

    FOREIGN KEY (RefereeId)

    REFERENCES RecommendationReferee(RefereeId)

go





/* 

 * TABLE: RequestTransaction 

 */



ALTER TABLE RequestTransaction ADD CONSTRAINT FK_Request_RequestTransaction 

    FOREIGN KEY (RequestId)

    REFERENCES Request(RequestId)

go





