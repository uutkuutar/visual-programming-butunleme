-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3306
-- Üretim Zamanı: 16 Oca 2023, 15:50:48
-- Sunucu sürümü: 5.7.36
-- PHP Sürümü: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `okul`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `dersler`
--

DROP TABLE IF EXISTS `dersler`;
CREATE TABLE IF NOT EXISTS `dersler` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dersadi` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `akts` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `donem` varchar(5) COLLATE utf8mb4_turkish_ci NOT NULL,
  `ogretmen` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`,`dersadi`,`akts`,`donem`,`ogretmen`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `dersler`
--

INSERT INTO `dersler` (`id`, `dersadi`, `akts`, `donem`, `ogretmen`) VALUES
(2, 'qwe', '1', 'w', 'w'),
(3, 'ttttttt', '1', 'ee', 'e');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ogrenciler`
--

DROP TABLE IF EXISTS `ogrenciler`;
CREATE TABLE IF NOT EXISTS `ogrenciler` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ad` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `soyad` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `mail` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `sifre` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `telno` varchar(12) COLLATE utf8mb4_turkish_ci NOT NULL,
  `adres` text COLLATE utf8mb4_turkish_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `ogrenciler`
--

INSERT INTO `ogrenciler` (`id`, `ad`, `soyad`, `mail`, `sifre`, `telno`, `adres`) VALUES
(1, 'utku', 'utar', 'aaaaa', 'qwe', '123132', 'tttttttttttttttttttttttttttttttt');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ogretmenler`
--

DROP TABLE IF EXISTS `ogretmenler`;
CREATE TABLE IF NOT EXISTS `ogretmenler` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ad` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `soyad` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `mail` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `sifre` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `telno` varchar(12) COLLATE utf8mb4_turkish_ci NOT NULL,
  `alan` varchar(25) COLLATE utf8mb4_turkish_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `mail` (`mail`),
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `ogretmenler`
--

INSERT INTO `ogretmenler` (`id`, `ad`, `soyad`, `mail`, `sifre`, `telno`, `alan`) VALUES
(2, 'asdasd', 'das', 'asd', 'da', 'ads', 'Matemaik'),
(3, 'rrrrrrrrr', 'das', 'asd', 'da', 'hghjhgj', 'Matemaik');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
