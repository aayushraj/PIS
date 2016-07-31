
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/23/2016 23:08:59
-- Generated from EDMX file: G:\SoftBitTech\PersonalInformationSystem\PersonalInformationSystem\PersonalInformationSystem.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PersonalInformationSystem];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_payment_StudentInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payment] DROP CONSTRAINT [FK_payment_StudentInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentCourseDetails_CourseInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourseDetails] DROP CONSTRAINT [FK_StudentCourseDetails_CourseInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentCourseDetails_StudentInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourseDetails] DROP CONSTRAINT [FK_StudentCourseDetails_StudentInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentQualification_StudentClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentQualification] DROP CONSTRAINT [FK_StudentQualification_StudentClass];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentQualification_StudentInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentQualification] DROP CONSTRAINT [FK_StudentQualification_StudentInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentQualification_StudentSubject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentQualification] DROP CONSTRAINT [FK_StudentQualification_StudentSubject];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentReference_StudentInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentReference] DROP CONSTRAINT [FK_StudentReference_StudentInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentSubject_StudentClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentSubject] DROP CONSTRAINT [FK_StudentSubject_StudentClass];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Class]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Class];
GO
IF OBJECT_ID(N'[dbo].[CourseInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseInfo];
GO
IF OBJECT_ID(N'[dbo].[Payment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payment];
GO
IF OBJECT_ID(N'[dbo].[StudentCourseDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentCourseDetails];
GO
IF OBJECT_ID(N'[dbo].[StudentInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentInfo];
GO
IF OBJECT_ID(N'[dbo].[StudentQualification]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentQualification];
GO
IF OBJECT_ID(N'[dbo].[StudentReference]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentReference];
GO
IF OBJECT_ID(N'[dbo].[StudentSubject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentSubject];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Classes'
CREATE TABLE [dbo].[Classes] (
    [ClassId] int IDENTITY(1,1) NOT NULL,
    [ClassName] nvarchar(50)  NULL,
    [CreatedOn] datetime  NULL,
    [CreatedBy] int  NULL,
    [ModifiedBy] int  NULL,
    [ModifiedOn] datetime  NULL,
    [DeletedBy] int  NULL,
    [DeletedOn] datetime  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'CourseInfoes'
CREATE TABLE [dbo].[CourseInfoes] (
    [CourseId] int IDENTITY(1,1) NOT NULL,
    [CourseName] nvarchar(50)  NULL,
    [CourseDesc] varchar(max)  NULL,
    [CourseDuration] decimal(18,0)  NULL,
    [Facilitator] nvarchar(50)  NULL,
    [CourseAmount] decimal(19,4)  NULL,
    [CreatedBy] int  NULL,
    [CreatedOn] datetime  NULL,
    [ModifiedBy] int  NULL,
    [ModifiedOn] datetime  NULL,
    [DeletedBy] int  NULL,
    [DeletedOn] datetime  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [PaymentId] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NULL,
    [PaymentType] nvarchar(50)  NULL,
    [PaidAmount] decimal(18,0)  NULL,
    [DueAmount] decimal(18,0)  NULL,
    [PaidBy] nvarchar(50)  NULL,
    [ReceivedBy] nvarchar(50)  NULL,
    [Remarks] varchar(max)  NULL,
    [CreatedBy] int  NULL,
    [CreatedOn] datetime  NULL,
    [ModifiedBy] int  NULL,
    [Modifiedon] datetime  NULL,
    [DeletedBy] int  NULL,
    [DeletedOn] datetime  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'StudentCourseDetails'
CREATE TABLE [dbo].[StudentCourseDetails] (
    [StudentCourseDetailsId] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [CourseId] int  NOT NULL,
    [EnrolledDate] datetime  NULL,
    [CreatedBy] int  NULL,
    [CreatedOn] datetime  NULL,
    [ModifiedBy] int  NULL,
    [ModifiedOn] datetime  NULL,
    [DeletedBy] int  NULL,
    [DeletedOn] datetime  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'StudentInfoes'
CREATE TABLE [dbo].[StudentInfoes] (
    [StudentId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [MiddleName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [Address] nvarchar(50)  NULL,
    [DateOfBirth] datetime  NULL,
    [City] nvarchar(50)  NULL,
    [Country] nvarchar(50)  NULL,
    [Gender] int  NULL,
    [Email] nvarchar(50)  NULL,
    [ResidenceNo] nvarchar(50)  NULL,
    [MobileNo] nvarchar(50)  NULL,
    [EnrolledDate] datetime  NULL,
    [ComputerLiterate] bit  NULL,
    [CreatedOn] datetime  NULL,
    [CreatedBy] int  NULL,
    [ModifiedBy] int  NULL,
    [ModifiedOn] datetime  NULL,
    [DeletedBy] int  NULL,
    [DeletedOn] datetime  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'StudentQualifications'
CREATE TABLE [dbo].[StudentQualifications] (
    [QualificationId] int IDENTITY(1,1) NOT NULL,
    [ClassId] int  NOT NULL,
    [SubjectId] int  NOT NULL,
    [StudentId] int  NOT NULL,
    [Board] nvarchar(50)  NULL,
    [Percentage] decimal(18,0)  NULL,
    [PassedYear] nvarchar(50)  NULL,
    [Status] bit  NULL,
    [CreatedOn] datetime  NULL,
    [CreatedBy] int  NULL,
    [ModifiedBy] int  NULL,
    [ModifiedOn] datetime  NULL,
    [DeletedBy] int  NULL,
    [DeletedOn] datetime  NULL
);
GO

-- Creating table 'StudentReferences'
CREATE TABLE [dbo].[StudentReferences] (
    [ReferenceId] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [ReferenceThrough] nvarchar(50)  NULL,
    [CreatedOn] datetime  NULL,
    [CreatedBy] int  NULL,
    [ModifiedBy] int  NULL,
    [ModifiedOn] datetime  NULL,
    [DeletedBy] int  NULL,
    [DeletedOn] datetime  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'StudentSubjects'
CREATE TABLE [dbo].[StudentSubjects] (
    [SubjectId] int IDENTITY(1,1) NOT NULL,
    [ClassId] int  NOT NULL,
    [SubjectName] nvarchar(50)  NULL,
    [CreatedOn] datetime  NULL,
    [CreatedBy] int  NULL,
    [ModifiedBy] int  NULL,
    [ModifiedOn] datetime  NULL,
    [DeletedBy] int  NULL,
    [DeletedOn] datetime  NULL,
    [Status] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ClassId] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [PK_Classes]
    PRIMARY KEY CLUSTERED ([ClassId] ASC);
GO

-- Creating primary key on [CourseId] in table 'CourseInfoes'
ALTER TABLE [dbo].[CourseInfoes]
ADD CONSTRAINT [PK_CourseInfoes]
    PRIMARY KEY CLUSTERED ([CourseId] ASC);
GO

-- Creating primary key on [PaymentId] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([PaymentId] ASC);
GO

-- Creating primary key on [StudentCourseDetailsId] in table 'StudentCourseDetails'
ALTER TABLE [dbo].[StudentCourseDetails]
ADD CONSTRAINT [PK_StudentCourseDetails]
    PRIMARY KEY CLUSTERED ([StudentCourseDetailsId] ASC);
GO

-- Creating primary key on [StudentId] in table 'StudentInfoes'
ALTER TABLE [dbo].[StudentInfoes]
ADD CONSTRAINT [PK_StudentInfoes]
    PRIMARY KEY CLUSTERED ([StudentId] ASC);
GO

-- Creating primary key on [QualificationId] in table 'StudentQualifications'
ALTER TABLE [dbo].[StudentQualifications]
ADD CONSTRAINT [PK_StudentQualifications]
    PRIMARY KEY CLUSTERED ([QualificationId] ASC);
GO

-- Creating primary key on [ReferenceId] in table 'StudentReferences'
ALTER TABLE [dbo].[StudentReferences]
ADD CONSTRAINT [PK_StudentReferences]
    PRIMARY KEY CLUSTERED ([ReferenceId] ASC);
GO

-- Creating primary key on [SubjectId] in table 'StudentSubjects'
ALTER TABLE [dbo].[StudentSubjects]
ADD CONSTRAINT [PK_StudentSubjects]
    PRIMARY KEY CLUSTERED ([SubjectId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClassId] in table 'StudentQualifications'
ALTER TABLE [dbo].[StudentQualifications]
ADD CONSTRAINT [FK_StudentQualification_StudentClass]
    FOREIGN KEY ([ClassId])
    REFERENCES [dbo].[Classes]
        ([ClassId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentQualification_StudentClass'
CREATE INDEX [IX_FK_StudentQualification_StudentClass]
ON [dbo].[StudentQualifications]
    ([ClassId]);
GO

-- Creating foreign key on [ClassId] in table 'StudentSubjects'
ALTER TABLE [dbo].[StudentSubjects]
ADD CONSTRAINT [FK_StudentSubject_StudentClass]
    FOREIGN KEY ([ClassId])
    REFERENCES [dbo].[Classes]
        ([ClassId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentSubject_StudentClass'
CREATE INDEX [IX_FK_StudentSubject_StudentClass]
ON [dbo].[StudentSubjects]
    ([ClassId]);
GO

-- Creating foreign key on [CourseId] in table 'StudentCourseDetails'
ALTER TABLE [dbo].[StudentCourseDetails]
ADD CONSTRAINT [FK_StudentCourseDetails_CourseInfo]
    FOREIGN KEY ([CourseId])
    REFERENCES [dbo].[CourseInfoes]
        ([CourseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentCourseDetails_CourseInfo'
CREATE INDEX [IX_FK_StudentCourseDetails_CourseInfo]
ON [dbo].[StudentCourseDetails]
    ([CourseId]);
GO

-- Creating foreign key on [StudentId] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_payment_StudentInfo]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[StudentInfoes]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_payment_StudentInfo'
CREATE INDEX [IX_FK_payment_StudentInfo]
ON [dbo].[Payments]
    ([StudentId]);
GO

-- Creating foreign key on [StudentId] in table 'StudentCourseDetails'
ALTER TABLE [dbo].[StudentCourseDetails]
ADD CONSTRAINT [FK_StudentCourseDetails_StudentInfo]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[StudentInfoes]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentCourseDetails_StudentInfo'
CREATE INDEX [IX_FK_StudentCourseDetails_StudentInfo]
ON [dbo].[StudentCourseDetails]
    ([StudentId]);
GO

-- Creating foreign key on [StudentId] in table 'StudentQualifications'
ALTER TABLE [dbo].[StudentQualifications]
ADD CONSTRAINT [FK_StudentQualification_StudentInfo]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[StudentInfoes]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentQualification_StudentInfo'
CREATE INDEX [IX_FK_StudentQualification_StudentInfo]
ON [dbo].[StudentQualifications]
    ([StudentId]);
GO

-- Creating foreign key on [StudentId] in table 'StudentReferences'
ALTER TABLE [dbo].[StudentReferences]
ADD CONSTRAINT [FK_StudentReference_StudentInfo]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[StudentInfoes]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentReference_StudentInfo'
CREATE INDEX [IX_FK_StudentReference_StudentInfo]
ON [dbo].[StudentReferences]
    ([StudentId]);
GO

-- Creating foreign key on [SubjectId] in table 'StudentQualifications'
ALTER TABLE [dbo].[StudentQualifications]
ADD CONSTRAINT [FK_StudentQualification_StudentSubject]
    FOREIGN KEY ([SubjectId])
    REFERENCES [dbo].[StudentSubjects]
        ([SubjectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentQualification_StudentSubject'
CREATE INDEX [IX_FK_StudentQualification_StudentSubject]
ON [dbo].[StudentQualifications]
    ([SubjectId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------