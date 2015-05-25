
/****** Object:  Table [dbo].[ProjectUsers]    Script Date: 2015-05-24 18:00:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TaskConnections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PreviousTask] [int] NOT NULL,
	[NextTask] [int] NULL,
 CONSTRAINT [PK_dbo.TaskConnections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT FK_TaskConnectionsPreviousTask FOREIGN KEY (PreviousTask) 
    REFERENCES dbo.Tasks (Id) 
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
CONSTRAINT FK_TaskConnectionsNextTask FOREIGN KEY (NextTask)
    REFERENCES dbo.Tasks (Id) 
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
) ON [PRIMARY] 

GO

