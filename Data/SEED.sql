-- Inserting into KolboldUser
INSERT INTO [KoboldUser] ([AspNetUserID], [FirstName], [LastName]) VALUES ('Testing123456789', 'Joeseph', 'ParentalFigure');
INSERT INTO [KoboldUser] ([AspNetUserID], [FirstName], [LastName]) VALUES ('159edrved58wa9c8d156ea8v1', 'Sandra', 'Hart');
INSERT INTO [KoboldUser] ([AspNetUserID], [FirstName], [LastName]) VALUES ('erferf8945v98e1sa651cfs876r41v6se41rvf', 'Fake', 'Guy');

-- --Inserting into Tutorials
--INSERT INTO [Tutorials] ([KoboldUser], [VideoUrl]) VALUES (1, 'https://www.youtube.com/watch?v=uZ0im09iRww&ab_channel=DuncanRhodesPaintingAcademy');
--INSERT INTO [Tutorials] ([KoboldUser], [VideoUrl]) VALUES (1, 'https://www.youtube.com/watch?v=m3rY0KSc1HA&t=187s&ab_channel=DuncanRhodesPaintingAcademy');
--INSERT INTO [Tutorials] ([KoboldUser], [VideoUrl]) VALUES (1, 'https://www.youtube.com/watch?v=D90aKdUawZ0&ab_channel=DuncanRhodesPaintingAcademy');
--INSERT INTO [Tutorials] ([KoboldUser], [VideoUrl]) VALUES (2, 'https://www.youtube.com/watch?v=P9b0gxk3c6s&ab_channel=MidwinterMinis');

--Inserting into Company
INSERT INTO [Company] ([CompanyName]) VALUES ('Unknown / Not Available'); --1
INSERT INTO [Company] ([CompanyName]) VALUES ('Citadel'); --2
INSERT INTO [Company] ([CompanyName]) VALUES ('The Army Painter'); --3
INSERT INTO [Company] ([CompanyName]) VALUES ('Vallejo'); --4
INSERT INTO [Company] ([CompanyName]) VALUES ('Ak Interactive'); --5
INSERT INTO [Company] ([CompanyName]) VALUES ('Dirty Down'); --6
INSERT INTO [Company] ([CompanyName]) VALUES ('Pro Acryl'); --7
INSERT INTO [Company] ([CompanyName]) VALUES ('Two Thin Coats'); --8
INSERT INTO [Company] ([CompanyName]) VALUES ('Coat DArms'); --9


--Inserting into PaintType
INSERT INTO [PaintType] ([TypeOfPaint]) VALUES ('Base'); --1
INSERT INTO [PaintType] ([TypeOfPaint]) VALUES ('Layering'); --2
INSERT INTO [PaintType] ([TypeOfPaint]) VALUES ('Shade'); --3
INSERT INTO [PaintType] ([TypeOfPaint]) VALUES ('Contrast'); --4
INSERT INTO [PaintType] ([TypeOfPaint]) VALUES ('Speedpaint'); --5
INSERT INTO [PaintType] ([TypeOfPaint]) VALUES ('Texture'); --6
INSERT INTO [PaintType] ([TypeOfPaint]) VALUES ('Techical or Effect'); --7
INSERT INTO [PaintType] ([TypeOfPaint]) VALUES ('Drybrushing'); --8 
INSERT INTO [PaintType] ([TypeOfPaint]) VALUES ('Pigment Powder'); --9
INSERT INTO [PaintType] ([TypeOfPaint]) VALUES ('Basing Material'); --10

--Inserting into Paints

INSERT INTO [Paints] ([PaintName], [CompanyID], [PaintTypeID]) VALUES ('Averland Sunset', 2, 1); --1
INSERT INTO [Paints] ([PaintName], [CompanyID], [PaintTypeID]) VALUES ('Mephiston Red', 2, 1); --2
INSERT INTO [Paints] ([PaintName], [CompanyID], [PaintTypeID]) VALUES ('Iron Warriors', 2, 1); --3
INSERT INTO [Paints] ([PaintName], [CompanyID], [PaintTypeID]) VALUES ('TrollSlayer Orange', 2, 2); --4
INSERT INTO [Paints] ([PaintName], [CompanyID], [PaintTypeID]) VALUES ('Agrax Earthshade', 2, 3); --5
INSERT INTO [Paints] ([PaintName], [CompanyID], [PaintTypeID]) VALUES ('Lahmian Medium', 2, 7); --6
INSERT INTO [Paints] ([PaintName], [CompanyID], [PaintTypeID]) VALUES ('Black', 4, 1); --7
INSERT INTO [Paints] ([PaintName], [CompanyID], [PaintTypeID]) VALUES ('Bold Titanuim White', 7, 1); --8
INSERT INTO [Paints] ([PaintName], [CompanyID], [PaintTypeID]) VALUES ('Muddy Ground', 5, 6); --9
INSERT INTO [Paints] ([PaintName], [CompanyID], [PaintTypeID]) VALUES ('Puddles', 5, 10); --10
INSERT INTO [Paints] ([PaintName], [CompanyID], [PaintTypeID]) VALUES ('Magic Metal', 9, 1); --11

--Inserting into OwnedPaint
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (1, 1);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (1, 3);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (1, 9);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (1, 4);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (2, 9);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (2, 5);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (2, 7);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (2, 1);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (3, 1);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (3, 2);

-- --Inserting into WantedPaint
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (1, 5);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (1, 4);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (1, 10);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (1, 6);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (2, 7);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (2, 10);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (2, 6);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (3, 6);

-- --Inserting into RefillPaint
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (1, 11);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (2, 11);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (2, 12);
INSERT INTO [OwnedPaint] ([KoboldUserID], [PaintID]) VALUES (2, 10);

-- --Inserting into PaintRecipes
 INSERT INTO [PaintRecipes] ([KoboldUserID], [RecipeName], [Description]) VALUES (1, 'Dirty Metal', 'A recipe to create a old worn down metal effect. Base with Iron Warriors and then shade with Agrax, then drybrush with Iron Warriors'); --1
 INSERT INTO [PaintRecipes] ([KoboldUserID], [RecipeName], [Description]) VALUES (1, 'Muddy Ground with puddles', 'Basing to create a muddy ground with fresh puddles'); --2
 INSERT INTO [PaintRecipes] ([KoboldUserID], [RecipeName], [Description]) VALUES (1, 'Worn Energy Cables', 'A dirty yellow used for ork veheicles that has electricy. Base with Averland Sunset and wash with Agrax'); --3
 INSERT INTO [PaintRecipes] ([KoboldUserID], [RecipeName], [Description]) VALUES (2, 'Worn Energy Cables', 'A dirty yellow used for ork veheicles that has electricy. Base with Averland Sunset and wash with Agrax'); --4
 INSERT INTO [PaintRecipes] ([KoboldUserID], [RecipeName], [Description]) VALUES (2, 'Red Armor', 'A drity red armor used for accents on orks. Base with Mephiston Red, shade with Agrax, then highlight with Trollslayer Orange'); --5

-- --Inserting into PaintsForRecipe
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (1, 5);
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (1, 6);
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (2, 10);
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (2, 6);
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (2, 11);
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (3, 1);
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (3, 6);
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (4, 1);
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (4, 6);
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (5, 2);
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (5, 6);
 INSERT INTO [PaintsForRecipe] ([RecipeID], [PaintID]) VALUES (5, 4);







