#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DicewareGenerator/DicewareGenerator.csproj", "DicewareGenerator/"]
COPY ["Diceware/Diceware.csproj", "Diceware/"]
RUN dotnet restore "DicewareGenerator/DicewareGenerator.csproj"
COPY . .
WORKDIR "/src/DicewareGenerator"
RUN dotnet build "DicewareGenerator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DicewareGenerator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DicewareGenerator.dll"]