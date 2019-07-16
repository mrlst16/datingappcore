USE [DatingAppCore]
GO
/****** Object:  StoredProcedure [dbo].[PotentialMatches2]    Script Date: 7/4/2019 8:24:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE SearchUsers
	-- Add the parameters for the stored procedure here
	@userid uniqueidentifier,
	@skip int = 0,
	@take int = 1000,
	@querystring nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @clientid uniqueidentifier = (select top 1 clientid from Users where ID = @userid);

	declare @results table (
		id int identity(1, 1),
		userid uniqueidentifier
	);

	declare @orig_lat DECIMAL(12, 9) = (select top 1 Lat from Users where ID = @userid order by CreateDate desc)
	declare @orig_lng DECIMAL(12, 9) = (select top 1 Lon from Users where ID = @userid order by CreateDate desc)
	
	declare @orig geography = geography::Point(@orig_lat, @orig_lng, 4326);
	
	declare @settings table (
		id int identity(1, 1),
		k nvarchar(max),
		v nvarchar(max)
	);
	
	declare @rawKvps table(
		id int identity(1, 1),
		kvp nvarchar(max)
	);
	
	insert into @rawKvps
	select TRIM(value)
	from string_split(@querystring, ',')
	
	declare @si int = 1;
	while @si <= (select count(*) from @rawKvps)
	Begin
		declare @kvp nvarchar(max) = (select kvp from @rawKvps where id = @si)
		insert into @settings
		select [name], [value]
		from SplitString(@kvp, '=')
		set @si = @si + 1;
	End

	declare @distanceSetting decimal 
		= cast((select top 1 Value 
				from UserProfileField 
				where Name = 'distance' 
				and UserID = @userid) 
				as decimal) 
				* 1609.34;

	if @distanceSetting is null
	Begin
		set @distanceSetting = 1000000000;
	End

	insert into @results
	select x.userid
	from (
		SELECT 
		@orig.STDistance(geography::Point(u.Lat, u.Lon, 4326)) distance, u.ID[userid], u.ClientID, u.CreateDate
		from Users u
		where u.Lat is not null
		and u.Lon is not null
	) x
	where x.distance <= @distanceSetting
	and x.userid not in (
		select m.UserToID from Swipes m where m.UserFromID = @userid
	)
	and x.userid <> @userid
	and x.ClientID = @clientid
	order by x.CreateDate
	OFFSET (@Skip) ROWS FETCH NEXT (@Take) ROWS ONLY

	if @kvp is null or LEN(@kvp) < 1
	Begin
		select userid from @results as ID;
		return;
	End

	declare @i int = 1;
	declare @counti int = (select count(*) from @results);

	while @i <= @counti
	Begin
		declare @userid2 uniqueidentifier = (select userid from @results where id = @i);
		
		declare @j int = 0;
		declare @count int = (select count(*) from @settings)

		if @count < 1
		Begin
			delete from @results where userid = @userid2;
			break;
		End

		while @j < @count
		Begin
			set @j = @j + 1;
			print @j
			declare @key nvarchar(max) = (select top 1 k from @settings where id = @j)
			declare @user1SettingVal nvarchar(max) = (select top 1 v from @settings where id = @j)
			declare @user2ProfileVal nvarchar(max) = (
				select top 1 Value 
				from UserProfileField 
				where UserID = @userid2 
				and Name = @key
				and IsSetting = 0
				order by CreateDate desc
			);

			print 'Key: ' + @key + ', @user1SettingVal: ' + @user1SettingVal + ', @user2ProfileVal: ' + @user2ProfileVal;

			if @user1SettingVal is null or @user2ProfileVal is null
			Begin
				delete from @results where userid = @userid2;
				break;
			End

			if @user1SettingVal <> @user2ProfileVal
			Begin
				delete from @results where userid = @userid2;
				break;
			End
		End

		if @userid2 in (select userid from @results)
		Begin
			print 'MATCH: user2id: ' + cast(@userid2 as nvarchar(max));
		End
		set @i = @i + 1;
	End

	select userid from @results as ID;
END