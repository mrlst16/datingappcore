Begin Tran

select * from Users

declare @userid uniqueidentifier = 'C323CE57-A962-4BCD-903B-1F7A301A18D0'
declare @kvpString nvarchar(max) = 'sex=f, gender = f,   dogs=n';
--declare @kvpString nvarchar(max) = '';

exec SearchUsers @userid, 0, 1000, @kvpString

--select *
--from UserProfileField
--where Name in ('sex', 'gender', 'dogs')
--and IsSetting = 0
--order by UserID, Name

Rollback Tran