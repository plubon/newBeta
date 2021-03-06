
/****** Object:  Table [dbo].[Subtasks]    Script Date: 2015-05-24 17:57:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Subtasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[State] [bit] NULL,
	[TaskId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Subtasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT FK_SubtasksTasks FOREIGN KEY (TaskId) 
    REFERENCES dbo.Tasks (Id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE,
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


