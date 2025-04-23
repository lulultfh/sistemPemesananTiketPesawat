create database sistemPemesananTiketPesawat

CREATE TABLE users (
    id_user INT PRIMARY KEY,
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
    negara_asal VARCHAR(30) NOT NULL,
);

Create table penerbangan(
	id_penerbangan varchar(10) primary key,
	noPenerbangan varchar(7) unique,
	tujuan varchar(50) not null,
	asal varchar(50) not null,
	waktuBrgkt datetime not null,
	waktuKedatangan dateTime,
	harga decimal(10,2),
	id_maskapai varchar(7) foreign key references maskapai(id_maskapai),
);

--baru sampai maskapai

create table pemesanan(
	pemesanan_id char(8) PRIMARY KEY,
	waktuPesan DATETIME not null,
	statusPesan VARCHAR(10) NOT NULL, 
	CONSTRAINT chk_statusPesan CHECK (statusPesan IN ('pending', 'confirmed' ,'canceled')),
	id_user int foreign key references users(id_user) not null,
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

INSERT INTO users (id_user, nama, email, passwd, noTelp) VALUES
(1, 'Amelia Salsabila', 'amliayaa@egmail.com', 'inipassword', '+628123456789');

INSERT INTO maskapai (id_maskapai, nama_maskapai, kode_maskapai, negara_asal) values
('MSK001', 'Garuda Indonesia', 'GA', 'Indonesia');

insert into penerbangan (id_penerbangan, noPenerbangan, tujuan, asal, waktuBrgkt, waktuKedatangan, harga, id_maskapai) values
('PNB001', 'GA1234', 'Jakarta', 'Yogyakarta', '2025-05-01 08:00:00', '2025-05-01 09:30:00', 750000.00, 'MSK001');

insert into pemesanan (pemesanan_id, waktuPesan, statusPesan, id_user) values
('PMS00123', '2025-04-23 10:00:00', 'confirmed', 1);

insert into pembayaran (id_pembayaran, jumlah_bayar, tanggal_bayar, statusBayar, pemesanan_id) values
(1, 750000.00, '2025-04-23 10:30:00', 'Berhasil', 'PMS00123');

insert into admin(id_admin, nama, email, password) values
(1, 'Super Admin 1', 'superadmin@stmtiket.com', 'isipasswordnya');

insert into penumpang (id_Penumpang, namaLengkap, tanggalLahir, jnsKelamin, kewarganegaraan) values
('PNP0001', 'Amelia Salsabila', '2001-07-15', 'perempuan', 'Indonesia');

insert into tiket (id_tiket, pemesanan_id, id_penumpang, id_penerbangan, kodeTiket) values
('TKT0001', 'PMS00123', 'PNP0001', 'PNB001', 'GA1234A');