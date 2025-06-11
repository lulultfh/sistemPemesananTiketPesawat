create database sistemPemesananTiketPesawat

CREATE TABLE pelanggan (
    id_pelanggan INT PRIMARY KEY,
    nama VARCHAR(100) NOT NULL,
    email VARCHAR(25) UNIQUE NOT NULL,
	constraint chk_email check(email LIKE '%_@_%._%'),
    passwd VARCHAR(30) NOT NULL,	
	constraint chk_passwd check(len(passwd)>=8), 
    noTelp VARCHAR(15) not null,
	constraint chk_noTelp check(noTelp like '+62%' and len(noTelp) between 11 and 14),
);




CREATE TABLE maskapai (
    id_maskapai varchar(7) PRIMARY KEY,
    nama_maskapai VARCHAR(30) NOT NULL,
    kode_maskapai VARCHAR(5) NOT NULL UNIQUE,
    negara_asal VARCHAR(30) NOT NULL
);



Create table penerbangan(
	id_penerbangan varchar(10) primary key,
	noPenerbangan varchar(7) unique,
	tujuan varchar(50) not null,
	asal varchar(50) not null,
	waktuBrgkt datetime not null,
	waktuKedatangan dateTime,
	harga decimal(10,2),
	id_maskapai varchar(7) foreign key references maskapai(id_maskapai)
);

--baru sampai maskapai

create table pemesanan(
	pemesanan_id char(8) PRIMARY KEY,
	waktuPesan DATETIME not null,
	statusPesan VARCHAR(10) NOT NULL, 
	CONSTRAINT chk_statusPesan CHECK (statusPesan IN ('pending', 'confirmed' ,'canceled')),
	id_pelanggan int foreign key references pelanggan(id_pelanggan) not null,
);

CREATE TABLE pembayaran (
    id_pembayaran INT PRIMARY KEY,
	jumlah_bayar DECIMAL(10,2) NOT NULL,
    tanggal_bayar DATETIME,
	statusBayar VARCHAR(10) DEFAULT 'Pending',
	CONSTRAINT chk_statusBayar CHECK (statusBayar IN ('Pending', 'Berhasil', 'Gagal')),
	pemesanan_id char(8) foreign key references pemesanan(pemesanan_id)
);

CREATE TABLE admin (
    id_admin INT PRIMARY KEY,
    nama VARCHAR(50) NOT NULL,
    email VARCHAR(25) UNIQUE NOT NULL,
	constraint check_email check(email LIKE '%_@_%._%'),
    password VARCHAR(25) NOT NULL,
	constraint chk_password check(len(password)>=8)
);

create table penumpang(
	id_Penumpang varchar(10) primary key,
	namaLengkap varchar(75) not null,
	tanggalLahir date not null,
	jnsKelamin varchar(9) not null,
	constraint chk_jnsKelamin check(jnsKelamin IN('perempuan', 'laki-laki')),
	kewarganegaraan varchar(20) not null,
);

create table tiket(
	id_tiket varchar(10) PRIMARY KEY,
	pemesanan_id char(8) foreign key references pemesanan(pemesanan_id) not null,
	id_penumpang varchar(10) foreign key references penumpang(id_penumpang) not null,
	id_penerbangan varchar(10) references penerbangan(id_penerbangan) not null,
	kodeTiket varchar(7) UNIQUE,
);

INSERT INTO pelanggan (id_pelanggan, nama, email, passwd, noTelp) VALUES
(1, 'Amelia Salsabila', 'amliayaa@egmail.com', 'inipassword', '+628123456789');

INSERT INTO maskapai (id_maskapai, nama_maskapai, kode_maskapai, negara_asal) values
('MSK001', 'Garuda Indonesia', 'GA', 'Indonesia');

insert into penerbangan (id_penerbangan, noPenerbangan, tujuan, asal, waktuBrgkt, waktuKedatangan, harga, id_maskapai) values
('PNB001', 'GA1234', 'Jakarta', 'Yogyakarta', '2025-05-01 08:00:00', '2025-05-01 09:30:00', 750000.00, 'MSK001');

insert into pemesanan (pemesanan_id, waktuPesan, statusPesan, id_pelanggan) values
('PMS00123', '2025-04-23 10:00:00', 'confirmed', 1);

