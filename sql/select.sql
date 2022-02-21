-- golf cup assignment --
-- select commands --
-- #1
SELECT
    ålder
from
    spelare
where
    namn = 'Johan Andersson';

-- #2
SELECT
    datum
from
    tävling
where
    namn = 'Big Golf Cup Skövde';

-- #3
-- blir ju inga resultat pga johan andersson ej har någon klubba i listan
SELECT
    material
from
    klubba
where
    pnr =(
        SELECT
            pnr
        FROM
            spelare
        WHERE
            namn = 'Johan Andersson'
            AND age = 25
    );

-- #4
SELECT
    *
from
    jacka
where
    pnr =(
        SELECT
            pnr
        FROM
            spelare
        WHERE
            namn = 'Johan Andersson'
            AND ålder = 25
    );

-- #5
SELECT
    s.namn,
    ts.tävlingsnamn
FROM
    tävling_spelare ts
    JOIN spelare s ON ts.pnr = s.pnr;

-- #6
SELECT
    r.vindstyrka,
    tr.tävlingsnamn
FROM
    tävling_regn tr
    JOIN regn r ON tr.typ = r.typ;

-- #7
SELECT
    *
from
    spelare
where
    ålder < 30;

-- #8
DELETE from
    jacka
where
    pnr =(
        SELECT
            pnr
        FROM
            spelare
        WHERE
            namn = 'Johan Andersson'
            AND ålder = 25
    );

-- #9 if safemode off
DELETE FROM
    spelare
WHERE
    namn = 'Nicklas Jansson'
    AND ålder = 35;

-- #9 if safemode on
DELETE FROM
    `golf`.`spelare`
WHERE
    (`pnr` = '850623-2076');

-- #10
SELECT
    AVG(ålder)
FROM
    spelare;