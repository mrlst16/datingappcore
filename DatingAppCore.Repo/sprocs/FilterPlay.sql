Begin Tran

declare @userid uniqueidentifier = 'B720EFB5-6DBC-4F5D-8AA8-D1516158B207'
declare @kvpString nvarchar(max) = 'sex=m, gender = m';

exec SearchUsers @userid, 0, 1000, @kvpString

select *
from UserProfileField
where Name in ('sex', 'gender')
order by UserID, Name

Rollback Tran