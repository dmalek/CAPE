# GitHub Copilot kao član tima
## Prezentacija — dopunjena verzija

---

## Slide 1 — Naslov
**GitHub Copilot kao član tima**
*Vođeni razvoj planovima i globalnim instrukcijama*

---

## Slide 2 — Kuka (otvaranje)

> *"Vi već znate koristiti AI. Ovo je kako ga se koristi disciplinirano, u timu, na projektu koji raste."*

- Copilot nije pametniji od vas
- Ali je konzistentniji, brži i nezaboravljiv
- Pitanje nije *može li* — nego *kako ga voditi*

---

## Slide 3 — Problem bez strukture

Tipičan scenario danas:
- Svaki developer prompta na svoj način
- Copilot ne zna ništa o projektu, arhitekturi, dogovorima
- Output ovisi o tome tko pita i kako pita
- **Rezultat:** nekonzistentan kod, tehnički dug, frustracija

> *Copilot bez instrukcija je novi developer koji nikad nije dobio onboarding.*

**Onboarding analogija:**
Zamislite novog developera koji prvog dana nema dokumentaciju, nema README, nema nikoga tko mu objasni kako projekt funkcionira. Što radi? Pretpostavlja. Pogađa. Griješi.
Copilot radi točno isto — ali puno brže i u puno većem obimu.
Sve što pomažepomaže novom čovjeku (ažuran README, komentari u kodu, logična struktura foldera, jasne konvencije), pomaže i Copilotu.

---

## Slide 4 — Rješenje: Copilot kao član tima

Četiri elementa koja mijenjaju pristup:

1. **Globalne instrukcije** — tko je Copilot na ovom projektu
2. **Konfiguracija okruženja** — što Copilot ima instalirano kad radi
3. **Plan po featureu** — što trenutno radi i kako
4. **Agentni način rada** — Copilot izvršava, ne improvizira

---

## Slide 5 — Globalne instrukcije

**Što je to?**
Datoteka `.github/copilot-instructions.md` — čita je svaki poziv Copilota u projektu.

**Što stavljamo unutra:**
- Opis projekta i arhitekture
- Tech stack i verzije
- Konvencije imenovanja i struktura foldera
- Što se ne smije raditi (zabrane)
- Preferirani paterni i knjižnice
- Institucionalno znanje tima koje nije nigdje zapisano — ali svi "znaju"

**Analogija:**
> *Onboarding dokument koji novi developer dobije prvog dana — samo što ga Copilot čita svaki put iznova.*

---

## Slide 6 — Primjer globalnih instrukcija

```markdown
# Copilot Instructions

## Projekt
Ovo je REST API za upravljanje narudžbama. Backend je Node.js + Express,
baza podataka je PostgreSQL, ORM je Prisma.

## Konvencije
- Svi fajlovi su u camelCase
- Svaka ruta ima svoj controller i service sloj
- Greške se uvijek bacaju kroz AppError klasu
- Komentari i varijable su na engleskom

## Zabrane
- Ne koristiti raw SQL — uvijek kroz Prisma
- Ne pisati logiku u route handleru direktno
- Ne koristiti var, samo const/let
```

---

## Slide 7 — Konfiguracija okruženja *(novi slide)*

**Dva načina rada — isti projekt, drugačiji kontekst:**

| | Agent Mode u Visual Studiju | Coding Agent na GitHubu |
|---|---|---|
| Gdje radi | Lokalno, u vašem IDE-u | Izolirani container, GitHub Actions |
| Kako se pokreće | Vi promptate u Copilot chatu | Dodijelite GitHub Issue |
| Testovi | Koristi vaš lokalni build | Treba posebnu konfiguraciju |
| Rezultat | Kod odmah u editoru | Draft Pull Request |

**Za vas — Visual Studio + C# .NET Core:**

Agent mode radi direktno u Visual Studiju i koristi vaš postojeći projekt — solution fajlove, NuGet pakete, launchSettings. Ništa ne trebate posebno konfigurirati za lokalni rad.

Ono što *trebate* osigurati je da projekt govori sam za sebe:

```xml
<!-- Primjer: jasna struktura u .csproj pomaže Copilotu razumjeti ovisnosti -->
<ItemGroup>
  <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
  <PackageReference Include="FluentValidation.AspNetCore" Version="11.3.0" />
  <PackageReference Include="Serilog.AspNetCore" Version="8.0.0" />
</ItemGroup>
```

> *Copilot čita vaš solution kao novi developer koji je upravo klonirao repo — što jasnije je strukturirano, to bolje radi.*

**Ako koristite coding agent na GitHubu** (napredni scenarij), tada je potreban `copilot-setup-steps.yml` koji instalira .NET SDK i pokreće restore:

```yaml
# .github/workflows/copilot-setup-steps.yml
jobs:
  copilot-setup-steps:
    runs-on: windows-latest
    steps:
      - uses: actions/checkout@v4
      - uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '8.0.x'
      - run: dotnet restore
      - run: dotnet build --no-restore
```

---

## Slide 8 — Plan po featureu

**Zašto svaki feature treba plan?**

- Copilot u agentnom načinu može raditi autonomno — ali samo ako zna što se od njega očekuje
- Bez plana: kreće od pretpostavki, dira stvari koje ne treba, traži potvrdu na svakom koraku
- S planom: zna cilj, zna granice, zna kad je gotov

**Struktura plana:**
1. Cilj — što i zašto
2. Scope — što dira, što ne dira
3. Koraci implementacije
4. Kriteriji završetka (Definition of Done)

---

## Slide 9 — Primjer plana

