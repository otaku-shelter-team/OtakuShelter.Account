FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/account/service
WORKDIR /otakushelter/account/service/src/OtakuShelter.Account.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/account/service
COPY --from=build /otakushelter/account/service/src/OtakuShelter.Account.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Account.Web.dll"] 