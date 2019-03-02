FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/accounts/service
WORKDIR /otakushelter/accounts/service/src/OtakuShelter.Accounts.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/accounts/service
COPY --from=build /otakushelter/accounts/service/src/OtakuShelter.Accounts.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Accounts.Web.dll"] 