insert into pembayaran (id_pembayaran, jumlah_bayar, tanggal_bayar, statusBayar, pemesanan_id) values
(1, 750000.00, '2025-04-23 10:30:00', 'Berhasil', 'PMS00123');

insert into admin(id_admin, nama, email, password) values
(1, 'Super Admin 1', 'superadmin@stmtiket.com', 'isipasswordnya');

insert into penumpang (id_Penumpang, namaLengkap, tanggalLahir, jnsKelamin, kewarganegaraan) values
('PNP0001', 'Amelia Salsabila', '2001-07-15', 'perempuan', 'Indonesia');

insert into tiket (id_tiket, pemesanan_id, id_penumpang, id_penerbangan, kodeTiket) values
('TKT0001', 'PMS00123', 'PNP0001', 'PNB001', 'GA1234A');

select * from penerbangan;

CREATE PROCEDURE addTiket
	@id_tiket varchar(10),
	@pemesanan_id char(8),
	@id_penumpang varchar(10),
	@id_penerbangan varchar(10),
	@kodeTiket varchar(7)
AS
BEGIN
	INSERT INTO tiket (id_tiket, pemesanan_id, id_penumpang, id_penerbangan, kodeTiket)
	VALUES (@id_tiket, @pemesanan_id, @id_penumpang, @id_penerbangan, @kodeTiket);
END;

create procedure updateTiket
	@id_tiket varchar(10),
	@pemesanan_id char(8),
	@id_penumpang varchar(10),
	@id_penerbangan varchar(10),
	@kodeTiket varchar(7)
AS
begin
	update tiket
	SET
		pemesanan_id = COALESCE(NULLIF(@pemesanan_id, ''), pemesanan_id),
        id_penumpang = COALESCE(NULLIF(@id_penumpang, ''), id_penumpang),
        id_penerbangan = COALESCE(NULLIF(@id_penerbangan, ''), id_penerbangan),
        kodeTiket = COALESCE(NULLIF(@kodeTiket, ''), kodeTiket)
	WHERE id_tiket = @id_tiket;
end;

create procedure deleteTiket
	@id_tiket varchar(10)
as
begin
	delete from tiket where id_tiket = @id_tiket;
end;

create procedure addPenerbangan
	@id_penerbangan varchar(10) = null,
	@noPenerbangan varchar(7) = null,
	@tujuan varchar(50) = null,
	@asal varchar(50) = null,
	@waktuBrgkt datetime = null,
	@waktuKedatangan dateTime = null,
	@harga decimal(10,2) = null,
	@id_maskapai varchar(7) = null
as
begin
	insert into penerbangan(id_penerbangan, noPenerbangan, tujuan, asal, waktuBrgkt, waktuKedatangan, harga, id_maskapai)
	values(@id_penerbangan, @noPenerbangan, @tujuan, @asal, @waktuBrgkt, @waktuKedatangan, @harga, @id_maskapai)
end;

create procedure updatePenerbangan
	@id_penerbangan varchar(10) = null,
	@noPenerbangan varchar(7) = null,
	@tujuan varchar(50) = null,
	@asal varchar(50) = null,
	@waktuBrgkt datetime = null,
	@waktuKedatangan dateTime = null,
	@harga decimal(10,2) = null,
	@id_maskapai varchar(7) = null
as
begin
	update penerbangan
	set
		noPenerbangan = COALESCE(NULLIF(@noPenerbangan, ''), noPenerbangan),
		tujuan = COALESCE(NULLIF(@tujuan, ''), tujuan),
		asal = COALESCE(NULLIF(@asal, ''), asal),
		waktuBrgkt = COALESCE(@waktuBrgkt, waktuBrgkt),
		waktuKedatangan = COALESCE(@waktuKedatangan, waktuKedatangan),
		harga = COALESCE(@harga, harga),
		id_maskapai = COALESCE(NULLIF(@id_maskapai, ''), id_maskapai)
	where id_penerbangan = @id_penerbangan;
end;

create procedure deletePenerbangan
	@id_penerbangan varchar(10) = null
as
begin
	delete from penerbangan where id_penerbangan = @id_penerbangan;
