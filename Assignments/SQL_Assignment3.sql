create database SQLAssignment3
use SQLAssignment3

--1. Create Tables
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName VARCHAR(100) UNIQUE,
    Location VARCHAR(100)
);

CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY IDENTITY(1,1),
    TeacherName VARCHAR(100),
    Email VARCHAR(100) UNIQUE,
    DepartmentID INT,
    HireDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender CHAR(1),
    DepartmentID INT,
    AdmissionDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    CourseName VARCHAR(100),
    Credits INT,
    DepartmentID INT,
    TeacherID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);

CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Exams (
    ExamID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT,
    ExamDate DATE,
    ExamType VARCHAR(50),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Marks (
    MarkID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT,
    ExamID INT,
    MarksObtained INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);

--2. Constraints

ALTER TABLE Students ADD CONSTRAINT CHK_Gender CHECK (Gender IN ('M','F'));

ALTER TABLE Courses ADD CONSTRAINT CHK_Credits CHECK (Credits BETWEEN 1 AND 5);

ALTER TABLE Marks ADD CONSTRAINT CHK_Marks CHECK (MarksObtained BETWEEN 0 AND 100);

ALTER TABLE Enrollments ADD CONSTRAINT DF_EnrollmentDate DEFAULT GETDATE() FOR EnrollmentDate;

--3. Alter Table

ALTER TABLE Students ADD PhoneNumber VARCHAR(15);

ALTER TABLE Teachers ADD Salary INT;

ALTER TABLE Teachers ALTER COLUMN Salary DECIMAL(10,2);

ALTER TABLE Teachers ADD CONSTRAINT CHK_Salary CHECK (Salary > 20000);

ALTER TABLE Students DROP COLUMN PhoneNumber;

EXEC sp_rename 'Teachers.TeacherName', 'FullName', 'COLUMN';

--4. Insert Sample Data

INSERT INTO Departments VALUES ('Computer Science','Block A'),('Mechanical','Block B'),
('Electrical','Block C'),('Civil','Block D'),('Electronics','Block E');

INSERT INTO Teachers (FullName,Email,DepartmentID,HireDate,Salary) VALUES
('John','john@gmail.com',1,'2021-03-10',50000),
('Smith','smith@gmail.com',2,'2023-01-11',45000),
('David','david@gmail.com',3,'2022-02-01',60000),
('Mary','mary@gmail.com',1,'2020-07-20',70000),
('Joseph','joseph@gmail.com',4,'2023-04-15',42000),
('Emma','emma@gmail.com',5,'2022-06-10',52000),
('Chris','chris@gmail.com',3,'2021-05-30',48000),
('Daniel','daniel@gmail.com',2,'2024-01-05',41000),
('Sophia','sophia@gmail.com',4,'2019-09-18',80000),
('Olivia','olivia@gmail.com',5,'2023-08-12',43000);

INSERT INTO Students (FirstName,LastName,DateOfBirth,Gender,DepartmentID,AdmissionDate)
VALUES ('Amit','Patil','2006-05-10','M',1,'2023-06-01'),
('Anita','Sharma','2007-02-15','F',1,'2023-06-01'),
('Rahul','Patel','2005-08-20','M',2,'2023-06-01'),
('Sneha','Reddy','2006-01-05','F',3,'2023-06-01'),
('Arjun','Verma','2007-03-11','M',4,'2023-06-01'),
('Pooja','Mehta','2006-07-12','F',5,'2023-06-01'),
('Kiran','Das','2005-09-10','M',1,'2023-06-01'),
('Riya','Nair','2007-11-02','F',2,'2023-06-01'),
('Vikram','Singh','2006-04-09','M',3,'2023-06-01'),
('Neha','Joshi','2005-06-22','F',4,'2023-06-01'),
('Ajay','Kumar','2006-12-11','M',5,'2023-06-01'),
('Meena','Iyer','2005-03-18','F',1,'2023-06-01'),
('Rohan','Kapoor','2007-09-19','M',2,'2023-06-01'),
('Priya','Shetty','2006-08-14','F',3,'2023-06-01'),
('Manoj','Yadav','2005-10-21','M',4,'2023-06-01'),
('Divya','Menon','2007-01-25','F',5,'2023-06-01'),
('Sanjay','Gupta','2006-02-10','M',1,'2023-06-01'),
('Asha','Kulkarni','2005-07-05','F',2,'2023-06-01'),
('Nikhil','Bansal','2006-11-30','M',3,'2023-06-01'),
('Kavya','Rao','2007-04-16','F',4,'2023-06-01');

INSERT INTO Courses (CourseName,Credits,DepartmentID,TeacherID) VALUES
('Database Systems',4,1,3),('Thermodynamics',3,2,4),('Circuit Analysis',4,3,5),
('Structural Design',3,4,7),('Digital Electronics',4,5,8),('Operating Systems',4,1,6),
('Machine Design',3,2,10),('Power Systems',4,3,9),('Surveying',2,4,11),('Microprocessors',4,5,12);

INSERT INTO Enrollments (StudentID,CourseID,EnrollmentDate) VALUES
(1,6,'2024-01-10'),(2,6,'2024-01-10'),(3,7,'2024-01-11'),(4,8,'2024-01-11'),
(5,9,'2024-01-12'),(6,10,'2024-01-12'),(7,11,'2024-01-13'),(8,12,'2024-01-13'),
(9,13,'2024-01-14'),(10,14,'2024-01-14'),(11,15,'2024-01-15'),(12,6,'2024-01-15'),
(13,7,'2024-01-16'),(14,8,'2024-01-16'),(15,9,'2024-01-17'),(16,10,'2024-01-17'),
(17,11,'2024-01-18'),(18,12,'2024-01-18'),(19,13,'2024-01-19'),(20,14,'2024-01-19'),
(1,7,'2024-01-20'),(2,8,'2024-01-20'),(3,9,'2024-01-21'),(4,10,'2024-01-21'),
(5,11,'2024-01-22'),(6,12,'2024-01-22'),(7,13,'2024-01-23'),(8,14,'2024-01-23'),
(9,15,'2024-01-24'),(10,6,'2024-01-24');

INSERT INTO Exams (CourseID, ExamDate, ExamType) VALUES
(6,'2024-03-10','Midterm'),(7,'2024-03-11','Midterm'),(8,'2024-03-12','Midterm'),
(9,'2024-03-13','Midterm'),(10,'2024-03-14','Midterm');

INSERT INTO Marks (StudentID,ExamID,MarksObtained) VALUES
(1,1,85),(2,1,78),(3,1,90),(4,1,67),(5,1,88),
(6,2,76),(7,2,92),(8,2,81),(9,2,74),(10,2,69),
(11,3,95),(12,3,72),(13,3,84),(14,3,79),(15,3,83),
(16,4,91),(17,4,68),(18,4,87),(19,4,80),(20,4,77),
(1,5,88),(2,5,75),(3,5,82),(4,5,90),(5,5,86),
(6,1,73),(7,2,89),(8,3,78),(9,4,84),(10,5,91);

--5. Filtering Data

--1
SELECT * FROM Students WHERE DepartmentID =
(SELECT DepartmentID FROM Departments WHERE DepartmentName='Computer Science');

-- 2
SELECT * FROM Teachers
WHERE HireDate > '2022-01-01';

-- 3
SELECT * FROM Students
WHERE FirstName LIKE 'A%';

-- 4
SELECT * FROM Courses
WHERE Credits > 3;

-- 5
SELECT * FROM Students
WHERE DateOfBirth BETWEEN '2005-01-01' AND '2008-12-31';

-- 6
SELECT * FROM Students
WHERE DepartmentID <>
(SELECT DepartmentID FROM Departments WHERE DepartmentName='Mechanical');

-- 7
SELECT * FROM Teachers
WHERE Salary BETWEEN 40000 AND 70000;

-- 8
SELECT * FROM Courses
WHERE TeacherID <> 3;

--6. Grouping Data

-- 1
SELECT DepartmentID, COUNT(*) AS StudentCount
FROM Students
GROUP BY DepartmentID;

-- 2
SELECT ExamID, AVG(MarksObtained) AS AverageMarks
FROM Marks
GROUP BY ExamID;

-- 3
SELECT CourseID, COUNT(StudentID) AS TotalStudents
FROM Enrollments
GROUP BY CourseID;

-- 4
SELECT ExamID, MAX(MarksObtained) AS MaxMarks
FROM Marks
GROUP BY ExamID;

-- 5
SELECT CourseID, MIN(MarksObtained)
FROM Marks
JOIN Exams ON Marks.ExamID = Exams.ExamID
GROUP BY CourseID;

-- 6
SELECT DepartmentID, COUNT(*) AS TotalStudents
FROM Students
GROUP BY DepartmentID
HAVING COUNT(*) > 5;

--7.Joins

-- 1
SELECT S.FirstName, S.LastName, D.DepartmentName
FROM Students S
JOIN Departments D
ON S.DepartmentID = D.DepartmentID;

-- 2
SELECT C.CourseName, T.FullName
FROM Courses C
JOIN Teachers T
ON C.TeacherID = T.TeacherID;

-- 3
SELECT S.FirstName, C.CourseName
FROM Students S
JOIN Enrollments E ON S.StudentID = E.StudentID
JOIN Courses C ON E.CourseID = C.CourseID;

-- 4
SELECT S.FirstName, M.MarksObtained, E.ExamType
FROM Students S
JOIN Marks M ON S.StudentID = M.StudentID
JOIN Exams E ON M.ExamID = E.ExamID;

-- 5
SELECT C.CourseName, T.FullName
FROM Courses C
LEFT JOIN Teachers T
ON C.TeacherID = T.TeacherID;

-- 6
SELECT *
FROM Teachers T
LEFT JOIN Courses C
ON T.TeacherID = C.TeacherID
WHERE C.TeacherID IS NULL;

--8. Subqueries
-- 1
SELECT * FROM Students WHERE StudentID IN (SELECT StudentID FROM Marks WHERE MarksObtained >
(SELECT AVG(MarksObtained) FROM Marks));

-- 2
SELECT * FROM Courses WHERE Credits =(SELECT MAX(Credits) FROM Courses);

-- 3
SELECT StudentID FROM Enrollments GROUP BY StudentID HAVING COUNT(CourseID) > 2;

-- 4
SELECT * FROM Teachers WHERE DepartmentID =
(SELECT DepartmentID FROM Teachers WHERE FullName='John');

-- 5
SELECT * FROM Marks WHERE MarksObtained =(SELECT MAX(MarksObtained) FROM Marks);

-- 6
SELECT DepartmentID FROM Students GROUP BY DepartmentID HAVING COUNT(*) =
(SELECT MAX(StudentCount) FROM (SELECT COUNT(*) StudentCount
FROM Students GROUP BY DepartmentID) AS temp);

--9. Views

GO
CREATE VIEW StudentDepartmentView AS
SELECT S.StudentID,S.FirstName + ' ' + S.LastName AS StudentName,D.DepartmentName
FROM Students S JOIN Departments D ON S.DepartmentID = D.DepartmentID;
GO

GO
CREATE VIEW StudentCourseView AS
SELECT s.FirstName + ' ' + s.LastName AS StudentName,
c.CourseName,e.EnrollmentDate FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID;
GO

GO
CREATE VIEW ExamResultView AS
SELECT s.FirstName + ' ' + s.LastName AS StudentName,
c.CourseName,ex.ExamType,m.MarksObtained
FROM Marks m JOIN Students s ON m.StudentID = s.StudentID
JOIN Exams ex ON m.ExamID = ex.ExamID
JOIN Courses c ON ex.CourseID = c.CourseID;
GO

SELECT * FROM StudentDepartmentView;
SELECT * FROM StudentCourseView;
SELECT * FROM ExamResultView;

DROP VIEW StudentDepartmentView;

--10. Indexes

-- 1
CREATE INDEX idx_student_lastname ON Students(LastName);

-- 2
CREATE INDEX idx_teacher_email ON Teachers(Email);

-- 3
CREATE INDEX idx_enrollment_student_course ON Enrollments(StudentID, CourseID);

-- 4
CREATE UNIQUE INDEX idx_department_name ON Departments(DepartmentName);

-- 5
DROP INDEX idx_student_lastname ON Students;