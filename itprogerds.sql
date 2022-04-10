-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Apr 08, 2022 at 05:27 PM
-- Server version: 5.6.34-log
-- PHP Version: 7.1.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `itprogerds`
--

-- --------------------------------------------------------

--
-- Table structure for table `ispolniteli`
--

CREATE TABLE `ispolniteli` (
  `id` int(40) UNSIGNED NOT NULL,
  `name` varchar(40) NOT NULL,
  `surname` varchar(40) NOT NULL,
  `age` int(40) NOT NULL,
  `NumberZakaza` int(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ispolniteli`
--

INSERT INTO `ispolniteli` (`id`, `name`, `surname`, `age`, `NumberZakaza`) VALUES
(1, 'Андрей', 'Белов', 28, 0);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) UNSIGNED NOT NULL,
  `login` varchar(100) NOT NULL,
  `pass` varchar(32) NOT NULL,
  `name` varchar(100) NOT NULL,
  `surname` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `login`, `pass`, `name`, `surname`) VALUES
(1, 'DrDima', '12345', '', ''),
(2, 'Yutachi', '1234', 'Yutachi', 'Karisak'),
(3, 'dream', '12345', 'Dima', 'Sitnik'),
(5, 'ursus', '12345', 'Dimka', 'On');

-- --------------------------------------------------------

--
-- Table structure for table `vidiwork`
--

CREATE TABLE `vidiwork` (
  `id` int(40) UNSIGNED NOT NULL,
  `work` varchar(100) NOT NULL,
  `cost` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `vidiwork`
--

INSERT INTO `vidiwork` (`id`, `work`, `cost`) VALUES
(1, 'Системой планово-предупредительного ремонта', 25000),
(2, 'Текущий ремонт ', 1500),
(3, 'Средний ремонт', 4500),
(4, 'Капитальный ремонт', 10000);

-- --------------------------------------------------------

--
-- Table structure for table `zakazhik`
--

CREATE TABLE `zakazhik` (
  `id` int(40) UNSIGNED NOT NULL,
  `name` varchar(40) NOT NULL,
  `surname` varchar(40) NOT NULL,
  `id_zakaz` int(40) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `zakazhik`
--

INSERT INTO `zakazhik` (`id`, `name`, `surname`, `id_zakaz`) VALUES
(1, 'Сергей', 'Федосеев', 2),
(2, 'Александр', 'Пустовой', 3);

-- --------------------------------------------------------

--
-- Table structure for table `zakaz_remont`
--

CREATE TABLE `zakaz_remont` (
  `id_zakaz` int(40) UNSIGNED NOT NULL,
  `vid_work` varchar(40) NOT NULL,
  `zakachik` varchar(40) NOT NULL,
  `cost` int(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `zakaz_remont`
--

INSERT INTO `zakaz_remont` (`id_zakaz`, `vid_work`, `zakachik`, `cost`) VALUES
(1, 'Текущий ремонт ', 'Максим', 1800),
(2, 'Средний ремонт', 'Сергей', 6430),
(3, 'Капитальный ремонт', 'Александр', 12000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ispolniteli`
--
ALTER TABLE `ispolniteli`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `vidiwork`
--
ALTER TABLE `vidiwork`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `zakazhik`
--
ALTER TABLE `zakazhik`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `zakaz_remont`
--
ALTER TABLE `zakaz_remont`
  ADD PRIMARY KEY (`id_zakaz`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `ispolniteli`
--
ALTER TABLE `ispolniteli`
  MODIFY `id` int(40) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `vidiwork`
--
ALTER TABLE `vidiwork`
  MODIFY `id` int(40) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `zakazhik`
--
ALTER TABLE `zakazhik`
  MODIFY `id` int(40) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `zakaz_remont`
--
ALTER TABLE `zakaz_remont`
  MODIFY `id_zakaz` int(40) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
