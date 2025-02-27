CREATE DATABASE [ProyectoPA]
USE [ProyectoPA]
GO
/****** Object:  Table [dbo].[Adopciones]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adopciones](
	[idAdopcion] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](50) NOT NULL,
	[idAnimal] [int] NOT NULL,
	[fechaAdopcion] [datetime] NOT NULL,
	[estadoAdopcion] [int] NOT NULL,
 CONSTRAINT [PK__Adopcion__210DF8ADB41E68D9] PRIMARY KEY CLUSTERED 
(
	[idAdopcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Animales]    Script Date: 4/15/2023 5:00:37 PM ******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Animales](
	[idAnimal] [int] IDENTITY(1,1) NOT NULL,
	[idTipoAnimal] [varchar](30) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[estado] [bit] NOT NULL,
	[imagen] [varbinary](max) NULL,
 CONSTRAINT [PK__Animales__0276B503E3C3AAB2] PRIMARY KEY CLUSTERED 
(
	[idAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Bitacoras]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacoras](
	[idBitacora] [int] IDENTITY(1,1) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[origen] [nvarchar](100) NOT NULL,
	[mensajeError] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [ProyectoPA]
GO

/****** Object:  Table [dbo].[Detalle]    Script Date: 4/16/2023 6:29:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Detalle](
	[idDetalle] [bigint] IDENTITY(1,1) NOT NULL,
	[idMaestro] [bigint] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioCompra] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK__DetalleF__DFF38252868A0C81] PRIMARY KEY CLUSTERED 
(
	[idDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EstadoAdopcion]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoAdopcion](
	[idEstadoAdopcion] [int] NOT NULL,
	[estadoAdopcion] [varchar](20) NULL,
 CONSTRAINT [PK_EstadoAdopcion] PRIMARY KEY CLUSTERED 
(
	[idEstadoAdopcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [ProyectoPA]
GO

/****** Object:  Table [dbo].[Maestro]    Script Date: 4/16/2023 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Maestro](
	[idMaestro] [bigint] IDENTITY(1,1) NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[FechaCompra] [datetime] NOT NULL,
	[SubTotal] [decimal](10, 2) NOT NULL,
	[Impuestos] [decimal](10, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK__Factura__3CD5687E49DE29A0] PRIMARY KEY CLUSTERED 
(
	[idMaestro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[cantidad] [int] NOT NULL,
	[precio] [numeric](10, 2) NOT NULL,
	[imagen] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [ProyectoPA]
GO

/****** Object:  Table [dbo].[Carrito]    Script Date: 4/16/2023 6:15:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Carrito](
	[idCarrito] [bigint] IDENTITY(1,1) NOT NULL,
	[idProducto] [int] NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED 
(
	[idCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[Roles]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRol] [varchar](30) NOT NULL,
	[rol] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAnimal]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAnimal](
	[idTipoAnimal] [varchar](30) NOT NULL,
	[tipoAnimal] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](50) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[correoElectronico] [varchar](30) NOT NULL,
	[contrasenna] [varchar](30) NOT NULL,
	[estado] [bit] NOT NULL,
	[idRol] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[correoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Adopciones]  WITH CHECK ADD  CONSTRAINT [FK_Adopciones_Animales] FOREIGN KEY([idAnimal])
REFERENCES [dbo].[Animales] ([idAnimal])
GO
ALTER TABLE [dbo].[Adopciones] CHECK CONSTRAINT [FK_Adopciones_Animales]
GO
ALTER TABLE [dbo].[Adopciones]  WITH CHECK ADD  CONSTRAINT [FK_Adopciones_EstadoAdopcion] FOREIGN KEY([estadoAdopcion])
REFERENCES [dbo].[EstadoAdopcion] ([idEstadoAdopcion])
GO
ALTER TABLE [dbo].[Adopciones] CHECK CONSTRAINT [FK_Adopciones_EstadoAdopcion]
GO
ALTER TABLE [dbo].[Adopciones]  WITH CHECK ADD  CONSTRAINT [FK_Adopciones_Usuarios] FOREIGN KEY([cedula])
REFERENCES [dbo].[Usuarios] ([cedula])
GO
ALTER TABLE [dbo].[Adopciones] CHECK CONSTRAINT [FK_Adopciones_Usuarios]
GO
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD  CONSTRAINT [FK__Animales__idTipo__49C3F6B7] FOREIGN KEY([idTipoAnimal])
REFERENCES [dbo].[TipoAnimal] ([idTipoAnimal])
GO
ALTER TABLE [dbo].[Animales] CHECK CONSTRAINT [FK__Animales__idTipo__49C3F6B7]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Productos] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Productos] ([idProducto])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Productos]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Usuarios] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Usuarios]
GO
ALTER TABLE [dbo].[Maestro]  WITH CHECK ADD  CONSTRAINT [FK_Maestro_Usuarios] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Maestro] CHECK CONSTRAINT [FK_Maestro_Usuarios]
GO
ALTER TABLE [dbo].[Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Maestro] FOREIGN KEY([idMaestro])
REFERENCES [dbo].[Maestro] ([idMaestro])
GO
ALTER TABLE [dbo].[Detalle] CHECK CONSTRAINT [FK_Detalle_Maestro]
GO
ALTER TABLE [dbo].[Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Productos] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Productos] ([idProducto])
GO
ALTER TABLE [dbo].[Detalle] CHECK CONSTRAINT [FK_Detalle_Productos]
GO

/****** Object:  StoredProcedure [dbo].[CambiarEstadoAdopcion]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CambiarEstadoAdopcion]
	@idAdopcion int,
	@id int
AS
BEGIN
	DECLARE @idAnimal int;

	SELECT @idAnimal = idAnimal
		FROM Adopciones
		WHERE idAdopcion = @idAdopcion;

	IF @id = 1 
	BEGIN

		UPDATE Adopciones
		SET estadoAdopcion = 1
		WHERE idAdopcion = @idAdopcion;
		
		UPDATE Animales
		SET estado = 0
		WHERE idAnimal = @idAnimal;
		
		
	END

	ELSE IF @id = 2
	BEGIN
		
		UPDATE Adopciones
		SET estadoAdopcion = 2
		WHERE idAdopcion = @idAdopcion;

		UPDATE Animales
		SET estado = 1
		WHERE idAnimal = @idAnimal;

	END

END
GO
/****** Object:  StoredProcedure [dbo].[MostrarAdopciones]    Script Date: 4/15/2023 5:00:37 PM ******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MostrarAdopciones]
	
AS
BEGIN
	SELECT	adop.idAdopcion, adop.cedula, adop.idAnimal, adop.fechaAdopcion,
		usr.nombre, usr.correoElectronico, tipoUsu.rol, ani.nombre AS nombre_animal, ani.descripcion,ani.imagen,
		tipoAni.tipoAnimal, estAdop.estadoAdopcion
FROM adopciones adop
	INNER JOIN usuarios usr ON adop.cedula = usr.cedula
	INNER JOIN animales ani ON adop.idAnimal = ani.idAnimal
	INNER JOIN tipoAnimal tipoAni ON ani.idTipoAnimal = tipoAni.idTipoAnimal
	INNER JOIN Roles tipoUsu ON usr.idRol = tipoUsu.idRol
	INNER JOIN estadoAdopcion estAdop ON adop.estadoAdopcion = Estadop.idEstadoAdopcion;
END
GO


/****** Object:  StoredProcedure [dbo].[MostrarAnimales]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MostrarAnimales]
	AS
	BEGIN

		SELECT idAnimal,		
			  tipoAnimal.tipoAnimal,
			  nombre,
			  descripcion,
			  estado,
			  imagen
		  FROM Animales 
		  INNER JOIN tipoAnimal
		  ON  Animales.idTipoAnimal = tipoAnimal.idTipoAnimal
	END
GO
/****** Object:  StoredProcedure [dbo].[MostrarProductos]    Script Date: 4/15/2023 5:00:37 PM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MostrarProductos]
	
AS
BEGIN
	
SELECT idProducto
      ,nombre
      ,descripcion
      ,cantidad
      ,precio
      ,imagen
      
  FROM Productos
  WHERE cantidad > 1
END
GO
/****** Object:  StoredProcedure [dbo].[Registrar]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Registrar] 
	@cedula VARCHAR(50),
	@nombre VARCHAR(30),
	@correoElectronico VARCHAR(30),
	@contrasenna VARCHAR(30)
AS
BEGIN
INSERT INTO Usuarios (cedula, nombre, correoElectronico, contrasenna, estado, idRol)
     VALUES (@cedula, @nombre, @correoElectronico, @contrasenna, 1, 2)
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarAdopcion]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarAdopcion]
	@idAnimal int,
	@cedula varchar(50),
	@fechaAdopcion datetime,
	@estadoAdopcion int
AS
BEGIN
	
	UPDATE Animales
	SET estado = 0
	WHERE idAnimal = @idAnimal;

	INSERT INTO Adopciones
           (cedula
           ,idAnimal
           ,fechaAdopcion
		   ,estadoAdopcion)
     VALUES
           (@cedula,
			@idAnimal,
			@fechaAdopcion,
			@estadoAdopcion)
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarAnimal]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarAnimal]
	@idTipoAnimal varchar(30),
	@nombre varchar(30),
	@descripcion varchar(100),
	@imagen varbinary(max)
AS
BEGIN
INSERT INTO Animales
           (idTipoAnimal,
           nombre,
           descripcion,
          estado,
		  imagen)
     VALUES
           (@idTipoAnimal,
			@nombre,
			@descripcion,
			1,
			@imagen)
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarProducto]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarProducto]
	@nombre varchar(30),
	@descripcion varchar(100),
	@cantidad int,
	@precio numeric (10,3),
	@imagen varbinary(max)

AS
BEGIN


INSERT INTO Productos
           (nombre
           ,descripcion
           ,cantidad
           ,precio
           ,imagen)
     VALUES
           (@nombre,@descripcion,@cantidad,@precio,@imagen)

END


/****** Object:  StoredProcedure [dbo].[ValidarUsuario]    Script Date: 4/15/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ValidarUsuario]
	@correoElectronico VARCHAR(30),
	@contrasenna VARCHAR(30)
AS
BEGIN
	SELECT idUsuario,
		  nombre,
		  correoElectronico,
		  cedula,
		  estado,
		  idRol
	  FROM dbo.Usuarios
	  WHERE correoElectronico = @correoElectronico
	  AND contrasenna = @contrasenna
	  AND estado = 1
END
GO


/*Stored Procedure ConfirmarPago*/
create procedure ConfirmarPago @ConsecutivoUsuario int
as
begin

	declare @iva DECIMAL(10,2) = 0.13

	-- registra maestro
	insert into dbo.Maestro(ConsecutivoUsuario,FechaCompra,SubTotal,Impuestos,Total)
	select C.ConsecutivoUsuario, 
			GETDATE(),
			SUM(C.Cantidad * P.Precio),
			SUM((C.Cantidad * P.Precio) * @iva),
			SUM(C.Cantidad * P.Precio + ((C.Cantidad * P.Precio) * @iva))
	from Carrito C
	inner join Productos P ON C.idProducto=P.idProducto 
	where C.ConsecutivoUsuario = @ConsecutivoUsuario
	group by C.ConsecutivoUsuario


	--registra detalle
	insert into dbo.Detalle(idMaestro,idProducto,cantidad,precioCompra)
	select @@IDENTITY, 
			C.idProducto,
			C.Cantidad,
			C.Cantidad * P.precio
	from Carrito C
	inner join Productos P ON C.idProducto=P.idProducto 
	where ConsecutivoUsuario = @ConsecutivoUsuario

	--descuenta del inventario
	update P
	set P.cantidad = P.cantidad -  C.cantidad
	from Productos P
	inner join Carrito C on P.idProducto = C.idProducto
	where C.ConsecutivoUsuario = @ConsecutivoUsuario

	--limpia el carrito
	delete from carrito where ConsecutivoUsuario = @ConsecutivoUsuario

