CREATE PROC PSP_tblCat_LayDanhSach
AS
SELECT CatID, CatName, CatStatus, CatDescription 
FROM dbo.tblCat
GO
CREATE PROC PSP_tblCat_XoaCategory
@CatID INT
AS
DELETE dbo.tblCat
WHERE CatID=@CatID
GO
CREATE PROC PSP_tblCat_ThemCategory
@CatName NVARCHAR(50),
@CatDescription NVARCHAR(255)
AS
INSERT INTO dbo.tblCat
        ( CatName ,
          CatStatus ,
          CatDescription
        )
VALUES  ( @CatName , -- CatName - nvarchar(50)
          1 , -- CatStatus - int 1 or 2
         @CatDescription  -- CatDescription - nvarchar(50)
        )