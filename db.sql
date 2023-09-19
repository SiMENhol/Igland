DROP DATABASE IF EXISTS Igland;						-- Sletter database Igland hvis den eksistere
CREATE DATABASE Igland;								-- Lager en database ved navn Igland
USE Igland;											-- Velger � bruke databasen Igland

CREATE TABLE navnPaaTable(							-- Lager ny table
RAD1 int(10) PRIMARY KEY NOT NULL,					-- Lager en ny rad som int som ikke kan v�re null, som ogs� er prim�rn�kkel
RAD2 varchar(255) UNIQUE,							-- Ny rad som kan v�re null og er unik
RAD3 datetime NOT NULL								-- Ny rad med dato
);

INSERT INTO navnPaaTable(RAD1, RAD2, RAD3) VALUES
('123', 'RAD2 INFO', '2023-09-19 12:53:56'),
('456', 'RAD2 INFOO', '2023-09-19 12:53:56');

--ALTER TABLE navnPaaTable							-- Endrer p� tabell
--ADD PRIMARY KEY (RAD1);							-- Setter RAD1 som prim�rn�kkel