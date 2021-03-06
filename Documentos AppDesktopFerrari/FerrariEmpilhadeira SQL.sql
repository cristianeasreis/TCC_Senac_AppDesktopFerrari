USE [master]
GO
/****** Object:  Database [FerrariEmpilhadeira]    Script Date: 08/09/2019 04:22:07 ******/
CREATE DATABASE [FerrariEmpilhadeira]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FerrariEmpilhadeira', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FerrariEmpilhadeira.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FerrariEmpilhadeira_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FerrariEmpilhadeira_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FerrariEmpilhadeira] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FerrariEmpilhadeira].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FerrariEmpilhadeira] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET ARITHABORT OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET  MULTI_USER 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FerrariEmpilhadeira] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FerrariEmpilhadeira] SET QUERY_STORE = OFF
GO
USE [FerrariEmpilhadeira]
GO
/****** Object:  Table [dbo].[AgendamentoVisita]    Script Date: 08/09/2019 04:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgendamentoVisita](
	[id_AgendamentoVisita] [int] IDENTITY(1,1) NOT NULL,
	[dt_visita] [datetime] NOT NULL,
	[ds_servico] [varchar](1000) NOT NULL,
	[ds_maquina] [varchar](100) NOT NULL,
	[nm_marca] [varchar](50) NOT NULL,
	[fl_status] [bit] NOT NULL,
	[dt_status] [datetime] NOT NULL,
	[nm_empresa] [varchar](100) NULL,
	[id_usuario] [int] NULL,
	[vl_sevico] [money] NULL,
	[dt_sevico] [datetime] NULL,
 CONSTRAINT [PK_AgendamentoVisita] PRIMARY KEY CLUSTERED 
(
	[id_AgendamentoVisita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 08/09/2019 04:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nm_empresa] [varchar](100) NOT NULL,
	[ds_email] [varchar](100) NOT NULL,
	[num_cnpj] [varchar](100) NULL,
	[num_telefone] [varchar](50) NOT NULL,
	[num_celular] [varchar](50) NOT NULL,
	[ds_endereco] [varchar](100) NOT NULL,
	[ds_numero] [varchar](20) NOT NULL,
	[nm_bairro] [varchar](100) NOT NULL,
	[nm_cidade] [varchar](100) NOT NULL,
	[nm_estado] [varchar](50) NOT NULL,
	[fl_status] [bit] NOT NULL,
	[dt_status] [datetime] NOT NULL,
	[ds_cep] [varchar](10) NULL,
	[ds_complemento] [varchar](20) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estoque]    Script Date: 08/09/2019 04:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estoque](
	[id_Estoque] [int] IDENTITY(1,1) NOT NULL,
	[nm_peca] [varchar](100) NOT NULL,
	[qda_peca] [varchar](100) NOT NULL,
	[vl_peca] [money] NOT NULL,
 CONSTRAINT [PK_Estoque] PRIMARY KEY CLUSTERED 
(
	[id_Estoque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 08/09/2019 04:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[id_tipo_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nm_tipo_usuario] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TipoUsuario] PRIMARY KEY CLUSTERED 
(
	[id_tipo_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/09/2019 04:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nm_usuario] [varchar](100) NOT NULL,
	[num_cpf] [varchar](15) NOT NULL,
	[ds_email] [varchar](100) NOT NULL,
	[ds_senha] [varchar](100) NOT NULL,
	[id_tipo_usuario] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AgendamentoVisita]  WITH CHECK ADD  CONSTRAINT [FK_AgendamentoVisita_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[AgendamentoVisita] CHECK CONSTRAINT [FK_AgendamentoVisita_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoUsuario1] FOREIGN KEY([id_tipo_usuario])
REFERENCES [dbo].[TipoUsuario] ([id_tipo_usuario])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoUsuario1]
GO
USE [master]
GO
ALTER DATABASE [FerrariEmpilhadeira] SET  READ_WRITE 
GO
