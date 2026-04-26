USE Podkladex;
GO

/* ==========================================
   SCALONY DML DOSTOSOWANY DO DDL Z POPRAWIONYMI DATAMI
   ========================================== */

-- ==========================================
-- 1. OSOBA
-- ==========================================
INSERT INTO Osoba (Imie, Nazwisko, Nr_telefonu, Adres_e_mail, Miejscowosc, Kod_pocztowy, Ulica, Numer, PESEL) VALUES 
('Szczepan', 'Witoslawski', '123456789', 'szczepan.witoslawski@email.com', 'Warszawa', '00-021', 'Kocjana', '34', '39123848473'),
('Jakub', 'Knociński', '111222333', 'jakub.knocinski@email.com', 'Warszawa', '00-001', 'Marszalkowska', '10', '39123804281'),
('Filip', 'Przybylski', '222333444', 'filip.przybylski@email.com', 'Krakow', '30-001', 'Florianska', '15', '39105725472'),
('Mateusz', 'Miazga', '333444555', 'mateusz.miazga@email.com', 'Poznan', '60-001', 'Polwiejska', '20', '02848718374'),
('Maciej', 'Wolski', '444555666', 'maciej.wolski@email.com', 'Wroclaw', '50-001', 'Swidnicka', '5', '02384620411'),
('Anna', 'Nowak', '555666777', 'anna.nowak@email.com', 'Lodz', '90-001', 'Piotrkowska', '101', '91020345678'),
('Piotr', 'Kowalski', '666777888', 'piotr.kowalski@email.com', 'Gdansk', '80-001', 'Dluga', '7', '88071534567'),
('Karolina', 'Zielińska', '777888999', 'karolina.zielinska@email.com', 'Lublin', '20-001', 'Narutowicza', '18', '95042156789'),
('Pawel', 'Mazur', '888999000', 'pawel.mazur@email.com', 'Bialystok', '15-001', 'Sienkiewicza', '22', '92091867891');
GO

-- ==========================================
-- 2. PRACOWNIK
-- ==========================================
INSERT INTO Pracownik (ID_osoba) VALUES
(1),(2),(3),(4),(5),(6),(7),(8),(9);
GO

-- ==========================================
-- 3. FIRMA
-- ==========================================
INSERT INTO Firma (Nazwa, Miejscowosc, Kod_pocztowy, Ulica, Numer, NIP)
VALUES 
('Podkładex', 'Warszawa', '01-373', 'Powstańców Śląskich', '15', '0123456789'),
('Stal-Blach Sp. z o.o.', 'Katowice', '40-001', 'Hutnicza', '15', '6340123456'),
('Walcownia Silesia S.A.', 'Chorzów', '41-500', 'Stalowa', '8A', '6279876543'),
('Metal-Szpula s.c.', 'Dąbrowa Górnicza', '41-300', 'Przemyslowa', '112', '6291112233'),
('Pol-Stal Dystrybucja', 'Krakow', '30-969', 'Nowohucka', '45B', '6780001122'),
('Blach-Hurt', 'Sosnowiec', '41-200', 'Żelazna', '3', '6445556677'),
('NovaStal Centrum Serwisowe', 'Tychy', '43-100', 'Towarowa', '22', '6469998877'),
('Hut-Mat Półfabrykaty', 'Gliwice', '44-100', 'Portowa', '1', '6312223344'),
('Cięcie-Format', 'Częstochowa', '42-200', 'Legionów', '88', '5734445566');
GO

-- ==========================================
-- 4. RODZAJ MATERIALU I MATERIAL
-- ==========================================
INSERT INTO Rodzaj_materialu (Nazwa) VALUES 
('Szpula'),
('Krąg'),
('Arkusz blachy');
GO

INSERT INTO Material (Nazwa, Opis, ID_rodzaj) 
VALUES 
('S235JR', 'Arkusz 1,6mm', 3),
('C45', 'stal', 3),
('S235JR', 'Arkusz 4mm', 3);

GO

-- ==========================================
-- 5. WYSYLKA
-- ==========================================
INSERT INTO Wysylka (Data_nadania, Cena) VALUES 
('2024-04-01', 145.00),
('2024-04-02', 100.00),
('2024-04-03', 120.00),
('2024-04-04', 250.00),
('2024-04-05', 300.00);
GO

