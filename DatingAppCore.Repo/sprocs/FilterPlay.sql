Begin Tran

select * from Users

--update Users set Birthday = dateadd(year, -25, getutcdate()) where ID = 'C323CE57-A962-4BCD-903B-1F7A301A18D0'
--update Users set Birthday = dateadd(year, -35, getutcdate()) where ID = '44C2838D-0F7A-4E8C-8145-46F569262C16'
--update Users set Birthday = dateadd(year, -45, getutcdate()) where ID = '770ABE28-4A61-4A49-BFB5-A0C9A004ACEE'
--update Users set Birthday = dateadd(year, -55, getutcdate()) where ID = '1C1C403F-6826-4736-A46C-A40568A00600'
--update Users set Birthday = dateadd(year, -65, getutcdate()) where ID = '105220E9-2917-4DAF-9490-ADF587491618'
--update Users set Birthday = dateadd(year, -75, getutcdate()) where ID = 'B720EFB5-6DBC-4F5D-8AA8-D1516158B207'
--update Users set Birthday = dateadd(year, -25, getutcdate()) where ID = 'C5919193-4E0F-4984-92F7-F3F4C9DACFD9'
--update Users set Birthday = dateadd(year, -25, getutcdate()) where ID = 'A7BF0AAB-C3BC-4524-BCC3-FADE75585A66'

declare @userid uniqueidentifier = 'B720EFB5-6DBC-4F5D-8AA8-D1516158B207'
declare @kvpString nvarchar(max) = 'sex=m, gender = m';
--declare @kvpString nvarchar(max) = '';








exec SearchUsers @userid, 0, 1000, @kvpString

--select *
--from UserProfileField
--where Name in ('sex', 'gender', 'dogs')
--and IsSetting = 0
--order by UserID, Name

--select * from Swipes where UserFromID = 'B720EFB5-6DBC-4F5D-8AA8-D1516158B207'


--delete from Swipes where UserFromID = 'B720EFB5-6DBC-4F5D-8AA8-D1516158B207'

Rollback Tran