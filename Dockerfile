FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 54059
EXPOSE 44336

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["PaymentsAPI/PaymentsAPI.csproj", "PaymentsAPI/"]
RUN dotnet restore "PaymentsAPI/PaymentsAPI.csproj"
COPY . .
WORKDIR "/src/PaymentsAPI"
RUN dotnet build "PaymentsAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PaymentsAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentsAPI.dll"]