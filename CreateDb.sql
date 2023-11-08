drop database IglandMVCdb;
create database if not exists IglandMVCdb;
use IglandMVCdb;
create table if not EXISTS AspNetUsers
(
         Id varchar(255) not null unique,
         UserName varchar(255),
         NormalizedUserName varchar(255),
         Email varchar(255),
         NormalizedEmail varchar(255),
         EmailConfirmed bit not null,
         PasswordHash varchar(255),
         SecurityStamp varchar(255),
         ConcurrencyStamp varchar(255),
         PhoneNumber varchar(50),
         PhoneNumberConfirmed bit not null,
         TwoFactorEnabled bit not null,
         LockoutEnd TIMESTAMP,
         LockoutEnabled bit not null,
         AccessFailedCount int not null,
          CONSTRAINT PK_AspNetUsers PRIMARY KEY (Id)
);
insert into AspNetUsers(Id,UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values('9670b732-ccb2-4e90-87f5-8b31ce8655fb', 'Igland@mail.com', 'IGLAND@MAIL.COM', 'Igland@mail.com', 'IGLAND@MAIL.COM', True, 'AQAAAAIAAYagAAAAEJ4HQojIkMee85/uU6/LD85or3Sjq4EY/i8WTx1XuKKh9Ar6Ylb3EChdkFArT0A7lQ==', 'PNR4WUNX2ZG3EYFMP4GYZAACIJZ4KDEW', 'a2849db4-acc1-4c85-8333-8b098eec9e02', True, False, '2023-11-06 19:55:08',False, '0');
create table if not EXISTS AspNetRoles
(
    Id varchar(255) not null,
    Name varchar(255),
    NormalizedName  varchar(255),
    ConcurrencyStamp  varchar(255),
    CONSTRAINT U_ROLE_ID_PK PRIMARY KEY (Id)
);
insert into AspNetRoles(id, Name, NormalizedName) values('Administrator', 'Administrator', 'Administrator');
create table if not EXISTS AspNetUserTokens
(
    UserId varchar(255) not null,
    LoginProvider varchar(255) not null ,
    Name  varchar(255) not null,
    Value  varchar(255),
    CONSTRAINT PK_AspNetUserTokens PRIMARY KEY (UserId, LoginProvider)
);

create table if not EXISTS AspNetRoleClaims
(
    Id int UNIQUE auto_increment,
    ClaimType varchar(255) not null ,
    ClaimValue varchar(255) not null,
    RoleId varchar(255),
    CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY (Id),
    foreign key(RoleId) 
        references AspNetRoles(Id)
);      

 create table if not EXISTS AspNetUserClaims
(
    Id int UNIQUE auto_increment,
    ClaimType varchar(255),
    ClaimValue  varchar(255),
    UserId varchar(255),
    CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY (Id),
    foreign key(UserId) 
        references AspNetUsers(Id)
);           

 create table if not EXISTS AspNetUserLogins
(
    LoginProvider int UNIQUE auto_increment,
    ProviderKey varchar(255) not null ,
    ProviderDisplayName  varchar(255) not null,
    UserId varchar(255) not null,
    CONSTRAINT PK_AspNetUserLogins PRIMARY KEY (LoginProvider),
    foreign key(UserId) 
        references AspNetUsers(Id)
);         

 create table if not EXISTS AspNetUserRoles
(
    UserId varchar(255) not null,
    RoleId varchar(255) not null,
    CONSTRAINT PK_AspNetUserRoles PRIMARY KEY (UserId,RoleId),
    foreign key(UserId) 
        references AspNetUsers(Id),
    foreign key(RoleId) 
        references AspNetRoles(Id)
); 
 
 
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
    ServiceSkjemaID int PRIMARY KEY auto_increment,
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