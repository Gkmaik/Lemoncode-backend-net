/* Listar las pistas (tabla Track) con precio mayor o igual a 1€ */
SELECT TrackId
      ,[Name]
      ,UnitPrice
  FROM dbo.Track T
  WHERE T.UnitPrice >= 1 


/* Listar las pistas de más de 4 minutos de duración */
SELECT TrackId
      ,[Name]
      ,Milliseconds
  FROM dbo.Track T
  WHERE T.Milliseconds > 240000 
  ORDER BY T.Milliseconds ASC
  

/* Listar las pistas que tengan entre 2 y 3 minutos de duración */
SELECT TrackId
      ,[Name]
      ,Milliseconds
  FROM dbo.Track T
  WHERE T.Milliseconds BETWEEN 120000 AND 180000
  ORDER BY T.Milliseconds ASC

  
/* Listar las pistas que uno de sus compositores (columna Composer) sea Mercury */
SELECT TrackId
      ,[Name]
      ,Composer
  FROM dbo.Track T
  WHERE T.Composer = 'Mercury'


/* Calcular la media de duración de las pistas (Track) de la plataforma */
SELECT AVG(Milliseconds) AS 'Media de duración de las pistas en Milisegundos'
  FROM dbo.Track
 
 
/* Listar los clientes (tabla Customer) de USA, Canada y Brazil */
SELECT C.CustomerId
      ,C.FirstName
      ,C.LastName
	  ,C.Country
  FROM dbo.Customer C
  WHERE C.Country IN ('USA','Canada','Brazil')
  

/* Listar todas las pistas del artista 'Queen' (Artist.Name = 'Queen') */
	/* Buscar ArtistId y AlbumID de Queen */
SELECT 
      Art.ArtistId
	  ,Art.[Name]
	  ,Alb.AlbumId
  FROM [LemonMusic].[dbo].[Artist] Art
  INNER JOIN dbo.Album Alb
   ON Art.ArtistId = Alb.ArtistId
  WHERE Art.ArtistId = 51


	/* Buscar todas las pistas del artista 'Queen' que en este caso (ArtistId = 51) */
SELECT TOP (1000) [TrackId]
      ,T.[Name]
      ,T.[AlbumId]
      ,T.[Composer]
	  ,A.ArtistId
  FROM [LemonMusic].[dbo].[Track] T
  LEFT JOIN [LemonMusic].[dbo].Album A
  ON A.AlbumId = T.AlbumId
  WHERE A.AlbumId IN (36,185,186)
			

/* Listar las pistas del artista 'Queen' en las que haya participado como compositor David Bowie */
SELECT TOP (1000) [TrackId]
      ,[Name]
      ,[AlbumId]
      ,[Composer]
  FROM [LemonMusic].[dbo].[Track] T
  WHERE T.Composer LIKE '%David Bo%'


/* Listar las pistas de la playlist 'Heavy Metal Classic' */
SELECT 
      PT.PlaylistId
      ,PT.TrackId
      ,PL.[Name]
  FROM dbo.PlaylistTrack PT
  LEFT JOIN dbo.Playlist PL
  ON PT.PlaylistId = PL.PlaylistId
  WHERE PL.[Name] LIKE 'Heavy Metal Classic'



/* Listar las playlist junto con el número de pistas que contienen */
SELECT PT.PlaylistId, COUNT(TrackId) AS N_Tracks	
  FROM dbo.PlaylistTrack PT
  LEFT JOIN dbo.Playlist PL
  ON PT.PlaylistId = PL.PlaylistId 
  GROUP BY PT.PlaylistId


/* Listar las playlist (sin repetir ninguna) que tienen alguna canción de AC/DC */
SELECT DISTINCT (PlaylistId)
	,T.Composer
  FROM dbo.PlaylistTrack PT
  LEFT JOIN dbo.Track T
  ON T.TrackId = PT.TrackId
  WHERE T.Composer LIKE 'AC/DC'


/* Listar las playlist que tienen alguna canción del artista Queen, junto con la cantidad que tienen */
SELECT PT.PlaylistId, COUNT(*) AS N_Tracks
  FROM dbo.PlaylistTrack PT
  LEFT JOIN dbo.Track T 
  ON PT.TrackId = T.TrackId
  WHERE T.Composer = 'Queen'
  GROUP BY PT.PlaylistId


/* Listar las pistas que no están en ninguna playlist */
SELECT *
  FROM dbo.PlaylistTrack PT
  WHERE PT.TrackId IS NULL


/* Listar los artistas que no tienen album */
SELECT Ar.[Name], COUNT(Al.AlbumId) AS N_Albums
FROM dbo.Artist Ar
LEFT JOIN dbo.Album Al
ON Ar.ArtistId = Al.ArtistId
WHERE Al.AlbumId IS NULL
GROUP BY Ar.[Name];


/* Listar los artistas con el número de albums que tienen */
SELECT Ar.[Name], COUNT(Al.AlbumId) AS N_Albums
FROM dbo.Artist Ar
LEFT JOIN dbo.Album Al
ON Ar.ArtistId = Al.ArtistId
GROUP BY Ar.[Name];