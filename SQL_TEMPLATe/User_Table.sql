create table Account
(
    AccountId    int identity primary key,
    Username       nvarchar(max) not null,
    Password       nvarchar(50)  not null,
    Firstname       nvarchar(50)  not null,
    Lastname     nvarchar(max) not null,
    MailAdress     nvarchar(max)
)
go

CREATE TRIGGER [dbo].[SetDefaultStudentenhuis]
    ON [dbo].[Table_Gebruiker]
    FOR INSERT
    AS
begin

    -- Set Studenthouse to Default 0
    INSERT INTO Table_Gebruiker_Activiteit(GebruikerID, StudenthuisID, [In])
    Values ((select i.GebruikerID from inserted i), 0, (Select Convert(date, GETDATE())));

    -- Set Saldo To 0 and StudentenHuis to 0
    INSERT INTO Table_Tegoed VALUES ((select i.GebruikerID from inserted i), 0, 0)

END
go

