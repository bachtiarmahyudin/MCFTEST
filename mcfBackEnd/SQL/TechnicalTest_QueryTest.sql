--Technical Test 1
CREATE TABLE [dbo].[tr_bpkb](
	[agreement_number] [varchar](100) NOT NULL,
	[bpkb_no] [varchar](100) NULL,
	[branch_id] [varchar](100) NULL,
	[bpkb_date] [datetime] NULL,
	[faktur_no] [varchar](100) NULL,
	[faktur_date] [datetime] NULL,
	[location_id] [varchar](10) NULL,
	[police_no] [varchar](20) NULL,
	[bpkb_date_in] [datetime] NULL,
	[created_by] [varchar](20) NULL,
	[created_on] [datetime] NULL,
	[last_updated_by] [varchar](20) NULL,
	[last_updated_on] [datetime] NULL,
 CONSTRAINT [PK_tr_bpkb] PRIMARY KEY CLUSTERED 
(
	[agreement_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--Technical Test 2
CREATE TABLE [dbo].[ms_storage_location](
	[location_id] [varchar](10) NOT NULL,
	[location_name] [varchar](100) NULL,
 CONSTRAINT [PK_ms_storage_location] PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--Technical Test 3
CREATE TABLE [dbo].[ms_user](
	[user_id] [bigint] NOT NULL,
	[user_name] [varchar](20) NULL,
	[password] [varchar](50) NULL,
	[is_active] [bit] NULL,
 CONSTRAINT [PK_ms_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


--Query Test 1
--NoKontrak, KodeCabang, dan KodeMotor

--Query Test 2
select * from pembayaran where DATEDIFF(TglBayar,'2014-10-20')=0

--Query Test 3
insert into cabang values ('200','Tangerang')

--Query Test 4
Update pembayaran set KodeMotor='001' where KodeCabang='200'

--Query Test 5

Select a.NoKontrak, a.TglBayar, a.JumlahBayar, a.KodeCabang, b.NamaCabang, 
a.NoKwitansi, a.NoKwitansi, a.KodeMotor, c.NamaMotor from Pembayaran a
Inner join Cabang b on a.kodecabang=b.kodecabang
Inner join Motor c on a. KodeMotor=c. KodeMotor

--Query Test 6
Select a.KodeCabang, a.NamaCabang, b.NoKontrak, b.NoKwitansi from Cabang a
left outer join Pembayaran b on a.kodecabang=b.kodecabang

--Query Test 7
Select a.KodeCabang, a.NamaCabang, count(*) as TotalData, sum(ifnull(b.JumlahBayar,0)) as TotalBayar from Cabang a
left outer join Pembayaran b on a.kodecabang=b.kodecabang
group by a.KodeCabang, a.NamaCabang
