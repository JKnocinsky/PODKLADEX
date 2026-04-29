USE master;
GO

-- DROP DATABASE Podkladex;
-- GO

CREATE DATABASE Podkladex;
GO

USE Podkladex;
GO

-- ==========================================
-- 1. DANE OSOBOWE I KADRY
-- ==========================================
CREATE TABLE Osoba (
    ID_osoba INT IDENTITY(1,1) PRIMARY KEY,
    Imie NVARCHAR(50) NOT NULL,
    Nazwisko NVARCHAR(50) NOT NULL,
    Nr_telefonu NVARCHAR(15) NOT NULL, -- Zmiana na 15 znaków
    Adres_e_mail NVARCHAR(50) NOT NULL,
    Miejscowosc NVARCHAR(50) NOT NULL,
    Kod_pocztowy NVARCHAR(10) NOT NULL,
    Ulica NVARCHAR(50) NOT NULL,
    Numer NVARCHAR(10) NOT NULL,
    PESEL CHAR(11) NOT NULL -- PESEL to zawsze 11 znaków
);
GO

CREATE TABLE Pracownik (
    ID_pracownik INT IDENTITY(1,1) PRIMARY KEY,
    ID_osoba INT NOT NULL FOREIGN KEY REFERENCES Osoba(ID_osoba)
);
GO

CREATE TABLE Szkolenie (
    ID_szkolenia INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(100) NOT NULL,
    Opis NVARCHAR(255) NULL,
    Czy_obowiazkowe BIT NULL,
    Waznosc INT NULL
);
GO

CREATE TABLE Typ_zwolnienia (
    ID_typ_zwolnienia INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(100) NOT NULL,
    Opis NVARCHAR(255) NULL
);
GO

CREATE TABLE Typ_badania_med (
    ID_typ_badania_med INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(100) NOT NULL,
    Opis NVARCHAR(255) NULL
);
GO

CREATE TABLE Zwolnienie_lekarskie (
    ID_zwolnienie INT IDENTITY(1,1) PRIMARY KEY,
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    ID_typ_zwolnienia INT NOT NULL FOREIGN KEY REFERENCES Typ_zwolnienia(ID_typ_zwolnienia),
    Data_poczatek DATE NOT NULL,
    Data_koniec DATE NOT NULL,
    Uwagi NVARCHAR(255) NULL
);
GO

CREATE TABLE Badanie_medyczne (
    ID_badanie_medyczne INT IDENTITY(1,1) PRIMARY KEY,
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    ID_typ_badania_med INT NOT NULL FOREIGN KEY REFERENCES Typ_badania_med(ID_typ_badania_med),
    Data_badania DATE NOT NULL,
    Data_waznosci DATE NULL,
    Koszt DECIMAL(10,2) NOT NULL,
    Uwagi NVARCHAR(255) NULL
);
GO

