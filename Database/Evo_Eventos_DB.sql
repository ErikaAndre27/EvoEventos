-- =========================
-- CREACI�N DE LA BASE DE DATOS
-- =========================
CREATE DATABASE EvoEventos;
go
-- =========================
-- SELECCION DE LA BASE DE DATOS
-- =========================

USE EvoEventos;

go

-- =========================
-- TABLAS DE SEGURIDAD Y USUARIOS
-- =========================

CREATE TABLE TipoDocumento (
    Id_Documento INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Abreviatura NVARCHAR(20),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Rol (
    Id_Rol INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Usuario (
    Id_Usuario INT PRIMARY KEY,
    Nombres NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Num_Documento NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) UNIQUE,
    Contrasena NVARCHAR(255) NOT NULL,
    Id_Rol INT FOREIGN KEY REFERENCES Rol(Id_Rol),
    Id_Documento INT FOREIGN KEY REFERENCES TipoDocumento(Id_Documento),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

-- =========================
-- TABLAS DE LOGS Y REPORTES
-- =========================

CREATE TABLE Tipo_Accion (
    Id_Accion INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Objeto_Afectado (
    Id_Objeto_Afectado INT IDENTITY PRIMARY KEY,
    Nombre_Tabla NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Log_Sistema (
    Id_Log INT IDENTITY PRIMARY KEY,
    Id_Accion INT FOREIGN KEY REFERENCES Tipo_Accion(Id_Accion),
    Id_Objeto_Afectado INT FOREIGN KEY REFERENCES Objeto_Afectado(Id_Objeto_Afectado),
    Id_Usuario INT FOREIGN KEY REFERENCES Usuario(Id_Usuario),
    Fecha_Hora DATETIME NOT NULL,
    Filtro_Aplicado NVARCHAR(255),
    Id_Documento INT,
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Log_Detalle (
    Id_Detalle INT IDENTITY PRIMARY KEY,
    Id_Log INT FOREIGN KEY REFERENCES Log_Sistema(Id_Log),
    Campo_Afectado NVARCHAR(100),
    Valor_Anterior NVARCHAR(255),
    Valor_Nuevo NVARCHAR(255),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE TipoReporte (
    Id_Tipo_Reporte INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Reporte (
    Id_Reporte INT IDENTITY PRIMARY KEY,
    Id_Tipo_Reporte INT FOREIGN KEY REFERENCES TipoReporte(Id_Tipo_Reporte),
    Id_Usuario INT FOREIGN KEY REFERENCES Usuario(Id_Usuario),
    Fecha DATE,
    Url_Archivo NVARCHAR(255),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

-- =========================
-- TABLAS DE CLIENTES
-- =========================

CREATE TABLE EstadoCliente (
    Id_Estado INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Cliente (
    Id_Cliente INT PRIMARY KEY,
    Nombres NVARCHAR(100) NOT NULL,
    Apellidos NVARCHAR(100),
    Telefonos NVARCHAR(50),
    Email NVARCHAR(100),
    Id_Estado INT FOREIGN KEY REFERENCES EstadoCliente(Id_Estado),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

-- =========================
-- TABLAS DE SERVICIOS
-- =========================

CREATE TABLE EstadoEquipo (
    Id_EstadoEquipo INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Equipo (
    Id_Equipo INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Cantidad INT,
    Descripcion NVARCHAR(255),
    Id_EstadoEquipo INT FOREIGN KEY REFERENCES EstadoEquipo(Id_EstadoEquipo),
    Id_Servicio INT,
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Insumo (
    Id_Insumo INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Cantidad INT,
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Servicio (
    Id_Servicio INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Precio DECIMAL(18,2),
    Precio_Hora DECIMAL(18,2),
    Precio_Unitario DECIMAL(18,2),
    Id_Insumo INT FOREIGN KEY REFERENCES Insumo(Id_Insumo),
    Id_Equipo INT FOREIGN KEY REFERENCES Equipo(Id_Equipo),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Catalogo (
    Id_Catalogo INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Imagen NVARCHAR(255),
    Tiempo_Uso NVARCHAR(50),
    Id_Servicio INT FOREIGN KEY REFERENCES Servicio(Id_Servicio),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

-- =========================
-- TABLAS DE SOLICITUDES Y CONTRATOS
-- =========================

CREATE TABLE Estado_Solicitud (
    Id_Estado INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Solicitud (
    Id_Solicitud INT PRIMARY KEY,
    Id_Cliente INT FOREIGN KEY REFERENCES Cliente(Id_Cliente),
    Id_Servicio INT FOREIGN KEY REFERENCES Servicio(Id_Servicio),
    Precio DECIMAL(18,2),
    Descripcion NVARCHAR(255),
    Fecha DATE,
    Fecha_Evento DATE,
    Direccion_Evento NVARCHAR(255),
    Id_Estado INT FOREIGN KEY REFERENCES Estado_Solicitud(Id_Estado),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Estado_Cotizacion (
    Id_Estado INT PRIMARY KEY,
    Nombre_Estado NVARCHAR(100) NOT NULL,
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Cotizacion (
    Id_Cotizacion INT PRIMARY KEY,
    Id_Solicitud INT FOREIGN KEY REFERENCES Solicitud(Id_Solicitud),
    Id_Cliente INT FOREIGN KEY REFERENCES Cliente(Id_Cliente),
    Id_Usuario INT FOREIGN KEY REFERENCES Usuario(Id_Usuario),
    Id_Estado INT FOREIGN KEY REFERENCES Estado_Cotizacion(Id_Estado),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE EstadoContrato (
    Id_EstadoContrato INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Contrato (
    Id_Contrato INT PRIMARY KEY,
    Id_Cotizacion INT FOREIGN KEY REFERENCES Cotizacion(Id_Cotizacion),
    Id_EstadoContrato INT FOREIGN KEY REFERENCES EstadoContrato(Id_EstadoContrato),
    Descripcion NVARCHAR(255),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

-- =========================
-- TABLAS DE RESERVAS Y PAGOS
-- =========================

CREATE TABLE EstadoReserva (
    Id_Estado INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE TipoPago (
    Id_TipoPago INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Pago (
    Id_Pago INT PRIMARY KEY,
    Precio DECIMAL(18,2),
    Comprobante NVARCHAR(255),
    Id_TipoPago INT FOREIGN KEY REFERENCES TipoPago(Id_TipoPago),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);

CREATE TABLE Reserva (
    Id_Reserva INT PRIMARY KEY,
    Id_Contrato INT FOREIGN KEY REFERENCES Contrato(Id_Contrato),
    Fecha DATE,
    Descripcion NVARCHAR(255),
    Id_Pago INT FOREIGN KEY REFERENCES Pago(Id_Pago),
    Id_Estado INT FOREIGN KEY REFERENCES EstadoReserva(Id_Estado),
    Fecha_Creado DATETIME NOT NULL DEFAULT GETDATE(),
    Fecha_Actualizado DATETIME
);