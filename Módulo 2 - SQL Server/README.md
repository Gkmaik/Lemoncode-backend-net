# Básico 1


## Arranco SQL Server en Docker
* Monto imagen docker de SQL Server 2017 usando Git Bash
~~~
docker run -e "ACCEPT_EULA=Y" \
-e "SA_PASSWORD=Lem0nCode!" \
-e "MSSQL_PID=Express" \
-p 1433:1433 \
--name sqlserver \
-d mcr.microsoft.com/mssql/server:2017-latest-ubuntu
~~~
* Entro al terminal
~~~
docker exec -it sqlserver bash
~~~
* Al sqlcmd le otorgo permisis de sysadmin y un password
~~~
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Lem0nCode!
~~~

## Restaurar una BBDD y crear una serie de consultas para recuperar información
* Descargo la base de datos LemonMusic.bak proporcionada por el enunciado del Básico 1
* Abro Git Bash, me ubico en la unidad C y copio la base de datos descargada a mi imagen docker que le he llamado _sqlserver_, en la caperta temporal _temp_.
~~~
docker cp ./LemonMusic.bak sqlserver:/tmp
~~~

### A third-level heading

~~~
Esto es código
~~~
