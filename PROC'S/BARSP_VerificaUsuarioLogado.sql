--DROP PROCEDURE BARSP_UsuarioLogado
	CREATE PROCEDURE BARSP_UsuarioLogado 
		@EmailLog				varchar(150),
		@SenhaLog				varchar(max)
	AS
			-- Nome: BARSP_UsuarioLogado
			-- Data Criação: 14/05/2016
			-- Autor: Luan felipe
			-- Exemplo: EXEC BARSP_UsuarioLogado
			-- OBS: Retorna o sequencial do usuario logado
			-- Retornos: 1 Usuario não existe
	BEGIN

	DECLARE @CodUsuaCad int

	IF EXISTS (SELECT TOP 1 1 FROM BAR_Usuarios WHERE Email = @EmailLog AND Num_SenhaCrip = @SenhaLog)
	BEGIN
		SET @CodUsuaCad = (SELECT TOP 1 Num_SeqlUsuario 
						FROM BAR_Usuarios WITH (NOLOCK)
				   WHERE Email = @EmailLog AND Num_SenhaCrip = @SenhaLog)
			
		RETURN @CodUsuaCad
	END

	RETURN 1

	END
GO