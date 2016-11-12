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
		id_usuario numeric(18,0) NOT NULL,
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

	CREATE TABLE SIEGFRIED.PLANES (
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
			   
	CREATE TABLE SIEGFRIED.PROFESIONALES ( 
		id_profesional numeric(18,0) NOT NULL PRIMARY KEY,
		matricula varchar(255)--ppor las dudas dejo esto -- cuenta como matricula?
	);

	CREATE TABLE SIEGFRIED.TIPOS_ESPECIALIDADES ( 
		id_tipo numeric(18,0) primary key,
		descripcion varchar(255)
	);

	CREATE TABLE SIEGFRIED.ESPECIALIDADES (
		id_especialidad numeric(18,0) PRIMARY KEY,
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
	
	CREATE TABLE SIEGFRIED.HISTORIAL_USUARIOS_PLANES (
		id_afiliado numeric(18,0) foreign key references siegfried.afiliados(id_afiliado),
		id_plan_viejo numeric(18,0) foreign key references siegfried.planes(id_plan),
		id_plan_nuevo numeric(18,0) foreign key references siegfried.planes(id_plan),
		motivo_cambio varchar(255)
	)	

		CREATE TABLE SIEGFRIED.TURNOS(
		id_turno numeric(18,0) primary key,
		id_afiliado numeric(18,0) foreign key references SIEGFRIED.AFILIADOS(id_afiliado),
		id_profesional numeric(18,0) foreign key references SIEGFRIED.PROFESIONALES(id_profesional),
		fecha datetime,
		id_especialidad numeric(18,0) foreign key references SIEGFRIED.ESPECIALIDADES(id_especialidad),
		--numero_turno numeric(18,0) -- ????
	);

		CREATE TABLE SIEGFRIED.AGENDA(
		id_agenda numeric(18,0) identity(1,1) NOT NULL PRIMARY KEY,
		id_profesional numeric(18,0) not null foreign key references SIEGFRIED.PROFESIONALES(id_profesional),
		dia_hora datetime,
		id_especialidad numeric(18,0) not null foreign key references SIEGFRIED.ESPECIALIDADES(id_especialidad),
		id_turno numeric(18,0) foreign key references SIEGFRIED.TURNOS(id_turno)
	);


	CREATE TABLE SIEGFRIED.CONSULTAS(
		id_consulta numeric(18,0) not null identity(1,1) primary key,
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
		fecha_compra datetime,
		consulta_fecha_impresion datetime,
		nro_consulta_medica numeric(18,0) default null
	);

	CREATE TABLE SIEGFRIED.COMPRA_BONOS(
		id_compra numeric(18,0) primary key identity(1,1),
		id_afiliado numeric(18,0) foreign key references SIEGFRIED.AFILIADOS(id_afiliado),
		fecha_compra datetime,
		cantidad numeric(18,0),
		monto numeric(18,0),
		id_plan numeric(18,0) foreign key references SIEGFRIED.PLANES(id_plan)
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

CREATE PROCEDURE SIEGFRIED.LOAD_ROLES_Y_FUNCIONALIDADES
AS
BEGIN
	INSERT INTO SIEGFRIED.ROLES (Nombre, Habilitado) VALUES
		('Administrador',1),('Afiliado',1), ('Profesional',1);

	--FALTA INSERTAR FUNCIONALIDADES_ROLES!!!
	INSERT INTO SIEGFRIED.FUNCIONALIDADES (Nombre) VALUES ('ABMRol'),
													('RegistroUsuario'),
													('ABMAfiliado'),
													('ABMProfesional'),
													('ABMEspecialidadesMedicas'),
													('ABMPlanes'),
													('RegistrarAgendaDelMedico'),
													('CompraBonos'),
													('PedirTurno'),
													('RegistroLLegadaAtencionMedica'),
													('RegistroResultadoAtencionMedica'),
													('CancelarAtencionMedicaAfiliado'),
													('CancelarAtencionMedicaMedico'),
													('ListadoEstadistico');
	INSERT INTO SIEGFRIED.FUNCIONALIDES_ROLES (Id_Funcionalidad,Id_Rol) VALUES
		(1,1),
		(2,1),
		(3,1),
		(4,1),
		(5,1),
		(6,1),
		(7,1),
		(8,1),
		(8,2),
		(9,1),
		(10,1),
		(11,3),
		(12,2),
		(13,3),
		(14,1);


END 
GO

CREATE PROCEDURE SIEGFRIED.LOAD_PLANES
AS
BEGIN
		INSERT INTO SIEGFRIED.PLANES
		SELECT DISTINCT
			Plan_Med_Codigo,
			Plan_Med_Descripcion,
			Plan_Med_Precio_Bono_Consulta
		FROM gd_esquema.Maestra
		WHERE Plan_Med_Codigo IS NOT NULL

END 
GO

CREATE PROCEDURE SIEGFRIED.LOAD_ESPECIALIDADES
AS
BEGIN

		INSERT INTO SIEGFRIED.TIPOS_ESPECIALIDADES
		SELECT DISTINCT
			Tipo_Especialidad_Codigo,
			Tipo_Especialidad_Descripcion
		FROM gd_esquema.Maestra 
		WHERE Tipo_Especialidad_Codigo IS NOT NULL;

		INSERT INTO SIEGFRIED.ESPECIALIDADES
		SELECT DISTINCT
			Especialidad_Codigo,
			Especialidad_Descripcion,
			Tipo_Especialidad_Codigo
		FROM gd_esquema.Maestra 
		WHERE Especialidad_Codigo IS NOT NULL;
END 
GO

CREATE PROCEDURE SIEGFRIED.LOAD_ESTADOS_CIVILES
AS
BEGIN
		INSERT INTO SIEGFRIED.ESTADOS_CIVILES (Descripcion)  VALUES ('Soltero/a'), ('Casado/a'), ('Viudo/a'), ('Divorciado/a'), ('Concubinato')
END 
GO

--Este procedure comprende:
-- 1) CARGAR TODOS LOS USUARIOS DE LA MAESTRA
-- 2) ASIGNAR LOS ROLES
-- 2) ASIGNARLE ESPECIALIDADES A LOS MEDICOS
-- 3) ASIGNARLE PLANES A LOS AFILIADOS
CREATE PROCEDURE SIEGFRIED.LOAD_USERS
AS
BEGIN
	SELECT DISTINCT
			Paciente_Nombre+Paciente_Apellido as username,   --username NVARCHAR(255),
			HASHBYTES('SHA2_256','1234') as contrasenia, --contrasenia binary(32),
			1 as habilitado,	--habilitado		numeric(18,0) DEFAULT 1,
			0 as cantlog,--cantlog			numeric(18,0) DEFAULT 0,
			Paciente_Nombre , --nombre nvarchar(255),
			Paciente_Apellido,
			Paciente_Direccion, --direccion nvarchar(255),
			'dni' as tipodni, --tipo_dni nvarchar(255),
			Paciente_Dni, --nro_dni numeric(18,0),
			Paciente_Telefono, --telefono numeric(18,0),
			Paciente_Mail, --mail nvarchar(255),
			Paciente_Fecha_Nac, --fecha_nacimiento datetime,
			NULL as id_plan -- id_plan?
	INTO #TempAfiliados
	FROM gd_esquema.Maestra
	WHERE Paciente_Nombre IS NOT NULL;

	INSERT INTO SIEGFRIED.AFILIADOS
	SELECT
		(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) * 100) + 1,
		1, -- Estado civil Soltero para todos los de la maestra
		0, -- Sin familiares
		(SELECT TOP 1 Plan_Med_Codigo FROM gd_esquema.Maestra WHERE Paciente_Dni = Temp.Paciente_Dni ) --Obtengo el plan directamente de la mestra
	FROM #TempAfiliados Temp

	INSERT INTO SIEGFRIED.USUARIOS
	SELECT
		(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) * 100) + 1,
		*
	FROM #TempAfiliados

	INSERT INTO SIEGFRIED.ROLES_USUARIOS
	SELECT 2, id_afiliado FROM SIEGFRIED.AFILIADOS



	DECLARE @CantidadAfiliados numeric(18,0)
	SELECT @CantidadAfiliados = COUNT(*) FROM #TempAfiliados

	SELECT DISTINCT
		Medico_Nombre+Medico_Apellido as username,   --username NVARCHAR(255),		
		HASHBYTES('SHA2_256','1234') as contrasenia, --contrasenia binary(32),
		1 as habilitado,	--habilitado		numeric(18,0) DEFAULT 1,
		0 as cantlog,--cantlog			numeric(18,0) DEFAULT 0,
		Medico_Nombre, --nombre nvarchar(255),
		Medico_Apellido,
		Medico_Direccion, --direccion nvarchar(255),
		'dni' as tipodni, --tipo_dni nvarchar(255),
		Medico_Dni, --nro_dni numeric(18,0),
		Medico_Telefono, --telefono numeric(18,0),
		Medico_Mail, --mail nvarchar(255),
		Medico_Fecha_Nac, --fecha_nacimiento datetime,
		NULL as sexo
	INTO #TempMedicos
	FROM gd_esquema.Maestra
	WHERE Medico_Nombre IS NOT NULL

	INSERT INTO SIEGFRIED.PROFESIONALES
	SELECT
		(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) * 100) + @CantidadAfiliados,
		NULL -- Por ahora matricula null
	FROM #TempMedicos

	INSERT INTO SIEGFRIED.USUARIOS
	SELECT
		(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) * 100) + @CantidadAfiliados,
		*
	FROM #TempMedicos

	INSERT INTO SIEGFRIED.ROLES_USUARIOS
	SELECT 3, id_profesional FROM SIEGFRIED.PROFESIONALES

	INSERT INTO SIEGFRIED.PROFESIONAL_ESPECIALIDAD
	SELECT
		(SELECT id_usuario FROM SIEGFRIED.USUARIOS where nro_dni = Medico_Dni),
		Especialidad_Codigo
	FROM ( SELECT DISTINCT Medico_Dni, Especialidad_Codigo FROM gd_esquema.Maestra WHERE Medico_Dni is not null and Especialidad_Codigo is not null) vista;
