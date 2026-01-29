# مرحله Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# کپی فایل solution
COPY *.slnx ./

# کپی همه csproj ها
COPY JWT.Api/*.csproj JWT.Api/
COPY JWT.Application/*.csproj JWT.Application/
COPY JWT.Domain/*.csproj JWT.Domain/
COPY JWT.Infrastructure/*.csproj JWT.Infrastructure/

# Restore روی solution
RUN dotnet restore

# کپی کل سورس
COPY . .

# Publish پروژه API
RUN dotnet publish JWT.Api/JWT.Api.csproj -c Release -o out

# مرحله Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "JWT.Api.dll"]
