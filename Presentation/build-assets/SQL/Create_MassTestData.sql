DECLARE @Count int = 1;

WHILE (@Count < 10000)
	BEGIN
		INSERT INTO Recipe.Recipes(RecipeId, Name, Description, ImagePublicId)
		VALUES(NEWID(), 'Test', 'Test', NULL);

		SET @Count = @Count + 1;
	END