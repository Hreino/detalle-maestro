USE [master]
GO
/****** Object:  Database [PruebaDetalleMaestro]    Script Date: 1/10/2018 14:37:20 ******/
CREATE DATABASE [PruebaDetalleMaestro]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaDetalleMaestro', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSTANDARD\MSSQL\DATA\PruebaDetalleMaestro.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaDetalleMaestro_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSTANDARD\MSSQL\DATA\PruebaDetalleMaestro_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PruebaDetalleMaestro] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaDetalleMaestro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaDetalleMaestro] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET RECOVERY FULL 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaDetalleMaestro] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PruebaDetalleMaestro] SET QUERY_STORE = OFF
GO
USE [PruebaDetalleMaestro]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [PruebaDetalleMaestro]
GO
/****** Object:  Table [dbo].[DetalleEncabezado]    Script Date: 1/10/2018 14:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleEncabezado](
	[idDetalle] [int] IDENTITY(1,1) NOT NULL,
	[idEncabezado] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Total] [money] NOT NULL,
 CONSTRAINT [PK_DetalleEncabezado] PRIMARY KEY CLUSTERED 
(
	[idDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encabezado]    Script Date: 1/10/2018 14:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encabezado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Cliente] [varchar](50) NOT NULL,
	[Fecha] [date] NOT NULL,
 CONSTRAINT [PK_Encabezado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 1/10/2018 14:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Precio] [money] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_DetalleEncabezado_Encabezado] FOREIGN KEY([idEncabezado])
REFERENCES [dbo].[Encabezado] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleEncabezado] CHECK CONSTRAINT [FK_DetalleEncabezado_Encabezado]
GO
ALTER TABLE [dbo].[DetalleEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_DetalleEncabezado_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[DetalleEncabezado] CHECK CONSTRAINT [FK_DetalleEncabezado_Producto]
GO
USE [master]
GO
ALTER DATABASE [PruebaDetalleMaestro] SET  READ_WRITE 
GO
