# IS200-1-2 prosjekt for Nøsted &

## Applikasjonens oppsett (arkitektur) 

For at klientens utviklere vet hva slags teknologier de må ha på plass for å sette opp 
applikasjonen 

For å sette opp applikasjonen trengs følgende teknologier:  

Docker brukes for å bygge og sette opp applikasjonen. 

MariaDB er en relasjonsdatabase og brukes for å lagre dataen. 

Github brukes for å lagre applikasjonens kode og sørger for versjonskontroll.  

 .NET, applikasjonen er skrevet i .NET 7.0, er dermed mulig det kan oppstå problemer hvis man prøver å kjøre koden med .NET 8.0 

En IDE som støtter .NET, vi har brukt Visual studio.  

 

## Hvordan applikasjonen kjøres (kjøring på Docker, kobling mot database, osv) 

For at klientens utviklere får kjøre applikasjonen på en riktig måte 


1. Installer Docker på systemet der applikasjonen skal kjøres.    

2. Klon applikasjonens kode fra Github til systemet der den skal kjøres. 

3. Finn hvor prosjekt mappen er plassert og kjør Startdb.cmd (startdb.sh for mac) fra prosjekt mappen. 

4. Bygg applikasjonen med Visual Studio. 

5. Kjør applikasjonen fra Visual Studio med Docker. 

 

 

## Komponenter av applikasjonen (MVC, repo, klasser, osv) 

For at klientens utviklere vet om komponentene som applikasjonen er oppbygget av, hva det gjør og hvorfor de er bygget slik 

Applikasjonen er bygget opp med følgende komponenter: 

### MVC 

  MVC er et rammeverk for programvareutvikling som skiller mellom data (model), logikk (controller) og visning (view). 

  Model: Representerer dataen i applikasjonen med klasser. 

  Controller: Behandler forespørsler fra brukere ved å kommunisere med model og view. 

  View: Presenterer dataen til brukerene. 

 

### Klasser 

  Klassene ligger i mappen "Model". 

  Klassene representerer dataen i applikasjonen. 

  For eksempel har klassen " ArbDokViewModel " informasjon om et arbeidsdokument, som ArbDokID, NotatFraMekaniker og Status. 

 

### Entity framework 

  Entity framework er et rammeverk som gjør det enklere å bruke dataen fra databasen. 

  Mappen "DataAccess" inneholder kode som bruker Entity framework til å kommunisere med databasen. 

  Mappen "Entities" består av dataen fra databasen, men representert som objekter slik at det er mulig å enklere jobbe med dataen i koden 

 

 

### Repository 

  Repository er et mønster som brukes til å håndtere data fra databasen. 

  I applikasjonen brukes repository til å gjøre det enklere å hente, lagre og oppdatere data fra databasen. 

  Mappen "Repository" inneholder implementasjonen av repository-mønsteret. 

 

### Database 

  Databasen ligger i mappen "Solution items". 

  Filen "CreateDb" inneholder oppsettet til databasen med alle tabellene	 

  Filen "StartDb" sørger for at databasen blir opprettet i Docker og starter CreateDb filen som lager tabellene. 

 

 

## Funksjonaliteter i applikasjonen (det som applikasjonen gjør) 

For at klientens utviklere vet hvilke krav spesifikasjoner ble utviklet som funksjonaliteter i applikasjonen, sånn at de vet hva bør utvikles videre 

 

Applikasjonen har følgende funksjonaliteter: 

### Brukeradministrasjon 

  Admin kan opprette, slette og endre rettigheter til brukere (avdelinger). 

### Dokumentbehandling 

  Brukere kan opprette, slette og redigere dokumenter. 

### Søk 

  Brukere kan søke i dokumentoversikten. 

### Autentisering 

  Brukere må logge inn for å få tilgang til applikasjonen. 

 

## Funksjonene kan brukes på følgende måte: 

### Brukeradministrasjon 

  Admin kan opprette nye brukere ved å fylle ut et skjema. 

  Admin kan slette brukere ved å velge brukeren og klikke på "Slett"-knappen. 

  Admin kan endre rettighetene til brukere ved å velge brukeren og klikke på "Gjør til administrator"-knappen. 

### Dokumentbehandling 

  Brukere kan opprette nye dokumenter ved å klikke på "Ny ordre"-knappen. 

  Brukere kan slette dokumenter ved å velge dokumentet og klikke på "Slett"-knappen. 

  Brukere kan redigere dokumenter ved å klikke på et eksisterende dokument. 

### Søk 

  Brukere kan søke i dokumentoversikten ved å skrive inn et søkeord i søkefeltet i dokumentoversikten. 

  Autentisering 

  Brukere kan logge inn ved å oppgi brukernavnet og passordet sitt. 
