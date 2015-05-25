
/****** Object:  Table [dbo].[Tasks]    Script Date: 2015-05-24 17:47:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[ProjectId] [int] NOT NULL,
	[AssignedTo] [nvarchar](128) NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Completion] [int] NOT NULL,
	[Color] [nvarchar](max) NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT FK_TasksProjects FOREIGN KEY (ProjectId) 
    REFERENCES dbo.Projects (Id) 
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
CONSTRAINT FK_TaskUsers FOREIGN KEY (AssignedTo) 
    REFERENCES dbo.AspNetUsers (Id) 
    ON DELETE NO ACTION
    ON UPDATE NO ACTIOn,
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
