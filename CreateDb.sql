drop database IglandMVCdb;
create database if not exists IglandMVCdb;
use IglandMVCdb;
create table if not EXISTS aspnetusers
(
    Id int not null unique auto_increment,
    PasswordHash varchar(255),
     UserName varchar(255),
    Name varchar(255),
    NormalizedUserName varchar(255),
    Email varchar(255) UNIQUE,
    NormalizedEmail varchar(255),
    IsAdmin BOOLEAN,
    ConcurrencyStamp varchar(255),
    AccessFailedCount int not null,
    EmailConfirmed bit not null,
    LockoutEnabled bit not null,
    LockoutEnd TIMESTAMP,
    PhoneNumber varchar(50),
             PhoneNumberConfirmed bit not null,
         TwoFactorEnabled bit not null,
         SecurityStamp varchar(255),
   
    CONSTRAINT U_User_ID_PK PRIMARY KEY (Id)
);
INSERT INTO aspnetusers (Id, Password, Name, Email, IsAdmin, AccessFailedCount, EmailConfirmed) VALUES ('1', 'Igland Admin', '12345', 'Igland@example.com', True, '4', True);
INSERT INTO aspnetusers (Id, Password, Name, Email, IsAdmin, AccessFailedCount, EmailConfirmed) VALUES ('2', 'Avdeling 1', '12345','Avdeling1@Igland.com', False, '4', True);
INSERT INTO aspnetusers (Id, Password, Name, Email, IsAdmin, AccessFailedCount, EmailConfirmed) VALUES ('3', 'Avdeling 2', '12345','Avdeling2@Igland.com', False, '4', True);
INSERT INTO aspnetusers (Id, Password, Name, Email, IsAdmin, AccessFailedCount, EmailConfirmed) VALUES ('4', 'Avdeling 3', '12345','Avdeling3@Igland.com', False, '4', True);

 create table if not EXISTS Kunder
(
    KundeID int PRIMARY KEY auto_increment,
    KundeNavn varchar(100)
);
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('100', 'Kunde1');
 create table if not EXISTS Ordre
(
    OrdreNummer int PRIMARY KEY auto_increment,
    KundeID int,
    SerieNummer varchar(30),
    VareNavn varchar(30),
    Status varchar(30),
    Arbdokument varchar(255),
    FOREIGN KEY (KundeId) 
        REFERENCES Kunder (KundeId)
); 
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status, Arbdokument) VALUES ('10000000', '100', '22222', 'SerieNR1', 'Godkjent', 'Arbdokument');
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