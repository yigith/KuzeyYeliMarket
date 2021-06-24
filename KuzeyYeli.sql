USE master;
GO

CREATE DATABASE KuzeyYeli;
GO

USE KuzeyYeli;
GO

CREATE TABLE Kategoriler
(
	Id INT PRIMARY KEY IDENTITY,
	KategoriAd NVARCHAR(50) NOT NULL
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

INSERT INTO Kategoriler(KategoriAd) VALUES
(N'İçecekler'), (N'Süt Ürünleri'), (N'Meyve/Sebze'), (N'Temizlik Ürünleri');

INSERT INTO Urunler(KategoriId, UrunAd, BirimFiyat, StokAdet) VALUES
(1, N'Kola', 4, 20),
(1, N'Fanta', 4, 40),
(1, N'Redbull', 6, 0),
(2, N'Süt', 4.5, 50),
(2, N'Yoğurt', 5, 10),
(3, N'Elma', 3.95, 60),
(3, N'Ananas', 10, 0),
(4, N'Çamaşır Suyu', 8.95, 15),
(4, N'Sıvı Sabun', 12.49, 20);
