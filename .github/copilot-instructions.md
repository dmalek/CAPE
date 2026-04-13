# Copilot upute za ovaj repozitorij

Ove upute definiraju kako GitHub Copilot treba postupati u ovom projektu.
Copilot ih mora tretirati kao obvezne.

---

## 1. Opća načela

- Ispravnost i sigurnost imaju prednost nad brzinom.
- Ne pretpostavljaj — ako nešto nije jasno, postavi pitanje.
- Ne mijenjaj dijelove koda koji nisu vezani uz aktivan zadatak.

---

## 2. Radni proces

Prije generiranja koda Copilot MORA:
1. Pogledati relevantne datoteke u `/plans`.
2. Pročitati trenutni plan i status zadataka.

Redoslijed rada:
1. **Analiza** → 2. **Prijedlog** → 3. **Odobrenje** → 4. **Implementacija**

Faze se ne smiju preskakati.

---

## 3. Upravljanje zadacima

Zadaci se nalaze u markdown datotekama unutar `/plans`.

Statusi: `TODO` | `IN_PROGRESS` | `DONE`

- Zadaci označeni `DONE` se **nikad ne ponavljaju**.
- Ako kod sugerira da je zadatak već implementiran, ali status nije `DONE` — pitaj korisnika.

---

## 4. Protokol odobrenja

Copilot **ne smije** implementirati zadatak bez eksplicitnog odobrenja.

Format odobrenja:
APPROVED: <naziv ili ID zadatka>

Bez odobrenja — stani i zatraži potvrdu.

---

## 5. Kontrola opsega

- Ne refaktoriraj nesrodne module.
- Ne preimenovuj datoteke bez zahtjeva.
- Ne mijenjaj arhitekturu bez odobrenja.

Ako zadatak zahtijeva šire promjene — objasni utjecaj i zatraži odobrenje.

---

## 6. Generiranje koda

- Prati postojeće konvencije imenovanja.
- Drži kod jednostavnim i čitljivim.
- Izbjegavaj nepotrebne apstrakcije i over-engineering.

---

## 7. Sigurnosna pravila

Copilot **ne smije**:
- brisati veće dijelove koda
- mijenjati strukturu projekta
- uvoditi breaking changes
- mijenjati konfiguracijske datoteke bez odobrenja

Ako je promjena rizična — stani i pitaj.

---

## 8. Stil odgovora

Svaki Copilotov odgovor treba:
1. Kratko objasniti pristup.
2. Predložiti rješenje.
3. Pričekati odobrenje prije implementacije.

---