end;


--indeks pada kolom tiket untuk mempercepat pencarian berdasarkan kodeTiket
if not exists(
	select 1
	from sys.indexes
	where name = 'idx_tiket_kodeTiket'
		AND object_id = OBJECT_ID('dbo.tiket')
)
BEGIN
	create nonclustered index idx_tiket_kodeTiket
	on dbo.tiket(kodeTiket);
	print 'Created idx_tiket_kodeTiket';
END
ELSE
	print 'idx_tiket_kodeTiket sudah ada'


--indeks pada kolom penerbangan untuk mempercepat pencarian berdasarkan noPenerbangan, asal, tujuan
if not exists(
	select 1
	from sys.indexes
	where name = 'idx_noPnbAsalTujuan'
	AND object_id = OBJECT_ID('dbo.penerbangan')
)
begin
	create nonclustered index idx_noPnbAsalTujuan
	on dbo.penerbangan(noPenerbangan, asal, tujuan);
	print 'buat idx_noPnbAsalTujuan di tabel penerbangan.';
end
else
	print 'idx_noPnbAsalTujuan sudah ada.';
go;

CREATE PROCEDURE addPenumpang
    @id_Penumpang VARCHAR(10),
    @namaLengkap VARCHAR(75),
    @tanggalLahir DATE,
    @jnsKelamin VARCHAR(9),
    @kewarganegaraan VARCHAR(20)
AS
BEGIN
    INSERT INTO penumpang (id_Penumpang, namaLengkap, tanggalLahir, jnsKelamin, kewarganegaraan)
    VALUES (@id_Penumpang, @namaLengkap, @tanggalLahir, @jnsKelamin, @kewarganegaraan)
END;


CREATE PROCEDURE updatePenumpang
    @id_Penumpang VARCHAR(10),
    @namaLengkap VARCHAR(100),
    @tanggalLahir DATE,
    @jnsKelamin VARCHAR(20),
    @kewarganegaraan VARCHAR(50)
AS
BEGIN
    UPDATE penumpang
    SET namaLengkap = COALESCE(NULLIF(@namaLengkap, ''), namaLengkap),
        tanggalLahir = COALESCE(@tanggalLahir, tanggalLahir),
        jnsKelamin = COALESCE(NULLIF(@jnsKelamin, ''), jnsKelamin),
        kewarganegaraan = COALESCE(NULLIF(@kewarganegaraan, ''), kewarganegaraan)
    WHERE id_Penumpang = @id_Penumpang
END;


CREATE PROCEDURE deletePenumpang
    @id_Penumpang VARCHAR(10)
AS
BEGIN
    DELETE FROM penumpang WHERE id_Penumpang = @id_Penumpang
END;




CREATE PROCEDURE addPemesanan
    @pemesanan_id CHAR(8),
    @waktuPesan DATETIME,
    @statusPesan VARCHAR(10),
    @id_pelanggan INT
AS
BEGIN
    INSERT INTO pemesanan (pemesanan_id, waktuPesan, statusPesan, id_pelanggan)
    VALUES (@pemesanan_id, @waktuPesan, @statusPesan, @id_pelanggan)
END;


CREATE PROCEDURE updatePemesanan
    @pemesanan_id VARCHAR(10),
    @waktuPesan DATETIME,
    @statusPesan VARCHAR(20),
    @id_pelanggan INT
AS
BEGIN
    UPDATE pemesanan
    SET waktuPesan = COALESCE(@waktuPesan, waktuPesan),
        statusPesan = COALESCE(NULLIF(@statusPesan, ''), statusPesan),
        id_pelanggan = COALESCE(@id_pelanggan, id_pelanggan)
    WHERE pemesanan_id = @pemesanan_id
END;


CREATE PROCEDURE deletePemesanan
    @pemesanan_id CHAR(8)
AS
BEGIN
    DELETE FROM pemesanan WHERE pemesanan_id = @pemesanan_id
END;



--Optimisasi query untuk tabel Pemesanan
IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'idx_statusPesan'
    AND object_id = OBJECT_ID('dbo.pemesanan')
)
BEGIN
    CREATE NONCLUSTERED INDEX idx_statusPesan
    ON dbo.pemesanan (statusPesan);
    PRINT 'Indeks idx_statusPesan berhasil dibuat di tabel pemesanan.';
