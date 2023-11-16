#!/bin/bash

# Kill running instance of container
docker kill mariadb

# Start the database
docker run --rm --env "TZ=Europe/Oslo" --name mariadb -p 3308:3306/tcp -v "$(pwd)/database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:10.5.11

# Wait for the container to be up
sleep 5

# Run SQL script
docker exec -i mariadb mysql -uroot -p12345 < CreateDb.sql

# Run SQL script for dummy data
docker exec -i mariadb mysql -uroot -p12345 < Dummydata.sql

echo ""
echo "Hvis alle 15 tabellene kom opp og ingen feilmelding"
echo "er databasen riktig satt opp."
echo ""
read -p "Press Enter to continue..."
