--DROP PROCEDURE BARSP_InsModoPreparo
	CREATE PROCEDURE BARSP_InsModoPreparo 
		@Num_SeqlReceitas			int,
		@Modo_Preparo			varchar(100)

	AS
			-- Nome: BARSP_InsModoPreparo
			-- Data Criação: 12/06/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_InsModoPreparo

	BEGIN
		INSERT INTO BAR_ModoPreparo(Num_SeqlReceitas, Modo_Preparo) values (@Num_SeqlReceitas, @Modo_Preparo)	
	END
GO