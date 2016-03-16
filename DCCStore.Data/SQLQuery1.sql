
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/16/2016 17:57:15
-- Generated from EDMX file: C:\Users\allan.oliveira\Documents\Visual Studio 2013\Projects\DCCStore\DCCStore.Data\DCCStoreDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DCCScoreDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_AlunoAval]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Avaliacoes] DROP CONSTRAINT [fk_AlunoAval];
GO
IF OBJECT_ID(N'[dbo].[fk_CursoAluno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alunos] DROP CONSTRAINT [fk_CursoAluno];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartamentosProfessores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Professores] DROP CONSTRAINT [FK_DepartamentosProfessores];
GO
IF OBJECT_ID(N'[dbo].[fk_DepCurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Curso] DROP CONSTRAINT [fk_DepCurso];
GO
IF OBJECT_ID(N'[dbo].[fk_Prof_ProfDisc]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfessorDisciplina] DROP CONSTRAINT [fk_Prof_ProfDisc];
GO
IF OBJECT_ID(N'[dbo].[fk_ProfDiscAval]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Avaliacoes] DROP CONSTRAINT [fk_ProfDiscAval];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfessorDisciplinaDisciplinas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfessorDisciplina] DROP CONSTRAINT [FK_ProfessorDisciplinaDisciplinas];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Alunos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alunos];
GO
IF OBJECT_ID(N'[dbo].[Avaliacoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Avaliacoes];
GO
IF OBJECT_ID(N'[dbo].[Curso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Curso];
GO
IF OBJECT_ID(N'[dbo].[Departamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departamentos];
GO
IF OBJECT_ID(N'[dbo].[Disciplinas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Disciplinas];
GO
IF OBJECT_ID(N'[dbo].[ProfessorDisciplina]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfessorDisciplina];
GO
IF OBJECT_ID(N'[dbo].[Professores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Professores];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Alunos'
CREATE TABLE [dbo].[Alunos] (
    [Id] int  NOT NULL,
    [CursoId] int  NOT NULL,
    [LoginDcc] varchar(255)  NOT NULL,
    [Matriculado] bit  NOT NULL
);
GO

-- Creating table 'Avaliacoes'
CREATE TABLE [dbo].[Avaliacoes] (
    [Id] int  NOT NULL,
    [AlunoId] int  NOT NULL,
    [ProfessorDisciplinaId] int  NOT NULL,
    [Review] varchar(1024)  NOT NULL,
    [NotaGeral] int  NOT NULL,
    [Assiduidade] int  NOT NULL,
    [Didatica] int  NOT NULL,
    [Cobranca] int  NOT NULL,
    [Dominio] int  NOT NULL
);
GO

-- Creating table 'Cursoes'
CREATE TABLE [dbo].[Cursoes] (
    [Id] int  NOT NULL,
    [Nome] varchar(255)  NOT NULL,
    [DepartamentoId] int  NOT NULL
);
GO

-- Creating table 'Departamentos'
CREATE TABLE [dbo].[Departamentos] (
    [Id] int  NOT NULL,
    [Nome] varchar(255)  NOT NULL,
    [Sigla] varchar(4)  NOT NULL
);
GO

-- Creating table 'Disciplinas'
CREATE TABLE [dbo].[Disciplinas] (
    [Id] int  NOT NULL,
    [Nome] varchar(255)  NULL
);
GO

-- Creating table 'ProfessorDisciplinas'
CREATE TABLE [dbo].[ProfessorDisciplinas] (
    [Id] int  NOT NULL,
    [DisciplinaId] int  NOT NULL,
    [ProfessorId] int  NOT NULL
);
GO

-- Creating table 'Professores'
CREATE TABLE [dbo].[Professores] (
    [Id] int  NOT NULL,
    [Nome] varchar(255)  NULL,
    [DepartamentoId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Alunos'
ALTER TABLE [dbo].[Alunos]
ADD CONSTRAINT [PK_Alunos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Avaliacoes'
ALTER TABLE [dbo].[Avaliacoes]
ADD CONSTRAINT [PK_Avaliacoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cursoes'
ALTER TABLE [dbo].[Cursoes]
ADD CONSTRAINT [PK_Cursoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Departamentos'
ALTER TABLE [dbo].[Departamentos]
ADD CONSTRAINT [PK_Departamentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Disciplinas'
ALTER TABLE [dbo].[Disciplinas]
ADD CONSTRAINT [PK_Disciplinas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProfessorDisciplinas'
ALTER TABLE [dbo].[ProfessorDisciplinas]
ADD CONSTRAINT [PK_ProfessorDisciplinas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Professores'
ALTER TABLE [dbo].[Professores]
ADD CONSTRAINT [PK_Professores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AlunoId] in table 'Avaliacoes'
ALTER TABLE [dbo].[Avaliacoes]
ADD CONSTRAINT [fk_AlunoAval]
    FOREIGN KEY ([AlunoId])
    REFERENCES [dbo].[Alunos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_AlunoAval'
CREATE INDEX [IX_fk_AlunoAval]
ON [dbo].[Avaliacoes]
    ([AlunoId]);
GO

-- Creating foreign key on [CursoId] in table 'Alunos'
ALTER TABLE [dbo].[Alunos]
ADD CONSTRAINT [fk_CursoAluno]
    FOREIGN KEY ([CursoId])
    REFERENCES [dbo].[Cursoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_CursoAluno'
CREATE INDEX [IX_fk_CursoAluno]
ON [dbo].[Alunos]
    ([CursoId]);
GO

-- Creating foreign key on [ProfessorDisciplinaId] in table 'Avaliacoes'
ALTER TABLE [dbo].[Avaliacoes]
ADD CONSTRAINT [fk_ProfDiscAval]
    FOREIGN KEY ([ProfessorDisciplinaId])
    REFERENCES [dbo].[ProfessorDisciplinas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_ProfDiscAval'
CREATE INDEX [IX_fk_ProfDiscAval]
ON [dbo].[Avaliacoes]
    ([ProfessorDisciplinaId]);
GO

-- Creating foreign key on [DepartamentoId] in table 'Cursoes'
ALTER TABLE [dbo].[Cursoes]
ADD CONSTRAINT [fk_DepCurso]
    FOREIGN KEY ([DepartamentoId])
    REFERENCES [dbo].[Departamentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_DepCurso'
CREATE INDEX [IX_fk_DepCurso]
ON [dbo].[Cursoes]
    ([DepartamentoId]);
GO

-- Creating foreign key on [DepartamentoId] in table 'Professores'
ALTER TABLE [dbo].[Professores]
ADD CONSTRAINT [FK_DepartamentosProfessores]
    FOREIGN KEY ([DepartamentoId])
    REFERENCES [dbo].[Departamentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartamentosProfessores'
CREATE INDEX [IX_FK_DepartamentosProfessores]
ON [dbo].[Professores]
    ([DepartamentoId]);
GO

-- Creating foreign key on [DisciplinaId] in table 'ProfessorDisciplinas'
ALTER TABLE [dbo].[ProfessorDisciplinas]
ADD CONSTRAINT [FK_ProfessorDisciplinaDisciplinas]
    FOREIGN KEY ([DisciplinaId])
    REFERENCES [dbo].[Disciplinas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfessorDisciplinaDisciplinas'
CREATE INDEX [IX_FK_ProfessorDisciplinaDisciplinas]
ON [dbo].[ProfessorDisciplinas]
    ([DisciplinaId]);
GO

-- Creating foreign key on [ProfessorId] in table 'ProfessorDisciplinas'
ALTER TABLE [dbo].[ProfessorDisciplinas]
ADD CONSTRAINT [fk_Prof_ProfDisc]
    FOREIGN KEY ([ProfessorId])
    REFERENCES [dbo].[Professores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Prof_ProfDisc'
CREATE INDEX [IX_fk_Prof_ProfDisc]
ON [dbo].[ProfessorDisciplinas]
    ([ProfessorId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------