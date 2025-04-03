--SELECT @@SERVERNAME AS NomeDoServidor, DB_NAME() AS NomeDoBanco;
CREATE DATABASE FullStackDB;
GO

USE FullStackDB;
GO

CREATE TABLE Providers (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Suburb NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(255) NOT NULL
);
GO

CREATE TABLE Orders (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    IdProvider UNIQUEIDENTIFIER NOT NULL,
    DateTimeCreated DATETIME DEFAULT GETUTCDATE(),
    Category NVARCHAR(100) NOT NULL,
    TotalValue DECIMAL(18,2) NOT NULL,
    Details NVARCHAR(MAX) NOT NULL,
    CurrentStatus INTEGER DEFAULT 0,
    FOREIGN KEY (IdProvider) REFERENCES Providers(Id)
);
GO

CREATE TABLE Logs (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    DateTimeCreated DATETIME DEFAULT GETUTCDATE(),
    ImportanceLevel INTEGER NOT NULL,
    EventMessage NVARCHAR(MAX) NOT NULL,
    Details NVARCHAR(MAX) NULL
);
GO

INSERT INTO Providers (Id, FirstName, LastName, Suburb, Phone, Email)
VALUES
    (NEWID(), 'Carlos', 'Silva', 'Centro', '11987654321', 'carlos.silva@email.com'),
    (NEWID(), 'Mariana', 'Souza', 'Jardins', '11976543210', 'mariana.souza@email.com'),
    (NEWID(), 'João', 'Pereira', 'Moema', '11965432109', 'joao.pereira@email.com');
GO

DECLARE @Prestador1 UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Providers ORDER BY NEWID());
DECLARE @Prestador2 UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Providers ORDER BY NEWID());
INSERT INTO Orders (Id, IdProvider, DateTimeCreated, Category, TotalValue, Details)
VALUES
    (NEWID(), @Prestador1, GETDATE(), 'Reparo Elétrico', 450.00, 'Troca de fiação elétrica em apartamento'),
    (NEWID(), @Prestador1, GETDATE(), 'Manutenção Hidráulica', 600.00, 'Conserto de vazamento no banheiro'),
    (NEWID(), @Prestador2, GETDATE(), 'Pintura Residencial', 1200.00, 'Pintura de sala e cozinha');
GO

INSERT INTO Logs (Id, DateTimeCreated, ImportanceLevel, EventMessage, Details)
VALUES
    (NEWID(), GETDATE(), 2, 'Ordem criada com sucesso.', 'ID da Ordem: 1'),
	(NEWID(), GETDATE(), 2, 'Ordem criada com sucesso.', 'ID da Ordem: 2'),
	(NEWID(), GETDATE(), 2, 'Ordem criada com sucesso.', 'ID da Ordem: 3');
GO

SELECT * FROM Providers;
GO

SELECT * FROM Orders;
GO

SELECT * FROM Logs;
GO
