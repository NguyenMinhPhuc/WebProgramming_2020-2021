CREATE DATABASE ThiASP
go
USE [ThiASP]
GO
/****** Object:  Table [dbo].[tblCat]    Script Date: 05/31/2021 09:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCat](
	[CatID] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [nvarchar](50) NULL,
	[CatStatus] [int] NULL,
	[CatDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblCat] PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: cấm 2: được sử dụng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCat', @level2type=N'COLUMN',@level2name=N'CatStatus'
GO
SET IDENTITY_INSERT [dbo].[tblCat] ON
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (1, N'Máy bộ', 1, N'Máy bộ giành cho gia đình')
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (3, N'Máy in', 2, N'Máy in giành cho gia đình và cho các công ty')
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (4, N'Máy MP3, MP4', 2, N'Máy nghe nhạc thời trang giành ')
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (5, N'Máy Scan', 2, N'Máy scan chất lượng cao, giá rẻ')
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (6, N'Mực in', 1, N'Mực in các loại, phù hợp nhiều máy in')
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (9, N'test', 1, N'sản phẩm không có')
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (10, N'hàng ddienrj tu', 1, N'sản phẩm không có')
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (11, N'dfdfa', 1, N'adsfasd')
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (12, N'hàng ddienrj tu', 1, N'dfasdf')
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (13, N'dAASasd', 1, N'DasdSADasd')
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (14, N'dAASasdfasdfads', 1, N'adsfasdfadsfasdf')
INSERT [dbo].[tblCat] ([CatID], [CatName], [CatStatus], [CatDescription]) VALUES (15, N'dAASasdfasdfads', 1, N'adsfasdfadsfasdf')
SET IDENTITY_INSERT [dbo].[tblCat] OFF
/****** Object:  Table [dbo].[tblUser]    Script Date: 05/31/2021 09:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Userpass] [varbinary](50) NULL,
	[Fullname] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[Systemright] [int] NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1:( cấm) - 2:(sử dụng)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUser', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: quyền User 2: quyền Admin' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUser', @level2type=N'COLUMN',@level2name=N'Systemright'
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON
INSERT [dbo].[tblUser] ([UserID], [Username], [Userpass], [Fullname], [Status], [Systemright], [Address], [Phone]) VALUES (2, N'Admin', NULL, N'Admin', 1, 1, N'Dong Nai', N'1234567890')
INSERT [dbo].[tblUser] ([UserID], [Username], [Userpass], [Fullname], [Status], [Systemright], [Address], [Phone]) VALUES (11, N'NguyenPhuc', NULL, N'Nguyễn Minh Phúc', 1, 1, N'Đồng Nai', N'0911132826')
INSERT [dbo].[tblUser] ([UserID], [Username], [Userpass], [Fullname], [Status], [Systemright], [Address], [Phone]) VALUES (12, N'NguyenHoang', NULL, N'Nguyễn Minh Hoàng', 2, 1, N'Bình Dương', N'0918123123')
INSERT [dbo].[tblUser] ([UserID], [Username], [Userpass], [Fullname], [Status], [Systemright], [Address], [Phone]) VALUES (13, N'TranHung', 0x01004EC97BDE0B77FF72FA3F847C7CAF68191A260356661D655D, N'Trần văn Hùng', 1, 1, N'Vũng Tàu', N'0984949948')
INSERT [dbo].[tblUser] ([UserID], [Username], [Userpass], [Fullname], [Status], [Systemright], [Address], [Phone]) VALUES (14, N'NguyenLe', 0x0100449A0CF5B006EA3595FA547C6A9520A70B3A541A18B562CE, N'Nguyễn Minh Lễ', 1, 1, N'Tp. HCM', N'0980298277')
INSERT [dbo].[tblUser] ([UserID], [Username], [Userpass], [Fullname], [Status], [Systemright], [Address], [Phone]) VALUES (19, N'thong tin nguoi', 0x0100B9FA7460BADC5655902BCC291F7C5D08708EBCBE5E902D45, N'Nguyễn Phúc', 1, 1, N'p', N'0911132826')
INSERT [dbo].[tblUser] ([UserID], [Username], [Userpass], [Fullname], [Status], [Systemright], [Address], [Phone]) VALUES (20, N'nmphuc01@outlook.com', 0x0100B87C635379712A65CB9E376A9BFA92B1CF6883265498975B, N'Nguyễn Phúc', 1, 1, N'số 10 - Huỳnh Văn Nghệ', N'0911132826')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
/****** Object:  StoredProcedure [dbo].[PSP_tblCat_XoaCategory]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_tblCat_XoaCategory]
@CatID INT
AS
DELETE dbo.tblCat
WHERE CatID=@CatID
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblCat_Update]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_tblCat_Update]
    @CatID int
    AS
    UPDATE dbo.tblCat
    SET CatStatus=CASE CatStatus WHEN 1 THEN 2 ELSE 1 END 
    WHERE CatID=@CatID
    
    SELECT CatStatus
    FROM dbo.tblCat
    WHERE CatID=@CatID
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblCat_ThemCategory]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_tblCat_ThemCategory]
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
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblCat_LayDanhSach]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_tblCat_LayDanhSach]
AS
SELECT CatID, CatName, CatStatus, CatDescription 
FROM dbo.tblCat
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblCat_InsertUpdate]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_tblCat_InsertUpdate]
@CatName NVARCHAR(50), @CatDescription NVARCHAR(50)
AS
INSERT dbo.tblCat
        ( CatName ,
          CatStatus ,
          CatDescription
        )
VALUES  ( @CatName ,
       1,
          @CatDescription
        )
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblCat_ChangeStatus]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[PSP_tblCat_ChangeStatus] @CatID INT
    AS
        SET XACT_ABORT ON 
        BEGIN TRAN
        DECLARE @Status INT
        SET @Status = ( SELECT  CatStatus
                        FROM    dbo.tblCat
                        WHERE   CatID =@CatID
                      )
        UPDATE  dbo.tblCat
        SET  CatStatus = CASE @Status
                             WHEN 1 THEN 2
                             ELSE 1
                           END
        WHERE   CatID = @CatID

        SELECT  CatStatus
        FROM    dbo.tblCat
        WHERE  CatID = @CatID
        COMMIT
GO
/****** Object:  StoredProcedure [dbo].[PSP_Cat_Select]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_Cat_Select]
AS
SELECT CatID, CatName, CatStatus, CatDescription FROM dbo.tblCat
GO
/****** Object:  StoredProcedure [dbo].[PSP_Cat_Delete]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_Cat_Delete]
@CatID int 
AS
DELETE dbo.tblCat
WHERE CatID=@CatID
GO
/****** Object:  StoredProcedure [dbo].[PSP_User_Delete]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_User_Delete]
@UserId INT
AS
DELETE dbo.tblUser
WHERE UserID=@UserId
GO
/****** Object:  StoredProcedure [dbo].[PSP_User_ChangeStatus]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_User_ChangeStatus]
@UserId INT
AS
SET XACT_ABORT ON 
BEGIN TRAN
DECLARE @Status INT
SET @Status=(SELECT [Status] FROM dbo.tblUser WHERE UserID=@UserId)
UPDATE dbo.tblUser
SET [Status]=CASE @Status WHEN 1 THEN 2 ELSE 1 END
WHERE UserID=@UserID

SELECT [Status] FROM dbo.tblUser WHERE UserID=@UserId
COMMIT
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblUser_Select]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_tblUser_Select]
AS
    SELECT ROW_NUMBER() OVER ( ORDER BY ( SELECT   1
                                         ) ) AS STT, UserID ,
            Username ,'' AS Userpass,
            Fullname ,
            [Status] ,
            Systemright ,
            [Address] ,
            Phone
          
    FROM    dbo.tblUser;
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblUser_Insert]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_tblUser_Insert]
    @Username VARCHAR(50) ,
    @Fullname NVARCHAR(50) ,
    @Address NVARCHAR(100) ,
    @Phone NVARCHAR(20)
AS
    INSERT  INTO dbo.tblUser
            ( Username ,
              Userpass ,
              Fullname ,
              [Status] ,
              Systemright ,
              [Address] ,
              Phone
            )
    VALUES  ( @Username ,
             pwdencrypt(@Username) ,
              @Fullname ,
              1 ,
              1 ,
              @Address ,
              @Phone
            );
GO
/****** Object:  Table [dbo].[tblPro]    Script Date: 05/31/2021 09:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPro](
	[ProID] [int] IDENTITY(1,1) NOT NULL,
	[ProName] [nvarchar](50) NULL,
	[ProStatus] [int] NULL,
	[ProDescription] [nvarchar](50) NULL,
	[CatID] [int] NULL,
 CONSTRAINT [PK_tblPro] PRIMARY KEY CLUSTERED 
(
	[ProID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Cấm 2: Được sử dụng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPro', @level2type=N'COLUMN',@level2name=N'ProStatus'
GO
SET IDENTITY_INSERT [dbo].[tblPro] ON
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (1, N'Máy bộ 1', 1, N'Máy bộ loại 1, giành cho cá nhân', 1)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (2, N'Máy bộ 2', 2, N'Máy bộ loại 2, giành cho gia đình', 1)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (3, N'Máy bộ 3', 2, N'Máy bộ loại 3, giành cho sinh viên', 1)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (4, N'Máy bộ 4', 2, N'Máy bộ loại 4, giành cho hộ gia đình', 1)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (5, N'Máy bộ 5', 1, N'Máy bộ loại 5, giành cho học sinh', 1)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (11, N'Máy in loại 1', 2, N'Máy in loại tốt nhất', 3)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (12, N'Máy in loại 2', 1, N'Máy in hàng khuyến mãi', 3)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (13, N'Máy in loại 3', 2, N'Máy in hô gia đình', 3)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (14, N'Máy in loại 4', 1, N'Máy in màu đặc biệt', 3)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (15, N'Máy in loại 5', 2, N'Máy in kim giảm giá', 6)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (16, N'Máy MP3 1GB', 1, N'Giảm giá mùa hè', 4)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (17, N'Máy MP3 2 GB', 2, N'Siêu khuyến mãi nhân dịp lễ', 4)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (18, N'Máy MP3  3GB, chống sốc', 1, N'Hàng chất lượng tốt, giá rẻ', 4)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (19, N'Máy MP3 4GB', 2, N'Âm thanh chất lượng, rõ', 4)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (20, N'Máy MP3  5GB', 1, N'Dung lượng cao, chống sốc', 4)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (21, N'Máy Scan 1', 2, N'Máy Scan 1 hàng chất lượng', 5)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (22, N'Máy Scan 2', 1, N'Hàng tặng không bán', 5)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (23, N'Máy Scan 3', 2, N'Giảm giá 50%', 5)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (24, N'Máy Scan 4', 1, N'Mua 1 tặng 1', 5)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (25, N'Máy Scan 5', 2, N'Máy Scanchất lượng hình ảnh cao', 5)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (26, N'Mực in phun', 1, N'Mực in phun giành cho gia đình', 6)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (27, N'Mực in màu', 2, N'Mực in màu bền đep5', 6)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (28, N'Mực in loại 1', 1, N'Hàng Trung Quốc', 6)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (29, N'Mực in loại 2', 2, N'Hàng chất lượng cao, giá rẻ', 6)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (30, N'Mực in Epson', 1, N'Mực in Epson giá rẻ', 6)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (36, N'tessst', 1, N'thuw du lieu', 4)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (37, N'thong tin ', 1, N'test', 4)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (38, N'tessst', 1, N'test', 3)
INSERT [dbo].[tblPro] ([ProID], [ProName], [ProStatus], [ProDescription], [CatID]) VALUES (39, N'tessst', 1, N'thuw du lieu', 1)
SET IDENTITY_INSERT [dbo].[tblPro] OFF
/****** Object:  StoredProcedure [dbo].[SPS_tblPro_Delete]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SPS_tblPro_Delete]
@ProID INT
AS
DELETE dbo.tblPro
WHERE ProID=@ProID
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblPro_SelectByCatID]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_tblPro_SelectByCatID] @CatID INT=0
AS
    BEGIN 
        SELECT  ProID ,
                ProName ,
                ProStatus ,
                ProDescription ,
                CatID
        FROM    dbo.tblPro
        WHERE   @CatID = CASE @CatID
                           WHEN 0 THEN 0
                           ELSE CatID
                         END;
    END;
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblPro_Select]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_tblPro_Select]
AS
SELECT ProID, ProName, ProStatus, ProDescription, CatID
FROM dbo.tblPro
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblPro_Insert]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_tblPro_Insert]
 @ProName NVARCHAR(50) , @ProDescription NVARCHAR(255), @CatID int
 AS
 INSERT INTO dbo.tblPro
         ( ProName ,
           ProStatus ,
           ProDescription ,
           CatID
         )
 VALUES  ( @ProName , -- ProName - nvarchar(50)
           1 , -- ProStatus - int
           @ProDescription , -- ProDescription - nvarchar(50)
           @CatID  -- CatID - int
         )
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblPro_Delete]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[PSP_tblPro_Delete]
@ProID INT
AS
DELETE dbo.tblPro
WHERE ProID=@ProID
GO
/****** Object:  StoredProcedure [dbo].[PSP_tblPro_ChangeStatus]    Script Date: 05/31/2021 09:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PSP_tblPro_ChangeStatus] --1
    @ProID INT
AS
    
    UPDATE  dbo.tblPro
    SET     ProStatus = CASE ProStatus
                          WHEN 1 THEN 2
                          ELSE 1
                        END
    WHERE   ProID = @ProID;

    SELECT  ProStatus
    FROM    tblPro
    WHERE   ProID = @ProID;
GO
/****** Object:  Default [DF_tblCat_CatStatus]    Script Date: 05/31/2021 09:40:26 ******/
ALTER TABLE [dbo].[tblCat] ADD  CONSTRAINT [DF_tblCat_CatStatus]  DEFAULT ((2)) FOR [CatStatus]
GO
/****** Object:  Default [DF_tblUser_Status]    Script Date: 05/31/2021 09:40:26 ******/
ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_Status]  DEFAULT ((2)) FOR [Status]
GO
/****** Object:  Default [DF__tblUser__Address__07F6335A]    Script Date: 05/31/2021 09:40:26 ******/
ALTER TABLE [dbo].[tblUser] ADD  DEFAULT (N'Dong Nai') FOR [Address]
GO
/****** Object:  Default [DF__tblUser__Phone__08EA5793]    Script Date: 05/31/2021 09:40:26 ******/
ALTER TABLE [dbo].[tblUser] ADD  DEFAULT ('1234567890') FOR [Phone]
GO
/****** Object:  ForeignKey [FK_tblPro_tblCat]    Script Date: 05/31/2021 09:40:26 ******/
ALTER TABLE [dbo].[tblPro]  WITH CHECK ADD  CONSTRAINT [FK_tblPro_tblCat] FOREIGN KEY([CatID])
REFERENCES [dbo].[tblCat] ([CatID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblPro] CHECK CONSTRAINT [FK_tblPro_tblCat]
GO
