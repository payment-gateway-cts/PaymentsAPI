USE [master]
GO
/****** Object:  Database [PaymentDB]    Script Date: 01-02-2019 01:08:20 ******/
CREATE DATABASE [PaymentDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PaymentDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PaymentDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PaymentDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PaymentDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PaymentDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PaymentDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PaymentDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PaymentDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PaymentDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PaymentDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PaymentDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PaymentDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PaymentDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PaymentDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PaymentDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PaymentDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PaymentDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PaymentDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PaymentDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PaymentDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PaymentDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PaymentDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PaymentDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PaymentDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PaymentDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PaymentDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PaymentDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PaymentDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PaymentDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PaymentDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PaymentDB] SET  MULTI_USER 
GO
ALTER DATABASE [PaymentDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PaymentDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PaymentDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PaymentDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PaymentDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 01-02-2019 01:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NULL,
	[AccountName] [nvarchar](100) NULL,
	[AccountTypeId] [bigint] NOT NULL,
	[IBAN] [nvarchar](100) NULL,
	[AccountNumber] [nvarchar](50) NULL,
	[Currency] [nvarchar](50) NULL,
	[CurrentBalance] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 01-02-2019 01:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CurrencyExchangeRates]    Script Date: 01-02-2019 01:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrencyExchangeRates](
	[CurrencyCode] [nvarchar](10) NOT NULL,
	[ExchangeRate] [numeric](18, 4) NOT NULL,
 CONSTRAINT [PK_CurrencyExchangeRates] PRIMARY KEY CLUSTERED 
(
	[CurrencyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 01-02-2019 01:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerPaymentMethod]    Script Date: 01-02-2019 01:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerPaymentMethod](
	[CustomerId] [bigint] NOT NULL,
	[PaymentMethodId] [bigint] NOT NULL,
	[CardNumber] [nvarchar](50) NULL,
	[CardExpiryDate] [date] NULL,
	[CardSecurityNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_CustomerPaymentMethods] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[PaymentMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 2/2/2019 8:22:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Payment](
	[Id] [uniqueidentifier] NOT NULL,
	[PayorAccountId] [bigint] NOT NULL,
	[PayorCustomerId] [bigint] NOT NULL,
	[PayeeAccountId] [bigint] NOT NULL,
	[PayeeCustomerId] [bigint] NOT NULL,
	[PaymentMethodId] [bigint] NOT NULL,
	[PaymentStatusId] [bigint] NOT NULL,
	[TransactionId] [nvarchar](10) NOT NULL,
	[TransactionType] [nvarchar](50) NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[PaymentAmount] [numeric](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 01-02-2019 01:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PaymentMethodName] [nvarchar](100) NOT NULL,
	[PaymentMethodCode] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentStatus]    Script Date: 01-02-2019 01:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentStatus](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_PaymentStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_AccountType] FOREIGN KEY([AccountTypeId])
REFERENCES [dbo].[AccountType] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_AccountType]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Customer]
GO
ALTER TABLE [dbo].[CustomerPaymentMethod]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPaymentMethods_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[CustomerPaymentMethod] CHECK CONSTRAINT [FK_CustomerPaymentMethods_Customer]
GO
ALTER TABLE [dbo].[CustomerPaymentMethod]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPaymentMethods_PaymentMethods] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethod] ([Id])
GO
ALTER TABLE [dbo].[CustomerPaymentMethod] CHECK CONSTRAINT [FK_CustomerPaymentMethods_PaymentMethods]
GO
ALTER TABLE [dbo].[Payment] ADD  CONSTRAINT [DF_Payment_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PayeeAccount] FOREIGN KEY([PayeeAccountId])
REFERENCES [dbo].[Account] ([Id])
GO

ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PayeeAccount]
GO

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PayeeCustomer] FOREIGN KEY([PayeeCustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO

ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PayeeCustomer]
GO

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PaymentMethod] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethod] ([Id])
GO

ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PaymentMethod]
GO

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PaymentStatus] FOREIGN KEY([PaymentStatusId])
REFERENCES [dbo].[PaymentStatus] ([Id])
GO

ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PaymentStatus]
GO

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PayorAccount] FOREIGN KEY([PayorAccountId])
REFERENCES [dbo].[Account] ([Id])
GO

ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PayorAccount]
GO

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PayorCustomer] FOREIGN KEY([PayorCustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO

ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PayorCustomer]
GO

USE [master]
GO
ALTER DATABASE [PaymentDB] SET  READ_WRITE 
GO
