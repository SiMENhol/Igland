@echo off

:: Kill running instance of container

docker kill mariadb

: : Starts the database
docker run --rm --env "TZ=Europe/Oslo" --name mariadb -p 3308:3306/tcp -v "%cd%\database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:10.5.11

: : Wait for container to be up
timeout /t 5

: : Run sql script
docker exec -i mariadb mysql  -uroot -p12345 < CreateDb.sql

: : Run sql script for dummydata
docker exec -i mariadb mysql  -uroot -p12345 < Dummydata.sql

:: Kill running instance of container
docker kill webapp

:: Builds image specified in Dockerfile
docker image build -t webapp .

:: Starts container with web application and maps port 80 (ext) to 80 (internal)
docker container run --rm -it -d --name webapp --publish 80:80 webapp

echo.
echo "Link: http://localhost:80/"
echo.

pause
