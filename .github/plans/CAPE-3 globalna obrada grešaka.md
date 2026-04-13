# Plan: Feature — globalna obrada grešaka

Name: Exception Handling 
Module: Middlewares  
Status: TODO  
Created: 13.4.2026.

## Cilj
Kreirati globalni middleware koji će hvatati i obrađivati sve iznimke koje se dogode tijekom obrade zahtjeva, te vraćati odgovarajuće HTTP odgovore s informacijama o grešci.

## Scope
- Dozvoljeno: u folderu Middleware kreirati globalni middleware za obradu iznimki ExceptionMiddleware. Middleware će hvatati sve iznimke koje se dogode tijekom obrade zahtjeva i vraćati odgovarajuće HTTP odgovore s informacijama o grešci.
- Nije dozvoljeno: ne dirati ništa izvan foldera Middleware

## Koraci
1. Kreirati globalni middleware za obradu iznimki
2. Implementirati obradu iznimki i vraćanje odgovarajućih HTTP odgovora


## Definition of Done
- Middleware je kreiran i registriran globalno
- Obrada iznimki i vraćanje odgovarajućih HTTP odgovora je implementirana


## Odrađene izmjene
<!-- Ovdje će se bilježiti sve odrađene izmjene vezane uz ovaj zadatak, uključujući reference na commitove, pull requestove ili druge relevantne informacije. -->