end
go

/*Stored procedure [ValidarStock] */
CREATE PROCEDURE [dbo].[ValidarStock] @ConsecutivoUsuario int
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @InStock bit = 1;
	DECLARE @idProducto int;
	DECLARE @Cantidad int;

    -- Check if each item in the carrito is in stock
    DECLARE carrito_cursor CURSOR FOR 
        SELECT idProducto, Cantidad FROM [dbo].[Carrito] WHERE ConsecutivoUsuario = @ConsecutivoUsuario;
    OPEN carrito_cursor;
    FETCH NEXT FROM carrito_cursor INTO @idProducto, @Cantidad;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @Stock int;
        SELECT @Stock = cantidad FROM [dbo].[Productos] WHERE idProducto = @idProducto;
        IF @Stock < @Cantidad
        BEGIN
            SET @InStock = 0;
            BREAK;
        END
        FETCH NEXT FROM carrito_cursor INTO @idProducto, @Cantidad;
    END
    CLOSE carrito_cursor;
    DEALLOCATE carrito_cursor;

    -- Return 1 if everything is in stock, 0 otherwise
    SELECT @InStock AS InStock;
END

--EXEC [dbo].[ValidarStock] @ConsecutivoUsuario = 1;

/*stored procedure Mostrar Facturas*/
create procedure MostrarFacturas @ConsecutivoUsuario int
as
begin
	select D.idMaestro,
	M.FechaCompra,
	M.Total
	from Maestro M
	inner join Detalle D ON M.idMaestro = D.idMaestro
	where M.ConsecutivoUsuario = @ConsecutivoUsuario