-- ==========================================
-- 6. KLIENT
-- ==========================================
INSERT INTO Klient (ID_osoba) VALUES 
(6), (2), (3), (4), (5),
(6), (2), (3), (4), (5);
GO

-- ==========================================
-- 7. KLIENT_FIRMA
-- ==========================================
INSERT INTO Klient_firma (ID_klient, ID_firma, Data_pocz, Data_koniec) VALUES 
(1, 1, '2024-03-14', '2024-04-05'),
(2, 2, '2024-03-23', '2024-04-12'),
(3, 3, '2024-03-01', '2024-04-06'),
(4, 4, '2024-03-09', '2024-04-07'),
(5, 5, '2024-03-28', '2024-04-11'),
(1, 5, '2024-03-30', '2024-04-20'),
(2, 4, '2024-03-17', '2024-04-16'),
(3, 1, '2024-03-03', '2024-04-21'),
(4, 3, '2024-03-04', '2024-04-18'),
(5, 2, '2024-03-05', '2024-04-24');
GO

-- ==========================================
-- 8. JEDNOSTKA
-- ==========================================
INSERT INTO Jednostka (Nazwa_jednostki) VALUES 
('mm'),
('kg');
GO

-- ==========================================
-- 9. NORMA
-- ==========================================
INSERT INTO Norma (Nazwa, Opis) VALUES 
('ISO-7089', 'Seria zwykla'),
('ISO-7090', 'Seria z fazowaniem'),
('ISO-7091', 'Seria zgrubna');
GO

-- ==========================================
-- 10. WLASCIWOSC
-- ==========================================
INSERT INTO Wlasciwosc (Nazwa_parametru, ID_jednostki) VALUES
('Grubość', 1),
('Średnica wewnetrzna', 1),
('Średnica zewnetrzna', 1),
('Szerokość', 1),
('Wysokość', 1),
('Średnica', 1),
('Długość', 1),
('Masa', 2);
GO

-- ==========================================
-- 11. PRODUKT
-- ==========================================
INSERT INTO Produkt (Nazwa) VALUES 
('M8'), 
('M10'),
('M12'),
('M16');
GO

-- ==========================================
-- 12. PRODUKT_NORMA
-- ==========================================
INSERT INTO Produkt_Norma (ID_normy, ID_produkt) VALUES 
(1, 1), (2, 1), (3, 1),
(1, 2), (2, 2), (3, 2),
(1, 3), (2, 3), (3, 3),
(1, 4), (2, 4), (3, 4);
GO

-- ==========================================
-- 13. PRODUKT_WLASCIWOSCI
-- ==========================================
INSERT INTO Produkt_wlasciwosci (ID_wlasciwosci, ID_produkt, Wartosc_minimalna, Wartosc_maksymalna, Wartosc_nominalna) VALUES 
(1, 1, 1.55, 1.65, 1.60), (2, 1, 8.30, 8.50, 8.40), (3, 1, 15.90, 16.10, 16.00),
(1, 2, 1.95, 2.05, 2.00), (2, 2, 10.40, 10.60, 10.50), (3, 2, 19.80, 20.20, 20.00),
(1, 3, 2.45, 2.55, 2.50), (2, 3, 12.80, 13.20, 13.00), (3, 3, 23.80, 24.20, 24.00),
(1, 4, 3.92, 4.08, 4.00), (2, 4, 16.80, 17.20, 17.00), (3, 4, 29.80, 30.20, 30.00);
GO

-- ==========================================
-- 14. MATERIAL_WLASCIWOSCI
-- ==========================================
INSERT INTO Material_wlasciwosci (ID_wlasciwosci, ID_material, Wartosc_minimalna, Wartosc_maksymalna, Wartosc_nominalna) VALUES
(1, 1, 1.55, 1.65, 1.60),
(1, 2, 1.90, 2.10, 2.00), 
(1, 3, 3.90, 4.10, 4.00);
GO

-- ==========================================
-- 15. DOSTAWA (Wszystkie przed uruchomieniem produkcji)
-- ==========================================
INSERT INTO Dostawa (ID_firma, ID_pracownik, Data_dostawy) VALUES 
(2, 1, '2024-01-01'),
(3, 2, '2024-02-03'),
(2, 1, '2024-03-15'),
(4, 3, '2024-04-12'),
(3, 1, '2024-05-20'),
(2, 2, '2024-06-08'),
(5, 1, '2024-07-11'),
(3, 1, '2024-08-10'),
(2, 3, '2024-09-16');
GO

