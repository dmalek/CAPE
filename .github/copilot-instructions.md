# Copilot upute za ovaj repozitorij

Ove upute definiraju kako GitHub Copilot treba postupati u ovom projektu.
Copilot ih mora tretirati kao obvezne.

## Stil odgovora

Svaki Copilotov odgovor treba:
1. Odgovaraj na hrvatskom jeziku.
2. Kratko objasniti pristup.
3. Predložiti rješenje.
4. Pričekati odobrenje prije implementacije.

---

## 1. Arhitektura CAPE Aplikacije

### Tehnološki stack
- **Framework**: ASP.NET Core (Minimal APIs)
- **ORM**: Entity Framework Core sa in-memory bazom podataka (`CAPE_DB`)
- **Baza**: In-Memory Database (za razvoj)
- **Jezik**: C# 14.0
- **Target**: .NET 10

### Projektna struktura
```
CAPE/
├── Context/                    # Data access sloj (EF Core)
│   ├── Models/                 # Entiteti
│   └── AppDbContext.cs         # DbContext
├── Endpoints/                  # API endpointovi
│   └── Todo/                   # Modul: Todo zadaci
│       └── Add/                # Akcija: Dodavanje
│           ├── AddTodoRequest.cs
│           ├── AddTodoResponse.cs
│           └── AddTodoEndpoint.cs
├── Middlewares/                # Middleware sloj / globalni handleri
├── Program.cs                  # Konfiguracija aplikacije
└── appsettings*.json           # Konfiguracija okruženja
```

### Konvencije
- **Organizacija endpointova**: `Endpoints/<Modul>/<Akcija>/`
- **Naming**: `<Akcija><Entitet>Request.cs`, `<Akcija><Entitet>Response.cs`, `<Akcija><Entitet>Endpoint.cs`
- **Registriranje endpointova**: Svi endpointovi se registriraju u `Program.cs` unutar `Endpoints` sekcije.
- **DbContext**: Koristit ću `AppDbContext` sa konfiguriranim modelima
- **Middleware**: Svi globalni middleware-i se registriraju u `Program.cs` unutar `Middlewares` sekcije.
---

## 2. Opća načela

- Ispravnost i sigurnost imaju prednost nad brzinom.
- Ne pretpostavljaj — ako nešto nije jasno, postavi pitanje.
- Ne mijenjaj dijelove koda koji nisu vezani uz aktivan zadatak.

---

## 3. Radni proces

Prije generiranja koda Copilot MORA:
1. Pogledati relevantne datoteke u `/plans`.
2. Pročitati trenutni plan i status zadataka.

Redoslijed rada:
1. **Analiza** → 2. **Prijedlog** → 3. **Odobrenje** → 4. **Implementacija** -> 5. **Dokumentacija**

Faze se ne smiju preskakati.

---

## 4. Upravljanje zadacima

Zadaci se nalaze u markdown datotekama unutar `/plans`.

Statusi: `TODO` | `IN_PROGRESS` | `DONE`

- Zadaci označeni `DONE` se **nikad ne ponavljaju**.
- Ako kod sugerira da je zadatak već implementiran, ali status nije `DONE` — pitaj korisnika.

---

## 5. Protokol odobrenja

Copilot **ne smije** implementirati zadatak bez eksplicitnog odobrenja.

Format odobrenja:
APPROVED: <naziv ili ID zadatka>

Bez odobrenja — stani i zatraži potvrdu.

---

## 6. Kontrola opsega

- Ne refaktoriraj nesrodne module.
- Ne preimenovuj datoteke bez zahtjeva.
- Ne mijenjaj arhitekturu bez odobrenja.

Ako zadatak zahtijeva šire promjene — objasni utjecaj i zatraži odobrenje.

---

## 7. Generiranje koda

- Prati postojeće konvencije imenovanja.
- Drži kod jednostavnim i čitljivim.
- Izbjegavaj nepotrebne apstrakcije i over-engineering.

---

## 8. Sigurnosna pravila

Copilot **ne smije**:
- brisati veće dijelove koda
- mijenjati strukturu projekta
- uvoditi breaking changes
- mijenjati konfiguracijske datoteke bez odobrenja

Ako je promjena rizična — stani i pitaj.

---

## 9. Komentiranje koda
- Komentiraj samo kompleksne dijelove koda.
- Obavezno komentiraj klase, metode i endpointove s jasnim opisom funkcionalnosti.

---

## 10. Dokumentacija

Copilot **treba**:
- dokumentirati sve nove funkcionalnosti i promjene u planu zadataka pod sekcijom "Odrađene izmjene".

---