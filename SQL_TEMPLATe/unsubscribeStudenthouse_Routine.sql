CREATE PROCEDURE [dbo].[UnsubscribeStudentenhuis]
	@gebrID int, @studID int
AS
BEGIN
	-- get current date	variable
	declare @currentdate DateTime;
	select @currentdate = (Select Convert (date, GETDATE()));	

	-- set studentenhuisID to 0 from table StudentenhuisID
	UPDATE Table_Tegoed 
	SET StudenthuisID = 0 , Saldo = 0
	Where GebruikerID = @gebrID AND StudenthuisID = @studID;

	-- set [Out] to current date
	Update Table_Gebruiker_Activiteit 
	Set [Out] = @currentdate 
	Where GebruikerID = @gebrID AND StudenthuisID = @studID;

	-- Make new row in table_Gebruikers_Activiteit with same userID, studID is 0 and [In] as Date now
	Insert Into Table_Gebruiker_Activiteit(GebruikerID,StudenthuisID,[In])
	Values(@gebrID,0,@currentdate)

end
go