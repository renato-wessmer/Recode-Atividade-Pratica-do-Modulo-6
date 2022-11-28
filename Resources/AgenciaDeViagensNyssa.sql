USE [master]
GO

/****** Object:  Database [agenciadeviagensnyssa]    Script Date: 07/11/2022 00:09:24 ******/
CREATE DATABASE [agenciadeviagensnyssa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'agenciadeviagensnyssa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\agenciadeviagensnyssa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'agenciadeviagensnyssa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\agenciadeviagensnyssa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [agenciadeviagensnyssa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [agenciadeviagensnyssa] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET ARITHABORT OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET  ENABLE_BROKER 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET RECOVERY FULL 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET  MULTI_USER 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [agenciadeviagensnyssa] SET DB_CHAINING OFF 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [agenciadeviagensnyssa] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [agenciadeviagensnyssa] SET QUERY_STORE = OFF
GO

ALTER DATABASE [agenciadeviagensnyssa] SET  READ_WRITE 
GO


