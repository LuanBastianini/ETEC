--DROP PROCEDURE BARSP_VerificaUsuarioLogado
	CREATE PROCEDURE BARSP_VerificaUsuarioLogado 
		@EmailLog				varchar(150),
		@SenhaLog				varchar(max)
	AS
			-- Nome: BARSP_VerificaUsuarioLogado
			-- Data Criação: 14/05/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_VerificaUsuario
			-- OBS: Retorna o sequencial do usuario logado
	BEGIN

	DECLARE @CodUsuaCad int

	SET @CodUsuaCad = (SELECT TOP 1 Num_SeqlUsuario 
						FROM BAR_Usuarios WITH (NOLOCK)
				   WHERE Email = @EmailLog AND Num_SenhaCrip = @SenhaLog)
			
	RETURN @CodUsuaCad

	END
GO