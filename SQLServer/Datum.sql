INSERT [dbo].[UserInfo] ([ID], [Account], [PWD], [Name], [Email], [UserLevel], [CreateDate], [MobilePhone]) VALUES (N'2d6d6010-676f-4033-bb98-08c4903836c6', N'admin', N'12345', N'Moudou', N'moudou@moudou.tw', 0, CAST(N'2021-07-31T09:30:48.800' AS DateTime), N'0999999999')
GO
INSERT [dbo].[UserInfo] ([ID], [Account], [PWD], [Name], [Email], [UserLevel], [CreateDate], [MobilePhone]) VALUES (N'51ad94b6-2e83-4494-bbea-2a69ffdcab77', N'Moudou', N'12345', N'Moudou2', N'moudou@moudou.com', 1, CAST(N'2021-07-31T09:30:48.800' AS DateTime), N'0999999999')
GO
INSERT [dbo].[Roles] ([ID], [RoleName]) VALUES (N'7b0c6a39-0721-402d-8cc6-8dd943e927f8', N'FinanceAdmin')
GO
INSERT [dbo].[Roles] ([ID], [RoleName]) VALUES (N'8cbd27ee-52a0-4a10-86bb-907efb92e660', N'FinanceReviewer')
GO
INSERT [dbo].[Roles] ([ID], [RoleName]) VALUES (N'71d46652-21a5-4b98-a920-e7c3f519e232', N'FinanceClerk')
GO
INSERT [dbo].[UserRoles] ([ID], [RoleID], [UserInfoID], [IsGrant], [EndDate]) VALUES (N'72e8b781-0931-4d9c-a512-40b57f917a7d', N'71d46652-21a5-4b98-a920-e7c3f519e232', N'51ad94b6-2e83-4494-bbea-2a69ffdcab77', 1, NULL)
GO
INSERT [dbo].[UserRoles] ([ID], [RoleID], [UserInfoID], [IsGrant], [EndDate]) VALUES (N'36fa3faf-3a0e-4832-bd89-d105f768cc60', N'8cbd27ee-52a0-4a10-86bb-907efb92e660', N'51ad94b6-2e83-4494-bbea-2a69ffdcab77', 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Accounting] ON 
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (4, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'Receive 1000', 1000, 1, CAST(N'2021-07-29T08:31:09.847' AS DateTime), N'123', N'20210901130800674416854.jpg')
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (6, N'51ad94b6-2e83-4494-bbea-2a69ffdcab77', N'TestCaption', 1600, 0, CAST(N'2021-07-29T13:48:48.873' AS DateTime), N'TestDesc', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1004, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'2002', 2002, 0, CAST(N'2021-08-02T10:35:02.997' AS DateTime), N'2002', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1005, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'2003', 2003, 0, CAST(N'2021-08-02T10:35:10.357' AS DateTime), N'2003', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1006, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'2004', 2004, 0, CAST(N'2021-08-02T10:35:15.893' AS DateTime), N'2004', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1007, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'2005', 2005, 0, CAST(N'2021-08-02T10:35:21.380' AS DateTime), N'2005', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1008, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'2006', 2006, 0, CAST(N'2021-08-02T10:35:27.540' AS DateTime), N'2006', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1009, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'2007', 2007, 0, CAST(N'2021-08-02T10:35:32.977' AS DateTime), N'2007', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1010, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'2008', 2008, 0, CAST(N'2021-08-02T10:35:37.987' AS DateTime), N'2008', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1011, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'2009', 2009, 0, CAST(N'2021-08-02T10:35:44.547' AS DateTime), N'2009', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1012, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'2010', 2010, 0, CAST(N'2021-08-02T10:35:50.203' AS DateTime), N'2010', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1013, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'2000', 2000, 0, CAST(N'2021-08-02T11:21:09.450' AS DateTime), N'2000', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1014, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'2021', 2021, 0, CAST(N'2021-08-02T11:29:18.387' AS DateTime), N'2021', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1015, N'51ad94b6-2e83-4494-bbea-2a69ffdcab77', N'123', 2000, 1, CAST(N'2021-08-12T11:19:10.970' AS DateTime), N'hello ', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1016, N'51ad94b6-2e83-4494-bbea-2a69ffdcab77', N'Test', 2000, 1, CAST(N'2021-08-12T11:28:57.810' AS DateTime), N'XXXXX', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1017, N'51ad94b6-2e83-4494-bbea-2a69ffdcab77', N'Test', 2000, 1, CAST(N'2021-08-12T11:30:40.407' AS DateTime), N'XXXXX', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1018, N'51ad94b6-2e83-4494-bbea-2a69ffdcab77', N'Test', 2000, 1, CAST(N'2021-08-12T13:30:13.677' AS DateTime), N'XXXXX', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1019, N'51ad94b6-2e83-4494-bbea-2a69ffdcab77', N'Test', 2000, 1, CAST(N'2021-08-12T13:30:56.263' AS DateTime), N'XXXXX', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1020, N'51ad94b6-2e83-4494-bbea-2a69ffdcab77', N'Caption', 2000, 0, CAST(N'2021-08-12T13:54:17.197' AS DateTime), N'Desc', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1021, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'Test123', 5000, 0, CAST(N'2021-08-19T13:18:39.247' AS DateTime), N'Test123', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1022, N'51ad94b6-2e83-4494-bbea-2a69ffdcab77', N'Test222', 5000, 0, CAST(N'2021-08-19T13:21:54.767' AS DateTime), N'Test222', NULL)
GO
INSERT [dbo].[Accounting] ([ID], [UserID], [Caption], [Amount], [ActType], [CreateDate], [Body], [CoverImage]) VALUES (1023, N'2d6d6010-676f-4033-bb98-08c4903836c6', N'Test Cover Image', 2000, 0, CAST(N'2021-09-01T11:34:47.207' AS DateTime), N'123123', N'20210901113447206351781.jpg')
GO
SET IDENTITY_INSERT [dbo].[Accounting] OFF
GO
