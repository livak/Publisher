
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/26/2013 23:07:24
-- Generated from EDMX file: C:\Users\Jure\Documents\GitHub\Publisher\proba\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PowerLogDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AlarmConfigAlarmLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AlarmLogSet] DROP CONSTRAINT [FK_AlarmConfigAlarmLog];
GO
IF OBJECT_ID(N'[dbo].[FK_AlarmConfigAlarmTerminal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AlarmTerminalSet] DROP CONSTRAINT [FK_AlarmConfigAlarmTerminal];
GO
IF OBJECT_ID(N'[dbo].[FK_VariableAlarmConfig]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AlarmConfigSet] DROP CONSTRAINT [FK_VariableAlarmConfig];
GO
IF OBJECT_ID(N'[dbo].[FK_VariableDoubleLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DoubleLogSet] DROP CONSTRAINT [FK_VariableDoubleLog];
GO
IF OBJECT_ID(N'[dbo].[FK_VariableSingleHistogram]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SingleHistogramSet] DROP CONSTRAINT [FK_VariableSingleHistogram];
GO
IF OBJECT_ID(N'[dbo].[FK_VariableSingleLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SingleLogSet] DROP CONSTRAINT [FK_VariableSingleLog];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AlarmConfigSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlarmConfigSet];
GO
IF OBJECT_ID(N'[dbo].[AlarmLogSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlarmLogSet];
GO
IF OBJECT_ID(N'[dbo].[AlarmTerminalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlarmTerminalSet];
GO
IF OBJECT_ID(N'[dbo].[DoubleLogSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DoubleLogSet];
GO
IF OBJECT_ID(N'[dbo].[SingleHistogramSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SingleHistogramSet];
GO
IF OBJECT_ID(N'[dbo].[SingleLogSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SingleLogSet];
GO
IF OBJECT_ID(N'[dbo].[VariableSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VariableSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AlarmConfigSet'
CREATE TABLE [dbo].[AlarmConfigSet] (
    [Id] int  NOT NULL,
    [HIHI_Enable] bit  NOT NULL,
    [HIHI_Name] nvarchar(max)  NOT NULL,
    [HIHI_LevelChange] float  NOT NULL,
    [HIHI_Delay] int  NOT NULL,
    [HI_Enable] bit  NOT NULL,
    [HI_Name] nvarchar(max)  NOT NULL,
    [HI_LevelChange] float  NOT NULL,
    [HI_Delay] int  NOT NULL,
    [LO_Enable] bit  NOT NULL,
    [LO_Name] nvarchar(max)  NOT NULL,
    [LO_LevelChange] float  NOT NULL,
    [LO_Delay] int  NOT NULL,
    [LOLO_Enabled] bit  NOT NULL,
    [LOLO_Name] nvarchar(max)  NOT NULL,
    [LOLO_LevelChange] float  NOT NULL,
    [LOLO_Delay] int  NOT NULL,
    [Enabled] bit  NOT NULL,
    [Location] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AlarmLogSet'
CREATE TABLE [dbo].[AlarmLogSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AlarmLevelName] nvarchar(max)  NOT NULL,
    [Action] nvarchar(max)  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [AlarmConfigId] int  NOT NULL,
    [CurrentValue] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AlarmTerminalSet'
CREATE TABLE [dbo].[AlarmTerminalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Active] bit  NOT NULL,
    [Acknowledged] bit  NOT NULL,
    [AlarmLevelName] nvarchar(max)  NOT NULL,
    [MaxValue] real  NOT NULL,
    [SetTime] datetime  NOT NULL,
    [MaxValueTime] datetime  NOT NULL,
    [DeactivatedTime] datetime  NULL,
    [SetPoint] float  NOT NULL,
    [Priority] int  NOT NULL,
    [AlarmConfig_Id] int  NOT NULL
);
GO

-- Creating table 'DoubleLogSet'
CREATE TABLE [dbo].[DoubleLogSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DoubleValue] float  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [VariableId] int  NOT NULL
);
GO

-- Creating table 'SingleHistogramSet'
CREATE TABLE [dbo].[SingleHistogramSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SingleValue] real  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [VariableId] int  NOT NULL
);
GO

-- Creating table 'SingleLogSet'
CREATE TABLE [dbo].[SingleLogSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SingleValue] real  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [VariableId] int  NOT NULL
);
GO

-- Creating table 'VariableSet'
CREATE TABLE [dbo].[VariableSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [DataLoggingEnabled] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AlarmConfigSet'
ALTER TABLE [dbo].[AlarmConfigSet]
ADD CONSTRAINT [PK_AlarmConfigSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AlarmLogSet'
ALTER TABLE [dbo].[AlarmLogSet]
ADD CONSTRAINT [PK_AlarmLogSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AlarmTerminalSet'
ALTER TABLE [dbo].[AlarmTerminalSet]
ADD CONSTRAINT [PK_AlarmTerminalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DoubleLogSet'
ALTER TABLE [dbo].[DoubleLogSet]
ADD CONSTRAINT [PK_DoubleLogSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SingleHistogramSet'
ALTER TABLE [dbo].[SingleHistogramSet]
ADD CONSTRAINT [PK_SingleHistogramSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SingleLogSet'
ALTER TABLE [dbo].[SingleLogSet]
ADD CONSTRAINT [PK_SingleLogSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VariableSet'
ALTER TABLE [dbo].[VariableSet]
ADD CONSTRAINT [PK_VariableSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AlarmConfigId] in table 'AlarmLogSet'
ALTER TABLE [dbo].[AlarmLogSet]
ADD CONSTRAINT [FK_AlarmConfigAlarmLog]
    FOREIGN KEY ([AlarmConfigId])
    REFERENCES [dbo].[AlarmConfigSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AlarmConfigAlarmLog'
CREATE INDEX [IX_FK_AlarmConfigAlarmLog]
ON [dbo].[AlarmLogSet]
    ([AlarmConfigId]);
GO

-- Creating foreign key on [AlarmConfig_Id] in table 'AlarmTerminalSet'
ALTER TABLE [dbo].[AlarmTerminalSet]
ADD CONSTRAINT [FK_AlarmConfigAlarmTerminal]
    FOREIGN KEY ([AlarmConfig_Id])
    REFERENCES [dbo].[AlarmConfigSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AlarmConfigAlarmTerminal'
CREATE INDEX [IX_FK_AlarmConfigAlarmTerminal]
ON [dbo].[AlarmTerminalSet]
    ([AlarmConfig_Id]);
GO

-- Creating foreign key on [Id] in table 'AlarmConfigSet'
ALTER TABLE [dbo].[AlarmConfigSet]
ADD CONSTRAINT [FK_VariableAlarmConfig]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[VariableSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [VariableId] in table 'DoubleLogSet'
ALTER TABLE [dbo].[DoubleLogSet]
ADD CONSTRAINT [FK_VariableDoubleLog]
    FOREIGN KEY ([VariableId])
    REFERENCES [dbo].[VariableSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VariableDoubleLog'
CREATE INDEX [IX_FK_VariableDoubleLog]
ON [dbo].[DoubleLogSet]
    ([VariableId]);
GO

-- Creating foreign key on [VariableId] in table 'SingleHistogramSet'
ALTER TABLE [dbo].[SingleHistogramSet]
ADD CONSTRAINT [FK_VariableSingleHistogram]
    FOREIGN KEY ([VariableId])
    REFERENCES [dbo].[VariableSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VariableSingleHistogram'
CREATE INDEX [IX_FK_VariableSingleHistogram]
ON [dbo].[SingleHistogramSet]
    ([VariableId]);
GO

-- Creating foreign key on [VariableId] in table 'SingleLogSet'
ALTER TABLE [dbo].[SingleLogSet]
ADD CONSTRAINT [FK_VariableSingleLog]
    FOREIGN KEY ([VariableId])
    REFERENCES [dbo].[VariableSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VariableSingleLog'
CREATE INDEX [IX_FK_VariableSingleLog]
ON [dbo].[SingleLogSet]
    ([VariableId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------