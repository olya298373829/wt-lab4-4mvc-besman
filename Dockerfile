FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build  
WORKDIR /src  
COPY ["wt-lab4-4mvc-besman.csproj", "./"]  
RUN dotnet restore "wt-lab4-4mvc-besman.csproj"  
COPY . .  
RUN dotnet publish "wt-lab4-4mvc-besman.csproj" -c Release -o /app/publish /p:UseAppHost=false  
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base  
WORKDIR /app  
EXPOSE 10000  
COPY --from=build /app/publish .  
ENV ASPNETCORE_URLS=http://+:10000  
ENTRYPOINT ["dotnet", "wt-lab4-4mvc-besman.dll"] 
