
IF DB_ID('CleanArchitecture') IS NULL
BEGIN
	CREATE DATABASE CleanArchitecture;
END
GO

USE [CleanArchitecture]
GO

IF NOT EXISTS (SELECT name FROM sys.schemas WHERE name = N'Recipe')
BEGIN
	EXEC('CREATE SCHEMA Recipe');
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE NAME='Recipes' and xtype='U')
BEGIN
	CREATE TABLE Recipe.Recipes (
		RecipeId uniqueidentifier NOT NULL,
		Name varchar(50) NOT NULL,
		Description varchar(250),
		ImagePublicId uniqueidentifier NULL,
		CONSTRAINT PK_RecipeId PRIMARY KEY NONCLUSTERED (RecipeId)
	);
	

	CREATE TABLE Recipe.Directions (
		DirectionId uniqueidentifier NOT NULL,
		RecipeId uniqueidentifier NOT NULL,
		StepNumber smallint NOT NULL,
		Description varchar(150) NOT NULL,
		CONSTRAINT PK_DirectionId PRIMARY KEY NONCLUSTERED (DirectionId),
		CONSTRAINT FK_Recipes_Directions FOREIGN KEY (RecipeId)
			REFERENCES Recipe.Recipes (RecipeId)
	);
	


	-- Vegan Pizza
	INSERT INTO Recipe.Recipes([RecipeId], [Name], [Description], [ImagePublicId])
	VALUES('59ff0357-be8e-46af-8b6e-e8e89e19519c', 'Vegan Pizza', 'Tomato and Basil Pizza on a Thin Garlic Crust', 'e8be0f9d-5709-4754-9329-0272cf5bf53b')
	INSERT INTO Recipe.Directions([DirectionId], [RecipeId], [StepNumber], [Description])
	VALUES(NEWID(), '59ff0357-be8e-46af-8b6e-e8e89e19519c', 1, 'On your favorite plant based pizza crust, polish it with minced garlic.'),
	(NEWID(), '59ff0357-be8e-46af-8b6e-e8e89e19519c', 2, 'Spread the tomato sauce evenly across the crust.'),
	(NEWID(), '59ff0357-be8e-46af-8b6e-e8e89e19519c', 3, 'Top your pizza with tomatoes, olives, mushrooms, and basil.'),
	(NEWID(), '59ff0357-be8e-46af-8b6e-e8e89e19519c', 4, 'Bake at 400 for 15-20 minutes, then enjoy!')

	--Buddha Bowl
	INSERT INTO Recipe.Recipes([RecipeId], [Name], [Description], [ImagePublicId])
	VALUES('11932f8c-92b4-4b3e-a267-b3518c6afb4b', 'Buddha Bowl', 'A Delicious Buddha Bowl Filled with All Your Favorite Veggies!', '42415e91-85a5-49d7-93e6-119e98a5445c')
	INSERT INTO Recipe.Directions([DirectionId], [RecipeId], [StepNumber], [Description])
	VALUES(NEWID(), '11932f8c-92b4-4b3e-a267-b3518c6afb4b', 1, 'In a bowl, combine rice, beans, zuchinni, corn, kale, and tomatoes.'),
	(NEWID(), '11932f8c-92b4-4b3e-a267-b3518c6afb4b', 2, 'Top with some fresh guacamole and serve with your favorite corn chips!')

	--Bean Burrito
	INSERT INTO Recipe.Recipes([RecipeId], [Name], [Description], [ImagePublicId])
	VALUES('1f861eb7-f567-47cf-a987-b7caf06b354b', 'Bean Burrito', 'The Best Bean Burrito You''ve Ever Had!', '4adf341b-95b2-4a2e-899e-5ffc84981157')
	INSERT INTO Recipe.Directions([DirectionId], [RecipeId], [StepNumber], [Description])
	VALUES(NEWID(), '1f861eb7-f567-47cf-a987-b7caf06b354b', 1, 'In a whole wheat or corn tortilla, fill your wrap with rice, black beans, bell pepper, and mushrooms.'),
	(NEWID(), '1f861eb7-f567-47cf-a987-b7caf06b354b', 2, 'Top your veggies with fresh avacado or your favorite vegan cheese.'),
	(NEWID(), '1f861eb7-f567-47cf-a987-b7caf06b354b', 3, 'Folder your wrap to make a burrito.'),
	(NEWID(), '1f861eb7-f567-47cf-a987-b7caf06b354b', 4, 'Toast it in the oven for a few minutes for an extra crispy version!')

	--Tempeh Tacos
	INSERT INTO Recipe.Recipes([RecipeId], [Name], [Description], [ImagePublicId])
	VALUES('84ed0761-1696-4276-bb94-1e958dab2fb7', 'Tempeh Tacos', 'Better than Taco Bell!', '07f37ff4-874f-4aba-9a02-8b1db4b55b04')
	INSERT INTO Recipe.Directions([DirectionId], [RecipeId], [StepNumber], [Description])
	VALUES(NEWID(), '84ed0761-1696-4276-bb94-1e958dab2fb7', 1, 'Saute your Tempeh until it''s nice and soft.'),
	(NEWID(), '84ed0761-1696-4276-bb94-1e958dab2fb7', 2, 'Fill your taco shells with your cooked tempeh, diced pineapple, vegan cheese, and sliced jalape�os.'),
	(NEWID(), '84ed0761-1696-4276-bb94-1e958dab2fb7', 3, 'Place in the oven on 350 for a few minutes to melt the cheese.')

	--Peanut Butter Pecan Waffles
	INSERT INTO Recipe.Recipes([RecipeId], [Name], [Description], [ImagePublicId])
	VALUES('125dfdd5-3615-4cc9-bf01-6f618d85e132', 'Peanut Butter Pecan Waffles', 'Perfect for Breakfast in Bed!', '9ea95a51-7132-4955-8b94-d0b28d240319')
	INSERT INTO Recipe.Directions([DirectionId], [RecipeId], [StepNumber], [Description])
	VALUES(NEWID(), '125dfdd5-3615-4cc9-bf01-6f618d85e132', 1, 'Using your favorite flour or GF flour, make your batter using flax eggs.'),
	(NEWID(), '125dfdd5-3615-4cc9-bf01-6f618d85e132', 2, 'Evenly spread your batter onto your waffle maker and let cook until dough rises and becomes crispy.'),
	(NEWID(), '125dfdd5-3615-4cc9-bf01-6f618d85e132', 3, 'Spread peanut butter across your waffle and top with pecans, cinnamon, and maple syrup!')

	--Tomato Soup
	INSERT INTO Recipe.Recipes([RecipeId], [Name], [Description], [ImagePublicId])
	VALUES('06170443-f950-4006-94dc-7a0fb76f8166', 'Tomato Soup', 'Great for a Chilly Fall Day by the Fire!', 'a617c269-6eb4-4f8b-a165-6cd1d96ed800')
	INSERT INTO Recipe.Directions([DirectionId], [RecipeId], [StepNumber], [Description])
	VALUES(NEWID(), '06170443-f950-4006-94dc-7a0fb76f8166', 1, 'In a large pan, bake 4-5 large tomatoes (diced), garlic, and onions at 400 degrees for 20-30 minutes.'),
	(NEWID(), '06170443-f950-4006-94dc-7a0fb76f8166', 2, 'In a large bowl, combine all ingredients with some basil, oregano, and thyme.'),
	(NEWID(), '06170443-f950-4006-94dc-7a0fb76f8166', 3, 'Blend your ingredients together using an immersion blender or high speed blender until soupy.'),
	(NEWID(), '06170443-f950-4006-94dc-7a0fb76f8166', 4, 'Service with your favorite vegan bread!')
END
GO
