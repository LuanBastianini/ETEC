--DROP PROCEDURE BARSP_InsReceitas 
	CREATE PROCEDURE BARSP_InsReceitas 
		@Num_SeqlUsua		int,
		@Nom_Receita		varchar(20),
		@Ind_LibComp		char(1),
		@Temp_Prep			smallint,
		@Rend_Porc			smallint
	AS
			-- Nome: BARSP_InsReceitas
			-- Data Criação: 11/06/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_InsReceitas

	BEGIN
		INSERT INTO BAR_Receita(Num_SeqlUsua, Nom_Receita, Ind_LibComp, Temp_Prep, Rend_Porc) values (@Num_SeqlUsua, @Nom_Receita, @Ind_LibComp, @Temp_Prep, @Rend_Porc )	

		RETURN SCOPE_IDENTITY()
	END
GO
