USE Podkladex

IF OBJECT_ID('dbo.Bilans_Miesieczny', 'V') IS NOT NULL
    DROP VIEW dbo.Bilans_Miesieczny;
GO

CREATE VIEW dbo.Bilans_Miesieczny
AS
WITH Przychody AS
(
    SELECT
        YEAR(z.Data_zrealizowania_z) AS Rok,
        MONTH(z.Data_zrealizowania_z) AS Miesiac,
        SUM(sz.Ilosc * sz.Cena) AS Przychody
    FROM Zamowienie z
    INNER JOIN Szczegoly_zamowienia sz
        ON z.ID_zamowienie = sz.ID_zamowienie
    WHERE
        z.Data_zrealizowania_z IS NOT NULL
        AND z.Data_zrealizowania_z <= CAST(GETDATE() AS date)
    GROUP BY
        YEAR(z.Data_zrealizowania_z),
        MONTH(z.Data_zrealizowania_z)
),

KosztyDostaw AS
(
    SELECT
        YEAR(d.Data_dostawy) AS Rok,
        MONTH(d.Data_dostawy) AS Miesiac,
        SUM(sd.Liczba * sd.Cena) AS KosztyDostaw
    FROM Dostawa d
    INNER JOIN Szczegoly_dostawy sd
        ON d.ID_dostawa = sd.ID_dostawa
    GROUP BY
        YEAR(d.Data_dostawy),
        MONTH(d.Data_dostawy)
),

KosztySzkolen AS
(
    SELECT
        YEAR(ps.Data_szkolenia) AS Rok,
        MONTH(ps.Data_szkolenia) AS Miesiac,
        SUM(ps.Cena_szkolenia) AS KosztySzkolen
    FROM Pracownik_szkolenia ps
    GROUP BY
        YEAR(ps.Data_szkolenia),
        MONTH(ps.Data_szkolenia)
),

KosztyBadan AS
(
    SELECT
        YEAR(bm.Data_badania) AS Rok,
        MONTH(bm.Data_badania) AS Miesiac,
        SUM(bm.Koszt) AS KosztyBadan
    FROM Badanie_medyczne bm
    GROUP BY
        YEAR(bm.Data_badania),
        MONTH(bm.Data_badania)
),

KosztyWysylek AS
(
    SELECT
        YEAR(w.Data_nadania) AS Rok,
        MONTH(w.Data_nadania) AS Miesiac,
        SUM(w.Cena) AS KosztyWysylek
    FROM Wysylka w
    GROUP BY
        YEAR(w.Data_nadania),
        MONTH(w.Data_nadania)
),

WszystkieDaty AS
(
    SELECT CAST(z.Data_zrealizowania_z AS date) AS DataZdarzenia
    FROM Zamowienie z
    WHERE
        z.Data_zrealizowania_z IS NOT NULL
        AND z.Data_zrealizowania_z <= CAST(GETDATE() AS date)

    UNION

    SELECT CAST(d.Data_dostawy AS date) AS DataZdarzenia
    FROM Dostawa d

    UNION

    SELECT CAST(ps.Data_szkolenia AS date) AS DataZdarzenia
    FROM Pracownik_szkolenia ps

    UNION

    SELECT CAST(bm.Data_badania AS date) AS DataZdarzenia
    FROM Badanie_medyczne bm

    UNION

    SELECT CAST(w.Data_nadania AS date) AS DataZdarzenia
    FROM Wysylka w

    UNION

    SELECT CAST(sp.Data_pocz AS date) AS DataZdarzenia
    FROM Siatka_plac sp

    UNION

    SELECT CAST(ISNULL(sp.Data_koniec, GETDATE()) AS date) AS DataZdarzenia
    FROM Siatka_plac sp
),

