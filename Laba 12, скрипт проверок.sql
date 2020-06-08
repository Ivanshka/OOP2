use OOP;

select * from Owners;
select * from Cars;
/*
select Owners.[Name] [Владелец], count(Cars.ID) [Количество машин]
	from Owners inner join Cars
		on Owners.ID = Cars.Owner_ID
	group by Owners.[Name];
	*/