END
GO

CREATE PROCEDURE SIEGFRIED.SET_ADMIN
AS
BEGIN
	INSERT INTO SIEGFRIED.USUARIOS VALUES (0,'admin',HASHBYTES('SHA2_256','w23e'),1,0,'Administrador','General',null,null,null,null,null,null,null)
	INSERT INTO SIEGFRIED.ROLES_USUARIOS VALUES (1, 0)
END
GO



CREATE PROCEDURE SIEGFRIED.LOAD_CONSULTAS_TURNOS
AS
BEGIN
		INSERT INTO SIEGFRIED.TURNOS
		SELECT DISTINCT
			[Turno_Numero],       
			(select id_usuario from SIEGFRIED.USUARIOS where Paciente_Dni = nro_dni),
			(select id_usuario from SIEGFRIED.USUARIOS u where Medico_Dni = nro_dni),
			[Turno_Fecha], --fecha datetime,
			Especialidad_Codigo
		FROM gd_esquema.Maestra 
		WHERE [Turno_Numero] IS NOT NULL;

		INSERT INTO SIEGFRIED.AGENDA
		SELECT DISTINCT
			(select id_usuario from SIEGFRIED.USUARIOS u where Medico_Dni = nro_dni),
			Turno_Fecha,
			Especialidad_Codigo,
			Turno_Numero
			FROM gd_esquema.Maestra 
		WHERE [Turno_Numero] IS NOT NULL;

		INSERT INTO SIEGFRIED.CONSULTAS
		SELECT DISTINCT
			Turno_Fecha, --hora_llegada datetime,
			Turno_Fecha, --hora_atencion datetime,
			Consulta_Sintomas,
			Consulta_Enfermedades,
			[Turno_Numero] --id_turno numeric(18,0) foreign key references SIEGFRIED.TURNOS(id_turno)
		FROM gd_esquema.Maestra 
		WHERE Turno_Numero IS NOT NULL AND Consulta_Sintomas IS NOT NULL ;
