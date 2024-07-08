#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["ExpenseControl.API/ExpenseControl.API.csproj", "ExpenseControl.API/"]
COPY ["ExpenseControl.Application/ExpenseControl.Application.csproj", "ExpenseControl.Application/"]
COPY ["ExpenseControl.Domain.Services/ExpenseControl.Domain.Services.csproj", "ExpenseControl.Domain.Services/"]
COPY ["ExpenseControl.Data/ExpenseControl.Data.csproj", "ExpenseControl.Data/"]
COPY ["ExpenseControl.Domain/ExpenseControl.Domain.csproj", "ExpenseControl.Domain/"]
COPY ["ExpenseControl.Infra/ExpenseControl.Infra.csproj", "ExpenseControl.Infra/"]
COPY ["ExpenseControl.CrossCutting/ExpenseControl.CrossCutting.csproj", "ExpenseControl.CrossCutting/"]
RUN dotnet restore "./ExpenseControl.API/ExpenseControl.API.csproj"
COPY . .
WORKDIR "/src/ExpenseControl.API"
RUN dotnet build "./ExpenseControl.API.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ExpenseControl.API.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExpenseControl.API.dll"]