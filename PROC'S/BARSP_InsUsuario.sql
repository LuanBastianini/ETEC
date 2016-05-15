--DROP PROCEDURE BARSP_InsUsuario 
	CREATE PROCEDURE BARSP_InsUsuario 
		@Nom_Usua			varchar(100),
		@Email				varchar(150),
		@Num_SenhaCrip		varchar(max)
	AS
			-- Nome: BARSP_InsUsuario
			-- Data Criação: 04/05/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_InsUsuario

	BEGIN
		INSERT INTO BAR_Usuarios(Nom_Usua, Email, Num_SenhaCrip) values (@Nom_Usua, @Email, @Num_SenhaCrip)	
	END
GO