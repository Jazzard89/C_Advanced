CREATE TABLE Gebruikers
(
	Naam VARCHAR(20) PRIMARY KEY,
	WachtWoord VARCHAR(20) NOT NULL
)

INSERT INTO Gebruikers(Naam, WachtWoord)
VALUES	('Ellen', 'Ellen123'),
		('John', 'John123'),
		('Murat', 'Murat123')