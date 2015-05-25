

/****** Object:  Table [dbo].[Comments]    Script Date: 2015-05-24 18:30:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorsId] [nvarchar](128) NULL,
	[Text] [nvarchar](max) NULL,
	[Date] [datetime] NOT NULL,
	[TaskId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT FK_CommentsTasks FOREIGN KEY (TaskId)
    REFERENCES dbo.Tasks (Id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ON [PRIMARY] 

GO


