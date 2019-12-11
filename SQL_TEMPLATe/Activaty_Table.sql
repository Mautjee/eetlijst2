create table Activaty
(
    ActivatyId     int identity
            primary key,
    AccountId      int not null
            references Account,
    StudenthouseId int not null
            references Studenthouse,
    Date            date,
    Description     nvarchar(max),
    Amount           int,
    OtherAccountId int not null
)
go

CREATE TRIGGER [dbo].[updateSaldo]
    ON dbo.Table_Activiteit
    FOR INSERT
    AS
begin

    -- Declareer alle variablen
    declare @bedrag int;

    -- vul alle variablen		
    select @bedrag = i.Bedrag from inserted i;

    -- update tabel met niewe waarden
    Update Table_Tegoed
    Set Saldo = saldo + @bedrag
    Where StudenthuisID = (select i.StudentenhuisID from inserted i)
      And GebruikerID = (select i.GebruikerID from inserted i);

    Update Table_Tegoed
    Set Saldo = saldo - @bedrag
    Where StudenthuisID = (select i.StudentenhuisID from inserted i)
      And GebruikerID = (select i.TegenGebruikerID from inserted i);
    print 'Saldo updated'
end
go

