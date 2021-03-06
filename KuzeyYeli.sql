USE master;
GO

DROP DATABASE KuzeyYeli;
CREATE DATABASE KuzeyYeli;
GO

USE KuzeyYeli;
GO

CREATE TABLE Kategoriler
(
	Id INT PRIMARY KEY IDENTITY,
	KategoriAd NVARCHAR(50) NOT NULL,
	UstKategoriId INT FOREIGN KEY REFERENCES Kategoriler(Id) NULL
);
GO

CREATE TABLE Urunler
(
	Id INT PRIMARY KEY IDENTITY,
	KategoriId INT FOREIGN KEY REFERENCES Kategoriler(Id) ON DELETE CASCADE NOT NULL,
	UrunAd NVARCHAR(50) NOT NULL,
	BirimFiyat DECIMAL(18, 2) NOT NULL,
	StokAdet INT NOT NULL,
	Resim VARBINARY(MAX) NULL
);
GO

INSERT INTO Kategoriler(KategoriAd, UstKategoriId) VALUES
(N'İçecekler', NULL), (N'Süt Ürünleri', NULL), (N'Meyve/Sebze', NULL), (N'Temizlik Ürünleri', NULL),
(N'Elektronik', NULL), (N'Cep Telefonu', 5), (N'Bilgisayar', 5), (N'Televizyon',5);

INSERT INTO Urunler(KategoriId, UrunAd, BirimFiyat, StokAdet) VALUES
(1, N'Kola', 4, 20),
(1, N'Fanta', 4, 40),
(1, N'Redbull', 6, 0),
(2, N'Süt', 4.5, 50),
(2, N'Yoğurt', 5, 10),
(3, N'Elma', 3.95, 60),
(3, N'Ananas', 10, 0),
(4, N'Çamaşır Suyu', 8.95, 15),
(4, N'Sıvı Sabun', 12.49, 20),
(6, N'Samsung Galaxy M31', 3671.33, 5),
(6, N'XiaomiRedmi Note 9 Pro', 3769.96, 4);
