
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/13/2018 19:29:24
-- Generated from EDMX file: C:\Users\Alex\source\repos\AspMvcECommerce2\AspMvcECommerce2.Domain\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AspNetMvcECommerce];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Article_d__artic__30F848ED]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Article_details] DROP CONSTRAINT [FK__Article_d__artic__30F848ED];
GO
IF OBJECT_ID(N'[dbo].[FK__Article_d__brand__31EC6D26]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Article_details] DROP CONSTRAINT [FK__Article_d__brand__31EC6D26];
GO
IF OBJECT_ID(N'[dbo].[FK__Article_d__color__32E0915F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Article_details] DROP CONSTRAINT [FK__Article_d__color__32E0915F];
GO
IF OBJECT_ID(N'[dbo].[FK__Article_d__size___33D4B598]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Article_details] DROP CONSTRAINT [FK__Article_d__size___33D4B598];
GO
IF OBJECT_ID(N'[dbo].[FK__Articles__catego__34C8D9D1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articles] DROP CONSTRAINT [FK__Articles__catego__34C8D9D1];
GO
IF OBJECT_ID(N'[dbo].[FK__Users__role_id__35BCFE0A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK__Users__role_id__35BCFE0A];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Article_details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Article_details];
GO
IF OBJECT_ID(N'[dbo].[Articles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articles];
GO
IF OBJECT_ID(N'[dbo].[Brands]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brands];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Colors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Colors];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Sizes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sizes];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Article_details'
CREATE TABLE [dbo].[Article_details] (
    [id] int IDENTITY(1,1) NOT NULL,
    [article_id] int  NULL,
    [color_id] int  NULL,
    [size_id] int  NULL,
    [brand_id] int  NULL
);
GO

-- Creating table 'Articles'
CREATE TABLE [dbo].[Articles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(25)  NOT NULL,
    [description] nvarchar(255)  NOT NULL,
    [image_url] nvarchar(225)  NULL,
    [image_base64] varchar(max)  NULL,
    [category_id] int  NULL,
    [price] decimal(10,2)  NOT NULL,
    [quantity] int  NOT NULL
);
GO

-- Creating table 'Brands'
CREATE TABLE [dbo].[Brands] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(25)  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(25)  NOT NULL
);
GO

-- Creating table 'Colors'
CREATE TABLE [dbo].[Colors] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(25)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(25)  NOT NULL
);
GO

-- Creating table 'Sizes'
CREATE TABLE [dbo].[Sizes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(25)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [login] nvarchar(25)  NOT NULL,
    [password] nvarchar(225)  NOT NULL,
    [role_id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Article_details'
ALTER TABLE [dbo].[Article_details]
ADD CONSTRAINT [PK_Article_details]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [PK_Articles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Brands'
ALTER TABLE [dbo].[Brands]
ADD CONSTRAINT [PK_Brands]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Colors'
ALTER TABLE [dbo].[Colors]
ADD CONSTRAINT [PK_Colors]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Sizes'
ALTER TABLE [dbo].[Sizes]
ADD CONSTRAINT [PK_Sizes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [article_id] in table 'Article_details'
ALTER TABLE [dbo].[Article_details]
ADD CONSTRAINT [FK__Article_d__artic__30F848ED]
    FOREIGN KEY ([article_id])
    REFERENCES [dbo].[Articles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Article_d__artic__30F848ED'
CREATE INDEX [IX_FK__Article_d__artic__30F848ED]
ON [dbo].[Article_details]
    ([article_id]);
GO

-- Creating foreign key on [brand_id] in table 'Article_details'
ALTER TABLE [dbo].[Article_details]
ADD CONSTRAINT [FK__Article_d__brand__31EC6D26]
    FOREIGN KEY ([brand_id])
    REFERENCES [dbo].[Brands]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Article_d__brand__31EC6D26'
CREATE INDEX [IX_FK__Article_d__brand__31EC6D26]
ON [dbo].[Article_details]
    ([brand_id]);
GO

-- Creating foreign key on [color_id] in table 'Article_details'
ALTER TABLE [dbo].[Article_details]
ADD CONSTRAINT [FK__Article_d__color__32E0915F]
    FOREIGN KEY ([color_id])
    REFERENCES [dbo].[Colors]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Article_d__color__32E0915F'
CREATE INDEX [IX_FK__Article_d__color__32E0915F]
ON [dbo].[Article_details]
    ([color_id]);
GO

-- Creating foreign key on [size_id] in table 'Article_details'
ALTER TABLE [dbo].[Article_details]
ADD CONSTRAINT [FK__Article_d__size___33D4B598]
    FOREIGN KEY ([size_id])
    REFERENCES [dbo].[Sizes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Article_d__size___33D4B598'
CREATE INDEX [IX_FK__Article_d__size___33D4B598]
ON [dbo].[Article_details]
    ([size_id]);
GO

-- Creating foreign key on [category_id] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [FK__Articles__catego__34C8D9D1]
    FOREIGN KEY ([category_id])
    REFERENCES [dbo].[Categories]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Articles__catego__34C8D9D1'
CREATE INDEX [IX_FK__Articles__catego__34C8D9D1]
ON [dbo].[Articles]
    ([category_id]);
GO

-- Creating foreign key on [role_id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK__Users__role_id__35BCFE0A]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[Roles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Users__role_id__35BCFE0A'
CREATE INDEX [IX_FK__Users__role_id__35BCFE0A]
ON [dbo].[Users]
    ([role_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------