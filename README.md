# Projekt_Zaliczeniowy

Opis projektu: <br>
Stworzenie systemu bibliotecznego w języku C#. System ten będzie obejmował interfejsy użytkownika dla bibliotekarzy oraz czytelników, umożliwiając zarządzanie książkami, wypożyczanie i zwracanie ich oraz przeglądanie dostępnych zasobów.

### Funkcjonalności projektu:

* Rejestracja i logowanie:
   - Bibliotekarze mogą zalogować się do systemu, aby zarządzać bazą danych książek.<br>
   - Czytelnicy mogą zarejestrować się i zalogować, aby przeglądać dostępne książki oraz wypożyczać je oraz zwrócić. <br>
*  Zarządzanie książkami:
   - Dodawanie nowych książek do systemu wraz z informacjami takimi jak tytuł, autor, kategoria, rok wydania.
   - Edycja i usuwanie książek.
   - Możliwość przeglądania wszystkich książek w bazie danych.
   - Wypożyczanie i zwracanie książek:
   - Czytelnicy mogą przeglądać dostępne książki i wypożyczać wybrane egzemplarze.
   - Limit czasowy wypożyczenia (np. 30 dni).
   - Powiadomienia o zbliżającym się terminie zwrotu.
 * Wyszukiwanie i sortowanie:
   - Możliwość wyszukiwania książek według różnych kryteriów, takich jak tytuł, autor, kategoria, itp.
   - Sortowanie wyników wyszukiwania.

### Technologie do wykorzystania:
  - C# jako główny język programowania.
  - Windows Forms do budowy interfejsu użytkownika.
  - XMAPP SQL do przechowywania danych
### Włączenie aplikacji
   - Zainstalować plik mysqli-connector-net-7.0.6.msi
   - Importować bazę danych biblioteka.sql
   - Wygenerować dane za pomocą generoaora.py
