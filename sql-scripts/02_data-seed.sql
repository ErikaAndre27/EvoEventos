USE EvoEventos;

INSERT INTO DocumentType
(
    Name, Abbreviation
)
VALUES ('Cédula de Ciudadanía', 'CC');

INSERT INTO Role
(
    Name
)
VALUES ('Admin'), ('Asesor');
GO

INSERT INTO [User]
(
    Name,
    Surnames,
    Email,
    IdDocumentType,
    DocumentNumber,
    Phone,
    Address,
    IdRole
)
SELECT
    'Erika',
    'Gonzalez',
    'admin@evoeventos.com',
    dt.Id,
    '1234567890',
    '3001234567',
    'Bogot ',
    r.Id
FROM DocumentType dt
INNER JOIN Role r ON r.Name = 'Admin'
WHERE dt.Abbreviation = 'CC';

select * from [User]

--Crear credenciales de usuario principal admin


INSERT INTO Credential
(
    IdUser,
    EmailIdentifier,
    DocumentIdentifier,
    Password
)
SELECT
    u.Id,
    u.Email,
    u.DocumentNumber,
    '$2a$11$YZ7b4pJ1utdreuDT2sFQieCTwO/luGUbaGX0BsSeky/sN3RzGxStC'
FROM [User] u
WHERE u.Email = 'admin@evoeventos.com';





