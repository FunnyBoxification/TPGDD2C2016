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

----------------------------------- PROCEDIMIENTOS --------------------------------------------------------------------

CREATE PROCEDURE SIEGFRIED.CREATE_TABLES_AND_FILL
AS
BEGIN
	SET NOCOUNT ON;

	CREATE TABLE SIEGFRIED.ESTADOS_CIVILES( 
		id_estado numeric(18,0) identity(1,1) NOT NULL PRIMARY KEY,
		descripcion nvarchar(255)
	);

	CREATE TABLE SIEGFRIED.USUARIOS (
		id_usuario numeric(18,0) IDENTITY(1,1) NOT NULL,
		username NVARCHAR(255),
		contrasenia binary(32),
		habilitado				numeric(18,0) DEFAULT 1,
		intentos_login			numeric(18,0) DEFAULT 0,
		nombre nvarchar(255),
		apellido nvarchar(255),
		direccion nvarchar(255),
		tipo_dni nvarchar(255),
		nro_dni numeric(18,0),
		telefono numeric(18,0),
		mail nvarchar(255),
		fecha_nacimiento datetime,
		sexo numeric(18,0) DEFAULT NULL,
		
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

	CREATE TABLE SIEGFRIED.PLANES(
		id_plan numeric(18,0) PRIMARY KEY,
		descripcion varchar(255),
		precio_bono_consulta numeric(18,0)
	);

	CREATE TABLE SIEGFRIED.AFILIADOS(
		id_afiliado numeric(18,0) NOT NULL,
		estado_civil numeric(18,0) FOREIGN KEY REFERENCES SIEGFRIED.ESTADOS_CIVILES(id_estado),
		cantidad_familiares numeric(18,0) DEFAULT 0,
		id_plan numeric(18,0) foreign key references SIEGFRIED.PLANES(id_plan),
		PRIMARY KEY(id_afiliado)
	);

		|				   
	CREATE TABLE SIEGFRIED.PROFESIONALES ( 
		id_profesional numeric(18,0) NOT NULL PRIMARY KEY,
		matricula varchar(255)--ppor las dudas dejo esto -- cuenta como matricula?
	);

	CREATE TABLE SIEGFRIED.TIPOS_ESPECIALIDADES ( 
		id_tipo numeric(18,0) primary key,
		descripcion varchar(255)
	);

	CREATE TABLE SIEGFRIED.ESPECIALIDADES (
		id_especialidad numeric(18,0) NOT NULL PRIMARY KEY,
		descripcion varchar(255),
		id_tipo_especialidad numeric(18,0) foreign key references SIEGFRIED.TIPOS_ESPECIALIDADES(id_tipo)
	);

	CREATE TABLE SIEGFRIED.PROFESIONAL_ESPECIALIDAD ( 
		Id_profesional			numeric(18,0),
		Id_especialidad			numeric(18,0),
		PRIMARY KEY(Id_profesional,Id_especialidad),
		FOREIGN KEY(Id_profesional) REFERENCES SIEGFRIED.PROFESIONALES(Id_profesional),
		FOREIGN KEY(Id_especialidad) REFERENCES SIEGFRIED.ESPECIALIDADES(Id_especialidad)
	);	


	CREATE TABLE SIEGFRIED.AGENDA (
		id_profesional numeric(18,0) not null,
		dia_semana numeric(18,0) not null,
		hora_desde numeric(18,0) not null,
		hora_hasta numeric(18,0) not null,
		primary key(id_profesional,dia_semana),
		foreign key(id_profesional) references SIEGFRIED.PROFESIONALES(id_profesional)
	);

	CREATE TABLE SIEGFRIED.TURNOS(
		id_turno numeric(18,0) primary key,
		id_afiliado numeric(18,0) foreign key references SIEGFRIED.AFILIADOS(id_afiliado),
		id_profesional numeric(18,0) foreign key references SIEGFRIED.PROFESIONALES(id_profesional),
		fecha datetime,
		--numero_turno numeric(18,0) -- ????
	);

	CREATE TABLE SIEGFRIED.CONSULTAS(
		id_consulta numeric(18,0) not null identity(1,1) primary key
		hora_llegada datetime,
		hora_atencion datetime,
		sintomas varchar(255),
		diagnostico varchar(255),
		id_turno numeric(18,0) foreign key references SIEGFRIED.TURNOS(id_turno)
	);

	CREATE TABLE SIEGFRIED.BONOS( -- FALTA AGREGAR CONSTRAINTS!!
		id_bono numeric(18,0) primary key,
		id_plan numeric(18,0) foreign key references SIEGFRIED.PLANES(id_plan),
		id_afiliado numeric(18,0) foreign key references SIEGFRIED.AFILIADOS(id_afiliado),
		id_consulta numeric(18,0) foreign key references SIEGFRIED.CONSULTAS(id_consulta),
		fecha_compra datetime
	);

	CREATE TABLE SIEGFRIED.TIPOS_CANCELACION(
		id_tipo numeric(18,0) not null identity(1,1) primary key,
		descripcion varchar(255)
	);

	CREATE TABLE SIEGFRIED.CANCELACION(
		id_turno numeric(18,0) foreign key references SIEGFRIED.TURNOS(id_turno),
		id_tipo_cancelacion numeric(18,0) foreign key references SIEGFRIED.TIPOS_CANCELACION(id_tipo),
		primary key(id_turno, id_tipo_cancelacion)
	);

	
    
END
GO


---------------------------------------------------- MAIN EXECUTION ---------------------------------------------------
BEGIN TRY
	BEGIN TRANSACTION MAIN_T
		INSERT INTO SIEGFRIED.USUARIOS
		SELECT DISTINCT
			Paciente_Nombre+Paciente_Apellido,   --username NVARCHAR(255),
			'1234', --contrasenia binary(32),
			1,	--habilitado		numeric(18,0) DEFAULT 1,
			0,--cantlog			numeric(18,0) DEFAULT 0,
			Paciente_Nombre, --nombre nvarchar(255),
			Paciente_Apellido,
			Paciente_Direccion, --direccion nvarchar(255),
			'dni', --tipo_dni nvarchar(255),
			Paciente_Dni, --nro_dni numeric(18,0),
			Paciente_Telefono, --telefono numeric(18,0),
			Paciente_Mail, --mail nvarchar(255),
			Paciente_Fecha_Nac, --fecha_nacimiento datetime,
			NULL
		FROM gd_esquema.Maestra 
		WHERE Paciente_Nombre IS NOT NULL;
		
		INSERT INTO SIEGFRIED.USUARIOS
		SELECT DISTINCT
			Medico_Nombre+Medico_Apellido,   --username NVARCHAR(255),
			'1234', --contrasenia binary(32),
			1,	--habilitado		numeric(18,0) DEFAULT 1,
			0,--cantlog			numeric(18,0) DEFAULT 0,
			Medico_Nombre, --nombre nvarchar(255),
			Medico_Apellido,
			Medico_Direccion, --direccion nvarchar(255),
			'dni', --tipo_dni nvarchar(255),
			Medico_Dni, --nro_dni numeric(18,0),
			Medico_Telefono, --telefono numeric(18,0),
			Medico_Mail, --mail nvarchar(255),
			Medico_Fecha_Nac, --fecha_nacimiento datetime,
			NULL
		FROM gd_esquema.Maestra 
		WHERE Paciente_Nombre IS NOT NULL;
		
		INSERT INTO SIEGFRIED.ESPECIALIDADES
		SELECT DISTINCT
			Especialidad_Codigo,
			Especialidad_Descripcion
		FROM gd_esquema.Maestra 
		WHERE Especialidad_Codigo IS NOT NULL;

		INSERT INTO SIEGFRIED.TIPOS_ESPECIALIDADES
		SELECT DISTINCT
			Tipo_Especialidad_Codigo,
			Tipo_Especialidad_Descripcion
		FROM gd_esquema.Maestra 
		WHERE Tipo_Especialidad_Codigo IS NOT NULL;

	--	HACER TODA LA NORMALIZACION DE LA TABLA MAESTRA ACA!!!
	COMMIT TRANSACTION MAIN_T
END TRY
BEGIN CATCH
	IF (@@TRANCOUNT > 0)
	BEGIN
		ROLLBACK TRANSACTION MAIN_T
	END
END CATCH

