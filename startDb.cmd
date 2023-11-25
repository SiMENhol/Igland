@echo off

echo Killing existing container mariadb
:: Kill running instance of container
docker kill mariadb

echo.
echo Creating container mariadb
: : Starts the database
docker run --rm --env "TZ=Europe/Oslo" --name mariadb -p 3308:3306/tcp -v "%cd%\database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:10.5.11

: : Wait for container to be up
timeout /t 5 /NOBREAK > nul

echo.
echo Creating database...
echo Creating tables:
: : Run sql script
docker exec -i mariadb mysql  -uroot -p12345 < CreateDb.sql

: : Run sql script for dummydata
docker exec -i mariadb mysql  -uroot -p12345 < Dummydata.sql
echo.
echo Dummydata inserted

echo.
echo Hvis alle 14 tabellene kom opp og ingen feilmelding
echo er databasen riktig satt opp
echo.
pause
