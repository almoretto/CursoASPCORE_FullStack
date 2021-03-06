/****** Script do comando SelectTopNRows de SSMS  ******/
SELECT TOP 1000 [Id]
      ,[Local]
      ,[EventDate]
      ,[Subject]
      ,[GuestsQty]
      ,[ImageURL]
  FROM [ProAgil_DB].[dbo].[Events];

  INSERT INTO 
			Events(
                    Local,
                    EventDate,  
                    Subject, 
                    GuestsQty,
					ImageURL)
			values( 
                    'São Paulo',
					'10/04/2021',  
                    'Angular & .Net Core', 
                     250,
					 'img1.jpg');
 INSERT INTO 
			Events(
                    Local,
                    EventDate,  
                    Subject, 
                    GuestsQty,
					ImageURL)
			values( 
                    'Belo Horizonte',
					'12/04/2021',  
                    'Angular and news', 
                     350,
					 'img3.jpg');			
INSERT INTO 
			Events(
                    Local,
                    EventDate,  
                    Subject, 
                    GuestsQty,
					ImageURL)
			values( 
                    'Guaratinguetá',
					'30/04/2021',  
                    'Nodejs e C#', 
                     150,
					 'img2.jpg');		
INSERT INTO 
			Events(
                    Local,
                    EventDate,  
                    Subject, 
                    GuestsQty,
					ImageURL)
			values( 
                    'Guaratinguetá',
					'30/04/2021',  
                    'Nodejs e C#', 
                     150,
					 'img2.jpg');
INSERT INTO 
			Events(
                    Local,
                    EventDate,  
                    Subject, 
                    GuestsQty,
					ImageURL)
			values( 
                    'São José do Rio Preto',
					'05/05/2021',  
                    'C# FullStack Web', 
                     250,
					 'img5.jpg');
INSERT INTO 
			Events(
                    Local,
                    EventDate,  
                    Subject, 
                    GuestsQty,
					ImageURL)
			values( 
                    'Guarujá',
					'15/04/2021',  
                    'C# e ASP.net', 
                     100,
					 'img3.jpg');
INSERT INTO 
			Events(
                    Local,
                    EventDate,  
                    Subject, 
                    GuestsQty,
					ImageURL)
			values( 
                    'São Sebastião',
					'10/05/2021',  
                    'FullStack DEV', 
                     150,
					 'img1.jpg');								
