--DROP PROCEDURE BARSP_SelReceitas
	CREATE PROCEDURE BARSP_SelReceitas
		@Nom_Pesquisado			varchar(max)

	AS
			-- Nome: BARSP_SelReceitas
			-- Data Criação: 14/06/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_SelReceitas 'MANTEIGA'

	BEGIN
		SELECT DISTINCT rt.Num_SeqlReceitas,
						rt.Nom_Receita,
						rt.Temp_Prep,
						rt.Rend_Porc,
						us.Nom_Usua
			FROM BAR_Receita rt
				INNER JOIN  BAR_Ingrediente it
					ON it.Num_SeqlReceitas = rt.Num_SeqlReceitas
				INNER JOIN BAR_ModoPreparo mp
					ON mp.Num_SeqlReceitas = it.Num_SeqlReceitas
				INNER JOIN BAR_Usuarios us
					ON us.Num_SeqlUsuario = rt.Num_SeqlUsua
			WHERE rt.Ind_LibComp = 'S'
				AND rt.Nom_Receita like '%' + @Nom_Pesquisado + '%' 
				OR rt.Num_SeqlReceitas IN (SELECT ind.Num_SeqlReceitas
												FROM BAR_Ingrediente ind
												WHERE Nom_Ingrediente like '%' + @Nom_Pesquisado + '%')
			
	END
GO
