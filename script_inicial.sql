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
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
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

	CREATE TABLE SIEGFRIED.AFILIADOS(
		id_afiliado numeric(18,0) IDENTITY(1,1) NOT NULL,
		nombre nvarchar(255),
		direccion nvarchar(255),
		telefono numeric(18,0),
		mail nvarchar(255),
		fecha_nacimiento datetime,
		sexo numeric(18,0) DEFAULT NULL,
		PRIMARY KEY(id_afiliado)
	);
    
END
GO
