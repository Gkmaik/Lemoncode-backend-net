CREATE VIEW [dbo].[vListaDeClientesYsuPaís]
	AS SELECT C.CustomerId
			  ,C.FirstName
			  ,C.LastName
			  ,C.Country
		  FROM dbo.Customer C
		  WHERE C.Country IN ('USA','Canada','Brazil')
