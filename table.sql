USE [sistemPemesananTiketPesawat]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 23/04/2025 21:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[id_admin] [int] NOT NULL,
	[nama] [varchar](50) NOT NULL,
	[email] [varchar](25) NOT NULL,
	[password] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_admin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[maskapai]    Script Date: 23/04/2025 21:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[maskapai](
	[id_maskapai] [varchar](7) NOT NULL,
	[nama_maskapai] [varchar](30) NOT NULL,
	[kode_maskapai] [varchar](5) NOT NULL,
	[negara_asal] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_maskapai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[kode_maskapai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pembayaran]    Script Date: 23/04/2025 21:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pembayaran](
	[id_pembayaran] [int] NOT NULL,
	[jumlah_bayar] [decimal](10, 2) NOT NULL,
	[tanggal_bayar] [datetime] NULL,
	[statusBayar] [varchar](10) NULL,
	[pemesanan_id] [char](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pembayaran] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pemesanan]    Script Date: 23/04/2025 21:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pemesanan](
	[pemesanan_id] [char](8) NOT NULL,
	[waktuPesan] [datetime] NOT NULL,
	[statusPesan] [varchar](10) NOT NULL,
	[id_user] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pemesanan_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[penerbangan]    Script Date: 23/04/2025 21:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[penerbangan](
	[id_penerbangan] [varchar](10) NOT NULL,
	[noPenerbangan] [varchar](7) NULL,
	[tujuan] [varchar](50) NOT NULL,
	[asal] [varchar](50) NOT NULL,
	[waktuBrgkt] [datetime] NOT NULL,
	[waktuKedatangan] [datetime] NULL,
	[harga] [decimal](10, 2) NULL,
	[id_maskapai] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_penerbangan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[noPenerbangan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[penumpang]    Script Date: 23/04/2025 21:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[penumpang](
	[id_Penumpang] [varchar](10) NOT NULL,
	[namaLengkap] [varchar](75) NOT NULL,
	[tanggalLahir] [date] NOT NULL,
	[jnsKelamin] [varchar](9) NOT NULL,
	[kewarganegaraan] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Penumpang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tiket]    Script Date: 23/04/2025 21:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tiket](
	[id_tiket] [varchar](10) NOT NULL,
	[pemesanan_id] [char](8) NOT NULL,
	[id_penumpang] [varchar](10) NOT NULL,
	[id_penerbangan] [varchar](10) NOT NULL,
	[kodeTiket] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tiket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[kodeTiket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 23/04/2025 21:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id_user] [int] NOT NULL,
	[nama] [varchar](100) NOT NULL,
	[email] [varchar](25) NOT NULL,
	[passwd] [varchar](30) NOT NULL,
	[noTelp] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[pembayaran] ADD  DEFAULT ('Pending') FOR [statusBayar]
GO
ALTER TABLE [dbo].[pembayaran]  WITH CHECK ADD FOREIGN KEY([pemesanan_id])
REFERENCES [dbo].[pemesanan] ([pemesanan_id])
GO
ALTER TABLE [dbo].[pemesanan]  WITH CHECK ADD FOREIGN KEY([id_user])
REFERENCES [dbo].[users] ([id_user])
GO
ALTER TABLE [dbo].[penerbangan]  WITH CHECK ADD FOREIGN KEY([id_maskapai])
REFERENCES [dbo].[maskapai] ([id_maskapai])
GO
ALTER TABLE [dbo].[tiket]  WITH CHECK ADD FOREIGN KEY([id_penerbangan])
REFERENCES [dbo].[penerbangan] ([id_penerbangan])
GO
ALTER TABLE [dbo].[tiket]  WITH CHECK ADD FOREIGN KEY([id_penumpang])
REFERENCES [dbo].[penumpang] ([id_Penumpang])
GO
ALTER TABLE [dbo].[tiket]  WITH CHECK ADD FOREIGN KEY([pemesanan_id])
REFERENCES [dbo].[pemesanan] ([pemesanan_id])
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD  CONSTRAINT [check_email] CHECK  (([email] like '%_@_%._%'))
GO
ALTER TABLE [dbo].[admin] CHECK CONSTRAINT [check_email]
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD  CONSTRAINT [chk_password] CHECK  ((len([password])>=(8)))
GO
ALTER TABLE [dbo].[admin] CHECK CONSTRAINT [chk_password]
GO
ALTER TABLE [dbo].[pembayaran]  WITH CHECK ADD  CONSTRAINT [chk_statusBayar] CHECK  (([statusBayar]='Gagal' OR [statusBayar]='Berhasil' OR [statusBayar]='Pending'))
GO
ALTER TABLE [dbo].[pembayaran] CHECK CONSTRAINT [chk_statusBayar]
GO
ALTER TABLE [dbo].[pemesanan]  WITH CHECK ADD  CONSTRAINT [chk_statusPesan] CHECK  (([statusPesan]='canceled' OR [statusPesan]='confirmed' OR [statusPesan]='pending'))
GO
ALTER TABLE [dbo].[pemesanan] CHECK CONSTRAINT [chk_statusPesan]
GO
ALTER TABLE [dbo].[penumpang]  WITH CHECK ADD  CONSTRAINT [chk_jnsKelamin] CHECK  (([jnsKelamin]='laki-laki' OR [jnsKelamin]='perempuan'))
GO
ALTER TABLE [dbo].[penumpang] CHECK CONSTRAINT [chk_jnsKelamin]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [chk_email] CHECK  (([email] like '%_@_%._%'))
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [chk_email]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [chk_noTelp] CHECK  (([noTelp] like '+62%' AND (len([noTelp])>=(11) AND len([noTelp])<=(14))))
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [chk_noTelp]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [chk_passwd] CHECK  ((len([passwd])>=(8)))
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [chk_passwd]
GO
