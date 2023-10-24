drop database IglandMVCdb;
create database if not exists IglandMVCdb;
use IglandMVCdb;
create table if not EXISTS users
(
    Id int not null unique auto_increment,
    Name varchar(255),
    Email varchar(255) UNIQUE,
   
    CONSTRAINT U_User_ID_PK PRIMARY KEY (Id)
);
INSERT INTO users (Id, Name, Email) VALUES ('1', 'Igland Admin', 'Igland@example.com');

 create table if not EXISTS Kunder
(
    KundeId int PRIMARY KEY,
    KundeNavn varchar(100)
);
 create table if not EXISTS Ordre
(
    OrdreNummer int PRIMARY KEY,
    KundeId int,
    SerieNummer varchar(30),
    VareNavn varchar(30),
    Status varchar(30),
    Arbdokument varchar(255),
    FOREIGN KEY (KundeId) 
        REFERENCES Kunder (KundeId)
); 
 create table if not EXISTS ServiceSkjema
(
    ServiceSkjemaID int PRIMARY KEY,
    OrdreNummer int,
    Aarsmodel int,
    Garanti varchar(255),
    Reperasjonbeskrivelse varchar(255),
    MedgåtteDeler varchar(255),
    DeleRetur varchar(255),
    ForesendelsesMaate varchar(255),
    foreign key(OrdreNummer) references Ordre(OrdreNummer)
);
 create table if not EXISTS ArbDokument
(
    ArbDokumentID int PRIMARY KEY,
    OrdreNummer int,
    DatoHenvendelse DATE,
    AvtaltLevering DATE,
    ProduktMotttat DATE,
    AvtaltFerdig DATE,
    foreign key(OrdreNummer)
        references Ordre(OrdreNummer)
);
 create table if not EXISTS Sjekkliste
(
    SjekklisteID int PRIMARY KEY,
    OrdreNummer int,
    Sjekklisteinnholdet varchar(255),
    Kommentar varchar(255),
    Signatur varchar(100),
    Dato datetime,
    SerieNr int,
    Type varchar(255),
    foreign key(OrdreNummer)
        references Ordre(OrdreNummer)
);
 create table if not EXISTS SjekklisteItem
(
    SjekklisteItemID int PRIMARY KEY,
    SjekklisteID int,
    CheckBoksNavn varchar(255),
    CheckboksValue varchar(255),
    foreign key(SjekklisteID)
        references Sjekkliste(SjekklisteID)
);       
 create table if not EXISTS KoblingsTabell
(
    OrdreNummer int,
    Avdeling varchar(255),
    KoblingsTabellID int PRIMARY KEY,
    TidsbrukPerAvdeling varchar(255),
    foreign key(OrdreNummer)
        references Ordre(OrdreNummer)
);     
 create table if not EXISTS Avdeling
(
    Rolle varchar(255) PRIMARY KEY,
    KoblingsTabellID int,
    AvdelingsID int,
    foreign key(KoblingsTabellID)
        references KoblingsTabell(KoblingsTabellID)
);
SHOW TABLES;