-- ==========================================
-- 16. SZCZEGOLY_DOSTAWY
-- ==========================================
INSERT INTO Szczegoly_dostawy (ID_dostawa, ID_material, Liczba, Cena) VALUES 
(1, 1, 200, 5.00),
(2, 2, 300, 4.00),
(3, 3, 500, 3.00),
(4, 1, 300, 5.00),
(5, 2, 500, 4.00),
(6, 3, 1000, 3.00),
(7, 1, 300, 5.00),
(8, 1, 500, 5.00),
(9, 3, 500, 3.00);
GO

-- ==========================================
-- 17. SLOWNIKI HR / UR
-- ==========================================
INSERT INTO Urlop (Nazwa) VALUES
('Wypoczynkowy'),
('Chorobowy'),
('Okolicznosciowy');
GO

INSERT INTO Rodzaj_umowy (Nazwa, Opis) VALUES
('Umowa o prace', 'Pelny etat'),
('Umowa zlecenie', 'Elastyczna'),
('Umowa o dzielo', 'Projektowa');
GO

INSERT INTO Szkolenie (Nazwa, Opis, Czy_obowiazkowe, Waznosc_obowiazkowe) VALUES
('BHP wstepne', 'Szkolenie wstepne BHP', 1, '2027-01-15'),
('BHP okresowe', 'Szkolenie okresowe dla pracownikow produkcji', 1, '2027-06-01'),
('Obsluga prasy', 'Szkolenie stanowiskowe dla operatorow pras', 1, '2027-03-31'),
('Kontrola jakosci', 'Podstawy kontroli wyrobow i pomiarow', 0, NULL),
('Pierwsza pomoc', 'Szkolenie z udzielania pierwszej pomocy', 0, '2027-09-30');
GO

INSERT INTO Typ_zwolnienia (Nazwa, Opis) VALUES
('L4', 'Zwolnienie lekarskie'),
('Opieka', 'Opieka nad dzieckiem lub czlonkiem rodziny'),
('Rehabilitacyjne', 'Swiadczenie rehabilitacyjne');
GO

INSERT INTO Typ_badania_med (Nazwa, Opis) VALUES
('Wstepne', 'Badanie przed rozpoczeciem pracy'),
('Okresowe', 'Badanie okresowe pracownika'),
('Kontrolne', 'Badanie po dluzszej nieobecnosci');
GO

INSERT INTO Czesc_zamienna (Nazwa) VALUES
('Lozysko'),
('Pasek klinowy'),
('Filtr oleju');
GO

INSERT INTO Rodzaj_obslugi (Nazwa, Opis) VALUES
('Przeglad', 'Okresowy'),
('Naprawa', 'Awaria'),
('Konserwacja', 'Zapobiegawcza');
GO

INSERT INTO Normy_eksploatacyjne (Nazwa_normy, Przebieg_norma) VALUES
('Przeglad 100h', 100),
('Przeglad 500h', 500),
('Przeglad 1000h', 1000);
GO

-- ==========================================
-- 18. UMOWA / URLOP / SIATKA PLAC
-- ==========================================
INSERT INTO Umowa (ID_pracownik, Data_roz, Data_zak, ID_rodzaju) VALUES
(1,'2024-01-01','2025-01-01',1),
(2,'2024-02-01','2025-02-01',1),
(3,'2024-03-01','2025-03-01',2),
(4,'2024-04-01','2025-04-01',2),
(5,'2024-05-01','2025-05-01',3),
(6,'2024-06-01','2025-06-01',1),
(7,'2024-07-01','2025-07-01',2),
(8,'2024-08-01','2025-08-01',3),
(9,'2024-09-01','2025-09-01',1);
GO

INSERT INTO Urlop_umowa (ID_umowy, ID_urlopu, Liczba_dni) VALUES
(1,1,20),
(2,1,20),
(3,2,10),
(4,3,5),
(5,1,15),
(6,2,10),
(7,1,20),
(8,3,5),
(9,1,20);
GO