END 
GO

CREATE PROCEDURE SIEGFRIED.LOAD_BONOS
AS
BEGIN

		INSERT INTO SIEGFRIED.COMPRA_BONOS	
		SELECT DISTINCT 
		(select u.id_usuario from SIEGFRIED.AFILIADOS a, SIEGFRIED.USUARIOS u where Paciente_Dni = u.nro_dni and u.id_usuario = a.id_afiliado),
		Compra_Bono_Fecha,
		1,
		Plan_Med_Precio_Bono_Consulta,
		Plan_Med_Codigo
		FROM gd_esquema.Maestra
		WHERE Bono_Consulta_Numero IS NOT NULL AND Compra_Bono_Fecha IS NOT NULL;

		INSERT INTO SIEGFRIED.BONOS
		SELECT DISTINCT
			m.Bono_Consulta_Numero,
			m.Plan_Med_Codigo,
			(select u.id_usuario from SIEGFRIED.AFILIADOS a, SIEGFRIED.USUARIOS u where m.Paciente_Dni = u.nro_dni and u.id_usuario = a.id_afiliado),
			(select id_consulta from siegfried.consultas where id_turno = m.Turno_Numero ),
			m.Bono_Consulta_Fecha_Impresion,
			m.Bono_Consulta_Fecha_Impresion,
			(SELECT COUNT(DISTINCT m2.Bono_Consulta_Numero)+1 FROM gd_esquema.Maestra m2 WHERE m2.Bono_Consulta_Fecha_Impresion is not null and m2.Turno_Fecha is not null and m2.Turno_Fecha < m.Turno_Fecha and m2.Paciente_Dni = m.Paciente_Dni )
		FROM gd_esquema.Maestra m
		WHERE m.Bono_Consulta_Numero IS NOT NULL AND m.Compra_Bono_Fecha IS NULL AND m.Turno_Fecha is not null;

			
