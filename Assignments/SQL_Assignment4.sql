--1.)1. Views Assignments
--1 Student Department View
CREATE VIEW vw_StudentDepartment
AS
SELECT 
    s.StudentID, s.FirstName + ' ' + s.LastName AS StudentName,d.DepartmentName,s.AdmissionDate
FROM Students s JOIN Departments d ON s.DepartmentID = d.DepartmentID;

SELECT * FROM vw_StudentDepartment;
SELECT *FROM vw_StudentDepartment WHERE DepartmentName = 'Computer Science';
DROP VIEW vw_StudentDepartment;

--2 Student Course Enrollment View
CREATE VIEW vw_StudentCourses
AS
SELECT 
    s.FirstName + ' ' + s.LastName AS StudentName,s.StudentID,c.CourseName,e.EnrollmentDate
FROM Students s JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID;

SELECT StudentName, CourseName, EnrollmentDate FROM vw_StudentCourses WHERE StudentID = 5;
SELECT StudentName, COUNT(CourseName) AS TotalCourses FROM vw_StudentCourses GROUP BY StudentName;
SELECT StudentName, CourseName, EnrollmentDate FROM vw_StudentCourses
WHERE YEAR(EnrollmentDate) > 2024;

--3 Exam Result View
CREATE VIEW vw_ExamResults
AS
SELECT
    s.FirstName + ' ' + s.LastName AS StudentName,c.CourseName,e.ExamType,m.MarksObtained
FROM Students s
JOIN Marks m ON s.StudentID = m.StudentID
JOIN Exams e ON m.ExamID = e.ExamID
JOIN Courses c ON e.CourseID = c.CourseID;

SELECT * FROM vw_ExamResults WHERE MarksObtained > 80;
SELECT * FROM vw_ExamResults WHERE MarksObtained = (
    SELECT MAX(MarksObtained)
    FROM vw_ExamResults v2
    WHERE v2.ExamType = vw_ExamResults.ExamType
);
SELECT * FROM vw_ExamResults WHERE MarksObtained < 40;

--4 Aggregate View
CREATE VIEW vw_DepartmentStudentCount
AS
SELECT d.DepartmentName, COUNT(s.StudentID) AS TotalStudents
FROM Departments d
JOIN Students s ON d.DepartmentID = s.DepartmentID
GROUP BY d.DepartmentName;

SELECT * FROM vw_DepartmentStudentCount WHERE TotalStudents > 10;
SELECT * FROM vw_DepartmentStudentCount ORDER BY TotalStudents DESC;

--2.) Stored Procedures Assignments
--1 Insert Student Procedure
CREATE PROCEDURE sp_InsertStudent
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Gender VARCHAR(10),
    @DepartmentID INT,
    @AdmissionDate DATE
AS
BEGIN
    INSERT INTO Students (FirstName, LastName, Gender, DepartmentID, AdmissionDate)
    VALUES (@FirstName, @LastName, @Gender, @DepartmentID, @AdmissionDate);
END;
EXEC sp_InsertStudent 'Rahul','Sharma','M',1,'2024-06-15';
SELECT * FROM Students;

--2 Get Students By Department
CREATE PROCEDURE sp_GetStudentsByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        StudentID,FirstName + ' ' + LastName AS StudentName,AdmissionDate
    FROM Students
    WHERE DepartmentID = @DepartmentID;
END;

EXEC sp_GetStudentsByDepartment 2;
EXEC sp_GetStudentsByDepartment 3;

--3 Course Enrollment Procedure
CREATE PROCEDURE sp_EnrollStudent
    @StudentID INT,
    @CourseID INT
AS
BEGIN
    INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate)
    VALUES (@StudentID, @CourseID, GETDATE());
END;
EXEC sp_EnrollStudent 5, 3;

--4 Student Marks Procedure
CREATE PROCEDURE sp_GetStudentMarks
    @StudentID INT
AS
BEGIN
    SELECT
        s.FirstName + ' ' + s.LastName AS StudentName,
        c.CourseName,e.ExamType,m.MarksObtained
    FROM Students s
    JOIN Marks m
        ON s.StudentID = m.StudentID
    JOIN Exams e
        ON m.ExamID = e.ExamID
    JOIN Courses c
        ON e.CourseID = c.CourseID
    WHERE s.StudentID = @StudentID;
END;

EXEC sp_GetStudentMarks 3;

--5 Update Student Marks
CREATE PROCEDURE sp_UpdateMarks
    @MarkID INT,
    @NewMarks INT
AS
BEGIN
    UPDATE Marks
    SET MarksObtained = @NewMarks
    WHERE MarkID = @MarkID;
    SELECT *
    FROM Marks
    WHERE MarkID = @MarkID;
END;

EXEC sp_UpdateMarks 5, 90;

--6 
CREATE PROCEDURE sp_DeleteEnrollment
    @EnrollmentID INT
AS
BEGIN
    DELETE FROM Enrollments
    WHERE EnrollmentID = @EnrollmentID;
END;
EXEC sp_DeleteEnrollment 4;
SELECT * FROM Enrollments WHERE EnrollmentID = 4;

--3.) User Defined Functions Assignments
--1 Calculate Grade (Scalar Function)
CREATE FUNCTION fn_GetGrade
(
    @MarksObtained INT
)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @Grade VARCHAR(10)
    IF @MarksObtained >= 90
        SET @Grade = 'A'
    ELSE IF @MarksObtained >= 75
        SET @Grade = 'B'
    ELSE IF @MarksObtained >= 60
        SET @Grade = 'C'
    ELSE
        SET @Grade = 'Fail'
    RETURN @Grade
END;

SELECT StudentID,MarksObtained,dbo.fn_GetGrade(MarksObtained) AS Grade FROM Marks;

--2 Student Age Function
CREATE FUNCTION fn_GetStudentAge
(
    @DateOfBirth DATE
)
RETURNS INT
AS
BEGIN
    DECLARE @Age INT
    SET @Age = DATEDIFF(YEAR, @DateOfBirth, GETDATE())
    RETURN @Age
END;

SELECT StudentID,FirstName + ' ' + LastName AS StudentName,dbo.fn_GetStudentAge(DateOfBirth) 
AS Age FROM Students;

--3 Total Marks Function
CREATE FUNCTION fn_GetTotalMarks
(
    @StudentID INT
)
RETURNS INT
AS
BEGIN
    DECLARE @TotalMarks INT
    SELECT @TotalMarks = SUM(MarksObtained)
    FROM Marks
    WHERE StudentID = @StudentID
    RETURN @TotalMarks
END;

SELECT StudentID,dbo.fn_GetTotalMarks(StudentID) AS TotalMarks FROM Students;

--4 Student Courses Function (Table Valued)
CREATE FUNCTION fn_GetStudentCourses
(
    @StudentID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        c.CourseName,e.EnrollmentDate
    FROM Enrollments e
    JOIN Courses c ON e.CourseID = c.CourseID
    WHERE e.StudentID = @StudentID
);

SELECT * FROM fn_GetStudentCourses(5);

--5 Department Students Function (Table Valued)
CREATE FUNCTION fn_GetDepartmentStudents
(
    @DepartmentID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        StudentID,FirstName + ' ' + LastName AS StudentName,
        AdmissionDate
    FROM Students
    WHERE DepartmentID = @DepartmentID
);
SELECT * FROM fn_GetDepartmentStudents(2);