# Plan: Feature — validacija requesta prije izvršavanja servisne logike

Name: Validate Request Before Service Logic  
Module: Middleware  
Status: TODO  
Created: 13.4.2026.

## Cilj
Kreirati globalni middleware koji će validirati incoming requestove prije nego što dođu do servisne logike. Validacija će se temeljiti na atributima koji se mogu dodati na modele requesta.

## Scope
- Dozvoljeno: u folderu Middleware kreirati globalni middleware za validaciju requesta. Validacija će se temeljiti na atributima koji se mogu dodati na modele requesta.
- Nije dozvoljeno: ne dirati ništa izvan foldera Middleware

## Koraci
1. Kreirati globalni middleware za validaciju requesta
2. Implementirati validaciju temeljem atributa na modelima requesta
3. Napisati unit testove za middleware

## Definition of Done
- Middleware je kreiran i registriran globalno
- Validacija requesta temeljem atributa na modelima je implementirana
- Svi testovi prolaze





