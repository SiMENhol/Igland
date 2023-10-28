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
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('123321', 'Kunde1');
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
INSERT INTO Ordre (OrdreNummer, SerieNummer, VareNavn, Status, Arbdokument) VALUES ('32112312', '22222', 'SerieNR1', 'Godkjent', 'Arbdokument');
 create table if not EXISTS ServiceSkjema
(
    ServiceSkjemaID int PRIMARY KEY,
    OrdreNummer int,
    Aarsmodel int,
    Garanti varchar(255),
    Reparasjonsbeskrivelse varchar(255),
    MedgaatteDeler varchar(255),
    DeleRetur varchar(255),
    ForesendelsesMaate varchar(255),
    foreign key(OrdreNummer) references Ordre(OrdreNummer)
);
INSERT INTO ServiceSkjema (ServiceSkjemaID, Aarsmodel, Garanti, Reparasjonsbeskrivelse, MedgaatteDeler, DeleRetur, ForesendelsesMaate) VALUES ('92321', '2010', 'Ja', 'Vinsj reparasjon', '1 del, 2 deler', 'Returdeler', 'Hentes av kunde' );
 create table if not EXISTS ArbDokument
(
    ArbeidsDokumentID int PRIMARY KEY auto_increment,
    OrdreNummer int,
    Kunde varchar(255),
    Vinsj varchar(255),
    HenvendelseMotatt DATETIME,
    AvtaltLevering DATETIME,
    ProduktMotatt DATETIME,
    SjekkUtfort DATETIME,
    AvtaltFerdig DATETIME,
    ServiceFerdig DATETIME,
    AntallTimer int,
    BestillingFraKunde varchar(255),
    NotatFraMekaniker varchar(255),
    Status varchar(255),
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