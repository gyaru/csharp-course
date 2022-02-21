-- golf cup assignment --
-- create commands --

-- drop if it already exists
drop database golf;
create database golf;
USE golf;

-- spelare
CREATE TABLE `spelare` (
    `namn` varchar(255) NOT NULL,
    `pnr` varchar(12) NOT NULL UNIQUE,
    `ålder` int NOT NULL,
    PRIMARY KEY (`pnr`)
) ENGINE = InnoDB;

-- tävling
CREATE TABLE `tävling` (
    `namn` varchar(255) NOT NULL UNIQUE,
    `datum` DATE NOT NULL,
    PRIMARY KEY (`namn`)
) ENGINE = InnoDB;

-- jacka
CREATE TABLE `jacka` (
    `initialer` varchar(20) NOT NULL,
    `storlek` varchar(20) NOT NULL,
    `material` varchar(20) NOT NULL,
    `pnr` varchar(12) NOT NULL,
    PRIMARY KEY (`pnr`, `initialer`),
    FOREIGN KEY(`pnr`) references spelare(pnr)
) ENGINE = InnoDB;

-- konstruktion
CREATE TABLE `konstruktion` (
    `serialnr` int NOT NULL AUTO_INCREMENT,
    `hårdhet` varchar(10) NOT NULL,
    PRIMARY KEY (`serialnr`)
) ENGINE = InnoDB;

-- klubba
CREATE TABLE `klubba` (
    `nr` int NOT NULL AUTO_INCREMENT,
    `material` varchar(20) NOT NULL,
    `pnr` varchar(12) NOT NULL,
    `serialnr` int NOT NULL,
    PRIMARY KEY (`nr`, `pnr`, `serialnr`),
    FOREIGN KEY(`pnr`) references spelare(pnr)
    ON DELETE CASCADE,
    FOREIGN KEY(`serialnr`) references konstruktion(`serialnr`)
) ENGINE = InnoDB;

-- regn
CREATE TABLE `regn` (
    `typ` varchar(20) NOT NULL,
    `vindstyrka` varchar(20) NOT NULL,
    PRIMARY KEY (`typ`)
) ENGINE = InnoDB;

-- spelare som deltar i tävling
CREATE TABLE `tävling_spelare` (
    `pnr` varchar(12) NOT NULL,
    `tävlingsnamn` varchar(30) NOT NULL,
    FOREIGN KEY(`pnr`) REFERENCES spelare(`pnr`)
    ON DELETE CASCADE,
    FOREIGN KEY(`tävlingsnamn`) REFERENCES tävling(namn)
) ENGINE = InnoDB;

-- regn på event
CREATE TABLE `tävling_regn` (
    `tid` varchar(20) NOT NULL,
    `typ` varchar(20) NOT NULL,
    `tävlingsnamn` varchar(255) NOT NULL,
    FOREIGN KEY(`tävlingsnamn`) REFERENCES tävling(namn),
    FOREIGN KEY(`typ`) REFERENCES regn(`typ`)
) ENGINE = InnoDB;