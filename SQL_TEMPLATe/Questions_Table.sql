create table Question
(
        QuestionId         int identity
            primary key,
        StudenthouseId int           not null
            references Studenthouse,
        Question         nvarchar(250) not null,
        Answer     nvarchar(250) not null
    )
go

