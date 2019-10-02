-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jun 15, 2019 at 05:08 PM
-- Server version: 10.1.19-MariaDB
-- PHP Version: 5.6.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hospital`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` varchar(30) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `date` date NOT NULL,
  `address` varchar(200) NOT NULL,
  `tel` varchar(20) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `first_name`, `last_name`, `date`, `address`, `tel`, `password`) VALUES
('22', 'admin', 'admin', '2019-08-03', 'fffff', '2345', '1234'),
('45678', 'hasitha', 'perera', '2019-06-03', 'kandy', '67542987', ''),
('a1234', 'malinda', 'sumathipala', '2018-06-07', 'no 8,nittabuwa road,veyangoda', '0773762975', '1234'),
('a4534', 'nadun', 'gunawardana', '2020-06-07', 'no 78,nittabuwa road,kiridiwela', '077356843', '1234'),
('a6700', 'kasun', 'rasidu', '2018-06-07', 'no 5,haduwa,polonnaruwa', '0753298678', '1234'),
('a9977', 'gihan', 'chathuranga', '2019-06-07', 'no 34,kaduwela , colombo 6', '0765439876', '1234');

-- --------------------------------------------------------

--
-- Table structure for table `appointment`
--

CREATE TABLE `appointment` (
  `id` int(20) NOT NULL,
  `std_id` varchar(20) NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `note` varchar(500) NOT NULL,
  `completed` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `appointment`
--

INSERT INTO `appointment` (`id`, `std_id`, `date`, `time`, `note`, `completed`) VALUES
(12, 's1234', '2019-06-07', '02:15:00', 'leg issue', 'yes'),
(13, 's3456', '2019-06-08', '09:40:00', 'hand issue', 'no'),
(14, 's9876', '2019-06-08', '06:40:00', 'feaver', 'yes'),
(15, 's9874', '2019-06-09', '17:20:00', 'alagic', 'yes'),
(16, 's8945', '2019-06-10', '08:20:00', 'stomak issue', 'yes'),
(17, 'sss', '2019-06-13', '00:00:00', 'dfrf', 'yes'),
(18, '4', '2019-06-11', '02:15:00', 'ffffffffffffffff', 'yes'),
(19, 's1234', '2019-06-12', '00:00:00', 'lllllll', 'yes'),
(20, 's1234', '2019-06-12', '00:00:00', '55555', 'yes');

-- --------------------------------------------------------

--
-- Table structure for table `doctor`
--

CREATE TABLE `doctor` (
  `id` varchar(20) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `date` date NOT NULL,
  `address` varchar(200) NOT NULL,
  `tel` varchar(20) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `doctor`
--

INSERT INTO `doctor` (`id`, `first_name`, `last_name`, `date`, `address`, `tel`, `password`) VALUES
('123', 'doc', 'tor', '2019-06-05', 'ws', '34', '1234'),
('d1095', 'prasad', 'siriwardana', '2016-06-07', 'no 21,kadawatha road,colombo 3', '0754297456', '1234'),
('d1234', 'kamal', 'subasinha', '1981-06-06', 'no 56 gampaha road, colombo 2', '077724674', '1234'),
('d5410', 'kapila', 'nirmal', '2017-06-07', 'no 23,kiribathgoda road,colombo 3', '0754294635', '1234'),
('d5687', 'nihal', 'gamage', '2018-06-07', 'no 36,trincomalle road,haputhale', '0776345297', '1234'),
('d6715', 'charitha', 'dissanayake', '2017-06-05', 'no 03,gampaha road,colombo 3', '0706745230', '1234');

-- --------------------------------------------------------

--
-- Table structure for table `drug`
--

CREATE TABLE `drug` (
  `id` int(20) NOT NULL,
  `name` varchar(30) NOT NULL,
  `exp` date NOT NULL,
  `qty` int(10) NOT NULL,
  `unit` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `drug`
--

INSERT INTO `drug` (`id`, `name`, `exp`, `qty`, `unit`) VALUES
(1, 'penadol', '2019-06-08', 55, ''),
(2, 'betadin', '2019-08-09', 66, ''),
(4, 'sitrexine', '2020-06-05', 252, ''),
(5, 'bensine', '2019-06-06', 5, ''),
(6, 'sergical', '2019-06-06', 2, ''),
(7, 'alcohol', '2020-06-07', 680, ''),
(8, 'adrilanine', '2019-06-07', 527, ''),
(9, 'amoxiline', '2019-08-07', 945, ''),
(10, 'oxigen', '2019-08-12', 192, ''),
(11, 'anti bactiriya', '2019-08-09', 259, ''),
(12, 'ttt', '2019-06-08', 77, ''),
(13, 'hhhh', '2019-06-12', 558, 'g');

-- --------------------------------------------------------

--
-- Table structure for table `drug_issue`
--

CREATE TABLE `drug_issue` (
  `Order_ID` int(11) NOT NULL,
  `Student_ID` varchar(50) NOT NULL,
  `Date` date NOT NULL,
  `Drugs` varchar(800) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `drug_issue`
--

INSERT INTO `drug_issue` (`Order_ID`, `Student_ID`, `Date`, `Drugs`) VALUES
(1, 's1234', '2019-06-14', 'penadol	2019-06-08	10\r\nsergical	2019-06-06	10\r\n		\r\n'),
(2, 's2345', '2019-06-14', 'adrilanine		10\r\namoxiline		20\r\n		\r\n'),
(3, 's4567', '2019-06-14', 'oxigen		20\r\nanti bactiriya		13\r\nsitrexine		13\r\n		\r\n'),
(4, 's1234', '2019-06-15', 'penadol	tds	3\r\nbetadin	tds	3\r\n		\r\n'),
(5, 's1234', '2019-06-15', 'penadol	mone	2\r\nadrilanine	ads	3\r\noxigen	night	3\r\n		\r\n'),
(6, 's2345', '2019-06-15', 'penadol	2019-06-29 12:00:00 AM	10\r\nsitrexine	2020-06-05 12:00:00 AM	15\r\nadrilanine	2019-07-07 12:00:00 AM	5\r\n		\r\n'),
(7, 's1234', '2019-06-15', 'penadol	2019-06-29 12:00:00 AM	5\r\noxigen	2019-08-12 12:00:00 AM	15\r\n		\r\n'),
(8, 's2876', '2019-06-15', 'amoxiline	2019-08-07 12:00:00 AM	35\r\npenadol	2019-06-29 12:00:00 AM	5\r\nbetadin	2019-08-09 12:00:00 AM	5\r\noxigen	2019-08-12 12:00:00 AM	15\r\n		\r\n');

-- --------------------------------------------------------

--
-- Table structure for table `feedback`
--

CREATE TABLE `feedback` (
  `id` int(11) NOT NULL,
  `std_id` varchar(30) NOT NULL,
  `StudentName` varchar(50) NOT NULL,
  `message` varchar(500) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `feedback`
--

INSERT INTO `feedback` (`id`, `std_id`, `StudentName`, `message`, `date`) VALUES
(4, 's2345', 'chamath lakmuthu', 'Send feedback and review requests to your customers via text message using Feedback Requests via text are sent between 9AM-9PM in the time zone your business is located in.', '2019-06-08'),
(5, 's1234', 'saman perera', 'If you are an Agency or have a white-label account, you can manage plans per location. Pricing tiers for agencies and resellers have been updated on our ', '2019-06-08'),
(6, 's5056', 'nisith heshan', 'hello', '2019-06-09');

-- --------------------------------------------------------

--
-- Table structure for table `medical_history`
--

CREATE TABLE `medical_history` (
  `id` int(11) NOT NULL,
  `std_id` varchar(30) NOT NULL,
  `std_name` varchar(100) NOT NULL,
  `diagnostic` varchar(500) NOT NULL,
  `drug` varchar(800) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `medical_history`
--

INSERT INTO `medical_history` (`id`, `std_id`, `std_name`, `diagnostic`, `drug`, `date`) VALUES
(8, 's2345', 'chamath lakmuthu', 'Studies have found many health problems related to stress. Stress seems to worsen or increase the risk of conditions like obesity', 'penadol	2019-06-29 12:00:00 AM	10\r\nsitrexine	2020-06-05 12:00:00 AM	15\r\nadrilanine	2019-07-07 12:00:00 AM	5\r\n		\r\n', '2019-06-07'),
(9, 's2876', 'saman kumara', 'risk of conditions like obesity, heart disease, Alzheimer''s disease, diabetes, depression, gastrointestinal problems, and asthma.', 'anti bactiriya	2019-08-09 12:00:00 AM	20\r\namoxiline	2019-08-07 12:00:00 AM	35\r\npenadol	2019-06-29 12:00:00 AM	5\r\nbetadin	2019-08-09 12:00:00 AM	5\r\noxigen	2019-08-12 12:00:00 AM	15\r\n		\r\n', '2019-06-07'),
(10, 's1234', 'saman perera', 'risk of conditions like obesity, heart disease, Alzheimer''s disease, diabetes, depression, gastrointestinal problems, and asthma.', 'anti bactiriya	2019-08-09 12:00:00 AM	20\r\npenadol	2019-06-29 12:00:00 AM	5\r\noxigen	2019-08-12 12:00:00 AM	15\r\n		\r\n', '2019-06-07'),
(11, 's1234', 'saman perera', 'er''s disease, diabetes, depression, gastrointestinal problems, and asthma.', 'anti bactiriya	2019-08-09 12:00:00 AM	20\r\npenadol	2019-06-29 12:00:00 AM	5\r\noxigen	2019-08-12 12:00:00 AM	15\r\n		\r\n', '2019-06-07'),
(12, 's1234', 'saman perera', 'gfhfgf', 'sergical	2019-06-06 12:00:00 AM	5\r\nadrilanine	2019-06-07 12:00:00 AM	6\r\n		\r\n', '2019-06-08'),
(13, 's1234', 'saman perera', 'sss', 'penadol	2019-06-08 12:00:00 AM	20\r\n		\r\n', '2019-06-09'),
(14, '4', ' ggg', 'ffh', 'penadol	2019-06-08 12:00:00 AM	0\r\n		\r\n', '2019-06-11'),
(15, '4', ' ggg', 'dff', 'penadol	2019-06-08 12:00:00 AM	0\r\n		\r\n', '2019-06-11'),
(16, 'sss', 'sss', 'sss', 'penadol	2019-06-08 12:00:00 AM	06\r\n		\r\n', '2019-06-11'),
(17, 's1234', 'saman perera', 'ddddd', 'penadol	2019-06-08 12:00:00 AM	6\r\n		\r\n', '2019-06-12'),
(18, 's1234', 'saman perera', 'hhhhhh', 'sergical	2019-06-06 12:00:00 AM	7\r\n		\r\n', '2019-06-12'),
(19, 's1234', 'saman perera', 'fghghh', 'penadol	tds	3\r\n		\r\n', '2019-06-15'),
(20, 's1234', 'saman perera', 'ttttttttttttttttttttt', 'penadol	tds	2\r\nsergical	tds	2\r\n		\r\n', '2019-06-15'),
(21, 's1234', 'saman perera', 'ggggggggggggggggggg', 'amoxiline	tds	3\r\n		\r\n', '2019-06-15'),
(22, 's1234', 'saman perera', 'dff', 'anti bactiriya	tds	6\r\n		\r\n', '2019-06-15');

-- --------------------------------------------------------

--
-- Table structure for table `pharmasist`
--

CREATE TABLE `pharmasist` (
  `id` varchar(30) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `date` date NOT NULL,
  `address` varchar(200) NOT NULL,
  `tel` varchar(20) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pharmasist`
--

INSERT INTO `pharmasist` (`id`, `first_name`, `last_name`, `date`, `address`, `tel`, `password`) VALUES
('11', 'pha', 'pharmasist', '2019-06-11', 'ddrf', '2345', '1234'),
('123q', 'darshana', 'nadeera', '2019-06-03', 'nittabuwa', '5765432', ''),
('p1234', 'gayani', 'perera', '1993-06-06', 'no 86, trincomalee road ,kanthale', '0785342954', '1234'),
('p7855', 'anushka', 'gamage', '1999-06-07', 'no 4,haldaduwana road,colombo 4', '0754874523', '1234'),
('p9438', 'sudipa', 'kumari', '2000-06-07', 'no 45,weliweriya road,colombo 4', '0754390897', '1234'),
('p9753', 'chathura', 'galapatha', '1998-06-07', 'no 98,hambanthota, kandy', '0754329875', '1234'),
('p9988', 'gihani', 'sammani', '1997-06-07', 'no 56,dabulla road, kandy', '0786345234', '1234');

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `id` varchar(20) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `bday` date NOT NULL,
  `address` varchar(200) NOT NULL,
  `tel` varchar(20) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`id`, `first_name`, `last_name`, `bday`, `address`, `tel`, `password`) VALUES
('s1234', 'saman', 'perera', '1995-01-06', 'no 3, udugampola road , minuwangoda', '0763529754', '1234'),
('s2345', 'chamath', 'lakmuthu', '1996-06-07', 'no 56,meegamu road, halawatha.', '0762396436', '1234'),
('s2876', 'saman', 'kumara', '1994-06-07', 'no 34,ballapana road,kurunegala', '0786543297', '1234'),
('s2996', 'lakmal', 'kumara', '1996-06-07', 'no 36,kdawatha road,kiribathgoda', '0756563297', '1234'),
('s3356', 'darshana', 'nadeera', '1995-06-07', 'no 9,dambulla road,trincomalee', '0712356893', '1234'),
('s3456', 'nisith', 'heshan', '2019-06-10', 'gampaha', '0876543216', '1234'),
('s5056', 'nisith', 'heshan', '1995-06-29', '80/6 ,veyangoda road,naiwala', '0718136893', '1234');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `appointment`
--
ALTER TABLE `appointment`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `doctor`
--
ALTER TABLE `doctor`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `drug`
--
ALTER TABLE `drug`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `drug_issue`
--
ALTER TABLE `drug_issue`
  ADD PRIMARY KEY (`Order_ID`);

--
-- Indexes for table `feedback`
--
ALTER TABLE `feedback`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `medical_history`
--
ALTER TABLE `medical_history`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `pharmasist`
--
ALTER TABLE `pharmasist`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appointment`
--
ALTER TABLE `appointment`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT for table `drug`
--
ALTER TABLE `drug`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- AUTO_INCREMENT for table `drug_issue`
--
ALTER TABLE `drug_issue`
  MODIFY `Order_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `feedback`
--
ALTER TABLE `feedback`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `medical_history`
--
ALTER TABLE `medical_history`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
