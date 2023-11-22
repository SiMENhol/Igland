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

 create table if not EXISTS Ordre
(
    OrdreNummer int PRIMARY KEY,
    KundeID int,
    SerieNummer varchar(30),
    VareNavn varchar(30),
    Status varchar(30),
    FOREIGN KEY (KundeId) 
        REFERENCES Kunder (KundeId)
); 

 create table if not EXISTS ServiceDokument
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

 create table if not EXISTS ArbDok
(
    ArbDokID int PRIMARY KEY auto_increment,
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
 CREATE TABLE IF NOT EXISTS Sjekkliste
(
    SjekklisteID int PRIMARY KEY AUTO_INCREMENT,
    OrdreNummer int,
    MekanikerKommentar varchar(255),
    MekanikerNavn varchar(100),
    Dato date,
    SerieNummer varchar(255),
    AntallTimer decimal,
    StatusString varchar(255),
    FOREIGN KEY(OrdreNummer) REFERENCES Ordre(OrdreNummer)
);

 CREATE TABLE IF NOT EXISTS SjekklisteItem
(
    SjekklisteItemID int PRIMARY KEY AUTO_INCREMENT,
    SjekklisteID int,
    Jobs varchar(255),
    JobGroups varchar(255),
    RadioButtonValue varchar(20),
    FOREIGN KEY(SjekklisteID) REFERENCES Sjekkliste(SjekklisteID)
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