INSERT INTO Wniosek_urlopowy (ID_pracownik, Data_rozp, Data_zak, ID_urlopu, Status_wniosku) VALUES
(1,'2024-06-01','2024-06-10',1,1),
(2,'2024-07-01','2024-07-05',2,1),
(3,'2024-08-01','2024-08-07',1,0),
(4,'2024-09-01','2024-09-03',3,1),
(5,'2024-06-15','2024-06-20',1,1),
(6,'2024-07-10','2024-07-15',2,0),
(7,'2024-08-20','2024-08-25',1,1),
(8,'2024-09-10','2024-09-12',3,1),
(9,'2024-10-01','2024-10-10',1,0);
GO

INSERT INTO Siatka_plac (Data_pocz, Data_koniec, ID_pracownik, Wynagrodzenie) VALUES
('2024-01-01','2024-12-31',1,6200.00),
('2024-02-01','2024-12-31',2,6100.00),
('2024-03-01','2024-12-31',3,4800.00),
('2024-04-01','2024-12-31',4,4700.00),
('2024-05-01','2024-12-31',5,5300.00),
('2024-06-01','2024-12-31',6,6000.00),
('2024-07-01','2024-12-31',7,4900.00),
('2024-08-01','2024-12-31',8,5100.00),
('2024-09-01','2024-12-31',9,6300.00);
GO

-- ==========================================
-- 19. BADANIA, ZWOLNIENIA, SZKOLENIA
-- ==========================================
INSERT INTO Zwolnienie_lekarskie (ID_pracownik, ID_typ_zwolnienia, Data_poczatek, Data_koniec, Uwagi) VALUES
(2, 1, '2024-03-11', '2024-03-18', 'Grypa'),
(4, 2, '2024-04-08', '2024-04-10', 'Opieka nad dzieckiem'),
(6, 1, '2024-05-20', '2024-05-27', 'Infekcja'),
(8, 3, '2024-06-12', '2024-06-20', 'Rehabilitacja po zabiegu');
GO

INSERT INTO Badanie_medyczne (ID_pracownik, ID_typ_badania_med, Data_badania, Data_waznosci, Koszt, Uwagi) VALUES
(1, 1, '2024-01-02', '2025-01-02', 180.00, 'Dopuszczony do pracy'),
(2, 1, '2024-02-02', '2025-02-02', 180.00, 'Dopuszczony do pracy'),
(3, 2, '2024-03-05', '2025-03-05', 200.00, 'Badanie okresowe'),
(4, 2, '2024-04-05', '2025-04-05', 200.00, 'Badanie okresowe'),
(5, 1, '2024-05-03', '2025-05-03', 180.00, 'Dopuszczony do pracy'),
(6, 3, '2024-06-03', '2025-06-03', 220.00, 'Badanie kontrolne'),
(7, 2, '2024-07-04', '2025-07-04', 200.00, 'Badanie okresowe'),
(8, 1, '2024-08-05', '2025-08-05', 180.00, 'Dopuszczony do pracy'),
(9, 2, '2024-09-06', '2025-09-06', 200.00, 'Badanie okresowe');
GO

INSERT INTO Pracownik_szkolenia (ID_pracownik, ID_szkolenia, Data_szkolenia, Data_waznosci, Cena_szkolenia) VALUES
(1,1,'2024-01-10','2027-01-15',150.00),
(1,3,'2024-01-15','2027-03-31',300.00),
(2,1,'2024-02-10','2027-01-15',150.00),
(2,4,'2024-02-15',NULL,250.00),
(3,2,'2024-03-12','2027-06-01',180.00),
(4,3,'2024-04-10','2027-03-31',300.00),
(5,5,'2024-05-20','2027-09-30',120.00),
(6,1,'2024-06-08','2027-01-15',150.00),
(7,2,'2024-07-14','2027-06-01',180.00),
(8,4,'2024-08-18',NULL,250.00),
(9,3,'2024-09-22','2027-03-31',300.00);
GO

