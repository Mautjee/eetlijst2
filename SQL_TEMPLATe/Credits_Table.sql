create table Credits
(
    AccountId   int not null
        references Account,
    StudenthouseId int not null
            references Studenthouse,
    Credit         int not null,
    primary key (AccountId, StudenthouseId),
        unique (AccountId, StudenthouseId)
)
go

