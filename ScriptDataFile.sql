USE [AWEBLEARNTOCODE]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaiHocs]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiHocs](
	[IdBaiHoc] [int] IDENTITY(1,1) NOT NULL,
	[TenBaiHoc] [nvarchar](200) NOT NULL,
	[IdKhoaHoc] [bigint] NULL,
 CONSTRAINT [PK_dbo.BaiHocs] PRIMARY KEY CLUSTERED 
(
	[IdBaiHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaiTaps]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiTaps](
	[IDBaiTap] [int] IDENTITY(1,1) NOT NULL,
	[TenBaiTap] [nvarchar](100) NOT NULL,
	[NoiDungBaiTap] [nvarchar](500) NOT NULL,
	[Diem] [int] NOT NULL,
	[TrangThaiHoanThanh] [int] NOT NULL,
	[BaiHoc_IdBaiHoc] [int] NULL,
 CONSTRAINT [PK_dbo.BaiTaps] PRIMARY KEY CLUSTERED 
(
	[IDBaiTap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaiViets]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiViets](
	[IdBaiViet] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](max) NULL,
	[NoiDungBaiViet] [nvarchar](max) NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[NgayDang] [datetime] NULL,
	[LuotXem] [int] NOT NULL,
	[LuotThich] [int] NOT NULL,
	[NgonNgu] [int] NOT NULL,
	[DanhMuc] [int] NOT NULL,
	[User_IdUser] [int] NULL,
 CONSTRAINT [PK_dbo.BaiViets] PRIMARY KEY CLUSTERED 
(
	[IdBaiViet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauHois]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHois](
	[IdCauHoi] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](max) NULL,
	[NoiDungCauHoi] [nvarchar](1500) NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[NgayDang] [datetime] NULL,
	[LuotXem] [int] NOT NULL,
	[NgonNgu] [int] NOT NULL,
	[DanhMuc] [int] NOT NULL,
	[User_IdUser] [int] NULL,
 CONSTRAINT [PK_dbo.CauHois] PRIMARY KEY CLUSTERED 
(
	[IdCauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietBaiHoc]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietBaiHoc](
	[IdChiTietBaiHoc] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung1] [nvarchar](max) NULL,
	[IdBaiHoc] [bigint] NULL,
 CONSTRAINT [PK_dbo.ChiTietBaiHoc] PRIMARY KEY CLUSTERED 
(
	[IdChiTietBaiHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietBaiLuyens]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietBaiLuyens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeBai] [nvarchar](1000) NOT NULL,
	[YeuCauDauVao] [nvarchar](100) NULL,
	[DauVao] [nvarchar](100) NULL,
	[DauRa] [nvarchar](100) NULL,
	[ViduVao] [nvarchar](100) NULL,
	[ViduRa] [nvarchar](100) NULL,
	[Diem] [int] NULL,
 CONSTRAINT [PK_dbo.ChiTietBaiLuyens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoaHocs]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoaHocs](
	[IDKhoaHoc] [int] IDENTITY(1,1) NOT NULL,
	[TenKhoaHoc] [nvarchar](500) NOT NULL,
	[NgonNgu] [int] NULL,
	[GiaGoiKhoaHoc] [money] NULL,
 CONSTRAINT [PK_dbo.KhoaHocs] PRIMARY KEY CLUSTERED 
(
	[IDKhoaHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LuyenCodes]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuyenCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenLuyenTap] [nvarchar](255) NOT NULL,
	[LuotXem] [int] NULL,
	[YeuThich] [int] NULL,
	[NgonNgu] [int] NOT NULL,
	[DoKho] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LuyenCodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MuaKhoaHoc]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MuaKhoaHoc](
	[IdMua] [int] IDENTITY(1,1) NOT NULL,
	[IdKhoaHoc] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
	[NgayThanhToan] [datetime] NOT NULL,
	[ThanhTien] [money] NULL,
 CONSTRAINT [PK_dbo.MuaKhoaHoc] PRIMARY KEY CLUSTERED 
(
	[IdMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanHois]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanHois](
	[IDPhanHoi] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [nvarchar](500) NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[NgayDang] [datetime] NULL,
	[LuotThich] [int] NULL,
	[BaiViet_IdBaiViet] [int] NULL,
	[CauHoi_IdCauHoi] [int] NULL,
	[User_IdUser] [int] NULL,
 CONSTRAINT [PK_dbo.PhanHois] PRIMARY KEY CLUSTERED 
(
	[IDPhanHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23/05/2023 10:01:15 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[TenUser] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[TenTaiKHoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaiTaps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BaiTaps_dbo.BaiHocs_BaiHoc_IdBaiHoc] FOREIGN KEY([BaiHoc_IdBaiHoc])
REFERENCES [dbo].[BaiHocs] ([IdBaiHoc])
GO
ALTER TABLE [dbo].[BaiTaps] CHECK CONSTRAINT [FK_dbo.BaiTaps_dbo.BaiHocs_BaiHoc_IdBaiHoc]
GO
ALTER TABLE [dbo].[BaiViets]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BaiViets_dbo.Users_User_IdUser] FOREIGN KEY([User_IdUser])
REFERENCES [dbo].[Users] ([IdUser])
GO
ALTER TABLE [dbo].[BaiViets] CHECK CONSTRAINT [FK_dbo.BaiViets_dbo.Users_User_IdUser]
GO
ALTER TABLE [dbo].[CauHois]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CauHois_dbo.Users_User_IdUser] FOREIGN KEY([User_IdUser])
REFERENCES [dbo].[Users] ([IdUser])
GO
ALTER TABLE [dbo].[CauHois] CHECK CONSTRAINT [FK_dbo.CauHois_dbo.Users_User_IdUser]
GO
ALTER TABLE [dbo].[MuaKhoaHoc]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MuaKhoaHoc_dbo.Users_IdUser] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([IdUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MuaKhoaHoc] CHECK CONSTRAINT [FK_dbo.MuaKhoaHoc_dbo.Users_IdUser]
GO
ALTER TABLE [dbo].[PhanHois]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PhanHois_dbo.BaiViets_BaiViet_IdBaiViet] FOREIGN KEY([BaiViet_IdBaiViet])
REFERENCES [dbo].[BaiViets] ([IdBaiViet])
GO
ALTER TABLE [dbo].[PhanHois] CHECK CONSTRAINT [FK_dbo.PhanHois_dbo.BaiViets_BaiViet_IdBaiViet]
GO
ALTER TABLE [dbo].[PhanHois]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PhanHois_dbo.CauHois_CauHoi_IdCauHoi] FOREIGN KEY([CauHoi_IdCauHoi])
REFERENCES [dbo].[CauHois] ([IdCauHoi])
GO
ALTER TABLE [dbo].[PhanHois] CHECK CONSTRAINT [FK_dbo.PhanHois_dbo.CauHois_CauHoi_IdCauHoi]
GO
ALTER TABLE [dbo].[PhanHois]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PhanHois_dbo.Users_User_IdUser] FOREIGN KEY([User_IdUser])
REFERENCES [dbo].[Users] ([IdUser])
GO
ALTER TABLE [dbo].[PhanHois] CHECK CONSTRAINT [FK_dbo.PhanHois_dbo.Users_User_IdUser]
GO
