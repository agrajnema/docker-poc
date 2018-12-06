FROM boxfuse/flyway
WORKDIR /src
COPY Migrations/sql .
ENTRYPOINT flyway migrate -user=sa -password=Testing_123 -url="jdbc:sqlserver://db:1433;databaseName=master" -locations="filesystem:." -mixed=true