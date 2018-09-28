# FROM microsoft/dotnet:sdk AS build-en

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
COPY ./publish /publish
WORKDIR /publish
ENTRYPOINT ["dotnet", "Lottery.RaffleConsole.dll"]