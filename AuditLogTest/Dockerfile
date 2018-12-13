FROM microsoft/aspnetcore-build AS build
WORKDIR /build

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o output

FROM microsoft/aspnetcore
WORKDIR /app

EXPOSE 80/tcp

COPY --from=build /build/output .

ENTRYPOINT ["dotnet","AuditLogTest.dll"]