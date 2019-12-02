-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 17, 2018 at 01:40 PM
-- Server version: 5.6.20
-- PHP Version: 5.5.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `projek`
--

-- --------------------------------------------------------

--
-- Table structure for table `anggota`
--

CREATE TABLE IF NOT EXISTS `anggota` (
  `Nim` varchar(15) NOT NULL,
  `Nama` text NOT NULL,
  `Kelas` varchar(10) NOT NULL,
  `Jurusan` varchar(25) NOT NULL,
  `No_Hp` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `anggota`
--

INSERT INTO `anggota` (`Nim`, `Nama`, `Kelas`, `Jurusan`, `No_Hp`) VALUES
('160102032', ' erlin', ' TI16A1', ' Informatika', ' 08921232'),
('160103013', ' Dicky ', ' TI16A1', ' Teknik Informatika', ' 08933293823'),
('160103015', ' Edy Kurniawan ', ' TI16A1', ' Teknik Informatika', ' 08788338777');

-- --------------------------------------------------------

--
-- Table structure for table `buku`
--

CREATE TABLE IF NOT EXISTS `buku` (
  `Kode_Buku` varchar(10) NOT NULL,
  `Judul` varchar(25) NOT NULL,
  `Penulis` text NOT NULL,
  `Penerbit` varchar(20) NOT NULL,
  `Tahun_Terbit` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `buku`
--

INSERT INTO `buku` (`Kode_Buku`, `Judul`, `Penulis`, `Penerbit`, `Tahun_Terbit`) VALUES
('AB12', ' Logika Informatika', ' Dr.Hamka', ' Cahaya Karya', 2010),
('AC01', ' Belajar Coding PHP', ' Edo', ' Rumah Terbit', 2017),
('AC03', ' Struktur Data', ' Indah N', ' Stmikdb', 2081);

-- --------------------------------------------------------

--
-- Table structure for table `peminjaman`
--

CREATE TABLE IF NOT EXISTS `peminjaman` (
  `Kode_Pinjam` varchar(10) NOT NULL,
  `Nim` varchar(15) NOT NULL,
  `Kode_Buku` varchar(20) NOT NULL,
  `Tanggal_Pinjam` date NOT NULL,
  `Tanggal_Kembali` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `peminjaman`
--

INSERT INTO `peminjaman` (`Kode_Pinjam`, `Nim`, `Kode_Buku`, `Tanggal_Pinjam`, `Tanggal_Kembali`) VALUES
('PAB11', ' 160102032', ' AB12', '2018-01-17', '2018-01-21'),
('PAB12', ' 160103015', ' AB12', '2018-01-17', '2018-01-19'),
('PC12', ' 160102032', ' AB12', '2018-01-17', '2018-01-18');

-- --------------------------------------------------------

--
-- Table structure for table `pengembalian`
--

CREATE TABLE IF NOT EXISTS `pengembalian` (
  `Kode_Pinjam` varchar(10) NOT NULL,
  `Kode_Buku` varchar(10) NOT NULL,
  `Nim` varchar(15) NOT NULL,
  `Tanggal_Kembali` date NOT NULL,
  `Jatuh_Tempo` varchar(15) NOT NULL,
  `Denda_Perhari` int(10) NOT NULL,
  `Total_Denda` int(10) NOT NULL,
  `Tanggal_Pinjam` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pengembalian`
--

INSERT INTO `pengembalian` (`Kode_Pinjam`, `Kode_Buku`, `Nim`, `Tanggal_Kembali`, `Jatuh_Tempo`, `Denda_Perhari`, `Total_Denda`, `Tanggal_Pinjam`) VALUES
('C002', '  AC01', '  160103015', '2018-01-23', ' 2', 2000, 4000, '2018-01-17'),
('C12', '  AB12', '  160103015', '2018-01-22', ' 4', 2000, 8000, '2018-01-17');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `username` varchar(10) NOT NULL,
  `password` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`username`, `password`) VALUES
('admin', 'admin');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `anggota`
--
ALTER TABLE `anggota`
 ADD PRIMARY KEY (`Nim`);

--
-- Indexes for table `buku`
--
ALTER TABLE `buku`
 ADD PRIMARY KEY (`Kode_Buku`);

--
-- Indexes for table `peminjaman`
--
ALTER TABLE `peminjaman`
 ADD PRIMARY KEY (`Kode_Pinjam`);

--
-- Indexes for table `pengembalian`
--
ALTER TABLE `pengembalian`
 ADD PRIMARY KEY (`Kode_Pinjam`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
 ADD PRIMARY KEY (`username`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
