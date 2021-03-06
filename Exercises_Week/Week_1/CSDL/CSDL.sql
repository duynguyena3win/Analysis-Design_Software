USE [QLSV]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 9/15/2013 4:40:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[hoten] [nvarchar](30) NULL,
	[mssv] [int] NOT NULL,
	[chnganh] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[mssv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
