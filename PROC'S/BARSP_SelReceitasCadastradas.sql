--DROP PROCEDURE BARSP_SelReceitasCadastradas 
	CREATE PROCEDURE BARSP_SelReceitasCadastradas
		@Num_SeqlUsuario			int

	AS
			-- Nome: BARSP_SelReceitasCadastradas
			-- Data Criação: 14/06/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_SelReceitasCadastradas 7

	BEGIN
		SELECT Num_SeqlReceitas,
			   Nom_Receita
			FROM BAR_Receita rt
			WHERE rt.Num_SeqlUsua = @Num_SeqlUsuario
	END
GO