END 
GO

CREATE PROCEDURE SIEGFRIED.CREATE_INDEXES
AS
BEGIN
		--Agenda
		CREATE INDEX DATE ON SIEGFRIED.AGENDA (dia_hora);  
		CREATE INDEX PROF ON SIEGFRIED.AGENDA (id_profesional);  


			
END 
GO

---------------------------------------------------- MAIN EXECUTION ---------------------------------------------------
BEGIN TRY
	BEGIN TRANSACTION MAIN_T
		EXEC SIEGFRIED.CREATE_TABLES_AND_FILL
		EXEC SIEGFRIED.LOAD_ESTADOS_CIVILES
		EXEC SIEGFRIED.LOAD_ROLES_Y_FUNCIONALIDADES
		EXEC SIEGFRIED.LOAD_PLANES
		EXEC SIEGFRIED.LOAD_ESPECIALIDADES
		EXEC SIEGFRIED.LOAD_USERS
		EXEC SIEGFRIED.LOAD_CONSULTAS_TURNOS
		EXEC SIEGFRIED.LOAD_BONOS
		EXEC SIEGFRIED.SET_ADMIN
		EXEC SIEGFRIED.CREATE_INDEXES
	COMMIT TRANSACTION MAIN_T
END TRY
BEGIN CATCH

	DECLARE  @error_num numeric, @error_sev nvarchar(255), @error_st int, @error_proc nvarchar(255), @error_mess nvarchar(255)
	
	SELECT  
        @error_num = ERROR_NUMBER() 
        ,@error_sev = ERROR_SEVERITY() 
        ,@error_st = ERROR_STATE() 
        ,@error_proc = ERROR_PROCEDURE() 
        ,@error_mess = ERROR_MESSAGE() ;  
	PRINT @error_num
	PRINT @error_proc
	PRINT @error_mess
	IF (@@TRANCOUNT > 0)
	BEGIN
		ROLLBACK TRANSACTION MAIN_T
	END
