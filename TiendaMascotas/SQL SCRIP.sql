use ProyectoPA

CREATE TABLE Usuarios(/*Considero que la edad no es necesaria xq eso me lo puede dar un API de la c�dula. Nombre y apellido se pueden hacer una sola*/
	idUsuario INT NOT NULL IDENTITY(1,1),
	nombre VARCHAR(30) NOT NULL,
	apellido VARCHAR(30) NOT NULL,
	cedula VARCHAR(50) NOT NULL UNIQUE,
	nombreUsuario VARCHAR(30) NOT NULL UNIQUE,
	contrasenna VARCHAR(30) NOT NULL,
	edad INT NOT NULL,
	estado INT NOT NULL,
	idRol VARCHAR(30) NOT NULL
	PRIMARY KEY(idUsuario)
);

CREATE TABLE Roles(
	idRol VARCHAR(30) NOT NULL,
	rol VARCHAR(30) NOT NULL,
	PRIMARY KEY(idRol)
);

CREATE TABLE Animales(
	idAnimal  INT NOT NULL IDENTITY(1,1),
	idTipoAnimal VARCHAR(30) NOT NULL,
	nombre VARCHAR(30) NOT NULL,
	descripcion VARCHAR(100) NOT NULL,
	estado INT NOT NULL
	PRIMARY KEY(idAnimal)
);

CREATE TABLE TipoAnimal(
	idTipoAnimal VARCHAR(30) NOT NULL,
	tipoAnimal VARCHAR(30) NOT NULL
	PRIMARY KEY(idTipoAnimal)
);

CREATE TABLE Adopciones( 
	idAdopcion INT NOT NULL IDENTITY(1,1),
	nombreUsuario VARCHAR(30) NOT NULL,
	idAnimal INT NOT NULL,
	fechaAdopcion DATE NOT NULL,
	PRIMARY KEY(idAdopcion)
);

CREATE TABLE Productos(
	idProducto INT NOT NULL IDENTITY(1,1),
	nombre VARCHAR(30) NOT NULL,
	descripcion VARCHAR(100) NOT NULL,
	cantidad INT NOT NULL,
	precio NUMERIC(10,3) NOT NULL,
	descuento INT NOT NULL,
	idTipoProducto VARCHAR(30) NOT NULL
	PRIMARY KEY (idProducto)
);

CREATE TABLE TipoProductos(
	idTipoProducto VARCHAR(30) NOT NULL,
	tipoProducto VARCHAR(30) NOT NULL
	PRIMARY KEY(idTipoProducto)
);

CREATE TABLE Factura(
	idFactura INT NOT NULL IDENTITY(1,1),
	cedula VARCHAR(50) NOT NULL,
	terminos VARCHAR(50) NOT NULL,
	fecha DATE NOT NULL
	PRIMARY KEY(idFactura)
);

CREATE TABLE DetalleFactura(
	idDetalleFactura INT NOT NULL IDENTITY(1,1),
	idFactura INT NOT NULL,
	idProducto INT NOT NULL,
	cantidad INT NOT NULL,
	monto INT NOT NULL
	PRIMARY KEY(idDetalleFactura)
);

CREATE TABLE Bitacoras(
    idBitacora INT NOT NULL IDENTITY(1,1),
	consecutivoError VARCHAR(30) NOT NULL,
    fechaHora DATETIME NOT NULL,
    origen NVARCHAR(100) NOT NULL,
	mensajeError NVARCHAR(MAX) NOT NULL,
	/*idUsuario INT NOT NULL,*/ /*Esta linea hace match con el usuario al cual se le presento el error, la hacemos?*/
);

ALTER TABLE Usuarios ADD FOREIGN KEY(idRol) REFERENCES Roles(idRol);
ALTER TABLE Animales ADD FOREIGN KEY(idTipoAnimal) REFERENCES TipoAnimal(idTipoAnimal);
ALTER TABLE Adopciones ADD FOREIGN KEY(nombreUsuario) REFERENCES Usuarios(nombreUsuario);
ALTER TABLE Adopciones ADD FOREIGN KEY(idAnimal) REFERENCES Animales(idAnimal);
ALTER TABLE Productos ADD FOREIGN KEY(idTipoProducto) REFERENCES TipoProductos(idTipoProducto);
ALTER TABLE Factura ADD FOREIGN KEY(cedula) REFERENCES Usuarios(cedula);
ALTER TABLE DetalleFactura ADD FOREIGN KEY(idFactura) REFERENCES Factura(idFactura);
ALTER TABLE DetalleFactura ADD FOREIGN KEY(idProducto) REFERENCES Productos(idProducto);
