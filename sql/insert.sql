-- golf cup assignment --
-- insert commands --
-- #1
INSERT INTO
    spelare (namn, pnr, ålder)
VALUES
    ('Johan Andersson', '960912-1950', '25'),
    ('Nicklas Jansson', '850623-2076', '36'),
    ('Annika Persson', '801030-6903', '41');

-- #2
INSERT INTO
    tävling (namn, datum)
VALUES
    ('Big Golf Cup Skövde', '2021-10-06');

INSERT INTO
    tävling_spelare (pnr, tävlingsnamn)
VALUES
    (
        (
            SELECT
                pnr
            FROM
                spelare
            WHERE
                namn = 'Johan Andersson'
        ),
        (
            SELECT
                namn
            FROM
                tävling
            WHERE
                datum = '2021-10-06'
        )
    ),
    (
        (
            SELECT
                pnr
            FROM
                spelare
            WHERE
                namn = 'Nicklas Jansson'
        ),
        (
            SELECT
                namn
            FROM
                tävling
            WHERE
                datum = '2021-10-06'
        )
    ),
    (
        (
            SELECT
                pnr
            FROM
                spelare
            WHERE
                namn = 'Annika Persson'
        ),
        (
            SELECT
                namn
            FROM
                tävling
            WHERE
                datum = '2021-10-06'
        )
    );

-- #3
INSERT INTO
    regn (typ, vindstyrka)
VALUES
    ('Hagel', '10m/s');

INSERT INTO
    tävling_regn (tid, typ, tävlingsnamn)
VALUES
    (
        '12:00',
        (
            SELECT
                typ
            FROM
                regn
            WHERE
                vindstyrka = '10m/s'
        ),
        (
            SELECT
                namn
            FROM
                tävling
            WHERE
                datum = '2021-10-06'
        )
    );

-- #4
INSERT INTO
    jacka (initialer, storlek, material, pnr)
VALUES
    (
        'JA',
        '46',
        'Fleece',
        (
            SELECT
                pnr
            FROM
                spelare
            WHERE
                namn = 'Johan Andersson'
                AND ålder = 25
        )
    ),
    (
        'J.A',
        '47',
        'Gore-Tex',
        (
            SELECT
                pnr
            FROM
                spelare
            WHERE
                namn = 'Johan Andersson'
                AND ålder = 25
        )
    );

-- #5
INSERT INTO
    konstruktion (hårdhet)
VALUES
    ('10'),
    ('5');

INSERT INTO
    klubba (material, pnr, serialnr)
VALUES
    (
        'Trä',
        (
            SELECT
                pnr
            FROM
                spelare
            WHERE
                namn = 'Nicklas Jansson'
                AND ålder = 36
        ),
        (
            SELECT
                serialnr
            FROM
                konstruktion
            WHERE
                hårdhet = '10'
        )
    ),
    (
        'Trä',
        (
            SELECT
                pnr
            FROM
                spelare
            WHERE
                namn = 'Annika Persson'
                AND ålder = 41
        ),
        (
            SELECT
                serialnr
            FROM
                konstruktion
            WHERE
                hårdhet = '5'
        )
    );