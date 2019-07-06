-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'SplitString') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION SplitString
GO

Create FUNCTION SplitString
(
	-- Add the parameters for the function here
	@string nvarchar(max),
	@delimiter nvarchar(1)
)
RETURNS @rt table(
	name nvarchar(max),
	value nvarchar(max)
)
AS
BEGIN
	declare @index int = CHARINDEX(@delimiter, @string);
	declare @k nvarchar(max);
	declare @v nvarchar(max);

	if @index > 0
	Begin
		set @k = TRIM(LEFT(@string, @index-1))
		set @v = TRIM(RIGHT(@string, LEN(@string)-@index))
	End
	Else
	Begin
		set @k = '';
		set @v = '';
	End

	insert into @rt
	select @k, @v

	return;
END
GO

