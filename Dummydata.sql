use IglandMVCdb;
INSERT INTO AspNetUsers(Id,UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values('9670b732-ccb2-4e90-87f5-8b31ce8655fb', 'Igland@mail.com', 'IGLAND@MAIL.COM', 'Igland@mail.com', 'IGLAND@MAIL.COM', True, 'AQAAAAIAAYagAAAAEJ4HQojIkMee85/uU6/LD85or3Sjq4EY/i8WTx1XuKKh9Ar6Ylb3EChdkFArT0A7lQ==', 'PNR4WUNX2ZG3EYFMP4GYZAACIJZ4KDEW', 'a2849db4-acc1-4c85-8333-8b098eec9e02', True, False, '2023-11-06 19:55:08',False, '0');
INSERT INTO AspNetUsers(Id,UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values('9670b732-ccb2-4e90-87f5-8b31ce8655db', 'Elektro@mail.com', 'ELEKTRO@MAIL.COM', 'Elektro@mail.com', 'ELEKTRO@MAIL.COM', True, 'AQAAAAIAAYagAAAAEJ4HQojIkMee85/uU6/LD85or3Sjq4EY/i8WTx1XuKKh9Ar6Ylb3EChdkFArT0A7lQ==', 'PNR4WUNX2ZG3EYFMP4GYZAACIJZ4KDEW', 'a2849db4-acc1-4c85-8333-8b098eec9e02', True, False, '2023-11-06 19:55:08',False, '0');
INSERT INTO AspNetUsers(Id,UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values('9670b732-ccb2-4e90-87f5-8b31ce8655sd', 'Mekanisk@mail.com', 'MEKANISK@MAIL.COM', 'Mekanisk@mail.com', 'MEKANISK@MAIL.COM', True, 'AQAAAAIAAYagAAAAEJ4HQojIkMee85/uU6/LD85or3Sjq4EY/i8WTx1XuKKh9Ar6Ylb3EChdkFArT0A7lQ==', 'PNR4WUNX2ZG3EYFMP4GYZAACIJZ4KDEW', 'a2849db4-acc1-4c85-8333-8b098eec9e02', True, False, '2023-11-06 19:55:08',False, '0');
INSERT INTO AspNetUsers(Id,UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values('9670b732-ccb2-4e90-87f5-8b31ce8655vd', 'Hydraulisk@mail.com', 'HYDRAULISK@MAIL.COM', 'Hydraulisk@mail.com', 'HYDRAULISK@MAIL.COM', True, 'AQAAAAIAAYagAAAAEJ4HQojIkMee85/uU6/LD85or3Sjq4EY/i8WTx1XuKKh9Ar6Ylb3EChdkFArT0A7lQ==', 'PNR4WUNX2ZG3EYFMP4GYZAACIJZ4KDEW', 'a2849db4-acc1-4c85-8333-8b098eec9e02', True, False, '2023-11-06 19:55:08',False, '0');
INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('9670b732-ccb2-4e90-87f5-8b31ce8655fb', 'Administrator');
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('100', 'ABC Shipping AS');
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('101', 'IndustriTech Solutions');
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('102', 'ByggMester AS');
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('103', 'EnergiService Norge');
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('104', 'Shipping Solutions Ltd');
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('105', 'KonstruksjonsService AS');
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('106', 'Vindkraft Teknologi Norge');
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('107', 'OljeRig Driftselskap');
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('108', 'ElektroMarin AS');
INSERT INTO Kunder (KundeId, KundeNavn) VALUES ('109', 'Fiskeflåten Service');
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status) VALUES ('10000000', '100', '11111', 'SerieNR1', 'Case ferdig');
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status) VALUES ('10000001', '101', '22222', 'SerieNR2', 'Case ferdig');
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status) VALUES ('10000002', '102', '33333', 'SerieNR3', 'Service ferdig');
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status) VALUES ('10000003', '103', '44444', 'SerieNR4', 'Service ferdig');
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status) VALUES ('10000004', '104', '55555', 'SerieNR5', 'Sjekk utført');
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status) VALUES ('10000005', '105', '77777', 'SerieNR6', 'Sjekk utført');
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status) VALUES ('10000006', '106', '88888', 'SerieNR7', 'Produkt mottatt');
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status) VALUES ('10000007', '107', '99999', 'SerieNR8', 'Produkt mottatt');
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status) VALUES ('10000008', '108', '10000', 'SerieNR9', 'Ordre opprettet');
INSERT INTO Ordre (OrdreNummer, KundeID, SerieNummer, VareNavn, Status) VALUES ('10000009', '109', '11110', 'SerieNR10', 'Ordre opprettet');
INSERT INTO ServiceDokument (ServiceSkjemaID, OrdreNummer, Aarsmodel, Garanti, Reparasjonsbeskrivelse, MedgaatteDeler, DeleRetur, ForesendelsesMaate) 
VALUES 
('5000', '10000000', '2015', 'Ja', 'Vinsjens motor trenger service', 'Drev', 'Ingen', 'Hentes av kunde'),
('5001', '10000001', '2005', 'Nei', 'Ujevn vinsjedrift', 'Lager', 'Ja', 'Sendes via Post'),
('5002', '10000002', '2012', 'Nei', 'Slark i vinsjens kontrollpanel', 'Kontrollpanel', 'Ingen', 'Hentes av kunde'),
('5003', '10000003', '2019', 'Ja', 'Vinsjen stopper midt i bruk', 'Kabler', 'Ingen', 'Hentes av kunde'),
('5004', '10000004', '2010', 'Ja', 'Vinsjen er treg i nedover retning', 'Bremsesystem', 'Ingen', 'Sendes via Post'),
('5005', '10000005', '2008', 'Nei', 'Mistenkelig lyd under bruk', 'Lager', 'Ja', 'Hentes av kunde'),
('5006', '10000006', '2017', 'Nei', 'Vinsjen stopper ved belastning', 'Kontrollenhet', 'Ingen', 'Hentes av kunde'),
('5007', '10000007', '2014', 'Ja', 'Vinsjens hastighet er ujevn', 'Motor', 'Ingen', 'Sendes via Post'),
('5008', '10000008', '2011', 'Ja', 'Vinsjens fjernkontroll fungerer ikke', 'Fjernkontroll', 'Ja', 'Sendes via Post'),
('5009', '10000009', '2016', 'Nei', 'Vinsjen reagerer ikke på kommando', 'Elektronikk', 'Ingen', 'Hentes av kunde');
INSERT INTO ArbDok (ArbDokID, OrdreNummer, Kunde, Vinsj, HenvendelseMotatt, AvtaltLevering, ProduktMotatt, SjekkUtfort, AvtaltFerdig, ServiceFerdig, AntallTimer, BestillingFraKunde, NotatFraMekaniker, Status) 
VALUES 
('1', '10000000', '100', 'Vinsj 1', '2023-10-15 09:30:00', '2023-10-16 12:00:00', '2023-10-17 14:30:00', '2023-10-18 10:00:00', '2023-10-19 15:30:00', '2023-10-20 11:45:00', '4', 'Ja', 'Byttet ut defekt wire og utført generell service', 'Case ferdig'),
('2', '10000001', '101', 'Vinsj 2', '2023-10-15 11:45:00', '2023-10-16 14:00:00', '2023-10-17 16:45:00', '2023-10-18 12:30:00', '2023-10-19 18:00:00', '2023-10-20 14:15:00', '3', 'Nei', 'Bestilt reservedel, venter på levering', 'Case ferdig'),
('3', '10000002', '102', 'Vinsj 3', '2023-10-15 14:00:00', '2023-10-16 16:15:00', '2023-10-17 18:30:00', '2023-10-18 15:45:00', '2023-10-19 20:00:00', '2023-10-20 16:30:00', '5', 'Ja', 'Byttet ut defekt kontrollenhet, testet OK', 'Service ferdig'),
('4', '10000003', '103', 'Vinsj 4', '2023-10-15 16:15:00', '2023-10-16 18:30:00', '2023-10-17 20:45:00', '2023-10-18 17:00:00', '2023-10-19 21:15:00', '2023-10-20 18:45:00', '6', 'Ja', 'Utført grundig inspeksjon, ingen feil funnet', 'Service ferdig'),
('5', '10000004', '104', 'Vinsj 5', '2023-10-15 18:30:00', '2023-10-16 20:45:00', '2023-10-17 23:00:00', '2023-10-18 19:15:00', '2023-10-19 00:30:00', '2023-10-20 20:00:00', '4', 'Ja', 'Smurt opp bremsesystemet, nå fungerer det som det skal', 'Sjekk utført'),
('6', '10000005', '105', 'Vinsj 6', '2023-10-16 09:30:00', '2023-10-17 12:00:00', '2023-10-18 14:30:00', '2023-10-19 10:00:00', '2023-10-20 15:30:00', '2023-10-21 11:45:00', '3', 'Nei', 'Diagnose pågår, rapport følger', 'Sjekk utført'),
('7', '10000006', '106', 'Vinsj 7', '2023-10-16 11:45:00', '2023-10-17 14:00:00', '2023-10-18 16:45:00', '2023-10-19 12:30:00', '2023-10-20 18:00:00', '2023-10-21 14:15:00', '5', 'Ja', 'Byttet ut defekt motor, utført grundig test', 'Produkt mottatt'),
('8', '10000007', '107', 'Vinsj 8', '2023-10-16 14:00:00', '2023-10-17 16:15:00', '2023-10-18 18:30:00', '2023-10-19 15:45:00', '2023-10-20 20:00:00', '2023-10-21 16:30:00', '6', 'Ja', 'Byttet ut elektronikk, testet OK', 'Produkt mottatt'),
('9', '10000008', '108', 'Vinsj 9', '2023-10-16 16:15:00', '2023-10-17 18:30:00', '2023-10-18 20:45:00', '2023-10-19 17:00:00', '2023-10-20 21:15:00', '2023-10-21 18:45:00', '2', 'Ja', 'Raskt serviceoppdrag, ingen feil funnet', 'Ordre opprettet'),
('10', '10000009', '109', 'Vinsj 10', '2023-10-16 18:30:00', '2023-10-17 20:45:00', '2023-10-18 23:00:00', '2023-10-19 19:15:00', '2023-10-20 00:30:00', '2023-10-21 20:00:00', '4', 'Nei', 'Utført forebyggende vedlikehold, anbefalt bytte av slitedeler', 'Ordre opprettet');
INSERT INTO Sjekkliste (OrdreNummer, MekanikerKommentar, MekanikerNavn, Dato, SerieNummer, AntallTimer, StatusString)
VALUES
    ('10000000', 'Utført generell sjekk. Ingen problemer funnet.', 'Ole Hansen', '2023-11-22', 'Serie1', 5, '1,0,1,2,2,1,0,0,1,2,2,1,0,2,1,0,2,1,0,2,1,0,2'),
    ('10000001', 'Byttet olje og oljefilter.', 'Marianne Olsen', '2023-11-23', 'Serie2', 3, '0,1,2,2,1,0,0,1,2,2,1,0,2,1,0,2,1,0,2,1,0,2,1'),
    ('10000002', 'Oppdaget feil i bremsesystemet. Reparert og testet OK.', 'Per Andersson', '2023-11-24', 'Serie3', 8, '2,2,1,0,0,1,2,2,1,0,0,1,2,2,1,0,2,1,0,2,1,0,2,'),
    ('10000003', 'Skiftet tennplugger og luftfilter.', 'Kari Pedersen', '2023-11-25', 'Serie4', 6, '1,0,0,1,2,2,1,0,2,1,0,2,1,0,2,1,0,2,1,0,2,1,0'),
    ('10000004', 'Feilsøking av elektrisk system. Reparert kortsirkuit.', 'Geir Johansen', '2023-11-26', 'Serie5', 4, '2,1,0,0,1,2,2,1,0,0,1,2,2,1,0,2,1,0,2,1,0,2,'),
    ('10000005', 'Gjennomført service og rutinemessig vedlikehold.', 'Anne Berg', '2023-11-27', 'Serie6', 7, '0,1,2,2,1,0,0,1,2,2,1,0,2,1,0,2,1,0,2,1,0,2,1'),
    ('10000006', 'Diagnostisert motorproblemer og utført nødvendige reparasjoner.', 'Jonas Svendsen', '2023-11-28', 'Serie7', 2, '2,2,1,0,0,1,2,2,1,0,0,1,2,2,1,0,2,1,0,2,1,0,2,'),
    ('10000007', 'Fullført årlig inspeksjon og service.', 'Mette Nilsen', '2023-11-29', 'Serie8', 9, '1,0,0,1,2,2,1,0,2,1,0,2,1,0,2,1,0,2,1,0,2,1,0'),
    ('10000008', 'Reparert lekkasje i kjølesystemet og påfylt kjølevæske.', 'Thomas Andersen', '2023-11-30', 'Serie9', 3, '2,1,0,0,1,2,2,1,0,0,1,2,2,1,0,2,1,0,2,1,0,2,'),
    ('10000009', 'Utført grundig inspeksjon av bremser og byttet bremseklosser.', 'Ingrid Larsen', '2023-12-01', 'Serie10', 6, '0,1,2,2,1,0,0,1,2,2,1,0,2,1,0,2,1,0,2,1,0,2,1');