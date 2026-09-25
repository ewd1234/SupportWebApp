# SupportWebApp - Støttesystem til Henvendelser (IBAS)

En webbaseret Blazor-applikation til håndtering af supporthenvendelser integreret med **Azure Cosmos DB** som NoSQL-database. Applikationen gør det muligt for kunder at oprette supporthenvendelser inden for specifikke kategorier, samt for supportmedarbejdere at få et samlet overblik over alle registrerede sager.

---

## Projektets Formål

Formålet med dette projekt er at udvikle en skalerbar, sikker og moderne support-webapplikation. Løsningen demonstrerer integrationen mellem en C# Blazor Web App og cloud-databasen **Azure Cosmos DB** ved hjælp af NoSQL API.

### Hovedfunktioner:
* **Opret Supporthenvendelse:** Formular med validering og opdeling i 6 specifikke kategorier (*Forhandler, Reservedele, Købsrådgivning, Produktforslag, Katalogbestilling, Øvrigt*).
* **Vis Supporthenvendelser:** Dynamisk oversigtsliste over alle registrerede henvendelser hentet direkte fra Cosmos DB.
* **Sikkerhed:** Følsomme oplysninger (connection string) opbevares sikkert uden for kildekoden via **.NET User Secrets**.

---

## Opsætning af Azure Cosmos DB 

Følgende Azure CLI-kommandoer opretter ressourcerne i Azure

> **Bemærk:** Kommandoerne benytter Bash-variabler og tilføjer `--enable-free-tier true` for at aktivere Azure-for-students rabatten.

### 1. Registrér CosmosDB Resource Provider
```bash
az provider register --namespace Microsoft.DocumentDB --wait
```

### 2. Opret Ressourcegruppe (Trin A)
```bash
export RESGRP="IBasSupportRG"

az group create --name "$RESGRP" --location westeurope
```

### 3. Opret CosmosDB Konto (Trin B)
```bash
export DBACCOUNT="ibas-db-account-$RANDOM"

az cosmosdb create \
  --name "$DBACCOUNT" \
  --resource-group "$RESGRP" \
  --enable-free-tier true
```

### 4. Opret Database i CosmosDB (Trin C)
```bash
export DATABASE="IBasSupportDB"

az cosmosdb sql database create \
  --account-name "$DBACCOUNT" \
  --resource-group "$RESGRP" \
  --name "$DATABASE"
```

### 5. Opret Container med Partition Key (Trin D)
```bash
export CONTAINER="ibassupport"

az cosmosdb sql container create \
  --account-name "$DBACCOUNT" \
  --resource-group "$RESGRP" \
  --database-name "$DATABASE" \
  --name "$CONTAINER" \
  --partition-key-path "/category"
```

---

## Lokal Konfiguration & User Secrets

Connection string til databasen opbevares i **User Secrets** for at undgå at hemmelige nøgler uploades til GitHub.

For at køre projektet lokalt på en ny maskine skal din CosmosDB Connection String tilføjes:

```bash
dotnet user-secrets init
dotnet user-secrets set "CosmosDb:ConnectionString" "DIN_AZURE_COSMOSDB_CONNECTION_STRING"
```

---

## Status & Næste Trin

### Hvad jeg nåede (Status):
* [x] **Aktivitet 1:** Opsætning af Azure Cosmos DB konto, database (`IBasSupportDB`) og container (`ibassupport`) med partition key `/category`.
* [x] **Aktivitet 1:** Beskyttelse af Connection String via .NET User Secrets.
* [x] **Aktivitet 2:** Oprettelse af C# datamodellen `SupportMessage.cs` med GUID som ID og JSON-annotations.
* [x] **Aktivitet 3:** Blazor-formular (`CreateSupport.razor`) med validering og gem-funktion mod Cosmos DB.
* [x] **Aktivitet 3:** Oversigtsside (`SupportList.razor`) der henter og viser alle supporthenvendelser fra Cosmos DB.
* [x] **Aktivitet 4:** Opsætning af `.gitignore` samt dokumentation og status i `README.md`.

### Hvad der mangler i forhold til afleveringen:
* *Intet* – Alle krævede aktiviteter og delopgaver i opgavesættet er gennemført og testet.

### næste trin (Mulige udvidelser):
1. **Søgning og filtrering:** Tilføje en simpel dropdown på oversigtssiden (`SupportList.razor`), så man kan filtrere listen på en bestemt kategori.
2. **Statusfelt på henvendelse:** Tilføje en status-egenskab (f.eks. "Modtaget", "Under behandling", "Afsluttet") på hver supportbesked.
