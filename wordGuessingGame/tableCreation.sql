CREATE TABLE
    words (
        word_id SERIAL PRIMARY KEY,
        word_text VARCHAR(50) UNIQUE NOT NULL
    );

INSERT INTO
    words (word_text)
VALUES
    ('APPLE'),
    ('MANGO'),
    ('GRAPE'),
    ('TRAIN'),
    ('PLANT'),
    ('BRAIN');

SELECT
    *
from
    words;

CREATE TABLE
    users (
        user_id SERIAL PRIMARY KEY,
        username VARCHAR(50) UNIQUE NOT NULL,
        password VARCHAR(100) NOT NULL,
        score INT DEFAULT 0
    );

INSERT INTO
    users (username, password)
VALUES
    ('abc', '111');

SELECT
    *
from
    users;