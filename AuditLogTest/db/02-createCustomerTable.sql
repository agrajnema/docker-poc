CREATE TABLE Customers (
    Id serial  PRIMARY KEY,
    FirstName VARCHAR(100)  NOT NULL,
    LastName  VARCHAR(100)  NOT NULL,
    Salary    SERIAL  NOT NULL
);