-- ==========================================
-- 20. MASZYNA / TYP / WYPOSAZENIE (Korekta dat zakupu/uruchomienia przed marcem 2024)
-- ==========================================
INSERT INTO Maszyna (Nazwa, Uwagi, Data_zakupu, Data_uruchomienia, Data_wylaczenia) VALUES
('Prasa_1',NULL,'2024-01-15','2024-02-01',NULL),
('Prasa_2',NULL,'2024-01-15','2024-02-01',NULL),
('Gilotyna_1',NULL,'2024-01-15','2024-02-01',NULL),
('Prasa_3',NULL,'2024-01-15','2024-02-01',NULL),
('Prasa_4',NULL,'2024-01-15','2024-02-01',NULL),
('Gilotyna_2',NULL,'2024-01-15','2024-02-01',NULL),
('Prasa_5',NULL,'2024-01-15','2024-02-01',NULL),
('Gilotyna_3',NULL,'2024-01-15','2024-02-01',NULL),
('Prasa_6',NULL,'2024-01-15','2024-02-01',NULL);
GO

INSERT INTO Typ (Nazwa) VALUES
('Prasa'),
('Nozyce gilotynowe'),
('Tokarka');
GO

INSERT INTO Wyposazenie (Nazwa, Uwagi) VALUES
('Wykrojnik_fi8',NULL),
('Wykrojnik_fi10',NULL),
('Wymienne_ostrze_1','Wymienne ostrze do nozyc gilotynowych'),
('Wykrojnik_fi12',NULL),
('Wykrojnik_fi6',NULL),
('Ostrze_2',NULL),
('Ostrze_3',NULL),
('Wykrojnik_prostokatny',NULL),
('Wykrojnik_specjalny',NULL);
GO

INSERT INTO Wyposazenie_wlasciwosci (ID_wlasciwosci, ID_wyposazenie, Wartosc) VALUES
(4,1,500.00),(5,1,500.00),(6,1,8.00),
(4,2,500.00),(5,2,500.00),(6,2,10.00),
(4,3,20.00),(7,3,800.00),
(6,4,12.00),
(6,5,6.00),
(7,6,750.00),
(7,7,820.00),
(4,8,300.00),
(4,9,450.00);
GO

INSERT INTO Typ_wlasciwosci (ID_wlasciwosci, ID_typ, Wartosc) VALUES
(4,1,10.00),
(5,1,5.00),
(6,2,2.00),
(4,1,12.00),
(5,1,6.00),
(6,2,3.00),
(4,1,15.00),
(5,1,7.00),
(6,2,4.00);
GO

INSERT INTO Maszyna_typ (ID_typ, ID_maszyna) VALUES
(1,1),
(1,2),
(2,3),
(1,4),
(1,5),
(2,6),
(1,7),
(2,8),
(1,9);
GO

-- ==========================================
-- 21. NORMA_PROD / GWARANCJA / MASZYNA_WYP
-- ==========================================
-- Normy ustalone jeszcze przed produkcja (2024-01-xx zamiast 2025-xx-xx)
INSERT INTO Norma_prod (ID_produkt, ID_material, Ilosc_mat, Ilosc, Czas, Data_) VALUES
(1,1,260.00,250.00,1.20,'2024-01-04'),
(2,2,325.00,312.00,1.00,'2024-01-07'),
(1,2,210.00,199.00,0.99,'2024-01-13'),
(2,1,415.00,400.00,1.50,'2024-01-01'),
(3,2,160.00,150.00,0.80,'2024-01-11'),
(1,3,620.00,600.00,2.10,'2024-01-20'),
(2,3,290.00,275.00,1.30,'2024-01-17'),
(3,1,345.00,330.00,1.10,'2024-01-30'),
(1,2,520.00,500.00,1.80,'2024-01-10');
GO

INSERT INTO Maszyna_wyp (ID_normaP, ID_maszyna, ID_wyposazenie) VALUES
(1,1,1),
(2,1,2),
(3,2,1),
(4,3,3),
(5,4,4),
(6,5,5),
(7,6,6),
(8,7,7),
(9,8,8);
GO

-- Każda maszyna ma dokładnie jednš gwarancję (ID_maszyna od 1 do 9)
INSERT INTO Gwarancja (ID_maszyna, ID_firma, Czas_gwarancji, Warunki) VALUES
(1,1,12.00,'Standardowa gwarancja 12 miesiecy'),
(2,1,12.00,'Standardowa gwarancja 12 miesiecy'),
(3,2,24.00,'Rozszerzona gwarancja'),
(4,3,12.00,'Standardowa gwarancja'),
(5,4,12.00,'Standardowa gwarancja'),
(6,5,12.00,'Standardowa gwarancja'),
(7,6,12.00,'Standardowa gwarancja'),
(8,7,24.00,'Rozszerzona gwarancja'),
(9,8,12.00,'Standardowa gwarancja');
GO