END CATCH
GO

-------------------------------------------------- PROCEDURES DE LA APLICACION ---------------------------------------------
CREATE FUNCTION [SIEGFRIED].[getUser] (@userName nvarchar(255), @password varchar(255))
returns integer
AS
BEGIN
DECLARE @resultExistence integer
DECLARE @resultLogin integer

	SET @resultExistence = (SELECT  USUARIOS.Id_Usuario FROM SIEGFRIED.USUARIOS where username like @userName)
	

	if @resultExistence >= 0 
	BEGIN
	SET @resultLogin = ( SELECT USUARIOS.Id_Usuario FROM SIEGFRIED.USUARIOS where contrasenia = HASHBYTES('SHA2_256',@password) AND username like @userName);
	if @resultLogin IS NULL 
	SET @resultLogin = -1
	END
	else if @resultExistence IS NULL
	SET @resultLogin = -2;

	return @resultLogin

END
GO
	-- /GETUSER


--AumentarIntentos
CREATE PROCEDURE [SIEGFRIED].[AumentarIntentosFallidos] @userName nvarchar(255)

AS
BEGIN

DECLARE @intentosActuales integer

SET @intentosActuales = (SELECT Intentos_Login FROM SIEGFRIED.USUARIOS WHERE username like @userName) 


UPDATE SIEGFRIED.USUARIOS SET Intentos_Login = (@intentosActuales + 1) WHERE username like @userName
END 
GO

--/AumentarIntentos


--LimpiarIntentos
CREATE PROCEDURE SIEGFRIED.LimpiarIntentos @userName varchar(255)

AS

BEGIN
UPDATE SIEGFRIED.USUARIOS SET Intentos_login = 0 WHERE nombre LIKE @userName

END
GO
--/LimpiarIntentos


--Trigger Intentos Fallidos
CREATE TRIGGER SIEGFRIED.TriggerIntentosFallidos
ON SIEGFRIED.USUARIOS
AFTER UPDATE
AS


BEGIN
DECLARE @intentos numeric(18,0)
DECLARE @userId numeric(18,0)

SELECT @intentos = (SELECT Intentos_Login FROM inserted)
SELECT @userId = (SELECT Id_Usuario FROM inserted)

if @intentos = 3 
UPDATE SIEGFRIED.USUARIOS SET Habilitado = 0 WHERE Id_Usuario = @userId


END
GO


CREATE PROCEDURE SIEGFRIED.ComprarBonos @afiliado numeric(18,0), @cantidad numeric(18,0), @fecha datetime
as 
begin
	DECLARE @plan numeric(18,0)
	set @plan = (SELECT id_plan FROM SIEGFRIED.AFILIADOS where id_afiliado = @afiliado)

	DECLARE @monto numeric(18,0)
	set @monto = (SELECT precio_bono_consulta FROM SIEGFRIED.PLANES where id_plan = @plan) * @cantidad

	insert into siegfried.COMPRA_BONOS (id_afiliado,fecha_compra,cantidad,monto,id_plan) VALUES (@afiliado, @fecha, @cantidad, @monto, @plan)
	
	DECLARE @i numeric(18,0)
	set @i = @cantidad

	WHILE(@i > 0)
	BEGIN
		insert into siegfried.BONOS (id_plan, id_afiliado, id_consulta, fecha_compra, nro_consulta_medica) VALUES (@plan,@afiliado,null,@fecha,null)
		set @i = @i - 1
	END
