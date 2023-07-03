#!!!!!SETUP STEPS!!!!!
1. Execute next comment in terminal to get the current ip
ipconfig /all 
look at "Ethernet adapter vEthernet (WSL)" line
IPv4 Address. . . . . . . . . . . : [current_ip](Preferred)

2. Update host file on your PC:
   like this instruction https://www.nublue.co.uk/guides/edit-hosts-file/#:~:text=In%20Windows%2010%20the%20hosts,%5CDrivers%5Cetc%5Chosts.

Need to path these lines

    127.0.0.1 www.alevelwebsite.com
    [current_ip] www.alevelwebsite.com
    192.168.0.1 www.alevelwebsite.com

3. Turn off /turn on wifi to make windows use changed host file instead of cached.

4. Open http://www.alevelwebsite.com/

!!To connect to Postgres 
1. Open localhost:8001 (from docker.compose)
2. Login to pgAdmin with creds from docker.compose (section pgadmin4)
3. Click on "Add new server".
4. Fill Name (any value just to indetify the server).
5. Open Connection tab.
6. Fill in Host name/address with postgres container name from docker.compose (current value "postgres").
7. Use 5432 port (internal docker port of postgres container).
8. Username and password is specified in connection string of catalog.api section of docker.compose.
9. Save

!!To view db data
1. Expand server in Object explorer -> Databases -> devices -> Schemas -> public -> Tables -> [tableName] 
2. Use Context menu -> View/Edit data.


#docker
docker-compose build --no-cache

docker-compose up

#Add-Migration
dotnet ef --startup-project Catalog/Catalog.Host migrations add InitialMigration --project Catalog/Catalog.Host

#Update-Migration
dotnet ef --startup-project Catalog/Catalog.Host database update InitialMigration --project Catalog/Catalog.Host

#Remove-Migration
dotnet ef --startup-project Catalog/Catalog.Host migrations remove --project Catalog/Catalog.Host -f