end
go

/****** Object:  StoredProcedure [dbo].[MostrarCompraCarrito]    Script Date: 4/19/2023 9:43:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[MostrarCompraCarrito]
	@ConsecutivoUsuario int 
AS
BEGIN

	SELECT	ISNULL(SUM(C.Cantidad),0)				CantidadCompra, 
			ISNULL(SUM(C.Cantidad * Precio),0)	MontoCompra
	FROM CARRITO C
	INNER JOIN PRODUCTOS P ON C.IdProducto = P.IdProducto
	WHERE ConsecutivoUsuario = @ConsecutivoUsuario

END
GO

USE [ProyectoPA]
GO

/****** Object:  StoredProcedure [dbo].[MostrarDetalleCarrito]    Script Date: 4/19/2023 9:43:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[MostrarDetalleCarrito]
	@ConsecutivoUsuario INT 
AS
BEGIN

	DECLARE @iva DECIMAL(10,2) = 0.13

	SELECT	CONVERT(VARCHAR,C.IdProducto) + ' - ' + P.Nombre			'Nombre',
			C.Cantidad													'Cantidad',
			P.Precio													'Precio',
			C.Cantidad * P.Precio										'SubTotal',
			(C.Cantidad * P.Precio) * @iva								'Impuesto',
			C.Cantidad * P.Precio + ((C.Cantidad * P.Precio) * @iva)	'Total'
	FROM CARRITO C
	INNER JOIN PRODUCTOS P ON C.IdProducto = P.IdProducto
	WHERE ConsecutivoUsuario = @ConsecutivoUsuario
END
GO

/****** Object:  StoredProcedure [dbo].[CorreoAdopcion]    Script Date: 04/23/2023 9:17:20 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CorreoAdopcion]
	@idAdopcion int
AS
BEGIN
	DECLARE @cedula int;
	SELECT 
		@cedula = cedula
	FROM Adopciones
	where idAdopcion = @idAdopcion

	SELECT 
		correoElectronico
	FROM Usuarios
	where cedula = @cedula 
END
GO


/*INSERT DE BD NECESARIOS*/
INSERT INTO EstadoAdopcion (idEstadoAdopcion ,estadoAdopcion)
VALUES  (1, 'Aceptada'),
		(2, 'Denegada'),
	    (3, 'En Espera')
GO

INSERT INTO TipoAnimal ([idTipoAnimal] ,[tipoAnimal])
VALUES  (1, 'perro'),
		(2, 'gato')
GO

INSERT INTO Roles (idRol ,rol)
VALUES  (1, 'admin'),
		(2, 'usuario')
GO

USE [ProyectoPA]
GO
