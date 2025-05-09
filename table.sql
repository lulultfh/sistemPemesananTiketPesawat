USE [sistemPemesananTiketPesawat]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 17/04/2025 16:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[id_admin] [int] NOT NULL,
	[id_maskapai] [int] NULL,
	[nama] [varchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](255) NOT NULL,
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
/****** Object:  Table [dbo].[maskapai]    Script Date: 17/04/2025 16:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[maskapai](
	[id_maskapai] [int] NOT NULL,
	[nama_maskapai] [varchar](50) NOT NULL,
	[kode_maskapai] [varchar](10) NOT NULL,
	[negara_asal] [varchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[pembayaran]    Script Date: 17/04/2025 16:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pembayaran](
	[id_pembayaran] [int] NOT NULL,
	[kode_pemesanan] [varchar](20) NOT NULL,
	[status] [varchar](10) NULL,
	[metode_pembayaran] [varchar](20) NOT NULL,
	[jumlah_bayar] [decimal](10, 2) NOT NULL,
	[tanggal_bayar] [datetime] NULL,
	[statusBayar] [varchar](10) NULL,
	[pemesanan_id] [int] NOT NULL,
	[tiket_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pembayaran] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[kode_pemesanan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pemesanan]    Script Date: 17/04/2025 16:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pemesanan](
	[pemesanan_id] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[id_penerbangan] [char](6) NULL,
	[waktu_pemesanan] [datetime] NOT NULL,
	[statusPesanan] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pemesanan_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[penerbangan]    Script Date: 17/04/2025 16:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[penerbangan](
	[id_penerbangan] [char](6) NOT NULL,
	[noPenerbangan] [varchar](7) NULL,
	[tujuan] [varchar](50) NOT NULL,
	[asal] [varchar](50) NOT NULL,
	[waktuBrgkt] [datetime] NULL,
	[waktuKedatangan] [datetime] NULL,
	[harga] [decimal](10, 2) NULL,
	[id_maskapai] [int] NOT NULL,
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
/****** Object:  Table [dbo].[penumpang]    Script Date: 17/04/2025 16:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[penumpang](
	[id_Penumpang] [int] NOT NULL,
	[namaLengkap] [varchar](50) NOT NULL,
	[tanggalLahir] [date] NOT NULL,
	[jenisKelamin] [varchar](9) NOT NULL,
	[nasionalisme] [varchar](20) NOT NULL,
	[id_penerbangan] [char](6) NULL,
	[pemesanan_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Penumpang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tiket]    Script Date: 17/04/2025 16:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tiket](
	[tiket_id] [int] NOT NULL,
	[pemesanan_id] [int] NOT NULL,
	[id_Penumpang] [int] NOT NULL,
	[kodeTiket] [varchar](7) NULL,
	[id_penerbangan] [char](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tiket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[kodeTiket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 17/04/2025 16:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id_user] [int] NOT NULL,
	[nama] [varchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[no_telepon] [varchar](15) NULL,
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
ALTER TABLE [dbo].[pembayaran] ADD  DEFAULT ('Pending') FOR [status]
GO
ALTER TABLE [dbo].[pembayaran] ADD  DEFAULT (getdate()) FOR [tanggal_bayar]
GO
ALTER TABLE [dbo].[pembayaran] ADD  DEFAULT ('Pending') FOR [statusBayar]
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD FOREIGN KEY([id_maskapai])
REFERENCES [dbo].[maskapai] ([id_maskapai])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[pembayaran]  WITH CHECK ADD FOREIGN KEY([pemesanan_id])
REFERENCES [dbo].[pemesanan] ([pemesanan_id])
GO
ALTER TABLE [dbo].[pembayaran]  WITH CHECK ADD FOREIGN KEY([tiket_id])
REFERENCES [dbo].[tiket] ([tiket_id])
GO
ALTER TABLE [dbo].[pemesanan]  WITH CHECK ADD FOREIGN KEY([id_penerbangan])
REFERENCES [dbo].[penerbangan] ([id_penerbangan])
GO
ALTER TABLE [dbo].[pemesanan]  WITH CHECK ADD FOREIGN KEY([id_user])
REFERENCES [dbo].[users] ([id_user])
GO
ALTER TABLE [dbo].[penerbangan]  WITH CHECK ADD FOREIGN KEY([id_maskapai])
REFERENCES [dbo].[maskapai] ([id_maskapai])
GO
ALTER TABLE [dbo].[penumpang]  WITH CHECK ADD FOREIGN KEY([id_penerbangan])
REFERENCES [dbo].[penerbangan] ([id_penerbangan])
GO
ALTER TABLE [dbo].[penumpang]  WITH CHECK ADD FOREIGN KEY([pemesanan_id])
REFERENCES [dbo].[pemesanan] ([pemesanan_id])
GO
ALTER TABLE [dbo].[tiket]  WITH CHECK ADD FOREIGN KEY([id_penerbangan])
REFERENCES [dbo].[penerbangan] ([id_penerbangan])
GO
ALTER TABLE [dbo].[tiket]  WITH CHECK ADD FOREIGN KEY([id_Penumpang])
REFERENCES [dbo].[penumpang] ([id_Penumpang])
GO
ALTER TABLE [dbo].[tiket]  WITH CHECK ADD FOREIGN KEY([pemesanan_id])
REFERENCES [dbo].[pemesanan] ([pemesanan_id])
GO
ALTER TABLE [dbo].[pembayaran]  WITH CHECK ADD  CONSTRAINT [chk_metode_pembayaran] CHECK  (([metode_pembayaran]='Virtual Account' OR [metode_pembayaran]='E-Wallet' OR [metode_pembayaran]='Kartu Kredit' OR [metode_pembayaran]='TransferBank'))
GO
ALTER TABLE [dbo].[pembayaran] CHECK CONSTRAINT [chk_metode_pembayaran]
GO
ALTER TABLE [dbo].[pembayaran]  WITH CHECK ADD  CONSTRAINT [chk_statusBayar] CHECK  (([statusBayar]='Gagal' OR [statusBayar]='Berhasil' OR [statusBayar]='Pending'))
GO
ALTER TABLE [dbo].[pembayaran] CHECK CONSTRAINT [chk_statusBayar]
GO
ALTER TABLE [dbo].[pemesanan]  WITH CHECK ADD  CONSTRAINT [chk_status] CHECK  (([statusPesanan]='canceled' OR [statusPesanan]='confirmed' OR [statusPesanan]='pending'))
GO
ALTER TABLE [dbo].[pemesanan] CHECK CONSTRAINT [chk_status]
GO
