USE [DatingAppCore]
GO
/****** Object:  StoredProcedure [dbo].[PotentialMatches]    Script Date: 5/27/2019 2:34:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PotentialMatches]
	-- Add the parameters for the stored procedure here
	@userid uniqueidentifier,
	@skip int = 0,
	@take int = 1000
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @results table (
		id int identity(1, 1),
		userid uniqueidentifier,
		sex char,
		gender char
	);

	declare @orig_lat DECIMAL(12, 9) = (select top 1 Lat from Users where ID = @userid order by CreateDate desc)
	declare @orig_lng DECIMAL(12, 9) = (select top 1 Lon from Users where ID = @userid order by CreateDate desc)
	
	declare @orig geography = geography::Point(@orig_lat, @orig_lng, 4326);
	
	declare @settings table (
		id int identity(1, 1),
		k nvarchar(max),
		v nvarchar(max)
	);

	insert into @settings
	select upf.Name, upf.Value
	from UserProfileField upf
	where upf.IsSetting = 1
	and upf.UserID = @userid
	--and upf.Name not in ('distance', 'SeekingGender', 'SeekingSex', 'Sex', 'Gender')

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

	declare @seekingSex char = (select top 1 Value 
				from UserProfileField 
				where Name = 'sex'
				and IsSetting = 1
				and UserID = @userid)

	declare @seekingGender char = (select top 1 Value 
				from UserProfileField 
				where Name = 'gender' 
				and IsSetting = 1
				and UserID = @userid)

	print 'Seeking Sex: ' + @seekingSex + '; Seeking Gender: ' + @seekingGender;

	insert into @results
	select x.userid, sex.Value, gender.Value
	from (
		SELECT 
		@orig.STDistance(geography::Point(u.Lat, u.Lon, 4326)) distance, u.ID[userid], u.CreateDate
		from Users u
		where u.Lat is not null
		and u.Lon is not null
	) x
	left join UserProfileField sex on x.userid = sex.UserID and sex.Name = 'sex' and sex.IsSetting = 0
	left join UserProfileField gender on x.userid = gender.UserID and gender.Name = 'gender' and gender.IsSetting = 0
	where x.distance <= @distanceSetting
	and sex.Value = @seekingSex
	and gender.Value = @seekingGender
	and x.userid not in (
		select m.UserToID from Swipes m where m.UserFromID = @userid
	)
	order by x.CreateDate desc
	OFFSET (@Skip) ROWS FETCH NEXT (@Take) ROWS ONLY

	--select * from @results;

	declare @i int = 1;
	while @i <= (select count(*) from @results)
	Begin
		declare @userid2 uniqueidentifier = (select userid from @results where id = @i);

		declare @haystack table(
			id int identity(1, 1),
			k nvarchar(max),
			v nvarchar(max)
		);
		insert into @haystack
		select upf.Name, upf.Value
		from UserProfileField upf
		where upf.IsSetting = 0
		and upf.UserID = @userid2

		declare @j int = 1;

		while @j <= (select count(*) from @settings)
		Begin
			declare @key nvarchar(max) = (select k from @settings where id = @j)
			if (select v from @settings where k = @key) <> (select v from @settings where k = @key)
			Begin
				delete from @results where userid = @userid2;
				continue;
			End
			
			set @j = @j + 1;
		End
		set @i = @i + 1;
	End

	select userid from @results as ID;
END

