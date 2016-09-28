-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Siegfried
-- Description:	Script Inicial TP GDD 2do Cuatrimestre 2016
-- =============================================


CREATE SCHEMA SIEGFRIED;
GO

CREATE PROCEDURE SIEGFRIED.CREATE_TABLES_AND_FILL
AS
BEGIN
	SET NOCOUNT ON;

	CREATE TABLE SIEGFRIED.USUARIOS (
		id_usuario numeric(18,0) IDENTITY(1,1) NOT NULL,
		username NVARCHAR(255),
		contrasenia binary(32),
		habilitado				numeric(18,0) DEFAULT 1,
		intentos_login			numeric(18,0) DEFAULT 0,
		primera_vez				numeric(18,0),
		PRIMARY KEY(id_usuario)
	);

	CREATE TABLE SIEGFRIED.ROLES
	(
		Id_Rol						numeric(18,0) IDENTITY(1,1) NOT NULL,
		Nombre						nvarchar(255),
		Habilitado					numeric(18,0) DEFAULT 1,
		PRIMARY KEY(Id_Rol)
	);

	CREATE TABLE SIEGFRIED.ROLES_USUARIOS 
	(
		Id_Rol						numeric(18,0),
		Id_Usuario					numeric(18,0),
		PRIMARY KEY(Id_Rol, Id_Usuario),
		FOREIGN KEY(Id_Rol) REFERENCES SIEGFRIED.ROLES(Id_Rol),
		FOREIGN KEY(Id_Usuario) REFERENCES SIEGFRIED.USUARIOS(Id_Usuario)

	);


	CREATE TABLE SIEGFRIED.FUNCIONALIDADES
	(
		Id_Funcionalidad			numeric(18,0) IDENTITY(1,1) NOT NULL,
		Nombre						nvarchar(255),
		PRIMARY KEY(Id_Funcionalidad)
	);
	
	CREATE TABLE SIEGFRIED.FUNCIONALIDES_ROLES
	(
		Id_Funcionalidad			numeric(18,0),
		Id_Rol						numeric(18,0),
		PRIMARY KEY(Id_Funcionalidad,Id_Rol),
		FOREIGN KEY(Id_Rol) REFERENCES SIEGFRIED.ROLES(Id_Rol),
		FOREIGN KEY(Id_Funcionalidad) REFERENCES SIEGFRIED.FUNCIONALIDADES(Id_Funcionalidad)
	);

	CREATE TABLE SIEGFRIED.ESTADOS_CIVILES( 
		id_estado numeric(18,0) identity(1,1) NOT NULL PRIMARY KEY,
		descripcion nvarchar(255)
	);

	CREATE TABLE SIEGFRIED.AFILIADOS(
		id_afiliado numeric(18,0) NOT NULL,
		nombre nvarchar(255),
		direccion nvarchar(255),
		telefono numeric(18,0),
		mail nvarchar(255),
		fecha_nacimiento datetime,
		sexo numeric(18,0) DEFAULT NULL,
		estado_civil numeric(18,0) FOREIGN KEY REFERENCES SIEGFRIED.ESTADOS_CIVILES(id_estado),
		cantidad_familiares numeric(18,0) DEFAULT 0,
		id_plan numeric(18,0) foreign key references SIEGFRIED.PLANES(id_plan)

		PRIMARY KEY(id_afiliado)
	);

	CREATE TABLE SIEGFRIED.PLANES(
		id_plan numeric(18,0) PRIMARY KEY,
		descripcion varchar(255),
		precio_bono_consulta numeric(18,0)
	);

	CREATE TABLE SIEGFRIED.PROFESIONALES ( 
		id_profesional numeric(18,0) -- cuenta como matricula?
	);

	CREATE TABLE SIEGFRIED.ESPECIALIDADES (
		id_especialidad numeric(18,0) NOT NULL PRIMARY KEY,
		descripcion varchar(255),
		id_tipo_especialidad numeric(18,0) foreign key references SIEGFRIED.TIPOS_ESPECIALIDADES(id_tipo)
	);

	CREATE TABLE SIEGFRIED.TIPOS_ESPECIALIDADES ( 
		id_tipo numeric(18,0) primary key,
		descripcion varchar(255)
	);

	CREATE TABLE SIEGFRIED.AGENDA (
		id_profesional numeric(18,0) not null,
		dia_semana numeric(18,0) not null,
		hora_desde numeric(18,0) not null,
		hora_hasta numeric(18,0) not null,
		primary key(id_profesional,dia_semana),
		foreign key(id_profesional) references SIEGFRIED.PROFESIONALES(id_profesional)
	)

	CREATE TABLE SIEGFRIED.TURNOS(
		id_turno numeric(18,0) primary key,
		id_afiliado numeric(18,0) foreign key references SIEGFRIED.AFILIADOS(id_afiliado),
		id_profesional numeric(18,0) foreign key references SIEGFRIED.PROFESIONALES(id_profesional),
		fecha datetime,
		--numero_turno numeric(18,0) -- ????
	)

	CREATE TABLE SIEGFRIED.CONSULTAS()

	CREATE TABLE SIEGFRIED.BONOS()

	CREATE TABLE SIEGFRIED.CANCELACION()

	CREATE TABLE SIEGFRIED.TIPOS_CANCELACION()
    
END
GO