```markdown
# Plan: Feature — Autentikacija korisnika

## Cilj
Implementirati JWT autentikaciju s refresh tokenom.

## Scope
- Dira: auth router, user service, middleware folder
- Ne dira: postojeći order modul, baza podataka (migracije već postoje)

## Koraci
1. Kreirati POST /auth/login endpoint
2. Implementirati generateToken i verifyToken u auth.service.ts
3. Kreirati authMiddleware koji štiti rute
4. Napisati unit testove za service sloj

## Definition of Done
- Login vraća access + refresh token
- Zaštićene rute vraćaju 401 bez tokena
- Svi testovi prolaze
```

---

## Slide 10 — Agentni način rada — kako izgleda iznutra *(prošireni slide)*

**Što se točno događa kad dodijelite zadatak Copilotu?**

```
[Vi]  →  Assign issue na GitHubu
            ↓
[Copilot]  Istražuje codebase
            ↓
           Kreira branch (copilot/feature-auth)
            ↓
           Pokreće setup okruženja (vaš copilot-setup-steps.yml)
            ↓
           Piše kod korak po korak
            ↓
           Pokreće testove, iterira dok ne prođu
            ↓
           Otvara Draft Pull Request
            ↓
[Vi]  →  Review → komentar → Copilot iterira
            ↓
[Vi]  →  Approve i merge (samo vi, Copilot to ne može)
```

> *Ti si arhitekt. Copilot je izvođač. Merge uvijek ostaje na tebi.*

**Ključna razlika od chat moda:**
- Chat mode = sinkrono, vi pratite svaki korak
- Coding agent = asinkrono, Copilot radi u pozadini dok vi radite nešto drugo

---

## Slide 11 — MCP serveri — proširivanje konteksta *(novi slide)*

**Što je MCP (Model Context Protocol)?**

Standardizirani način da Copilotu date pristup vanjskim sustavima — ne samo vašem kodu.

**Primjeri:**
| MCP server | Što Copilot dobiva |
|---|---|
| Jira / GitHub Issues | Može čitati opise ticketa, komentare, prioritete |
| Confluence / Notion | Pristup internoj dokumentaciji i specifikacijama |
| Slack | Kontekst razgovora koji su definirali odluke |
| Baza podataka | Može provjeriti shemu direktno, bez opisa u instrukcijama |

**Zašto je ovo važno?**

Bez MCP-a: Copilot zna samo što je u kodu i što ste mu napisali u instrukcijama.
S MCP-om: Copilot može sam dohvatiti opis ticketa, pročitati specifikaciju iz Confluencea, i razumjeti kontekst koji normalno morate ručno copy-pastati u prompt.

```yaml
# Primjer u copilot-setup-steps.yml
mcp_servers:
  - type: url
    url: https://jira.mcp.yourcompany.com
    name: jira
```

> *MCP je odgovor na pitanje: "Kako Copilot zna o našem specifičnom kontekstu?"*

---

## Slide 12 — Demo

**Što ćemo pokazati:**

1. Otvoriti demo projekt s `copilot-instructions.md` i `copilot-setup-steps.yml`
2. Pokazati gotov plan za feature
3. Dodijeliti GitHub Issue Copilotu — pratiti kako otvara branch i draft PR
4. Pratiti session log — korak po korak što Copilot radi
5. Pokazati kako poštuje scope (ne dira module izvan plana)
6. Rezultat: gotov, konzistentan kod bez improvizacije, spreman za review

---

## Slide 13 — Radionica

**Zadaci (45 min):**

- **Zadatak 1** *(10 min)* — Dobivate starter projekt. Napišite `copilot-instructions.md`.
- **Zadatak 2** *(5 min)* — Napišite `copilot-setup-steps.yml` za isti projekt.
- **Zadatak 3** *(10 min)* — Dobivate opis featurea. Napišite plan.
- **Zadatak 4** *(15 min)* — Pokrenite Copilot agent i pratite izvršavanje.
- **Debriefing** *(5 min)* — Što je radilo, što nije, što biste mijenjali?

---

## Slide 14 — Zaključak

**Ključne poruke:**

- Copilot je onoliko dobar koliko su dobre vaše instrukcije
- Globalne instrukcije = konzistentnost kroz cijeli tim
- Konfiguracija okruženja = Copilot može pokrenuti testove i iterirati samostalno
- Plan = predvidljivost bez stalnog nadzora
- Agentni način = manje mikromenadžmenta, više arhitekture
- **Human review ostaje obavezan** — Copilot ne može sam mergati, ne može pokrenuti CI/CD bez vaše potvrde

**Promjena mindset-a:**
> *Od "tražim od AI-a da mi pomogne" → "dajem AI-u zadatak koji može izvršiti autonomno"*

---

## Napomene za predavača

**Slide 3** — Naglasiti onboarding analogiju, publika se s tim lako poistovjeti.

**Slide 7** — Ovo je tehnički najčešće propušteni korak. Bez setup YAMLa, testovi ne prolaze i agent se "vrti" bez rezultata. Demo to može pokazati ako ima vremena.

**Slide 10** — Dijagram toka je ključan za razumijevanje razlike između chat moda i coding agenta. Naglasiti da merge uvijek ostaje na čovjeku — to uklanja strah kod konzervativnijih timova.

**Slide 11** — MCP je naprednija tema. Ako publika nije tehnički jaka, dovoljno je reći "možete mu dati pristup Jiri i dokumentaciji" bez ulaženja u tehničke detalje.

**Radionica** — Zadatak 2 (setup YAML) je novi u odnosu na originalnu verziju. Može se izostaviti ako nema vremena, ali preporučljivo ga je uključiti jer sprječava probleme na Zadatku 4.
