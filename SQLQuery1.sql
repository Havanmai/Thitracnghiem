CREATE DATABASE TracNghiem
GO

USE TracNghiem
GO

-- Bảng thông tin học sinh và lớp học
CREATE TABLE HocSinh (
    MaHS INT PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    NgaySinh DATE NOT NULL,
    DiaChi NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(20) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    MaLop INT NOT NULL
)
GO

CREATE TABLE LopHoc (
    MaLop INT PRIMARY KEY,
    TenLop NVARCHAR(50) NOT NULL,
    GiaoVienChuNhiem NVARCHAR(50) NOT NULL
)
GO

-- Bảng thông tin kho đề thi
CREATE TABLE DeThi (
    MaDe INT PRIMARY KEY,
    TenDe NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE CauHoi (
    MaCauHoi INT PRIMARY KEY,
    NoiDung NVARCHAR(500) NOT NULL,
    MaDe INT NOT NULL,
    FOREIGN KEY (MaDe) REFERENCES DeThi(MaDe)
)
GO

CREATE TABLE PhuongAn (
    MaPhuongAn INT PRIMARY KEY,
    NoiDung NVARCHAR(500) NOT NULL,
    MaCauHoi INT NOT NULL,
    DapAnDung BIT NOT NULL,
    FOREIGN KEY (MaCauHoi) REFERENCES CauHoi(MaCauHoi)
)
GO

-- Bảng thông tin bài thi của học sinh
CREATE TABLE BaiThi (
    MaBaiThi INT PRIMARY KEY,
    MaHS INT NOT NULL,
    MaDe INT NOT NULL,
    ThoiGianThi DATETIME NOT NULL,
    Diem FLOAT,
    FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS),
    FOREIGN KEY (MaDe) REFERENCES DeThi(MaDe)
)
GO

-- Bảng thông tin kết quả làm bài của học sinh
CREATE TABLE KetQuaThi (
    MaBaiThi INT NOT NULL,
    MaCauHoi INT NOT NULL,
    MaPhuongAn INT NOT NULL,
    PRIMARY KEY (MaBaiThi, MaCauHoi),
    FOREIGN KEY (MaBaiThi) REFERENCES BaiThi(MaBaiThi),
    FOREIGN KEY (MaCauHoi) REFERENCES CauHoi(MaCauHoi),
    FOREIGN KEY (MaPhuongAn) REFERENCES PhuongAn(MaPhuongAn)
)
GO

-- Bảng thông tin role
CREATE TABLE [Role] (
    RoleID INT PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
)
GO

-- Bảng thông tin đăng nhập
CREATE TABLE [User] (
    UserID INT PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    RoleID INT NOT NULL,
    FOREIGN KEY (RoleID) REFERENCES [Role](RoleID)
)
GO




INSERT INTO HocSinh (MaHS, HoTen, NgaySinh, DiaChi, SoDienThoai, Email, MaLop)
VALUES (1, N'Nguyễn Văn A', '2005-01-01', N'Hà Nội', N'0987654321', N'nguyenvana@gmail.com', 1),
(2, N'Phạm Thị B', '2006-02-02', N'Hải Phòng', N'0123456789', N'phamthib@gmail.com', 1)
GO

INSERT INTO LopHoc (MaLop, TenLop, GiaoVienChuNhiem)
VALUES (1, N'Lớp 10A1', N'Nguyễn Văn B')
GO

INSERT INTO DeThi (MaDe, TenDe)
VALUES (1, N'Đề thi số 1'),
(2, N'Đề thi số 2')
GO

INSERT INTO CauHoi (MaCauHoi, NoiDung, MaDe)
VALUES (1, N'Câu hỏi số 1', 1),
(2, N'Câu hỏi số 2', 1),
(3, N'Câu hỏi số 3', 2)
GO

INSERT INTO PhuongAn (MaPhuongAn,                                                   , MaCauHoi, DapAnDung)
VALUES (1, N'Phương án A', 1, 0),
(2, N'Phương án B', 1, 1),
(3, N'Phương án C', 1, 0),
(4, N'Phương án D', 1, 0),
(5, N'Phương án A', 2, 0),
(6, N'Phương án B', 2, 0),
(7, N'Phương án C', 2, 1),
(8, N'Phương án D', 2, 0),
(9, N'Phương án A', 3, 0),
(10, N'Phương án B', 3, 0),
(11, N'Phương án C', 3, 0),
(12, N'Phương án D', 3, 1)
GO

INSERT INTO BaiThi (MaBaiThi, MaHS, MaDe, ThoiGianThi, Diem)
VALUES (1, 1, 1, '2022-05-10 10:00:00', 8.5),
(2, 2, 2, '2022-05-10 14:00:00', 7.0)
GO

INSERT INTO KetQuaThi (MaBaiThi, MaCauHoi, MaPhuongAn)
VALUES (1, 1, 2),
(1, 2, 7),
(2, 3, 12)
GO