USE [master]
GO
/****** Object:  Database [UCRMS_TeamAvengers]    Script Date: 12/18/2019 10:14:42 AM ******/
CREATE DATABASE [UCRMS_TeamAvengers]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UCRMS_TeamAvengers', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UCRMS_TeamAvengers.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UCRMS_TeamAvengers_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UCRMS_TeamAvengers_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UCRMS_TeamAvengers].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET ARITHABORT OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET  MULTI_USER 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UCRMS_TeamAvengers]
GO
/****** Object:  Table [dbo].[AssignStudentTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssignStudentTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NULL,
	[Date] [varchar](50) NOT NULL,
	[StudentID] [int] NULL,
	[CourseID] [int] NULL,
	[GradeID] [int] NOT NULL,
 CONSTRAINT [PK_AssignStudentTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssignTeacherTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssignTeacherTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_AssignTeacherTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassRoomAllocationTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassRoomAllocationTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeFrom] [varchar](50) NULL,
	[TimeTo] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[DepartmentID] [int] NULL,
	[CourseID] [int] NULL,
	[RoomNoID] [int] NULL,
	[SevenDayWeekID] [int] NULL,
 CONSTRAINT [PK_ClassRoomAllocationTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassRoomTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassRoomTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](50) NOT NULL,
	[RoomName] [varchar](50) NOT NULL,
	[RoomLocation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ClassRoomTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](50) NOT NULL,
	[CourseName] [varchar](100) NOT NULL,
	[CourseCredit] [decimal](10, 2) NOT NULL,
	[CourseDescription] [varchar](300) NULL,
	[DepartmentID] [int] NOT NULL,
	[SemesterID] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DepartmentTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DepartmentTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeptCode] [varchar](50) NULL,
	[DeptName] [varchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GradeTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GradeTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GradeTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SemesterTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SemesterTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SemesterCode] [int] NOT NULL,
	[SemesterName] [varchar](50) NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SevenDayWeekTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SevenDayWeekTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Day] [varchar](50) NOT NULL,
	[DayShortName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SevenDayWeekTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NOT NULL,
	[StudentEmail] [varchar](50) NOT NULL,
	[StudentContactNo] [varchar](50) NOT NULL,
	[StudentAddDate] [date] NOT NULL,
	[StudentAddress] [varchar](50) NULL,
	[StudentRegNo] [varchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_StudentTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TeacherDesignationTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TeacherDesignationTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DesignationName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TeacherDesignationTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TeacherTable]    Script Date: 12/18/2019 10:14:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TeacherTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NOT NULL,
	[TeacherAddress] [varchar](500) NULL,
	[TeacherEmail] [varchar](50) NOT NULL,
	[TeacherContactNo] [varchar](50) NOT NULL,
	[TeacherCredit] [decimal](18, 2) NOT NULL,
	[TeacherDesignationID] [int] NOT NULL,
	[TeacherDepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_TeacherTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AssignStudentTable] ON 

INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1008, N'0', N'2019-18-12', 1006, 15, 1)
INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1009, N'0', N'2019-18-12', 1007, 15, 14)
INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1010, N'0', N'2019-18-12', 1008, 15, 1)
INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1011, N'0', N'2019-18-12', 1010, 15, 14)
INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1012, N'0', N'2019-18-12', 1011, 15, 14)
INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1013, N'0', N'2019-18-12', 1009, 15, 14)
INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1014, N'0', N'2019-18-12', 1006, 16, 14)
INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1015, N'0', N'2019-18-12', 1007, 16, 14)
INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1016, N'0', N'2019-18-12', 1008, 16, 14)
INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1017, N'0', N'2019-18-12', 1010, 16, 14)
INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1018, N'0', N'2019-18-12', 1011, 16, 14)
INSERT [dbo].[AssignStudentTable] ([Id], [Status], [Date], [StudentID], [CourseID], [GradeID]) VALUES (1019, N'0', N'2019-18-12', 1009, 16, 14)
SET IDENTITY_INSERT [dbo].[AssignStudentTable] OFF
SET IDENTITY_INSERT [dbo].[AssignTeacherTable] ON 

INSERT [dbo].[AssignTeacherTable] ([Id], [Status], [TeacherId], [CourseId]) VALUES (18, N'Assigned', 9, 18)
INSERT [dbo].[AssignTeacherTable] ([Id], [Status], [TeacherId], [CourseId]) VALUES (19, N'Assigned', 9, 21)
INSERT [dbo].[AssignTeacherTable] ([Id], [Status], [TeacherId], [CourseId]) VALUES (20, N'Assigned', 8, 20)
INSERT [dbo].[AssignTeacherTable] ([Id], [Status], [TeacherId], [CourseId]) VALUES (21, N'Assigned', 10, 16)
INSERT [dbo].[AssignTeacherTable] ([Id], [Status], [TeacherId], [CourseId]) VALUES (22, N'Assigned', 9, 15)
SET IDENTITY_INSERT [dbo].[AssignTeacherTable] OFF
SET IDENTITY_INSERT [dbo].[ClassRoomAllocationTable] ON 

INSERT [dbo].[ClassRoomAllocationTable] ([Id], [TimeFrom], [TimeTo], [Status], [DepartmentID], [CourseID], [RoomNoID], [SevenDayWeekID]) VALUES (25, N'1000', N'1130', N'1', 25, 15, 2, 2)
INSERT [dbo].[ClassRoomAllocationTable] ([Id], [TimeFrom], [TimeTo], [Status], [DepartmentID], [CourseID], [RoomNoID], [SevenDayWeekID]) VALUES (26, N'1125', N'1150', N'1', 25, 20, 6, 2)
INSERT [dbo].[ClassRoomAllocationTable] ([Id], [TimeFrom], [TimeTo], [Status], [DepartmentID], [CourseID], [RoomNoID], [SevenDayWeekID]) VALUES (27, N'1150', N'1250', N'1', 25, 15, 6, 2)
INSERT [dbo].[ClassRoomAllocationTable] ([Id], [TimeFrom], [TimeTo], [Status], [DepartmentID], [CourseID], [RoomNoID], [SevenDayWeekID]) VALUES (28, N'0920', N'1000', N'1', 25, 20, 10, 3)
INSERT [dbo].[ClassRoomAllocationTable] ([Id], [TimeFrom], [TimeTo], [Status], [DepartmentID], [CourseID], [RoomNoID], [SevenDayWeekID]) VALUES (29, N'1000', N'1045', N'1', 25, 20, 10, 3)
INSERT [dbo].[ClassRoomAllocationTable] ([Id], [TimeFrom], [TimeTo], [Status], [DepartmentID], [CourseID], [RoomNoID], [SevenDayWeekID]) VALUES (30, N'0812', N'0845', N'1', 25, 19, 2, 8)
SET IDENTITY_INSERT [dbo].[ClassRoomAllocationTable] OFF
SET IDENTITY_INSERT [dbo].[ClassRoomTable] ON 

INSERT [dbo].[ClassRoomTable] ([Id], [RoomNo], [RoomName], [RoomLocation]) VALUES (2, N'A-501', N'AFiveOne', N'Adminstrative Building')
INSERT [dbo].[ClassRoomTable] ([Id], [RoomNo], [RoomName], [RoomLocation]) VALUES (6, N'A-502', N'AFiveTwo', N'Adminstrative Building')
INSERT [dbo].[ClassRoomTable] ([Id], [RoomNo], [RoomName], [RoomLocation]) VALUES (7, N'A-503', N'AFiveThree', N'Adminstrative Building')
INSERT [dbo].[ClassRoomTable] ([Id], [RoomNo], [RoomName], [RoomLocation]) VALUES (8, N'A-601', N'ASixOne', N'Adminstrative Building')
INSERT [dbo].[ClassRoomTable] ([Id], [RoomNo], [RoomName], [RoomLocation]) VALUES (9, N'A-602', N'ASixTwo', N'Adminstrative Building')
INSERT [dbo].[ClassRoomTable] ([Id], [RoomNo], [RoomName], [RoomLocation]) VALUES (10, N'S-101', N'SOneOne', N'Science Building')
SET IDENTITY_INSERT [dbo].[ClassRoomTable] OFF
SET IDENTITY_INSERT [dbo].[CourseTable] ON 

INSERT [dbo].[CourseTable] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentID], [SemesterID]) VALUES (15, N'CSE-101', N'Computer Fundamental', CAST(2.00 AS Decimal(10, 2)), N'Description', 25, 1)
INSERT [dbo].[CourseTable] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentID], [SemesterID]) VALUES (16, N'STAT-102', N'Statistics', CAST(2.00 AS Decimal(10, 2)), N'Description', 25, 2)
INSERT [dbo].[CourseTable] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentID], [SemesterID]) VALUES (17, N'CSE-801', N'Data Mining', CAST(3.00 AS Decimal(10, 2)), N'Description', 25, 8)
INSERT [dbo].[CourseTable] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentID], [SemesterID]) VALUES (18, N'CSE-701', N'Graph Theory', CAST(3.00 AS Decimal(10, 2)), N'Description', 25, 7)
INSERT [dbo].[CourseTable] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentID], [SemesterID]) VALUES (19, N'CSE-601', N'System Analysis and Design', CAST(3.00 AS Decimal(10, 2)), N'Description', 25, 6)
INSERT [dbo].[CourseTable] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentID], [SemesterID]) VALUES (20, N'CSE-501', N'Algorithm', CAST(3.00 AS Decimal(10, 2)), N'Description', 25, 5)
INSERT [dbo].[CourseTable] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentID], [SemesterID]) VALUES (21, N'CSE-802', N'Thesis', CAST(4.00 AS Decimal(10, 2)), N'Description', 25, 8)
INSERT [dbo].[CourseTable] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentID], [SemesterID]) VALUES (22, N'CSE-201', N'Structured Programming', CAST(3.00 AS Decimal(10, 2)), N'Description', 25, 2)
INSERT [dbo].[CourseTable] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentID], [SemesterID]) VALUES (23, N'CSE-202', N'Discrete Mathematics', CAST(3.00 AS Decimal(10, 2)), N'Description', 25, 2)
SET IDENTITY_INSERT [dbo].[CourseTable] OFF
SET IDENTITY_INSERT [dbo].[DepartmentTable] ON 

INSERT [dbo].[DepartmentTable] ([Id], [DeptCode], [DeptName]) VALUES (25, N'CSE', N'Computer Science and Engineering')
INSERT [dbo].[DepartmentTable] ([Id], [DeptCode], [DeptName]) VALUES (26, N'BBA', N'Bachelor of Business Administration')
INSERT [dbo].[DepartmentTable] ([Id], [DeptCode], [DeptName]) VALUES (27, N'LLB', N'Bachelor of Law')
SET IDENTITY_INSERT [dbo].[DepartmentTable] OFF
SET IDENTITY_INSERT [dbo].[GradeTable] ON 

INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (1, N'A+')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (2, N'A')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (3, N'A-')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (4, N'B+')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (5, N'B')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (6, N'B-')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (7, N'C+')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (8, N'C')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (9, N'C-')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (10, N'D+')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (11, N'D')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (12, N'D-')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (13, N'F')
INSERT [dbo].[GradeTable] ([Id], [Grade]) VALUES (14, N'Not Graded Yet')
SET IDENTITY_INSERT [dbo].[GradeTable] OFF
SET IDENTITY_INSERT [dbo].[SemesterTable] ON 

INSERT [dbo].[SemesterTable] ([Id], [SemesterCode], [SemesterName]) VALUES (1, 1, N'1st')
INSERT [dbo].[SemesterTable] ([Id], [SemesterCode], [SemesterName]) VALUES (2, 2, N'2nd')
INSERT [dbo].[SemesterTable] ([Id], [SemesterCode], [SemesterName]) VALUES (3, 3, N'3rd')
INSERT [dbo].[SemesterTable] ([Id], [SemesterCode], [SemesterName]) VALUES (4, 4, N'4th')
INSERT [dbo].[SemesterTable] ([Id], [SemesterCode], [SemesterName]) VALUES (5, 5, N'5th')
INSERT [dbo].[SemesterTable] ([Id], [SemesterCode], [SemesterName]) VALUES (6, 6, N'6th')
INSERT [dbo].[SemesterTable] ([Id], [SemesterCode], [SemesterName]) VALUES (7, 7, N'7th')
INSERT [dbo].[SemesterTable] ([Id], [SemesterCode], [SemesterName]) VALUES (8, 8, N'8th')
SET IDENTITY_INSERT [dbo].[SemesterTable] OFF
SET IDENTITY_INSERT [dbo].[SevenDayWeekTable] ON 

INSERT [dbo].[SevenDayWeekTable] ([Id], [Day], [DayShortName]) VALUES (2, N'Saturday', N'Sat')
INSERT [dbo].[SevenDayWeekTable] ([Id], [Day], [DayShortName]) VALUES (3, N'Sunday', N'Sun')
INSERT [dbo].[SevenDayWeekTable] ([Id], [Day], [DayShortName]) VALUES (4, N'Monday', N'Mon')
INSERT [dbo].[SevenDayWeekTable] ([Id], [Day], [DayShortName]) VALUES (5, N'Tuesday', N'Tue')
INSERT [dbo].[SevenDayWeekTable] ([Id], [Day], [DayShortName]) VALUES (6, N'Wednesday', N'Wed')
INSERT [dbo].[SevenDayWeekTable] ([Id], [Day], [DayShortName]) VALUES (7, N'Thursday', N'Thurs')
INSERT [dbo].[SevenDayWeekTable] ([Id], [Day], [DayShortName]) VALUES (8, N'Friday', N'Fri')
SET IDENTITY_INSERT [dbo].[SevenDayWeekTable] OFF
SET IDENTITY_INSERT [dbo].[StudentTable] ON 

INSERT [dbo].[StudentTable] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddDate], [StudentAddress], [StudentRegNo], [DepartmentID]) VALUES (1006, N'Nurul Momen', N'momen@gmail.com', N'+8801111111111', CAST(0x81400B00 AS Date), N'Oxygen', N'CSE-2019-001', 25)
INSERT [dbo].[StudentTable] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddDate], [StudentAddress], [StudentRegNo], [DepartmentID]) VALUES (1007, N'Musfiq Montasir', N'mushfiq@gmail.com', N'+8801111111112', CAST(0x81400B00 AS Date), N'Textile', N'CSE-2019-002', 25)
INSERT [dbo].[StudentTable] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddDate], [StudentAddress], [StudentRegNo], [DepartmentID]) VALUES (1008, N'Sarwar Hossain', N'tanim@gmail.com', N'+8801111111113', CAST(0x81400B00 AS Date), N'Bahadderhat', N'CSE-2019-003', 25)
INSERT [dbo].[StudentTable] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddDate], [StudentAddress], [StudentRegNo], [DepartmentID]) VALUES (1009, N'Tanzeed Kaisar', N'tanni@gmail.com', N'+8801111111113', CAST(0x90400B00 AS Date), N'Bahadderhat', N'CSE-2020-001', 25)
INSERT [dbo].[StudentTable] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddDate], [StudentAddress], [StudentRegNo], [DepartmentID]) VALUES (1010, N'Showmik Barua', N'showmik@gmail.com', N'+8801111111113', CAST(0x88400B00 AS Date), N'Chandgao', N'CSE-2019-004', 25)
INSERT [dbo].[StudentTable] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddDate], [StudentAddress], [StudentRegNo], [DepartmentID]) VALUES (1011, N'Foisal Minhaz', N'foisal@gmail.com', N'+8801111111114', CAST(0x88400B00 AS Date), N'New York', N'CSE-2019-005', 25)
SET IDENTITY_INSERT [dbo].[StudentTable] OFF
SET IDENTITY_INSERT [dbo].[TeacherDesignationTable] ON 

INSERT [dbo].[TeacherDesignationTable] ([Id], [DesignationId], [DesignationName]) VALUES (6, 1, N'Proffessor')
INSERT [dbo].[TeacherDesignationTable] ([Id], [DesignationId], [DesignationName]) VALUES (7, 2, N'Associate Proffessor')
INSERT [dbo].[TeacherDesignationTable] ([Id], [DesignationId], [DesignationName]) VALUES (9, 3, N'Assistant Proffessor')
INSERT [dbo].[TeacherDesignationTable] ([Id], [DesignationId], [DesignationName]) VALUES (10, 4, N'Lecturer')
INSERT [dbo].[TeacherDesignationTable] ([Id], [DesignationId], [DesignationName]) VALUES (11, 5, N'Assistant Lecturer')
INSERT [dbo].[TeacherDesignationTable] ([Id], [DesignationId], [DesignationName]) VALUES (12, 6, N'Adjunct Lectruer')
SET IDENTITY_INSERT [dbo].[TeacherDesignationTable] OFF
SET IDENTITY_INSERT [dbo].[TeacherTable] ON 

INSERT [dbo].[TeacherTable] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [TeacherCredit], [TeacherDesignationID], [TeacherDepartmentID]) VALUES (8, N'Mr. Tanveer Ahsan', N'Chandgaon', N'tanveerahsan@gmail.com', N'+8801819941685', CAST(16.00 AS Decimal(18, 2)), 9, 25)
INSERT [dbo].[TeacherTable] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [TeacherCredit], [TeacherDesignationID], [TeacherDepartmentID]) VALUES (9, N'Mohammed Shamsul Alam', N'Chawkbazar', N'alam_cse@yahoo.com', N'+8801819941685', CAST(16.00 AS Decimal(18, 2)), 6, 25)
INSERT [dbo].[TeacherTable] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [TeacherCredit], [TeacherDesignationID], [TeacherDepartmentID]) VALUES (10, N'Dr Abu Naser Md Rezaul Karim', N'Chandgaon', N'zakianaser@yahoo.com', N'+8801819941685', CAST(12.00 AS Decimal(18, 2)), 7, 25)
SET IDENTITY_INSERT [dbo].[TeacherTable] OFF
ALTER TABLE [dbo].[AssignStudentTable]  WITH CHECK ADD  CONSTRAINT [FK_AssignStudentTable_CourseTable] FOREIGN KEY([CourseID])
REFERENCES [dbo].[CourseTable] ([Id])
GO
ALTER TABLE [dbo].[AssignStudentTable] CHECK CONSTRAINT [FK_AssignStudentTable_CourseTable]
GO
ALTER TABLE [dbo].[AssignStudentTable]  WITH CHECK ADD  CONSTRAINT [FK_AssignStudentTable_GradeTable] FOREIGN KEY([GradeID])
REFERENCES [dbo].[GradeTable] ([Id])
GO
ALTER TABLE [dbo].[AssignStudentTable] CHECK CONSTRAINT [FK_AssignStudentTable_GradeTable]
GO
ALTER TABLE [dbo].[AssignStudentTable]  WITH CHECK ADD  CONSTRAINT [FK_AssignStudentTable_StudentTable] FOREIGN KEY([StudentID])
REFERENCES [dbo].[StudentTable] ([Id])
GO
ALTER TABLE [dbo].[AssignStudentTable] CHECK CONSTRAINT [FK_AssignStudentTable_StudentTable]
GO
ALTER TABLE [dbo].[AssignTeacherTable]  WITH CHECK ADD  CONSTRAINT [FK_AssignTeacherTable_CourseTable] FOREIGN KEY([CourseId])
REFERENCES [dbo].[CourseTable] ([Id])
GO
ALTER TABLE [dbo].[AssignTeacherTable] CHECK CONSTRAINT [FK_AssignTeacherTable_CourseTable]
GO
ALTER TABLE [dbo].[AssignTeacherTable]  WITH CHECK ADD  CONSTRAINT [FK_AssignTeacherTable_TeacherTable] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[TeacherTable] ([Id])
GO
ALTER TABLE [dbo].[AssignTeacherTable] CHECK CONSTRAINT [FK_AssignTeacherTable_TeacherTable]
GO
ALTER TABLE [dbo].[ClassRoomAllocationTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoomAllocationTable_ClassRoomAllocationTable] FOREIGN KEY([CourseID])
REFERENCES [dbo].[CourseTable] ([Id])
GO
ALTER TABLE [dbo].[ClassRoomAllocationTable] CHECK CONSTRAINT [FK_ClassRoomAllocationTable_ClassRoomAllocationTable]
GO
ALTER TABLE [dbo].[ClassRoomAllocationTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoomAllocationTable_ClassRoomAllocationTable1] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[DepartmentTable] ([Id])
GO
ALTER TABLE [dbo].[ClassRoomAllocationTable] CHECK CONSTRAINT [FK_ClassRoomAllocationTable_ClassRoomAllocationTable1]
GO
ALTER TABLE [dbo].[ClassRoomAllocationTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoomAllocationTable_ClassRoomAllocationTable2] FOREIGN KEY([SevenDayWeekID])
REFERENCES [dbo].[SevenDayWeekTable] ([Id])
GO
ALTER TABLE [dbo].[ClassRoomAllocationTable] CHECK CONSTRAINT [FK_ClassRoomAllocationTable_ClassRoomAllocationTable2]
GO
ALTER TABLE [dbo].[ClassRoomAllocationTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoomAllocationTable_ClassRoomAllocationTable3] FOREIGN KEY([RoomNoID])
REFERENCES [dbo].[ClassRoomTable] ([Id])
GO
ALTER TABLE [dbo].[ClassRoomAllocationTable] CHECK CONSTRAINT [FK_ClassRoomAllocationTable_ClassRoomAllocationTable3]
GO
ALTER TABLE [dbo].[CourseTable]  WITH CHECK ADD  CONSTRAINT [FK_CourseTable_DepartmentTable] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[DepartmentTable] ([Id])
GO
ALTER TABLE [dbo].[CourseTable] CHECK CONSTRAINT [FK_CourseTable_DepartmentTable]
GO
ALTER TABLE [dbo].[CourseTable]  WITH CHECK ADD  CONSTRAINT [FK_CourseTable_SemesterTable] FOREIGN KEY([SemesterID])
REFERENCES [dbo].[SemesterTable] ([Id])
GO
ALTER TABLE [dbo].[CourseTable] CHECK CONSTRAINT [FK_CourseTable_SemesterTable]
GO
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_DepartmentTable] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[DepartmentTable] ([Id])
GO
ALTER TABLE [dbo].[StudentTable] CHECK CONSTRAINT [FK_StudentTable_DepartmentTable]
GO
ALTER TABLE [dbo].[TeacherTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherTable_DepartmentTable] FOREIGN KEY([TeacherDepartmentID])
REFERENCES [dbo].[DepartmentTable] ([Id])
GO
ALTER TABLE [dbo].[TeacherTable] CHECK CONSTRAINT [FK_TeacherTable_DepartmentTable]
GO
ALTER TABLE [dbo].[TeacherTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherTable_TeacherDesignationTable] FOREIGN KEY([TeacherDesignationID])
REFERENCES [dbo].[TeacherDesignationTable] ([Id])
GO
ALTER TABLE [dbo].[TeacherTable] CHECK CONSTRAINT [FK_TeacherTable_TeacherDesignationTable]
GO
USE [master]
GO
ALTER DATABASE [UCRMS_TeamAvengers] SET  READ_WRITE 
GO
