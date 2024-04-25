USE [persona_db]
GO

INSERT INTO [dbo].[persona]
           ([cc]
           ,[nombre]
           ,[apellido]
           ,[genero]
           ,[edad])
     VALUES
           (<cc, int,>
           ,<nombre, varchar(45),>
           ,<apellido, varchar(45),>
           ,<genero, varchar(1),>
           ,<edad, int,>)
GO

