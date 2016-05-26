--DROP PROCEDURE BARSP_VerificaEmail 
	CREATE PROCEDURE BARSP_VerificaEmail 
		@Email				varchar(150)
	AS
			-- Nome: BARSP_VerificaEmail
			-- Data Criação: 07/05/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_VerificaUsuario
			-- OBS: 0. PROCESSO OK
			--		1. JÁ EXISTE ENDEREÇO DE EMAIL 
	BEGIN

		IF EXISTS (SELECT TOP 1 1 FROM BAR_Usuarios WHERE Email = @Email)
			BEGIN
				RETURN 1
			END

		RETURN 0
	END

