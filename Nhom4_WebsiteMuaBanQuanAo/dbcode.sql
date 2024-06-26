CREATE DATABASE DBPermission
GO
USE [DBPermission]
GO
/****** Object:  Table [dbo].[admins]    Script Date: 10/1/2021 8:53:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[admins](
	[id_admin] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](10) NULL,
	[name] [nvarchar](100) NULL,
	[email] [varchar](100) NULL,
	[id_permission] [int] NULL,
 CONSTRAINT [PK_admins] PRIMARY KEY CLUSTERED 
(
	[id_admin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[permissions]    Script Date: 10/1/2021 8:53:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permissions](
	[id_permission] [int] IDENTITY(1,1) NOT NULL,
	[permission_name] [nvarchar](1000) NULL,
 CONSTRAINT [PK_permissions] PRIMARY KEY CLUSTERED 
(
	[id_permission] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[students]    Script Date: 10/1/2021 8:53:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[students](
	[id_student] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](10) NULL,
	[name] [nvarchar](100) NULL,
	[email] [varchar](100) NULL,
	[id_permission] [int] NULL,
 CONSTRAINT [PK_students] PRIMARY KEY CLUSTERED 
(
	[id_student] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[teachers]    Script Date: 10/1/2021 8:53:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[teachers](
	[id_teacher] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](10) NULL,
	[name] [nvarchar](100) NULL,
	[email] [varchar](100) NULL,
	[id_permission] [int] NULL,
 CONSTRAINT [PK_teachers] PRIMARY KEY CLUSTERED 
(
	[id_teacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[admins]  WITH CHECK ADD  CONSTRAINT [FK_admins_permissions] FOREIGN KEY([id_permission])
REFERENCES [dbo].[permissions] ([id_permission])
GO
ALTER TABLE [dbo].[admins] CHECK CONSTRAINT [FK_admins_permissions]
GO
ALTER TABLE [dbo].[students]  WITH CHECK ADD  CONSTRAINT [FK_students_permissions] FOREIGN KEY([id_permission])
REFERENCES [dbo].[permissions] ([id_permission])
GO
ALTER TABLE [dbo].[students] CHECK CONSTRAINT [FK_students_permissions]
GO
ALTER TABLE [dbo].[teachers]  WITH CHECK ADD  CONSTRAINT [FK_teachers_permissions] FOREIGN KEY([id_permission])
REFERENCES [dbo].[permissions] ([id_permission])
GO
ALTER TABLE [dbo].[teachers] CHECK CONSTRAINT [FK_teachers_permissions]
GO
