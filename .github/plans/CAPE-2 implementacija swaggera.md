# Plan: Feature — implementacija swaggera

Name: Implement Swagger  
Module: 
Status: DONE
Created: 13.4.2026.

## Cilj
Instalirati i konfigurirati Swagger za automatsko generiranje API dokumentacije na temelju endpointa i modela requesta/responsea.

## Scope
- Dozvoljeno: instalirati i konfigurirati Swagger u projektu.
- Nije dozvoljeno: ne dirati ništa izvan konfiguracije Swaggera.
- 
## Koraci
1. Instalirati paket Microsoft.AspNetCore.OpenApi
2. Konfigurirati Swagger u projektu


## Definition of Done
- Swagger je instaliran i konfiguriran u projektu
- API dokumentacija se generira automatski na temelju endpointa i modela requesta/responsea

## Odrađene izmjene

### 1. Instalacija paketa
- **CAPE/CAPE.csproj**: Dodani paketi
  - `Microsoft.AspNetCore.OpenApi` Version="10.0.3" (već postojeći)
  - `Scalar.AspNetCore` Version="1.2.40" (za moderan UI umjesto zastarjelog Swashbuckle-a)

### 2. Konfiguracija u Program.cs
- **Dodani usings**: `using Scalar.AspNetCore;`
- **Registracija servisa**: 
  - `builder.Services.AddOpenApi();` - omogućava nativnu OpenAPI podršku
- **HTTP pipeline konfiguracija**:
  - `app.MapOpenApi();` - mapira OpenAPI JSON endpoint
  - `app.MapScalarApiReference();` - mapira moderan Scalar UI za API dokumentaciju

### 3. Rezultat
- ✅ Build je prošao bez greške
- ✅ API dokumentacija je dostupna na:
  - **Scalar UI**: `https://localhost:<port>/scalar/v1`
  - **OpenAPI JSON**: `https://localhost:<port>/openapi/v1.json`
- ✅ Dokumentacija se automatski generira na temelju endpointa (`AddTodoEndpoint`) i modela (`AddTodoRequest`, `AddTodoResponse`)

### 4. Tehnička napomena
Korištena je **Scalar UI** umjesto tradicionalnog Swagger UI jer:
- Nativna kompatibilnost sa .NET 10 i nativnim OpenAPI suportom
- Moderni i responzivni interfejs
- Direktna integracija sa `Microsoft.AspNetCore.OpenApi` pakete






