CREATE PROCEDURE [dbo].[StudentenhuisbewonerEnSaldo]
	@gebrID int, @studID int
AS
BEGIN
set nocount on
 SELECT t.Saldo FROM dbo.Table_Tegoed t Right JOIN dbo.Table_Studentenhuis s 
 ON t.StudenthuisID = s.StudentenhuisID 
 WHERE t.StudenthuisID = @studID AND t.GebruikerID = @gebrID;

end
go