end
go

CREATE PROCEDURE SIEGFRIED.GENERAR_CONSULTA @turno numeric(18,0), @bono numeric(18,0), @fecha datetime
as 
begin
	INSERT INTO SIEGFRIED.CONSULTAS (hora_llegada, hora_atencion, sintomas, diagnostico, id_turno)
	VALUES
	(@fecha,null,null,null,@turno)

	declare @afiliado numeric(18,0)
	set @afiliado = (SELECT TOP 1 id_afiliado FROM SIEGFRIED.TURNOS where id_turno = @turno)

	UPDATE SIEGFRIED.BONOS 
	SET id_consulta = @@IDENTITY, id_bono = @bono, nro_consulta_medica = (SELECT MAX(nro_consulta_medica) FROM SIEGFRIED.BONOS WHERE id_afiliado = @afiliado) + 1
	WHERE id_bono = @bono
end
go

create procedure SIEGFRIED.BAJA_USUARIO 
	@id numeric(18,0)
as begin
	UPDATE SIEGFRIED.USUARIOS SET 
			habilitado = 0
		WHERE id_usuario = @id
end
go

create procedure SIEGFRIED.MODIFICAR_AFILIADO 
	@nombre varchar(255),
	@apellido varchar(255),
	@nroDoc numeric(18,0),
	@direccion varchar(255),
	@telefono numeric(18,0),
	@password varchar(255),
	@mail varchar(255),
	@fechaNac datetime,
	@sexo numeric(18,0),
	@estadoCivil numeric(18,0),
	@cantFamiliares numeric(18,0),
	@plan numeric(18,0),
	@id numeric(18,0) output
as begin
	DECLARE @idAfiliado numeric(18,0)
	set @idAfiliado = (SELECT id_usuario FROM SIEGFRIED.USUARIOS WHERE nro_dni = @nroDoc)

	UPDATE  SIEGFRIED.AFILIADOS SET 
	estado_civil = @estadoCivil, cantidad_familiares = @cantFamiliares, id_plan = @plan 
	WHERE id_afiliado = @idAfiliado 

	UPDATE SIEGFRIED.USUARIOS SET 
			username = @nombre+@apellido,
			contrasenia = HASHBYTES('SHA2_256',@password),
			habilitado = 1,
			intentos_login = 0,
			nombre = @nombre,
			apellido = @apellido,
			direccion = @direccion,
			tipo_dni = 'dni',
			nro_dni = @nroDoc,
			telefono = @telefono,
			mail = @mail,
			fecha_nacimiento = @fechaNac,
			sexo = @sexo
		WHERE id_usuario = @idAfiliado
end
go

create procedure SIEGFRIED.ALTA_AFILIADO_FAMILIAR
	@nombre varchar(255),
	@apellido varchar(255),
	@nroDoc numeric(18,0),
	@direccion varchar(255),
	@telefono numeric(18,0),
	@password varchar(255),
	@mail varchar(255),
	@fechaNac datetime,
	@sexo numeric(18,0),
	@estadoCivil numeric(18,0),
	@idTitular numeric(18,0),
	@plan numeric(18,0),
	@id numeric(18,0) output
as
begin
	declare @cantidadFamiliaresActual numeric(18,0)
	set @cantidadFamiliaresActual = (SELECT COUNT(id_afiliado) FROM SIEGFRIED.AFILIADOS WHERE id_afiliado/100 = @idTitular/100)

	DECLARE @idUsuario numeric(18,0)
	set @idUsuario = @idTitular + @cantidadFamiliaresActual + 1

	INSERT INTO SIEGFRIED.AFILIADOS (id_afiliado, estado_civil, cantidad_familiares, id_plan) VALUES (@idUsuario,@estadoCivil,@cantidadFamiliaresActual,@plan)
	INSERT INTO SIEGFRIED.USUARIOS 
		(
			id_usuario,
			username,
			contrasenia,
			habilitado,
			intentos_login,
			nombre,
			apellido,
			direccion,
			tipo_dni,
			nro_dni,
			telefono,
			mail,
			fecha_nacimiento,
			sexo
		)
		VALUES (@idUsuario,@nombre+@apellido,HASHBYTES('SHA2_256',@password),1,0,@nombre,@apellido,@direccion,'dni',@nroDoc, @telefono,@mail,@fechaNac,@sexo)
		SET @id = @idUsuario
	
	
