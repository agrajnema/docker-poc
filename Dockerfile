#Build stage
FROM microsoft/aspnetcore-build AS build
WORKDIR /build

#Restore
COPY AuditLogTest/AuditLogTest.csproj ./AuditLogTest/
RUN dotnet restore AuditLogTest/AuditLogTest.csproj

COPY AuditLogUnitTest/AuditLogUnitTest.csproj ./AuditLogUnitTest/
RUN dotnet restore AuditLogUnitTest/AuditLogUnitTest.csproj

#Copy src
COPY . .

#Run Test
RUN dotnet test AuditLogUnitTest/AuditLogUnitTest.csproj

#Publish 
RUN dotnet publish AuditLogTest/AuditLogTest.csproj -o /publish

#Runtime stage
FROM microsoft/aspnetcore
COPY --from=build /publish /publish
WORKDIR /publish
ENTRYPOINT ["dotnet", "AuditLogTest.dll"]