END
ELSE
    PRINT 'Indeks idx_statusPesan sudah ada di tabel pemesanan.';



--Optimisasi query untuk tabel Penumpang
IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'idx_namaKewarganegaraan'
    AND object_id = OBJECT_ID('dbo.penumpang')
)
BEGIN
    CREATE NONCLUSTERED INDEX idx_namaKewarganegaraan
    ON dbo.penumpang (namaLengkap, kewarganegaraan);
    PRINT 'Indeks idx_namaKewarganegaraan berhasil dibuat di tabel penumpang.';
END
ELSE
    PRINT 'Indeks idx_namaKewarganegaraan sudah ada di tabel penumpang.';

-- Tambah Maskapai
CREATE PROCEDURE Addmaskapai
    @id_maskapai VARCHAR(7),
    @nama_maskapai VARCHAR(30),
    @kode_maskapai VARCHAR(5),
    @negara_asal VARCHAR(30)
AS
BEGIN
    INSERT INTO maskapai (id_maskapai, nama_maskapai, kode_maskapai, negara_asal)
    VALUES (@id_maskapai, @nama_maskapai, @kode_maskapai, @negara_asal);
END;


-- Hapus Maskapai
CREATE PROCEDURE Deletemaskapai
    @id_maskapai VARCHAR(7)
AS
BEGIN
    DELETE FROM maskapai
    WHERE id_maskapai = @id_maskapai;
END;


-- Update Maskapai
CREATE PROCEDURE Updatemaskapai
    @id_maskapai VARCHAR(7),
    @nama_maskapai VARCHAR(30),
    @kode_maskapai VARCHAR(5),
    @negara_asal VARCHAR(30)
AS
BEGIN
    UPDATE maskapai
    SET nama_maskapai = COALESCE(NULLIF(@nama_maskapai, ''), nama_maskapai), 
        kode_maskapai = COALESCE(NULLIF(@kode_maskapai, ''), kode_maskapai),
        negara_asal = COALESCE(NULLIF(@negara_asal, ''), negara_asal) 
    WHERE id_maskapai = @id_maskapai;
END;

-- Tambah Admin
CREATE PROCEDURE Addadmin
    @id_admin INT,
    @nama VARCHAR(50),
    @email VARCHAR(25),
    @password VARCHAR(25)
AS
BEGIN
    INSERT INTO admin (id_admin, nama, email, password)
    VALUES (@id_admin, @nama, @email, @password);
END;


-- Hapus Admin
CREATE PROCEDURE Deleteadmin
    @id_admin INT
AS
BEGIN
    DELETE FROM admin
    WHERE id_admin = @id_admin;
END;


-- Update Admin
CREATE PROCEDURE Updateadmin
    @id_admin INT,
    @nama VARCHAR(50),
    @email VARCHAR(25),
    @password VARCHAR(25)
AS
BEGIN
    UPDATE admin
    SET nama = COALESCE(NULLIF(@nama, ''), nama),
        email = COALESCE(NULLIF(@email, ''), email),
        password = COALESCE(NULLIF(@password, ''), password)
    WHERE id_admin = @id_admin;
END;




-- 1. Indeks pada kolom nama_maskapai
IF NOT EXISTS (
    SELECT 1 
	FROM sys.indexes
    WHERE name = 'idx_Maskapai_Nama'
	AND object_id = OBJECT_ID('dbo.maskapai')
)
BEGIN
    CREATE NONCLUSTERED INDEX idx_Maskapai_Nama 
	ON dbo.maskapai(nama_maskapai);
    PRINT 'Created idx_Maskapai_Nama';
END
ELSE
    PRINT 'idx_Maskapai_Nama sudah ada.';

-- 2. Indeks pada kolom negara_asal 0
IF NOT EXISTS (
    SELECT 1 
	FROM sys.indexes
    WHERE name = 'idx_Maskapai_Negara'
	AND object_id = OBJECT_ID('dbo.maskapai')
)
BEGIN
    CREATE NONCLUSTERED INDEX idx_Maskapai_Negara 
	ON dbo.maskapai(negara_asal);
    PRINT 'Created idx_Maskapai_Negara';
