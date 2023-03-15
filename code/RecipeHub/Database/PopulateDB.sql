DELETE FROM PlannedMeals;
DELETE FROM PantryItems;
DELETE FROM RecipeIngredients;
DELETE FROM RecipeSteps;
DELETE FROM RecipeTypes;
DELETE FROM "Type";
DELETE FROM Recipes;
DELETE FROM Ingredients;
DELETE FROM Passwords;
DELETE FROM "Sessions";
DELETE FROM MeasurementTypes;
DELETE FROM Users;

SET IDENTITY_INSERT MeasurementTypes ON;
INSERT INTO MeasurementTypes
	(typeId, name)
VALUES
    (1, 'Quantity'),
    (2, 'Mass'),
    (3, 'Volume');
SET IDENTITY_INSERT MeasurementTypes OFF;
	
SET IDENTITY_INSERT Users ON;
INSERT INTO Users 
	(userId, username, firstName, lastName, email)
VALUES
    (1, 'MasterChef', 'John', 'Doe', 'john.doe@gmail.com'),
    (2, 'Onion_King', 'Oliver', 'Vidall', 'OliveOnion@yahoo.com'),
    (3, 'hotlava77', 'Taylor', 'Kennedy', 'hotlava77@hotmail.com');
SET IDENTITY_INSERT Users OFF;

INSERT INTO
    Passwords
VALUES
    (1, 'b109f3bbbc244eb82441917ed06d618b9008dd09b3befd1b5e07394c706a8bb980b1d7785e5976ec049b46df5f1326af5a2ea6d103fd07c95385ffab0cacbc86'), --password
    (2, 'b109f3bbbc244eb82441917ed06d618b9008dd09b3befd1b5e07394c706a8bb980b1d7785e5976ec049b46df5f1326af5a2ea6d103fd07c95385ffab0cacbc86'), --password
    (3, 'b109f3bbbc244eb82441917ed06d618b9008dd09b3befd1b5e07394c706a8bb980b1d7785e5976ec049b46df5f1326af5a2ea6d103fd07c95385ffab0cacbc86'); --password
	
SET IDENTITY_INSERT Ingredients ON;
INSERT INTO Ingredients
	(ingredientId, name, measurementType)
VALUES
    (1, 'Carrot', 1), --Veggies
    (10, 'Lettuce', 2),
    (11, 'Tomato', 1),
    (12, 'Garlic', 1),
    (16, 'Lemon', 1),
    (17, 'Orange', 1),
    (21, 'Potato', 1),
    (23, 'Nori', 1),

    (2, 'Chicken Breast', 1), --Meats
    (5, 'Porkchop', 1),
    (6, 'Egg', 1),
    (24, 'Ground Beef', 2),
    (28, 'Shrimp', 2),

    (3, 'Flour', 3), --Grains
    (4, 'Panko', 3),
    (8, 'Spaghetti Noodles', 2),
    (9, 'Macaroni', 2),
    (14, 'Granola', 3),
    (22, 'White Rice', 2),

    (7, 'Sugar', 3), --Condiments and Spices
    (13, 'Salt', 2),
    (18, 'Soysauce', 3),
    (19, 'Vegetable Oil', 3),
    (20, 'White Pepper Powder', 3),
    (26, 'Tomato Sauce', 3),

    (15, 'Milk', 3), --Dairy
    (25, 'Sliced Cheddar', 1),
    (27, 'Butter', 3);
SET IDENTITY_INSERT Ingredients OFF;

SET IDENTITY_INSERT Recipes ON;
INSERT INTO Recipes
	(recipeId, authorId, name, description, isPublic)
VALUES
    (1, 1, 'Tonkatsu', 'A popular Japanese meal.', 1),
    (2, 1, 'Karaage', 'Japanese style fried chicken.', 1),
    (3, 1, 'Nori Maki', 'A simple Japanese rice meal.', 0),

    (4, 2, 'Hamburger', 'An American classic.', 1),
    (5, 2, 'Salad', 'A healthy snack - or meal!', 1),
    (6, 2, 'Porkchops', 'Simple and straight forward.', 0),
    
    (7, 3, 'Spaghetti', 'An Italian meal.', 1),
    (8, 3, 'Spaghetti and Shrimp', 'Another Italian meal.', 1),
    (9, 3, 'Cold Cereal', 'A straightforward breakfase', 0);
SET IDENTITY_INSERT Recipes OFF;

SET IDENTITY_INSERT "Type" ON;
INSERT INTO "Type" (typeId, typeName)
VALUES
(1, 'Breakfast'),
(2, 'Lunch'),
(3, 'Dinner'),
(4, 'Snack'),
(5, 'Dessert'),
(6, 'Vegan'),
(7, 'Vegitarian'),
(8, 'Gluten Free'),
(9, 'Healthy'),
(10, 'Grilling'),
(11, 'Fun food'),
(12, 'Keto')
SET IDENTITY_INSERT "Type" OFF;

INSERT INTO RecipeTypes (recipeId, typeId)
VALUES
(1,1),
(1,6),
(1,7),
(3, 3),
(3, 6),
(3, 7),
(3, 8),
(3, 9),
(4, 3),
(4, 10),
(4, 11),
(5, 2),
(5, 3),
(5, 6),
(5, 7),
(5, 8),
(5, 9),
(5, 12),
(6, 2),
(6, 3),
(6, 8),
(6, 12),
(7, 3),
(8, 3)

