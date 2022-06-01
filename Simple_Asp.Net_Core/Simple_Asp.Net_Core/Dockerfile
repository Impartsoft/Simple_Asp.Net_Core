#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Simple_Asp.Net_Core/Simple_Asp.Net_Core.csproj", "Simple_Asp.Net_Core/"]
RUN dotnet restore "Simple_Asp.Net_Core/Simple_Asp.Net_Core.csproj"
COPY . .
WORKDIR "/src/Simple_Asp.Net_Core"
RUN dotnet build "Simple_Asp.Net_Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Simple_Asp.Net_Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Simple_Asp.Net_Core.dll"]