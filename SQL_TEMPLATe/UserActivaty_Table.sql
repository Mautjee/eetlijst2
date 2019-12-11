create table Table_Gebruiker_Activiteit
(
    Id            int identity
        constraint PK_Table_Gebruiker_Activiteit
            primary key,
    GebruikerID   int not null
        references Table_Gebruiker,
    StudenthuisID int not null
        constraint FK__Table_Geb__Stude__55009F39
            references Table_Studentenhuis,
    [In]          date,
    Out           date
)
go

CREATE TRIGGER VeranderStudentenhuisBijSaldo
    ON Table_Gebruiker_Activiteit
    for Update
    as
Begin

    -- make query

    UPDATE Table_Tegoed
    SET StudenthuisID = (select i.StudenthuisID from inserted i)
    WHERE GebruikerID = (select i.GebruikerID from inserted i);

end
go

disable trigger VeranderStudentenhuisBijSaldo on Table_Gebruiker_Activiteit
go

disable trigger VeranderStudentenhuisBijSaldo on Table_Gebruiker_Activiteit
go

