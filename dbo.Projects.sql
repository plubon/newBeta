

/****** Object:  Table [dbo].[Projects]    Script Date: 2015-05-24 17:36:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[StartDate] [datetime] NOT NULL,
	[OwnersId] [nvarchar](128) NULL,
	[ManagersId] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT FK_ProjectOwners FOREIGN KEY (OwnersId) 
    REFERENCES dbo.AspNetUsers (Id) 
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
CONSTRAINT FK_ProjectManagers FOREIGN KEY (ManagersId) 
    REFERENCES dbo.AspNetUsers (Id) 
    ON DELETE SET NULL
    ON UPDATE CASCADE,
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

