--SELECT @@SERVERNAME AS NomeDoServidor, DB_NAME() AS NomeDoBanco;
CREATE DATABASE FullStackDB;
GO

USE FullStackDB;
GO

CREATE TABLE Providers (
    Id INTEGER PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Suburb NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(255) NOT NULL
);
GO

CREATE TABLE Orders (
    Id INTEGER PRIMARY KEY,
    IdProvider INTEGER NOT NULL,
    DateTimeCreated DATETIME DEFAULT GETUTCDATE(),
    Category NVARCHAR(100) NOT NULL,
    TotalValue DECIMAL(18,2) NOT NULL,
    Details NVARCHAR(MAX) NOT NULL,
    CurrentStatus INTEGER DEFAULT 0,
    FOREIGN KEY (IdProvider) REFERENCES Providers(Id)
);
GO

CREATE TABLE LogSystem (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    DateTimeCreated DATETIME DEFAULT GETUTCDATE(),
    ImportanceLevel INTEGER NOT NULL,
    EventMessage NVARCHAR(MAX) NOT NULL,
    Details NVARCHAR(MAX) NULL
);
GO

INSERT INTO Providers (Id, FirstName, LastName, Suburb, Phone, Email)
VALUES
    (1, 'Carlos', 'Silva', 'Centro', '11987654321', 'carlos.silva@email.com'),
    (2, 'Mariana', 'Souza', 'Jardins', '11976543210', 'mariana.souza@email.com'),
    (3, 'João', 'Pereira', 'Moema', '11965432109', 'joao.pereira@email.com');
GO

INSERT INTO Orders (Id, IdProvider, DateTimeCreated, Category, TotalValue, Details)
VALUES
    (1, 2, GETDATE(), 'Reparo Elétrico', 450.00, 'Troca de fiação elétrica em apartamento'),
    (2, 3, GETDATE(), 'Manutenção Hidráulica', 600.00, 'Conserto de vazamento no banheiro'),
    (3, 1, GETDATE(), 'Pintura Residencial', 1200.00, 'Pintura de sala e cozinha');
GO

INSERT INTO LogSystem (Id, DateTimeCreated, ImportanceLevel, EventMessage, Details)
VALUES
    (NEWID(), GETDATE(), 2, 'Ordem criada com sucesso.', 'ID da Ordem: 1'),
	(NEWID(), GETDATE(), 2, 'Ordem criada com sucesso.', 'ID da Ordem: 2'),
	(NEWID(), GETDATE(), 2, 'Ordem criada com sucesso.', 'ID da Ordem: 3');
GO

SELECT * FROM Providers;
GO

SELECT * FROM Orders;
GO

SELECT * FROM LogSystem;
GO