end
go

create procedure SIEGFRIED.ALTA_AFILIADO_TITULAR 
	@nombre varchar(255),
	@apellido varchar(255),
	@nroDoc numeric(18,0),
	@direccion varchar(255),
	@telefono numeric(18,0),
	@password varchar(255),
	@mail varchar(255),
	@fechaNac datetime,
	@sexo numeric(18,0),
	@estadoCivil numeric(18,0),
	@cantFamiliares numeric(18,0),
	@plan numeric(18,0),
	@id numeric(18,0) output
as begin
	DECLARE @cantUsers numeric(18,0)
	set @cantUsers = (SELECT COUNT(*) FROM SIEGFRIED.USUARIOS)

	DECLARE @idUsuario numeric(18,0)
	set @idUsuario = (@cantUsers * 100) + 1

	INSERT INTO SIEGFRIED.AFILIADOS (id_afiliado, estado_civil, cantidad_familiares, id_plan) VALUES (@idUsuario,@estadoCivil,@cantFamiliares,@plan)
	INSERT INTO SIEGFRIED.USUARIOS 
		(
			id_usuario,
			username,
			contrasenia,
			habilitado,
			intentos_login,
			nombre,
			apellido,
			direccion,
			tipo_dni,
			nro_dni,
			telefono,
			mail,
			fecha_nacimiento,
			sexo
		)
		VALUES (@idUsuario,@nombre+@apellido,HASHBYTES('SHA2_256',@password),1,0,@nombre,@apellido,@direccion,'dni',@nroDoc, @telefono,@mail,@fechaNac,@sexo)
		SET @id = @idUsuario
end
go

CREATE PROCEDURE SIEGFRIED.CREARDIAAGENDA
	-- Add the parameters for the stored procedure here
	@desde DATETIME, 
	@hasta datetime,
	@idprofesional int,
	@especialidad int
AS
BEGIN
	DECLARE @fecha datetime  = @desde;
	WHILE @desde <= @hasta
	BEGIN
		declare @horassemanales int
		SET @horassemanales = (select count(*)/2 from SIEGFRIED.AGENDA where DATEPART(week,@desde) = DATEPART(week,dia_hora) and id_profesional = @idprofesional)
		if @horassemanales >= 48
		BEGIN
			declare @msj varchar = 'El medico ya posee asignadas 48 horas semanales! No puede poseer mas para la semana del dia'+ @desde
			RAISERROR(@msj, 18, 0)
			RETURN 
		END
		INSERT INTO SIEGFRIED.AGENDA VALUES(@idprofesional, @desde, @especialidad, null); 
		SET @desde = DATEADD(minute,30,@desde);
	END

END
GO


CREATE PROCEDURE SIEGFRIED.GRABAR_TURNO
	@id_agenda numeric(18,0), 
	@id_afiliado numeric(18,0)
AS
BEGIN
	
	INSERT INTO SIEGFRIED.TURNOS
	SELECT TOP 1
		(SELECT MAX(id_turno) + 1  FROM SIEGFRIED.TURNOS),
		@id_afiliado,
		id_profesional,
		dia_hora,
	    id_especialidad
	FROM SIEGFRIED.AGENDA
	WHERE id_agenda = @id_agenda;
	
	UPDATE SIEGFRIED.AGENDA SET id_turno = @@IDENTITY WHERE id_agenda = @id_agenda
END
GO