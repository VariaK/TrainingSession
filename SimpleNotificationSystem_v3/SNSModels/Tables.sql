CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL
);

CREATE TYPE notification_type AS ENUM ('Email', 'SMS');

CREATE TABLE Notifications (
    Id SERIAL PRIMARY KEY,
    FromAdd VARCHAR(100) NOT NULL,
    ToAdd VARCHAR(100) NOT NULL,
    Message TEXT NOT NULL,
    NotificationType notification_type NOT NULL,
    SentTime TIMESTAMP NOT NULL
);