-- ==========================================
-- 22. AWARIE / OBSLUGA 
-- (Zmieniono dni tak, by awarie wystepowaly w trakcie dat 'Zadan produkcyjnych', 
-- a obsluga w 'okienkach' miedzy konkretnymi zadaniami)
-- ==========================================
INSERT INTO Awaria (ID_maszyna, Data_zgloszenia, ID_pracownik, Opis, Data_usuniecia) VALUES
(1,'2024-03-02',1,'Uszkodzone lozysko','2024-03-03'),
(2,'2024-03-03',2,'Zerwany pasek','2024-03-04'),
(3,'2024-03-06',3,'Wycieki oleju','2024-03-07'),
(4,'2024-03-11',4,'Halas','2024-03-12'),
(5,'2024-03-13',5,'Przegrzewanie','2024-03-14'),
(1,'2024-03-16',6,'Drgania','2024-03-17'),
(2,'2024-03-21',7,'Awaria silnika','2024-03-22'),
(3,'2024-03-26',8,'Zuzycie czesci','2024-03-27'),
(4,'2024-04-02',9,'Uszkodzenie filtra','2024-04-03');
GO

INSERT INTO Czesci_awaria (ID_czesci, ID_awaria, Liczba) VALUES
(1,1,2),
(2,2,1),
(3,3,1),
(1,4,1),
(2,5,2),
(3,6,1),
(1,7,3),
(2,8,1),
(3,9,2);
GO

INSERT INTO Obsluga (ID_maszyna, Data_poczatek, ID_pracownik, ID_rodzaj_obslugi, Uwagi, Data_koniec, Przebieg) VALUES
(1,'2024-03-10',1,1,'OK','2024-03-10',50.00),
(2,'2024-03-15',2,2,'Naprawa','2024-03-15',60.00),
(3,'2024-03-15',3,3,'Konserwacja','2024-03-15',40.00),
(4,'2024-03-25',4,1,'OK','2024-03-25',55.00),
(5,'2024-03-25',5,2,'Naprawa','2024-03-25',70.00),
(1,'2024-03-25',6,3,'Konserwacja','2024-03-25',30.00),
(2,'2024-03-28',7,1,'OK','2024-03-28',50.00),
(3,'2024-04-01',8,2,'Naprawa','2024-04-01',65.00),
(4,'2024-04-06',9,3,'Konserwacja','2024-04-06',45.00);
GO

INSERT INTO Normy_maszyna (ID_normy_ekspl, ID_maszyna, Wartosc) VALUES
(1,1,100.00),
(2,2,500.00),
(3,3,1000.00),
(1,2,100.00),
(2,3,500.00),
(3,1,1000.00),
(1,3,100.00),
(2,1,500.00),
(3,2,1000.00);
GO

INSERT INTO Czesci_przeglady (ID_czesci, ID_obsluga, Liczba, Opis) VALUES
(1,1,1,'Wymiana'),
(2,2,1,'Naprawa'),
(3,3,1,'Kontrola'),
(1,4,2,'Wymiana'),
(2,5,1,'Naprawa'),
(3,6,2,'Kontrola'),
(1,7,1,'Wymiana'),
(2,8,2,'Naprawa'),
(3,9,1,'Kontrola');
GO

-- ==========================================
-- 23. ZAMOWIENIA I PRODUKCJA
-- ==========================================
INSERT INTO Zamowienie (ID_klient, Data_przyjecia_z, Data_zrealizowania_z) VALUES 
(1, '2024-03-01', '2024-03-05'),
(2, '2024-03-02', '2024-03-06'),
(3, '2024-03-05', '2024-03-10'),
(6, '2024-03-10', '2024-03-15'),
(7, '2024-03-12', '2024-03-18'),
(8, '2024-03-15', '2024-03-20'),
(9, '2024-03-20', '2024-03-25'),
(10, '2024-03-25', '2024-03-30'),
(4, '2024-04-01', '2024-04-11'),
(5, '2024-04-02', '2024-04-13');
GO

INSERT INTO Wysylka_zamowienie (ID_zamowienie, ID_wysylka) VALUES 
(1, 1), 
(2, 2), 
(3, 3), 
(4, 4), 
(5, 5),
(6, 1), 
(7, 2), 
(8, 3), 
(9, 4), 
(10, 5);
GO