CREATE TABLE Siatka_plac (
    ID_siatka_plac INT IDENTITY(1,1) PRIMARY KEY,
    Data_pocz DATE NOT NULL,
    Data_koniec DATE NULL,
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    Wynagrodzenie DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE Pracownik_szkolenia (
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    ID_szkolenia INT NOT NULL FOREIGN KEY REFERENCES Szkolenie(ID_szkolenia),
    Data_szkolenia DATE NOT NULL,
    Data_waznosci DATE NULL,
    Cena_szkolenia DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (ID_pracownik, ID_szkolenia)
);
GO

CREATE TABLE Urlop (
    ID_urlopu INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL
);
GO 

CREATE TABLE Wniosek_urlopowy (
    ID_wniosku INT IDENTITY(1,1) PRIMARY KEY,
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    Data_rozp DATE NOT NULL,
    Data_zak DATE NOT NULL,
    ID_urlopu INT NOT NULL FOREIGN KEY REFERENCES Urlop(ID_urlopu),
    Status_wniosku BIT NOT NULL
);
GO

CREATE TABLE Rodzaj_umowy (
    ID_rodzaju INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Opis NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Umowa (
    ID_umowa INT IDENTITY(1,1) PRIMARY KEY,
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    Data_roz DATE NOT NULL,
    Data_zak DATE NOT NULL,
    ID_rodzaju INT NOT NULL FOREIGN KEY REFERENCES Rodzaj_umowy(ID_rodzaju)
);
GO

CREATE TABLE Urlop_umowa (
    ID_Urlop_umowa INT IDENTITY(1,1) PRIMARY KEY,
    ID_umowy INT NOT NULL FOREIGN KEY REFERENCES Umowa(ID_umowa),
    ID_urlopu INT NOT NULL FOREIGN KEY REFERENCES Urlop(ID_urlopu),
    Liczba_dni DECIMAL(6,2) NOT NULL
);
GO

-- ==========================================
-- 2. KONTRAHENCI I ZAMÓWIENIA
-- ==========================================
CREATE TABLE Firma (
    ID_firma INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Miejscowosc NVARCHAR(50) NOT NULL,
    Kod_pocztowy NVARCHAR(10) NOT NULL,
    Ulica NVARCHAR(50) NOT NULL,
    Numer NVARCHAR(10) NOT NULL,
    NIP VARCHAR(13) NOT NULL
);
GO

CREATE TABLE Klient (
    ID_klient INT IDENTITY(1,1) PRIMARY KEY,
    ID_osoba INT NULL FOREIGN KEY REFERENCES Osoba(ID_osoba)
);
GO

CREATE TABLE Klient_firma (
    ID_klient_firma INT IDENTITY(1,1) PRIMARY KEY,
    ID_klient INT NULL FOREIGN KEY REFERENCES Klient(ID_klient),
    ID_firma INT NULL FOREIGN KEY REFERENCES Firma(ID_firma),
    Data_pocz DATE NOT NULL,
    Data_koniec DATE NULL -- Klienci aktualni nie mają daty końca
);
GO

CREATE TABLE Wysylka (
    ID_wysylka INT IDENTITY(1,1) PRIMARY KEY,
    Data_nadania DATE NOT NULL,
    Cena DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE Zamowienie (
    ID_zamowienie INT IDENTITY(1,1) PRIMARY KEY,
    ID_klient INT NOT NULL FOREIGN KEY REFERENCES Klient(ID_klient),
    Data_przyjecia_z DATE NOT NULL,
    Data_zrealizowania_z DATE NULL -- Zamówienia w toku
);
GO

CREATE TABLE Wysylka_zamowienie (
    ID_wysylka_zamowienie INT IDENTITY(1,1) PRIMARY KEY, -- Zmiana nazwy klucza głównego
    ID_zamowienie INT NOT NULL FOREIGN KEY REFERENCES Zamowienie(ID_zamowienie),
    ID_wysylka INT NOT NULL FOREIGN KEY REFERENCES Wysylka(ID_wysylka)
);
GO

-- ==========================================
-- 3. MATERIAŁY, PRODUKTY I SŁOWNIKI
-- ==========================================
CREATE TABLE Jednostka (
    ID_jednostki INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa_jednostki NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Wlasciwosc (
    ID_wlasciwosci INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa_parametru NVARCHAR(50) NOT NULL,
    ID_jednostki INT NOT NULL FOREIGN KEY REFERENCES Jednostka(ID_jednostki)
);
GO

CREATE TABLE Typ (
    ID_typ INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Typ_wlasciwosci (
    ID_typ_wlasciwosci INT IDENTITY(1,1) PRIMARY KEY,
    ID_wlasciwosci INT NOT NULL FOREIGN KEY REFERENCES Wlasciwosc(ID_wlasciwosci),
    ID_typ INT NOT NULL FOREIGN KEY REFERENCES Typ(ID_typ),
    Wartosc DECIMAL(6,2) NOT NULL
);
GO

CREATE TABLE Produkt (
    ID_produkt INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Rodzaj_materialu (
    ID_rodzaj INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Material (
    ID_material INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Opis NVARCHAR(50) NOT NULL,
    ID_rodzaj INT NOT NULL FOREIGN KEY REFERENCES Rodzaj_materialu(ID_rodzaj) -- Przypisanie do słownika rodzajów
);
GO

CREATE TABLE Material_wlasciwosci (
    ID_material_wlasciwosci INT IDENTITY(1,1) PRIMARY KEY,
    ID_wlasciwosci INT NOT NULL FOREIGN KEY REFERENCES Wlasciwosc(ID_wlasciwosci),
    ID_material INT NOT NULL FOREIGN KEY REFERENCES Material(ID_material),
    Wartosc_minimalna DECIMAL(6,2) NOT NULL,
    Wartosc_maksymalna DECIMAL(6,2) NOT NULL,
    Wartosc_nominalna DECIMAL(6,2) NOT NULL
);
GO

CREATE TABLE Dostawa (
    ID_dostawa INT IDENTITY(1,1) PRIMARY KEY,
    ID_firma INT NOT NULL FOREIGN KEY REFERENCES Firma(ID_firma),
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    Data_dostawy DATE NOT NULL
    -- Usunięto ID_material (tabela Szczegoly_dostawy obsługuje relację do materiałów)
);
GO

CREATE TABLE Szczegoly_dostawy (
    ID_szczegoly_dostawy INT IDENTITY(1,1) PRIMARY KEY,
    ID_dostawa INT NOT NULL FOREIGN KEY REFERENCES Dostawa(ID_dostawa),
    ID_material INT NOT NULL FOREIGN KEY REFERENCES Material(ID_material), -- Połączono z konkretnym materiałem
    Liczba DECIMAL(10,2) NOT NULL,
    Cena DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE Szczegoly_zamowienia (
    ID_szczegoly_zamowienia INT IDENTITY(1,1) PRIMARY KEY,
    ID_zamowienie INT NOT NULL FOREIGN KEY REFERENCES Zamowienie(ID_zamowienie),
    ID_produkt INT NOT NULL FOREIGN KEY REFERENCES Produkt(ID_produkt),
    Ilosc DECIMAL(10,2) NOT NULL,
    ID_material INT NOT NULL FOREIGN KEY REFERENCES Material(ID_material),
    Uwagi NVARCHAR(255) NULL,
    Cena DECIMAL(10,2) NOT NULL
);
GO

-- ==========================================
-- 4. PRODUKCJA I MASZYNY
-- ==========================================
CREATE TABLE Maszyna (
    ID_maszyna INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Uwagi NVARCHAR(250) NULL,
    Data_zakupu DATE NOT NULL,
    Data_uruchomienia DATE NOT NULL,
    Data_wylaczenia DATE NULL
);
GO

CREATE TABLE Zadanie_produkcyjne (
    ID_zadanieP INT IDENTITY(1,1) PRIMARY KEY,
    ID_maszyna INT NOT NULL FOREIGN KEY REFERENCES Maszyna(ID_maszyna),
    Data_zadania DATE NOT NULL,
    ID_zamowienie INT NOT NULL FOREIGN KEY REFERENCES Zamowienie(ID_zamowienie)
);
GO

CREATE TABLE Norma (
    ID_normy INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Opis NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Produkt_Norma (
    ID_produkty_normy INT IDENTITY(1,1) PRIMARY KEY,
    ID_normy INT NOT NULL FOREIGN KEY REFERENCES Norma(ID_normy),
    ID_produkt INT NOT NULL FOREIGN KEY REFERENCES Produkt(ID_produkt)
);
GO

CREATE TABLE Produkt_wlasciwosci (
    ID_produkty_wlasciwosci INT IDENTITY(1,1) PRIMARY KEY,    
    ID_wlasciwosci INT NOT NULL FOREIGN KEY REFERENCES Wlasciwosc(ID_wlasciwosci),
    ID_produkt INT NOT NULL FOREIGN KEY REFERENCES Produkt(ID_produkt),
    Wartosc_minimalna DECIMAL(6,2) NOT NULL,
    Wartosc_maksymalna DECIMAL(6,2) NOT NULL,
    Wartosc_nominalna DECIMAL(6,2) NOT NULL
);
GO

CREATE TABLE Norma_prod (
    ID_normaP INT IDENTITY(1,1) PRIMARY KEY,
    ID_produkt INT NOT NULL FOREIGN KEY REFERENCES Produkt(ID_produkt),
    ID_material INT NOT NULL FOREIGN KEY REFERENCES Material(ID_material),
    Ilosc_mat DECIMAL(10,2) NOT NULL,
    Ilosc DECIMAL(10,2) NOT NULL,
    Czas DECIMAL(10,2) NOT NULL,
    Data_ DATE NOT NULL
);
GO

CREATE TABLE Kontrola_mat (
    ID_Kontrola_mat INT IDENTITY(1,1) PRIMARY KEY,
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    RBH DECIMAL(10,2) NULL,
    Zatwierdzone BIT NOT NULL,
    Odpady DECIMAL(10,2) NULL,
    ID_zadanieP INT NOT NULL FOREIGN KEY REFERENCES Zadanie_produkcyjne(ID_zadanieP),
    ID_material INT NOT NULL FOREIGN KEY REFERENCES Material(ID_material)
);
GO

CREATE TABLE Kontrola_prod (
    ID_Kontrola_prod INT IDENTITY(1,1) PRIMARY KEY,
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    RBH DECIMAL(10,2) NULL,
    Zatwierdzone BIT NOT NULL,
    Odpady DECIMAL(10,2) NULL,
    ID_zadanieP INT NOT NULL FOREIGN KEY REFERENCES Zadanie_produkcyjne(ID_zadanieP)
);
GO

CREATE TABLE Pomiar (
    ID_Pomiar INT IDENTITY(1,1) PRIMARY KEY,
    ID_Kontrola_prod INT NOT NULL FOREIGN KEY REFERENCES Kontrola_prod(ID_Kontrola_prod),
    ID_wlasciwosci INT NOT NULL FOREIGN KEY REFERENCES Wlasciwosc(ID_wlasciwosci),
    Wartosc_zmierzona DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE Pomiar_mat (
    ID_Pomiar_mat INT IDENTITY(1,1) PRIMARY KEY,
    ID_Kontrola_mat INT NOT NULL FOREIGN KEY REFERENCES Kontrola_mat(ID_Kontrola_mat),
    ID_wlasciwosci INT NOT NULL FOREIGN KEY REFERENCES Wlasciwosc(ID_wlasciwosci),
    Wartosc_zmierzona DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE Produkcja (
    ID_produkcja INT IDENTITY(1,1) PRIMARY KEY,
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    RBH DECIMAL(10,2) NOT NULL, -- Ujednolicenie precyzji
    Wyprodukowano DECIMAL(10,2) NOT NULL,
    Odpady DECIMAL(10,2) NOT NULL,
    ID_zadanieP INT NOT NULL FOREIGN KEY REFERENCES Zadanie_produkcyjne(ID_zadanieP),
    ID_normyP INT NOT NULL FOREIGN KEY REFERENCES Norma_prod(ID_normaP)
);
GO

-- ==========================================
-- 5. PARK MASZYNOWY, UTRZYMANIE RUCHU
-- ==========================================
CREATE TABLE Maszyna_typ (
    ID_maszyna_typ INT IDENTITY(1,1) PRIMARY KEY,
    ID_typ INT NOT NULL FOREIGN KEY REFERENCES Typ(ID_typ),
    ID_maszyna INT NOT NULL FOREIGN KEY REFERENCES Maszyna(ID_maszyna)
);
GO

CREATE TABLE Wyposazenie (
    ID_wyposazenie INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Uwagi NVARCHAR(250) NULL
);
GO

CREATE TABLE Wyposazenie_wlasciwosci (
    ID_wypos_wlasc INT IDENTITY(1,1) PRIMARY KEY,
    ID_wlasciwosci INT NOT NULL FOREIGN KEY REFERENCES Wlasciwosc(ID_wlasciwosci),
    ID_wyposazenie INT NOT NULL FOREIGN KEY REFERENCES Wyposazenie(ID_wyposazenie),
    Wartosc DECIMAL(6,2) NOT NULL
);
GO

CREATE TABLE Maszyna_wyp (
    ID_maszyna_wyp INT IDENTITY(1,1) PRIMARY KEY,
    ID_normaP INT NOT NULL FOREIGN KEY REFERENCES Norma_prod(ID_normaP),
    ID_maszyna INT NOT NULL FOREIGN KEY REFERENCES Maszyna(ID_maszyna),
    ID_wyposazenie INT NOT NULL FOREIGN KEY REFERENCES Wyposazenie(ID_wyposazenie)
);
GO

CREATE TABLE Gwarancja (
    ID_gwarancja INT IDENTITY(1,1) PRIMARY KEY,
    ID_maszyna INT NOT NULL FOREIGN KEY REFERENCES Maszyna(ID_maszyna),
    ID_firma INT NOT NULL FOREIGN KEY REFERENCES Firma(ID_firma),
    Czas_gwarancji DECIMAL(6,2) NOT NULL,
    Warunki NVARCHAR(250) NULL
);
GO

CREATE TABLE Czesc_zamienna (
    ID_czesci INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Awaria (
    ID_awaria INT IDENTITY(1,1) PRIMARY KEY,
    ID_maszyna INT NOT NULL FOREIGN KEY REFERENCES Maszyna(ID_maszyna),
    Data_zgloszenia DATE NOT NULL,
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    Opis NVARCHAR(250) NOT NULL,
    Data_usuniecia DATE NULL -- Do czasu usunięcia awarii data powinna móc być pusta
);
GO

CREATE TABLE Czesci_awaria (
    ID_Czesci_awaria INT IDENTITY(1,1) PRIMARY KEY,
    ID_czesci INT NOT NULL FOREIGN KEY REFERENCES Czesc_zamienna(ID_czesci),
    ID_awaria INT NOT NULL FOREIGN KEY REFERENCES Awaria(ID_awaria),
    Liczba INT NOT NULL
);
GO

CREATE TABLE Rodzaj_obslugi (
    ID_rodzaj_obslugi INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Opis NVARCHAR(250) NOT NULL
);
GO

CREATE TABLE Obsluga (
    ID_obsluga INT IDENTITY(1,1) PRIMARY KEY,
    ID_maszyna INT NOT NULL FOREIGN KEY REFERENCES Maszyna(ID_maszyna),
    Data_poczatek DATE NOT NULL,
    ID_pracownik INT NOT NULL FOREIGN KEY REFERENCES Pracownik(ID_pracownik),
    ID_rodzaj_obslugi INT NOT NULL FOREIGN KEY REFERENCES Rodzaj_obslugi(ID_rodzaj_obslugi),
    Uwagi NVARCHAR(250) NULL,
    Data_koniec DATE NULL,
    Przebieg DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE Normy_eksploatacyjne (
    ID_normy_ekspl INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa_normy NVARCHAR(50) NOT NULL,
    Przebieg_norma DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE Normy_maszyna (
    ID_Normy_maszyna INT IDENTITY(1,1) PRIMARY KEY,
    ID_normy_ekspl INT NOT NULL FOREIGN KEY REFERENCES Normy_eksploatacyjne(ID_normy_ekspl),
    ID_maszyna INT NOT NULL FOREIGN KEY REFERENCES Maszyna(ID_maszyna),
    Wartosc DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE Czesci_przeglady (
    ID_Czesci_przeglady INT IDENTITY(1,1) PRIMARY KEY,
    ID_czesci INT NOT NULL FOREIGN KEY REFERENCES Czesc_zamienna(ID_czesci),
    ID_obsluga INT NOT NULL FOREIGN KEY REFERENCES Obsluga(ID_obsluga),
    Liczba INT NOT NULL,
    Opis NVARCHAR(250) NULL
);
GO

-- Tworzenie widoku stanu magazynowego
GO
CREATE VIEW AktualnyStanMagazynu AS
WITH Dostawy_Suma AS (
    SELECT 
        ID_material, 
        SUM(Liczba) AS Suma_Dostaw
    FROM Szczegoly_dostawy
    GROUP BY ID_material
),
Zuzycie_Suma AS (
    SELECT 
        np.ID_material,
        SUM(((p.Wyprodukowano + p.Odpady) / np.Ilosc) * np.Ilosc_mat) AS Suma_Zuzycia
    FROM Produkcja p
    JOIN Norma_prod np ON p.ID_normyP = np.ID_normaP
    GROUP BY np.ID_material
)
SELECT 
    m.ID_material,
    m.Nazwa AS Nazwa_Materialu,
    m.Opis AS Opis_Materialu,
    rm.Nazwa AS Rodzaj_Materialu,
    ISNULL(d.Suma_Dostaw, 0) AS Calkowite_Dostawy,
    ISNULL(z.Suma_Zuzycia, 0) AS Calkowite_Zuzycie,
    (ISNULL(d.Suma_Dostaw, 0) - ISNULL(z.Suma_Zuzycia, 0)) AS Aktualny_Stan
FROM Material m
LEFT JOIN Rodzaj_materialu rm ON m.ID_rodzaj = rm.ID_rodzaj
LEFT JOIN Dostawy_Suma d ON m.ID_material = d.ID_material
LEFT JOIN Zuzycie_Suma z ON m.ID_material = z.ID_material;
GO
