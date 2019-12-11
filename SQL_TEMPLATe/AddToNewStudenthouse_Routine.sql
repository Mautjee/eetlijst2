Create PROCEDURE [dbo].[AddToNewStudentenhuis]
	@gebrID int, @studID int
AS
BEGIN
	-- get current date	variable
	declare @currentdate DateTime;
	select @currentdate = (Select Convert (date, GETDATE()));	

	--Update the table and set studenthouse to new house
	update Table_Gebruiker_Activiteit 
	SET StudenthuisID = @studID, [In] = @currentdate 
	Where GebruikerID = @gebrID and StudenthuisID = 0;
	
	-- Update the table tegoed to new house
	Update Table_Tegoed
	SET StudenthuisID = @studID
	Where GebruikerID = @gebrID;

end
go
