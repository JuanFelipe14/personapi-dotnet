USE [persona_db]
GO

INSERT INTO [dbo].[estudios]
           ([id_prof]
           ,[cc_per]
           ,[fecha]
           ,[univer])
     VALUES
           (<id_prof, int,>
           ,<cc_per, int,>
           ,<fecha, date,>
           ,<univer, varchar(50),>)
GO