INSERT INTO Zadanie_produkcyjne (ID_maszyna, Data_zadania, ID_zamowienie) VALUES 
(1, '2024-03-02', 1),
(2, '2024-03-03', 2),
(3, '2024-03-06', 3),
(4, '2024-03-11', 4),
(5, '2024-03-13', 5),
(1, '2024-03-16', 6),
(2, '2024-03-21', 7),
(3, '2024-03-26', 8),
(4, '2024-04-02', 9),
(5, '2024-04-03', 10);
GO

INSERT INTO Produkcja (ID_pracownik, RBH, Wyprodukowano, Odpady, ID_zadanieP, ID_normyP) VALUES 
(1, 8.00, 9999.00, 100.00, 1, 1), 
(2, 4.50, 5000.00, 50.00, 5, 2), 
(1, 12.00, 9999.00, 2000.00, 2, 3), 
(3, 6.25, 8000.00, 100.00, 1, 4),
(1, 8.50, 9999.00, 50.00, 5, 5),
(2, 5.00, 4000.00, 100.00, 6, 3), 
(3, 10.00, 9999.00, 100.00, 7, 2), 
(1, 7.50, 9000.00, 200.00, 8, 1), 
(2, 4.00, 5000.00, 200.00, 9, 4), 
(3, 8.00, 9999.00, 20.00, 10, 5);
GO

INSERT INTO Szczegoly_zamowienia (ID_zamowienie, ID_produkt, Ilosc, ID_material, Uwagi, Cena) VALUES 
(1, 4, 9999.00, 3, 'Priorytet', 0.15),
(2, 4, 5000.00, 1, 'Standard', 0.45),
(3, 3, 9999.00, 3, 'Duza partia', 0.20),
(4, 2, 8000.00, 3, 'Pilne', 1.25),
(5, 1, 9999.00, 2, 'Stala wspolpraca', 0.85),
(6, 4, 4000.00, 3, 'Priorytet', 0.15),
(7, 4, 9999.00, 2, 'Powtorzenie zlecenia', 0.60),
(8, 3, 9000.00, 3, 'Partia testowa', 0.25),
(9, 2, 5000.00, 1, 'Standard', 1.30),
(10, 1, 9999.00, 3, 'Odbior etapowy', 0.90);
GO

-- ==========================================
-- 24. KONTROLA MATERIALU I PRODUKTU
-- ==========================================
INSERT INTO Kontrola_mat (ID_pracownik, RBH, Zatwierdzone, Odpady, ID_zadanieP, ID_material) VALUES
(1, 1.50, 1, 5.00, 1, 3),
(2, 1.20, 1, 3.00, 2, 1),
(3, 1.00, 0, 8.00, 3, 3),
(1, 1.40, 1, 2.00, 4, 2),
(2, 1.10, 1, 4.00, 5, 1);
GO

INSERT INTO Kontrola_prod (ID_pracownik, RBH, Zatwierdzone, Odpady, ID_zadanieP) VALUES
(3, 2.00, 1, 10.00, 1),
(1, 1.80, 1, 6.00, 2),
(2, 2.10, 0, 15.00, 3),
(3, 1.70, 1, 5.00, 4),
(1, 1.90, 1, 8.00, 5);
GO

INSERT INTO Pomiar_mat (ID_Kontrola_mat, ID_wlasciwosci, Wartosc_zmierzona) VALUES
(1, 1, 1.60),
(1, 2, 8.40),
(2, 1, 1.58),
(2, 2, 10.50),
(3, 1, 2.70),
(3, 2, 13.10),
(4, 1, 2.00),
(4, 2, 16.90),
(5, 1, 4.00),
(5, 2, 17.00);
GO

INSERT INTO Pomiar (ID_Kontrola_prod, ID_wlasciwosci, Wartosc_zmierzona) VALUES
(1, 1, 1.61),
(1, 2, 8.42),
(1, 3, 16.00),
(2, 1, 1.99),
(2, 2, 10.55),
(2, 3, 20.00),
(3, 1, 2.60),
(3, 2, 13.50),
(4, 1, 2.48),
(4, 2, 13.00),
(5, 1, 3.98),
(5, 2, 17.05);
GO