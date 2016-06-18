--DROP PROCEDURE BARSP_SelIngredientesModoPreparo
	CREATE PROCEDURE BARSP_SelIngredientesModoPreparo
		@Num_SeqlReceitas			int

	AS
			-- Nome: BARSP_SelIngredientesModoPreparo
			-- Data Criação: 14/06/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_SelIngredientesModoPreparo 29

	BEGIN
		SELECT it.Num_SeqlIngrediente,
			   it.Nom_Ingrediente						
			FROM  BAR_Ingrediente it
			WHERE it.Num_SeqlReceitas = @Num_SeqlReceitas

		SELECT mp.Num_SeqlModPreparo,
			   mp.Modo_Preparo						
			FROM  BAR_ModoPreparo mp
			WHERE mp.Num_SeqlReceitas = @Num_SeqlReceitas
	END
GO
