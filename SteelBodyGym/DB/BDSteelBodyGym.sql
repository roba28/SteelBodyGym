CREATE DATABASE SteelBodyGym;

USE SteelBodyGym;
USE SteelBodyGym

-- Tabla Rol: Roles de usuarios en el gimnasio
CREATE TABLE Rol (
    rol_id INT PRIMARY KEY,
    nombre_rol VARCHAR(50) NOT NULL
);

-- Tabla Usuarios: Informaci�n b�sica de los usuarios
CREATE TABLE Usuarios (
    usuario_id INT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    genero VARCHAR(10),
    rol_id INT,
    FOREIGN KEY (rol_id) REFERENCES Rol(rol_id)
);

-- Tabla EstadoUsuario: Estados posibles de un usuario (activo, inactivo, etc.)
CREATE TABLE EstadoUsuario (
    estado_id INT PRIMARY KEY,
    nombre_estado VARCHAR(50) NOT NULL
);

-- Tabla RutinasGimnasio: Informaci�n sobre las rutinas disponibles en el gimnasio
CREATE TABLE RutinasGimnasio (
    rutina_id INT PRIMARY KEY,
    nombre_rutina VARCHAR(50) NOT NULL
);

-- Tabla RutinasPorUsuario: Relaci�n entre usuarios y rutinas
CREATE TABLE RutinasPorUsuario (
    usuario_id INT,
    rutina_id INT,
    PRIMARY KEY (usuario_id, rutina_id),
    FOREIGN KEY (usuario_id) REFERENCES Usuarios(usuario_id),
    FOREIGN KEY (rutina_id) REFERENCES RutinasGimnasio(rutina_id)
);

-- Tabla MaquinasGimnasio: Informaci�n sobre las m�quinas disponibles en el gimnasio
CREATE TABLE MaquinasGimnasio (
    maquina_id INT PRIMARY KEY,
    nombre_maquina VARCHAR(50) NOT NULL
);

-- Tabla Provincia, Canton, Distrito: Informaci�n geogr�fica
CREATE TABLE Provincia (
    provincia_id INT PRIMARY KEY,
    nombre_provincia VARCHAR(50) NOT NULL


);

CREATE TABLE Canton (
    canton_id INT PRIMARY KEY,
    nombre_canton VARCHAR(50) NOT NULL,
    provincia_id INT,
    FOREIGN KEY (provincia_id) REFERENCES Provincia(provincia_id)
);

CREATE TABLE Distrito (
    distrito_id INT PRIMARY KEY,
    nombre_distrito VARCHAR(50) NOT NULL,
    canton_id INT,
    FOREIGN KEY (canton_id) REFERENCES Canton(canton_id)
);

-- Tabla TipoIdentificacion: Tipos de identificaci�n (c�dula, pasaporte, etc.)
CREATE TABLE TipoIdentificacion (
    tipo_id INT PRIMARY KEY,
    nombre_tipo VARCHAR(50) NOT NULL
);

-- Tabla PagosPorUsuario: Informaci�n sobre los pagos realizados por cada usuario
CREATE TABLE PagosPorUsuario (
    pago_id INT PRIMARY KEY,
    usuario_id INT,
    fecha_pago DATE NOT NULL,
    monto DECIMAL(10, 2) NOT NULL,
    tipo_pago_id INT,
    tipo_inscripcion_id INT,
    FOREIGN KEY (usuario_id) REFERENCES Usuarios(usuario_id),
    FOREIGN KEY (tipo_pago_id) REFERENCES TiposPago(tipo_pago_id),
    FOREIGN KEY (tipo_inscripcion_id) REFERENCES TiposInscripcion(tipo_inscripcion_id)
);

-- Tabla TiposPago: Tipos de pagos (tarjeta, efectivo, etc.)
CREATE TABLE TiposPago (
    tipo_pago_id INT PRIMARY KEY,
    nombre_tipo_pago VARCHAR(50) NOT NULL
);

-- Tabla TiposInscripcion: Tipos de inscripci�n en el gimnasio (mensual, anual, etc.)
CREATE TABLE TiposInscripcion (
    tipo_inscripcion_id INT PRIMARY KEY,
    nombre_tipo_inscripcion VARCHAR(50) NOT NULL
);

-- Tabla MedidasCorporalesUsuario: Informaci�n sobre las medidas corporales de los usuarios
CREATE TABLE MedidasCorporalesUsuario (
    medida_id INT PRIMARY KEY,
    usuario_id INT,
    fecha_medicion DATE NOT NULL,
    altura DECIMAL(5, 2),
    peso DECIMAL(5, 2),
    cintura DECIMAL(5, 2),
    FOREIGN KEY (usuario_id) REFERENCES Usuarios(usuario_id)
);
