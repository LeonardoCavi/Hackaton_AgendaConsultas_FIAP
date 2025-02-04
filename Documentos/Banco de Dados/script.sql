USE [HealthMedDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02/08/2024 19:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 02/08/2024 19:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consulta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Inicio] [datetime2](7) NOT NULL,
	[Fim] [datetime2](7) NOT NULL,
	[MedicoId] [int] NOT NULL,
	[PacienteId] [int] NOT NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medico]    Script Date: 02/08/2024 19:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medico](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[CPF] [varchar](11) NOT NULL,
	[NumeroCRM] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Medico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicoCredencial]    Script Date: 02/08/2024 19:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicoCredencial](
	[MedicoId] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
 CONSTRAINT [PK_MedicoCredencial] PRIMARY KEY CLUSTERED 
(
	[MedicoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicoHorarioExpediente]    Script Date: 02/08/2024 19:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicoHorarioExpediente](
	[MedicoId] [int] NOT NULL,
	[TrabalhaDomingo] [bit] NOT NULL,
	[InicioDomingo] [time](7) NOT NULL,
	[FimDomingo] [time](7) NOT NULL,
	[TrabalhaSegunda] [bit] NOT NULL,
	[InicioSegunda] [time](7) NOT NULL,
	[FimSegunda] [time](7) NOT NULL,
	[TrabalhaTerca] [bit] NOT NULL,
	[InicioTerca] [time](7) NOT NULL,
	[FimTerca] [time](7) NOT NULL,
	[TrabalhaQuarta] [bit] NOT NULL,
	[InicioQuarta] [time](7) NOT NULL,
	[FimQuarta] [time](7) NOT NULL,
	[TrabalhaQuinta] [bit] NOT NULL,
	[InicioQuinta] [time](7) NOT NULL,
	[FimQuinta] [time](7) NOT NULL,
	[TrabalhaSexta] [bit] NOT NULL,
	[InicioSexta] [time](7) NOT NULL,
	[FimSexta] [time](7) NOT NULL,
	[TrabalhaSabado] [bit] NOT NULL,
	[InicioSabado] [time](7) NOT NULL,
	[FimSabado] [time](7) NOT NULL,
 CONSTRAINT [PK_MedicoHorarioExpediente] PRIMARY KEY CLUSTERED 
(
	[MedicoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 02/08/2024 19:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[CPF] [varchar](11) NOT NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PacienteCredencial]    Script Date: 02/08/2024 19:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PacienteCredencial](
	[PacienteId] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PacienteCredencial] PRIMARY KEY CLUSTERED 
(
	[PacienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Medico_MedicoId] FOREIGN KEY([MedicoId])
REFERENCES [dbo].[Medico] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Medico_MedicoId]
GO
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Paciente_PacienteId] FOREIGN KEY([PacienteId])
REFERENCES [dbo].[Paciente] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Paciente_PacienteId]
GO
ALTER TABLE [dbo].[MedicoCredencial]  WITH CHECK ADD  CONSTRAINT [FK_MedicoCredencial_Medico_MedicoId] FOREIGN KEY([MedicoId])
REFERENCES [dbo].[Medico] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicoCredencial] CHECK CONSTRAINT [FK_MedicoCredencial_Medico_MedicoId]
GO
ALTER TABLE [dbo].[MedicoHorarioExpediente]  WITH CHECK ADD  CONSTRAINT [FK_MedicoHorarioExpediente_Medico_MedicoId] FOREIGN KEY([MedicoId])
REFERENCES [dbo].[Medico] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicoHorarioExpediente] CHECK CONSTRAINT [FK_MedicoHorarioExpediente_Medico_MedicoId]
GO
ALTER TABLE [dbo].[PacienteCredencial]  WITH CHECK ADD  CONSTRAINT [FK_PacienteCredencial_Paciente_PacienteId] FOREIGN KEY([PacienteId])
REFERENCES [dbo].[Paciente] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PacienteCredencial] CHECK CONSTRAINT [FK_PacienteCredencial_Paciente_PacienteId]
GO
