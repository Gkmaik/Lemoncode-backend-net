CREATE VIEW [dbo].[vArtistasConAlbum]
	AS SELECT Ar.[Name], COUNT(Al.AlbumId) AS N_Albums
			FROM dbo.Artist Ar
			LEFT JOIN dbo.Album Al
			ON Ar.ArtistId = Al.ArtistId
			GROUP BY Ar.[Name];
