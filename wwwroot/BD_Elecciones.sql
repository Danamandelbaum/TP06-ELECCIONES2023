USE [master]
GO
/****** Object:  Database [BD_Elecciones]    Script Date: 14/7/2023 11:43:03 ******/
CREATE DATABASE [BD_Elecciones]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_Elecciones', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BD_Elecciones.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_Elecciones_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BD_Elecciones_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BD_Elecciones] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_Elecciones].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_Elecciones] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_Elecciones] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_Elecciones] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_Elecciones] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_Elecciones] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_Elecciones] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_Elecciones] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_Elecciones] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_Elecciones] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_Elecciones] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_Elecciones] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_Elecciones] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_Elecciones] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_Elecciones] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_Elecciones] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_Elecciones] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_Elecciones] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_Elecciones] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_Elecciones] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_Elecciones] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_Elecciones] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_Elecciones] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_Elecciones] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_Elecciones] SET  MULTI_USER 
GO
ALTER DATABASE [BD_Elecciones] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_Elecciones] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_Elecciones] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_Elecciones] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_Elecciones] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BD_Elecciones', N'ON'
GO
ALTER DATABASE [BD_Elecciones] SET QUERY_STORE = OFF
GO
USE [BD_Elecciones]
GO
/****** Object:  User [alumno]    Script Date: 14/7/2023 11:43:03 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Candidato]    Script Date: 14/7/2023 11:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidato](
	[idCandidato] [int] IDENTITY(1,1) NOT NULL,
	[idPartido] [int] NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[foto] [text] NOT NULL,
	[postulacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Candidatos] PRIMARY KEY CLUSTERED 
(
	[idCandidato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partido]    Script Date: 14/7/2023 11:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partido](
	[idPartido] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[logo] [text] NOT NULL,
	[sitioWeb] [varchar](50) NOT NULL,
	[fechaFundacion] [date] NOT NULL,
	[cantidadDiputados] [int] NOT NULL,
	[cantidadSenadores] [int] NOT NULL,
 CONSTRAINT [PK_Partidos] PRIMARY KEY CLUSTERED 
(
	[idPartido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Partido] ON 

INSERT [dbo].[Partido] ([idPartido], [nombre], [logo], [sitioWeb], [fechaFundacion], [cantidadDiputados], [cantidadSenadores]) VALUES (1, N'La Libertad Avanza', N'https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/Logo_La_Libertad_Avanza.png/1200px-Logo_La_Libertad_Avanza.png', N'https://lalibertadavanza.com.ar/', CAST(N'2021-07-14' AS Date), 3, 0)
INSERT [dbo].[Partido] ([idPartido], [nombre], [logo], [sitioWeb], [fechaFundacion], [cantidadDiputados], [cantidadSenadores]) VALUES (3, N'Juntos por el Cambio', N'https://upload.wikimedia.org/wikipedia/commons/thumb/f/f1/Juntos-Por-El-Cambio-Logo.svg/2560px-Juntos-Por-El-Cambio-Logo.svg.png', N'https://jxc.com.ar/', CAST(N'2019-06-12' AS Date), 50, 31)
INSERT [dbo].[Partido] ([idPartido], [nombre], [logo], [sitioWeb], [fechaFundacion], [cantidadDiputados], [cantidadSenadores]) VALUES (4, N'Frente de Todos', N'https://upload.wikimedia.org/wikipedia/commons/thumb/c/c4/Frente_de_Todos_logo.svg/2560px-Frente_de_Todos_logo.svg.png', N'https://www.frentedetodos.org/', CAST(N'2019-06-12' AS Date), 118, 33)
SET IDENTITY_INSERT [dbo].[Partido] OFF
GO
ALTER TABLE [dbo].[Candidato]  WITH CHECK ADD  CONSTRAINT [FK_Candidatos_Partidos] FOREIGN KEY([idPartido])
REFERENCES [dbo].[Partido] ([idPartido])
GO
ALTER TABLE [dbo].[Candidato] CHECK CONSTRAINT [FK_Candidatos_Partidos]
GO
USE [master]
GO
ALTER DATABASE [BD_Elecciones] SET  READ_WRITE 
GO
