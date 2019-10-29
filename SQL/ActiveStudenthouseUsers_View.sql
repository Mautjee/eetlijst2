CREATE VIEW dbo.vwActiveStudentenhuisGebruikers
AS
SELECT tg.Voornaam, tt.Saldo, tt.GebruikerID, tt.StudenthuisID, st.NaamHuis
FROM dbo.Table_Tegoed AS tt
         INNER JOIN
     dbo.Table_Gebruiker_Activiteit AS tga ON tt.GebruikerID = tga.GebruikerID
         INNER JOIN
     dbo.Table_Gebruiker AS tg ON tg.GebruikerID = tt.GebruikerID
         INNER JOIN
     dbo.Table_Studentenhuis AS st ON tt.StudenthuisID = st.StudentenhuisID
WHERE (tga.Out IS NULL)
go