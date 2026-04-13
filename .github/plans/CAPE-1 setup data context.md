# Plan: Feature — postaviti data context i modele podataka

Name: Setup Data Context and Models  
Module: Context  
Status: DONE  
Created: 13.4.2026.

## Cilj
Kreirati osnovne modele podataka i postaviti data context prem diagramu

```mermaid
erDiagram
    TODO_ITEM ||--o{ ITEM_HISTORY : has

    TODO_ITEM {
        int itemId PK
        string title
        string description
        string useremail
        date dueDate
        string status
    }

    ITEM_HISTORY {
        int historyId PK
        int itemId FK
        string action
        date timestamp
    }
```

## Scope
- Dozvoljeno: u folderu Context kreirati model TodoItem i ItemHistory, postaviti relaciju između njih. Kreirati dbContext i konfigurirati ga da koristi memory database.   
- Nije dozvoljeno: ne dirati ništa izvan foldera Context

## Koraci
1. Kreirati model TodoItem i ItemHistory, postaviti relaciju između njih
2. Kreirati dbContext i konfigurirati ga da koristi memory database
3. Napisati unit testove za service sloj

## Definition of Done
- Modeli su kreirani i imaju ispravnu relaciju
- DbContext je kreiran i konfiguriran da koristi memory database
- Svi testovi prolaze