ZakresDat AS
(
    SELECT
        DATEFROMPARTS(YEAR(MIN(DataZdarzenia)), MONTH(MIN(DataZdarzenia)), 1) AS DataOd,
        DATEFROMPARTS(YEAR(MAX(DataZdarzenia)), MONTH(MAX(DataZdarzenia)), 1) AS DataDo
    FROM WszystkieDaty
    WHERE DataZdarzenia IS NOT NULL
),

Liczby AS
(
    SELECT TOP (
        SELECT
            CASE
                WHEN DataOd IS NULL OR DataDo IS NULL THEN 0
                ELSE DATEDIFF(MONTH, DataOd, DataDo) + 1
            END
        FROM ZakresDat
    )
        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS Nr
    FROM sys.all_objects
),

Miesiace AS
(
    SELECT
        YEAR(DATEADD(MONTH, l.Nr, z.DataOd)) AS Rok,
        MONTH(DATEADD(MONTH, l.Nr, z.DataOd)) AS Miesiac,
        CAST(DATEADD(MONTH, l.Nr, z.DataOd) AS date) AS PierwszyDzienMiesiaca,
        CAST(EOMONTH(DATEADD(MONTH, l.Nr, z.DataOd)) AS date) AS OstatniDzienMiesiaca
    FROM ZakresDat z
    INNER JOIN Liczby l
        ON DATEADD(MONTH, l.Nr, z.DataOd) <= z.DataDo
),

KosztyWynagrodzen AS
(
    SELECT
        m.Rok,
        m.Miesiac,
        SUM(sp.Wynagrodzenie) AS KosztyWynagrodzen
    FROM Miesiace m
    INNER JOIN Siatka_plac sp
        ON sp.Data_pocz <= m.OstatniDzienMiesiaca
        AND (sp.Data_koniec IS NULL OR sp.Data_koniec >= m.PierwszyDzienMiesiaca)
    GROUP BY
        m.Rok,
        m.Miesiac
)

SELECT
    m.Rok,
    m.Miesiac,

    ISNULL(p.Przychody, 0) AS Przychody,

    ISNULL(kd.KosztyDostaw, 0) AS KosztyDostaw,
    ISNULL(ks.KosztySzkolen, 0) AS KosztySzkolen,
    ISNULL(kb.KosztyBadan, 0) AS KosztyBadan,
    ISNULL(kw.KosztyWysylek, 0) AS KosztyWysylek,
    ISNULL(kwyn.KosztyWynagrodzen, 0) AS KosztyWynagrodzen,

    ISNULL(kd.KosztyDostaw, 0)
    + ISNULL(ks.KosztySzkolen, 0)
    + ISNULL(kb.KosztyBadan, 0)
    + ISNULL(kw.KosztyWysylek, 0)
    + ISNULL(kwyn.KosztyWynagrodzen, 0) AS Wydatki,

    ISNULL(p.Przychody, 0)
    - (
        ISNULL(kd.KosztyDostaw, 0)
        + ISNULL(ks.KosztySzkolen, 0)
        + ISNULL(kb.KosztyBadan, 0)
        + ISNULL(kw.KosztyWysylek, 0)
        + ISNULL(kwyn.KosztyWynagrodzen, 0)
      ) AS Dochod

FROM Miesiace m
LEFT JOIN Przychody p
    ON m.Rok = p.Rok
    AND m.Miesiac = p.Miesiac
LEFT JOIN KosztyDostaw kd
    ON m.Rok = kd.Rok
    AND m.Miesiac = kd.Miesiac
LEFT JOIN KosztySzkolen ks
    ON m.Rok = ks.Rok
    AND m.Miesiac = ks.Miesiac
LEFT JOIN KosztyBadan kb
    ON m.Rok = kb.Rok
    AND m.Miesiac = kb.Miesiac
LEFT JOIN KosztyWysylek kw
    ON m.Rok = kw.Rok
    AND m.Miesiac = kw.Miesiac
LEFT JOIN KosztyWynagrodzen kwyn
    ON m.Rok = kwyn.Rok
    AND m.Miesiac = kwyn.Miesiac;
GO