END
ELSE
    PRINT 'idx_Maskapai_Negara sudah ada.';



	-- 1. Indeks pada kolom nama
IF NOT EXISTS (
    SELECT 1 
	FROM sys.indexes
    WHERE name = 'idx_Admin_Nama'
    AND object_id = OBJECT_ID('dbo.admin')
)
BEGIN
    CREATE NONCLUSTERED INDEX idx_Admin_Nama 
	ON dbo.admin(nama);
    PRINT 'Created idx_Admin_Nama';
END
ELSE
    PRINT 'idx_Admin_Nama sudah ada.';
	--
CREATE PROCEDURE addpelanggan
    @id_pelanggan INT,
    @nama VARCHAR(100),
    @email VARCHAR(25),
    @passwd VARCHAR(30),
    @noTelp VARCHAR(15)
AS
BEGIN
    INSERT INTO pelanggan (id_pelanggan, nama, email, passwd, noTelp)
    VALUES (@id_pelanggan, @nama, @email, @passwd, @noTelp);
END;


CREATE PROCEDURE updatepelanggan
    @id_pelanggan INT,
    @nama VARCHAR(100) = NULL,
    @email VARCHAR(25) = NULL,
    @passwd VARCHAR(30) = NULL,
    @noTelp VARCHAR(15) = NULL
AS
BEGIN
    UPDATE Pelanggan
    SET
        nama = COALESCE(NULLIF(@nama, ''), nama),
        email = COALESCE(NULLIF(@email, ''), email),
        passwd = COALESCE(NULLIF(@passwd, ''), passwd),
        noTelp = COALESCE(NULLIF(@noTelp, ''), noTelp)
    WHERE id_pelanggan = @id_pelanggan;
END;

CREATE PROCEDURE deletepelanggan
    @id_pelanggan INT
AS
BEGIN
    DELETE FROM pelanggan
    WHERE id_pelanggan = @id_pelanggan;
END;


CREATE PROCEDURE addpembayaran
    @id_pembayaran INT,
    @jumlah_bayar DECIMAL(10,2),
    @statusBayar VARCHAR(10),
    @pemesanan_id CHAR(8)
AS
BEGIN
    INSERT INTO pembayaran (id_pembayaran, jumlah_bayar, statusBayar, pemesanan_id)
    VALUES (@id_pembayaran, @jumlah_bayar, @statusBayar, @pemesanan_id);
END;

CREATE PROCEDURE updatepembayaran
    @id_pembayaran INT,
    @jumlah_bayar DECIMAL(10,2) = NULL,
    @statusBayar VARCHAR(10) = NULL,
    @pemesanan_id CHAR(8) = NULL
AS
BEGIN
    UPDATE pembayaran
    SET 
        jumlah_bayar  = COALESCE(@jumlah_bayar, jumlah_bayar),
        statusBayar   = COALESCE(@statusBayar, statusBayar),
        pemesanan_id  = COALESCE(@pemesanan_id, pemesanan_id)
    WHERE id_pembayaran = @id_pembayaran;
END;

CREATE PROCEDURE deletepembayaran
    @id_pembayaran INT
AS
BEGIN
    DELETE FROM pembayaran
    WHERE id_pembayaran = @id_pembayaran
END;


IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'idx_pembayaran_pemesanan_id'
        AND object_id = OBJECT_ID('dbo.pembayaran')
)
BEGIN
    CREATE NONCLUSTERED INDEX idx_pembayaran_pemesanan_id
    ON dbo.pembayaran(pemesanan_id);
    PRINT 'Created idx_pembayaran_pemesanan_id';
END
ELSE
    PRINT 'idx_pembayaran_pemesanan_id sudah ada';



IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'idx_pelanggan_email'
        AND object_id = OBJECT_ID('dbo.pelanggan')
)
BEGIN
    CREATE NONCLUSTERED INDEX idx_pelanggan_email
    ON dbo.pelanggan(email);
    PRINT 'Created idx_pelanggan_email';
END
ELSE
    PRINT 'idx_pelanggan_email sudah ada';