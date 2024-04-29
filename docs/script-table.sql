
create table tb_department
(
    Id        int identity
        constraint PK_tb_department
            primary key,
    Name      varchar(50) not null,
    CreatedAt datetime2   not null,
    UpdatedAt datetime2   not null
)
go

create table tb_employee
(
    Id           int identity
        constraint PK_tb_employee
            primary key,
    CPF          varchar(20)            not null,
    Email        nvarchar(max)          not null,
    Salary       float                  not null,
    BirthDate    datetime2              not null,
    DepartmentId int                    not null
        constraint FK_tb_employee_tb_department_DepartmentId
            references tb_department
            on delete cascade,
    CreatedAt    datetime2              not null,
    UpdatedAt    datetime2              not null,
    Fullname     varchar(50) default '' not null
)
go


create table tb_project
(
    Id          int identity
        constraint PK_tb_project
            primary key,
    Name        varchar(20)  not null,
    Details     varchar(100) not null,
    ManagerName varchar(20)  not null,
    CreatedAt   datetime2    not null,
    UpdatedAt   datetime2    not null
)
go

create table [tb_employee-project]
(
    EmployeeId int not null
        constraint [FK_tb_employee-project_tb_employee_EmployeeId]
            references tb_employee
            on delete cascade,
    ProjectId  int not null
        constraint [FK_tb_employee-project_tb_project_ProjectId]
            references tb_project
            on delete cascade,
    constraint [PK_tb_employee-project]
        primary key (EmployeeId, ProjectId)
)
go

create index IX_tb_employee_DepartmentId
    on tb_employee (DepartmentId)
go

create index [IX_tb_employee-project_ProjectId]
    on [tb_employee-project] (ProjectId)
go

