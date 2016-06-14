--DROP PROCEDURE BARSP_InsIngrediente
	CREATE PROCEDURE BARSP_InsIngrediente 
		@Num_SeqlReceitas			int,
		@Nom_Ingrediente			varchar(50)

	AS
			-- Nome: BARSP_InsIngrediente
			-- Data Criação: 12/06/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_InsIngrediente

	BEGIN
		INSERT INTO BAR_Ingrediente(Num_SeqlReceitas, Nom_Ingrediente) values (@Num_SeqlReceitas, @Nom_Ingrediente)	
	END
GO