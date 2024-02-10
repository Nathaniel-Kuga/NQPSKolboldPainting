ALTER TABLE [Tutorials] DROP CONSTRAINT [Tutorials_FK_KolboldUserID]
ALTER TABLE [OwnedPaint] DROP CONSTRAINT [OwnedPaint_FK_KolboldUserID]
ALTER TABLE [WantedPaint] DROP CONSTRAINT [WantedPaint_FK_KolboldUserID]
ALTER TABLE [RefillPaint] DROP CONSTRAINT [RefillPaint_FK_KolboldUserID]
ALTER TABLE [OwnedPaint] DROP CONSTRAINT [OwnedPaint_FK_PaintID]
ALTER TABLE [WantedPaint] DROP CONSTRAINT [WantedPaint_FK_PaintID]
ALTER TABLE [RefillPaint] DROP CONSTRAINT [RefillPaint_FK_PaintID]
ALTER TABLE [Paints] DROP CONSTRAINT [Paints_FK_CompanyID]
ALTER TABLE [Paints] DROP CONSTRAINT [Paints_FK_PaintTypeID]
ALTER TABLE [PaintRecipes] DROP CONSTRAINT [PaintRecipes_FK_KolboldUserID]
ALTER TABLE [PaintsForRecipe] DROP CONSTRAINT [PaintsForRecipe_FK_RecipeID]
ALTER TABLE [PaintsForRecipe] DROP CONSTRAINT [PaintsForRecipe_FK_PaintID]

DROP TABLE [KolboldUser]
DROP TABLE [Tutorials]
DROP TABLE [OwnedPaint]
DROP TABLE [WantedPaint]
DROP TABLE [RefillPaint]
DROP TABLE [Paints]
DROP TABLE [Company]
DROP TABLE [PaintType]
DROP TABLE [PaintRecipes]
DROP TABLE [PaintsForRecipe]
