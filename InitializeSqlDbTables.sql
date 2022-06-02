use [YourDatabase];
go

create table CORE_Carrier
(
	CarrierId int identity(1,1),
	CarrierName nvarchar(500) not null,
	constraint PK__CORE_Carrier primary key (CarrierId)
);

create table CORE_Contract
(
	ContractId int identity(1,1),
	CarrierId int not null,
	EffectiveDate date not null,
	TermDate date not null,
	constraint PK__CORE_Contract primary key (ContractId),
	constraint FK__CORE_Contract_CarrierId foreign key (CarrierId) 
		references CORE_Carrier(CarrierId)
);

insert into CORE_Carrier
(
	CarrierName
)
values('Carrier1'),
	('Carrier2'),
	('Carrier3');

insert into CORE_Contract
(
	CarrierId,
	EffectiveDate,
	TermDate
)
select 
	1 as CarrierId,
	getdate() as EffectiveDate,
	getdate() as TermDate
union select 
	2 as CarrierId,
	getdate() as EffectiveDate,
	getdate() as TermDate;

/*
select * 
from CORE_Contract c
join CORE_Carrier r
	on c.CarrierId = r.CarrierId;
*/

