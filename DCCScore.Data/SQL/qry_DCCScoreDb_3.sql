﻿USE [DCCScoreDb]
GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 03/22/2016 18:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parametros](
	[Chave] [varchar](50) NOT NULL,
	[Valor] [varchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Chave] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Chave] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO

/****** Object:  Table [dbo].[Disciplinas]    Script Date: 03/22/2016 18:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Disciplinas](
	[Id] [int] NOT NULL,
	[Nome] [varchar](255) NULL,
 CONSTRAINT [PK_Disciplinas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 03/22/2016 18:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departamentos](
	[Id] [int] NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Sigla] [varchar](4) NOT NULL,
 CONSTRAINT [PK_Departamentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
INSERT [dbo].[Departamentos] ([Id], [Nome], [Sigla]) VALUES (1, N'Departamento de Ciência da Computação', N'DCC')
INSERT [dbo].[Departamentos] ([Id], [Nome], [Sigla]) VALUES (2, N'Escola de Ciência da Informação', N'ECI')
INSERT [dbo].[Departamentos] ([Id], [Nome], [Sigla]) VALUES (3, N'Departamento de Estatística', N'DEST')
INSERT [dbo].[Departamentos] ([Id], [Nome], [Sigla]) VALUES (4, N'Departamento de Matemática', N'DMAT')
INSERT [dbo].[Departamentos] ([Id], [Nome], [Sigla]) VALUES (5, N'Instituto de Ciências Exatas', N'ICEX')
INSERT [dbo].[Departamentos] ([Id], [Nome], [Sigla]) VALUES (6, N'Departamento de Economia', N'ECN')
INSERT [dbo].[Departamentos] ([Id], [Nome], [Sigla]) VALUES (7, N'Departamento de Ciências Administrativas', N'CAD')
INSERT [dbo].[Departamentos] ([Id], [Nome], [Sigla]) VALUES (8, N'Escola de Engenharia', N'ENG')
/****** Object:  Table [dbo].[Cursos]    Script Date: 03/22/2016 18:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cursos](
	[Id] [int] NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[DepartamentoId] [int] NOT NULL,
 CONSTRAINT [PK_Cursoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
INSERT [dbo].[Cursos] ([Id], [Nome], [DepartamentoId]) VALUES (1, N'Sistemas de Informação', 1)
INSERT [dbo].[Cursos] ([Id], [Nome], [DepartamentoId]) VALUES (2, N'Ciência da Computação', 1)
INSERT [dbo].[Cursos] ([Id], [Nome], [DepartamentoId]) VALUES (3, N'Matemática Computacional', 1)
INSERT [dbo].[Cursos] ([Id], [Nome], [DepartamentoId]) VALUES (4, N'Engenharia de Sistemas', 8)
/****** Object:  Table [dbo].[Professores]    Script Date: 03/22/2016 18:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Professores](
	[Id] [int] NOT NULL,
	[Nome] [varchar](255) NULL,
	[DepartamentoId] [int] NOT NULL,
 CONSTRAINT [PK_Professores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Alunos]    Script Date: 03/22/2016 18:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alunos](
	[Id] [int] NOT NULL,
	[CursoId] [int] NOT NULL,
	[LoginDcc] [varchar](255) NOT NULL,
	[Matriculado] [bit] NOT NULL,
 CONSTRAINT [PK_Alunos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[ProfessorDisciplinas]    Script Date: 03/22/2016 18:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessorDisciplinas](
	[Id] [int] NOT NULL,
	[DisciplinaId] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
 CONSTRAINT [PK_ProfessorDisciplinas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Avaliacoes]    Script Date: 03/22/2016 18:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Avaliacoes](
	[Id] [int] NOT NULL,
	[AlunoId] [int] NOT NULL,
	[ProfessorDisciplinaId] [int] NOT NULL,
	[Review] [varchar](1024) NOT NULL,
	[NotaGeral] [int] NOT NULL,
	[Assiduidade] [int] NOT NULL,
	[Didatica] [int] NOT NULL,
	[Cobranca] [int] NOT NULL,
	[Dominio] [int] NOT NULL,
 CONSTRAINT [PK_Avaliacoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  ForeignKey [fk_CursoAluno]    Script Date: 03/22/2016 18:57:46 ******/
ALTER TABLE [dbo].[Alunos]  WITH CHECK ADD  CONSTRAINT [fk_CursoAluno] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Cursos] ([Id])
GO
ALTER TABLE [dbo].[Alunos] CHECK CONSTRAINT [fk_CursoAluno]
GO
/****** Object:  ForeignKey [fk_AlunoAval]    Script Date: 03/22/2016 18:57:46 ******/
ALTER TABLE [dbo].[Avaliacoes]  WITH CHECK ADD  CONSTRAINT [fk_AlunoAval] FOREIGN KEY([AlunoId])
REFERENCES [dbo].[Alunos] ([Id])
GO
ALTER TABLE [dbo].[Avaliacoes] CHECK CONSTRAINT [fk_AlunoAval]
GO
/****** Object:  ForeignKey [fk_ProfDiscAval]    Script Date: 03/22/2016 18:57:46 ******/
ALTER TABLE [dbo].[Avaliacoes]  WITH CHECK ADD  CONSTRAINT [fk_ProfDiscAval] FOREIGN KEY([ProfessorDisciplinaId])
REFERENCES [dbo].[ProfessorDisciplinas] ([Id])
GO
ALTER TABLE [dbo].[Avaliacoes] CHECK CONSTRAINT [fk_ProfDiscAval]
GO
/****** Object:  ForeignKey [fk_DepCurso]    Script Date: 03/22/2016 18:57:46 ******/
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [fk_DepCurso] FOREIGN KEY([DepartamentoId])
REFERENCES [dbo].[Departamentos] ([Id])
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [fk_DepCurso]
GO
/****** Object:  ForeignKey [fk_Prof_ProfDisc]    Script Date: 03/22/2016 18:57:46 ******/
ALTER TABLE [dbo].[ProfessorDisciplinas]  WITH CHECK ADD  CONSTRAINT [fk_Prof_ProfDisc] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professores] ([Id])
GO
ALTER TABLE [dbo].[ProfessorDisciplinas] CHECK CONSTRAINT [fk_Prof_ProfDisc]
GO
/****** Object:  ForeignKey [FK_ProfessorDisciplinaDisciplinas]    Script Date: 03/22/2016 18:57:46 ******/
ALTER TABLE [dbo].[ProfessorDisciplinas]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorDisciplinaDisciplinas] FOREIGN KEY([DisciplinaId])
REFERENCES [dbo].[Disciplinas] ([Id])
GO
ALTER TABLE [dbo].[ProfessorDisciplinas] CHECK CONSTRAINT [FK_ProfessorDisciplinaDisciplinas]
GO
/****** Object:  ForeignKey [FK_DepartamentosProfessores]    Script Date: 03/22/2016 18:57:46 ******/
ALTER TABLE [dbo].[Professores]  WITH CHECK ADD  CONSTRAINT [FK_DepartamentosProfessores] FOREIGN KEY([DepartamentoId])
REFERENCES [dbo].[Departamentos] ([Id])
GO
ALTER TABLE [dbo].[Professores] CHECK CONSTRAINT [FK_DepartamentosProfessores]
GO
