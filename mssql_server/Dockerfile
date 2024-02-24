FROM mcr.microsoft.com/mssql/server:2019-CU14-ubuntu-20.04

COPY setup.sql setup.sql
COPY setup_database.sh setup_database.sh
COPY entrypoint.sh entrypoint.sh

CMD /bin/bash ./entrypoint.sh