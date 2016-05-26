--DROP PROCEDURE BARSP_SelDadosUsuario 
	CREATE PROCEDURE BARSP_SelDadosUsuario
		@Num_SeqlUsuario			int

	AS
			-- Nome: BARSP_SelDadosUsuario
			-- Data Criação: 21/05/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_SelDadosUsuario

	BEGIN
		SELECT Nom_Usua,
			   Email
			FROM BAR_Usuarios
			WHERE Num_SeqlUsuario = @Num_SeqlUsuario
	END
GO