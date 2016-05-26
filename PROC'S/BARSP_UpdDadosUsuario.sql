--DROP PROCEDURE BARSP_UpdDadosUsuario 
	CREATE PROCEDURE BARSP_UpdDadosUsuario
		@Num_SeqlUsuario			int,
		@Nom_Usua			varchar(100) = NULL,
		@Email				varchar(150) = NULL,
		@Num_SenhaCrip		varchar(max) = NULL

	AS
			-- Nome: BARSP_UpdDadosUsuario
			-- Data Criação: 21/05/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_UpdDadosUsuario

	BEGIN
		IF(@Num_SenhaCrip IS NULL)
			BEGIN
				UPDATE BAR_Usuarios SET Nom_Usua = @Nom_Usua, Email = @Email WHERE Num_SeqlUsuario = @Num_SeqlUsuario
			END
		ELSE
			UPDATE BAR_Usuarios SET Nom_Usua = @Nom_Usua, Email = @Email, Num_SenhaCrip = @Num_SenhaCrip WHERE Num_SeqlUsuario = @Num_SeqlUsuario
		
	END
GO