INSERT INTO
    RecipeIngredients
VALUES
    (4, 1, 500), --Tonkatsu
    (3, 1, 400),
    (6, 1, 3),
    (5, 1, 4),

--No karaage

    (23, 3, 6), --Nori Maki
    (22, 3, 600),
    (18, 3, 200),

    (22, 4, 1000), --Hamburger
    (13, 4, 50),
    (25, 4, 2),
    (10, 4, 2),
    (11, 4, 1),
    (12, 4, 1),

    (1, 5, 1), --Salad
    (10, 5, 200),
    (11, 5, 2),

    (6, 6, 2), --Porkchops
    (5, 6, 2),

    (8, 7, 1000), --Spaghetti
    (12, 7, 1),
    (26, 7, 300),
    (24, 7, 1000),

    (8, 8, 1000), --Shrimp Spaghetti
    (27, 8, 300),
    (3, 8, 100),
    (28, 8, 500),
    (12, 8, 1),
    (19, 8, 300),

    (14, 9, 500), --Cold Cereal
    (15, 9, 500);

INSERT INTO
    RecipeSteps
VALUES
    (1, 1, 'Prep the area', 'Fill one large bowl with flour, one with egg, and one with panko.'), --Tonkatsu
    (1, 2, 'Heat oil', 'Heat a sauce pan of oil.'),
    (1, 3, 'Cover porkchop in flour.', 'Place a porkchop in the bowl of flour. Cover completely.'),
    (1, 4, 'Cover porkchop in egg', 'Move the porkchop into the egg bowl. Submerge entirely.'),
    (1, 5, 'Cover porkchop in panko', 'Move the porkchop again into the bowl of panko. Cover entirely.'),
    (1, 6, 'Fry the porkchop', 'Place the porkchop into the pan of oil. Cook for 5-10 minutes, or until brown.'),

    --No Karaage

    (3, 1, 'Cook rice', 'Cook rice in a rice cooker.'), --Norimaki
    (3, 2, 'Wrap in nori', 'Scoop rice out and wrap in nori.'),
    (3, 3, 'Dip in soysauce', 'Optionally, dip the norimaki in soy sauce.'),

    (4, 1, 'Shape patty', 'Grab a handful of ground beef and kneed into the shape of a patty. Add spices to taste.'), --Hamburger
    (4, 2, 'Grill patty', 'Place the patty on a grill until brown.'),
    (4, 3, 'Place on bun', 'Place the cooked patty on a bun'),
    (4, 4, 'Add toppings', 'Add Cheese, tomatoes, and lettuce to the burger, to taste.'),

    (5, 1, 'Mix ingredients together', 'Just mix everything together.'), --Salad

    (6, 1, 'Cover in egg', 'Batter the porkchop with egg.'), --Porkchops
    (6, 2, 'Cook on stove', 'Place the porkchop on a pan. Set stovetop to medium heat.'),

    (7, 1, 'Boil noodles', 'Boil the spaghetti noodles in water.'),--Spaghetti
    (7, 2, 'Cook meat', 'Cook ground beef until brown.'),
    (7, 3, 'Drain grease', 'Drain the grease from the ground beef.'),
    (7, 4, 'Add sauce', 'Add sauce to the grounf beef.'),
    (7, 5, 'Serve', 'Serve the sauce on the noodles.'),

    (8, 1, 'Boil noodles', 'Boil the spaghetti noodles in water.'),--Shrimp Spaghetti
    (8, 2, 'Add butter and oil', 'Add butter and oil to a pan.'),
    (8, 3, 'Add shrimp and garlic', 'Cook the shrimp and garlic in the pan with the oil and butter.'),
    (8, 4, 'Serve', 'Serve sauce on the noodles.'),

    (9, 1, 'Pour milk', 'Pour milk into a bowl.'), --Cold cereal
    (9, 2, 'Add cereal', 'Add cereal to the bowl.');

INSERT INTO
    PantryItems
VALUES
    (1, 1, 1000),
    (2, 1, 1000),
    (3, 1, 1000),
    (4, 1, 1000),
    (5, 1, 1000),
    (6, 1, 1000),
    (7, 1, 1000),
    (8, 1, 1000),
    (9, 1, 1000),
    (10, 1, 1000),
    (11, 1, 1000),
    (12, 1, 1000),
    (13, 1, 1000),
    (14, 1, 1000),
    (15, 1, 1000),
    (16, 1, 1000),
    (17, 1, 1000),
    (18, 1, 1000),
    (19, 1, 1000),
    (20, 1, 1000),
    (21, 1, 1000),
    (22, 1, 1000),
    (23, 1, 1000),
    (24, 1, 1000),
    (25, 1, 1000),
    (26, 1, 1000),
    (27, 1, 1000),
    (28, 1, 1000),

    (1, 2, 1000),
    (10, 2, 1000),
    (11, 2, 1000),
    (12, 2, 1000),
    (16, 2, 1000),
    (17, 2, 1000),
    (21, 2, 1000),
    (23, 2, 1000),
    (3, 2, 1000),
    (4, 2, 1000),
    (8, 2, 1000),
    (9, 2, 1000),
    (14, 2, 1000),
    (22, 2, 1000);