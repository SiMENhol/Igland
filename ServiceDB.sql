drop database Service;
CREATE database Service;
use Service;
CREATE TABLE Ordre 

( 

    OrdreNummer int PRIMARY KEY, 

    KundeID int, 

    SerieNummer varchar(30), 

    VareNavn varchar(30), 

    Status varchar(30), 

    ArbDokID int 

); 

 

CREATE TABLE Deler 

( 
ServiceDelerID int PRIMARY KEY auto_increment,

PaaLager bool,

Produktnavn varchar(50)


); 

 

CREATE TABLE Service 

( 

ServiceID int PRIMARY KEY, 

OrdreNummer int, 

ServiceDelerID int, 

EksterneDeler boolean,

EkterneDelerNaar DATETIME,

FOREIGN KEY (OrdreNummer) REFERENCES Ordre(OrdreNummer), 

FOREIGN KEY (ServiceDelerID) REFERENCES Deler(ServiceDelerID) 

);
-- Insert data into Ordre table
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status, ArbDokID)
VALUES 
(1, 101, 'SN123', 'Vinsj MK1', 'Venter', 201),
(2, 102, 'SN456', 'El-vinsj', 'Under arbeid', 202),
(3, 103, 'SN789', 'Spaktalje', 'Fullfort', 203),
(4, 104, 'SN101', 'Haandvinsj', 'Venter', 204),
(5, 105, 'SN202', 'Vinsj MK1', 'Under arbeid', 205),
(6, 106, 'SN303', 'Hydraulisk vinsj', 'Fullfort', 206),
(7, 107, 'SN404', 'Radiostyrt vinsj', 'Venter', 207),
(8, 108, 'SN505', 'El-vinsj', 'Under arbeid', 208),
(9, 109, 'SN606', 'Vinsj', 'Fullfort', 209),
(10, 110, 'SN707', 'Mini vinsj', 'Venter', 210);

-- Insert data into Deler table
INSERT INTO Deler (Produktnavn, PaaLager) VALUES
('Bolter', True),
('Skruer', True),
('Besnor', True),
('Socker Connector', True),
('Wire', True),
('Krok', True),
('Thumb Switch', True),
('Motor', True),
('Batteri', True),
('Vinsj Kontroller', True);

-- Insert data into Service table
INSERT INTO Service (ServiceID, OrdreNummer, ServiceDelerID, EksterneDeler, EkterneDelerNaar)
VALUES 
(101, 1, 1, 1, '2023-11-15 10:00:00'),
(102, 2, 2, 0, NULL),
(103, 3, 3, 1, '2023-11-20 14:30:00'),
(104, 4, 4, 1, '2023-11-25 09:45:00'),
(105, 5, 5, 0, NULL),
(106, 6, 6, 1, '2023-11-30 11:15:00'),
(107, 7, 7, 1, '2023-12-05 13:30:00'),
(108, 8, 8, 0, NULL),
(109, 9, 9, 1, '2023-12-10 16:00:00'),
(110, 10, 10, 1, '2023-12-15 08:45:00');

SELECT
    Service.ServiceID,
    Ordre.OrdreNummer,
    Deler.Produktnavn AS DelerNavn,
    Deler.PaaLager AS  'Er Paa Lager',
    Ordre.VareNavn AS VareNavn,
    EksterneDeler AS 'Krever utstyr som ikke er tilgjengelig',
    Service.EkterneDelerNaar AS 'Utstyr forventes tilgjengelig'
FROM
    Service
JOIN
    Ordre ON Service.OrdreNummer = Ordre.OrdreNummer
JOIN
    Deler ON Service.ServiceDelerID = Deler.ServiceDelerID
WHERE
    Deler.PaaLager = TRUE 
    AND Service.EksterneDeler = 1
ORDER BY
    Service.EkterneDelerNaar;