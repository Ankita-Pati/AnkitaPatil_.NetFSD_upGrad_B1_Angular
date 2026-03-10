--1.) Triggers Assignments

-- 1  Audit Trigger for Students
CREATE TABLE StudentAudit (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    ActionType VARCHAR(20),
    ActionDate DATETIME
);

CREATE TRIGGER trg_StudentInsertAudit
ON Students
AFTER INSERT
AS
BEGIN
    INSERT INTO StudentAudit (StudentID, ActionType, ActionDate)
    SELECT StudentID, 'INSERT', GETDATE()
    FROM inserted;
END;

INSERT INTO Students (FirstName, LastName, Gender, DepartmentID, AdmissionDate)
VALUES ('Ravi', 'Kumar', 'M', 1, '2024-07-10');
SELECT * FROM StudentAudit;
INSERT INTO Students (FirstName, LastName, Gender, DepartmentID, AdmissionDate)
VALUES ('Anita','Sharma','F',2,'2024-07-11'),('Vikram','Patel','M',3,'2024-07-12');

--2 Prevent Deleting Students 
CREATE TRIGGER trg_PreventStudentDelete
ON Students
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Enrollments e
        JOIN deleted d
        ON e.StudentID = d.StudentID
    )
    BEGIN
        RAISERROR ('Student has course enrollments and cannot be deleted',16,1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        DELETE FROM Students
        WHERE StudentID IN (SELECT StudentID FROM deleted);
    END
END;

select * from Students
select * from Enrollments
DELETE FROM Students WHERE StudentID = 5;
DELETE FROM Students WHERE StudentID = 27;

--3  Update Marks Trigger

CREATE TABLE MarksAudit
(
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    ExamID INT,
    OldMarks INT,
    NewMarks INT,
    UpdatedDate DATETIME
);
CREATE TRIGGER trg_UpdateMarksAudit
ON Marks
AFTER UPDATE
AS
BEGIN
    INSERT INTO MarksAudit (StudentID, ExamID, OldMarks, NewMarks, UpdatedDate)
    SELECT 
        d.StudentID,
        d.ExamID,
        d.MarksObtained,
        i.MarksObtained,
        GETDATE()
    FROM deleted d
    JOIN inserted i
        ON d.MarkID = i.MarkID;
END;

UPDATE Marks SET MarksObtained = 92 WHERE MarkID = 3;
SELECT * FROM MarksAudit;

--2.) Exception Handling Assignments 
--1  Insert Student Procedure with Exception Handling 
CREATE PROCEDURE sp_AddStudent
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Gender VARCHAR(10),
    @AdmissionDate DATE
AS
BEGIN
    BEGIN TRY
        INSERT INTO Students (FirstName, LastName, DepartmentID, Gender, AdmissionDate)
        VALUES (@FirstName, @LastName, @DepartmentID, @Gender, @AdmissionDate);
        PRINT 'Student inserted successfully';
    END TRY
    BEGIN CATCH
        PRINT 'Error occurred while inserting student';
        PRINT ERROR_MESSAGE();
    END CATCH
END;

EXEC sp_AddStudent 'Arjun','Patil',1,'M','2024-07-15';
EXEC sp_AddStudent 'Neha','Sharma',99,'F','2024-07-16';
SELECT * FROM Students;

--2 Marks Validation Procedure 
CREATE PROCEDURE sp_InsertMarks
    @StudentID INT,
    @ExamID INT,
    @MarksObtained INT
AS
BEGIN
    -- Validate marks
    IF @MarksObtained < 0 OR @MarksObtained > 100
    BEGIN
        RAISERROR('Invalid Marks',16,1);
        RETURN;
    END
    -- Insert marks if valid
    INSERT INTO Marks (StudentID, ExamID, MarksObtained)
    VALUES (@StudentID, @ExamID, @MarksObtained);
    PRINT 'Marks inserted successfully';
END;

EXEC sp_InsertMarks 5, 2, 85;
EXEC sp_InsertMarks 5, 2, 120;
SELECT * FROM Marks;

--3  Safe Delete Procedure
CREATE PROCEDURE sp_DeleteStudent
    @StudentID INT
AS
BEGIN
    BEGIN TRY

        DELETE FROM Students
        WHERE StudentID = @StudentID;
        PRINT 'Student deleted successfully';
    END TRY
    BEGIN CATCH
        PRINT 'Error while deleting student';
        PRINT ERROR_MESSAGE();
    END CATCH
END;

EXEC sp_DeleteStudent 5;
EXEC sp_DeleteStudent 28;
SELECT * FROM Students WHERE StudentID = 28;

--3.) Cursors Assignments
--1 Display Student Names 
CREATE PROCEDURE sp_DisplayStudentsCursor
AS
BEGIN
    DECLARE @StudentID INT
    DECLARE @StudentName VARCHAR(100)
    DECLARE student_cursor CURSOR FOR
    SELECT StudentID, FirstName + ' ' + LastName
    FROM Students
    OPEN student_cursor
    FETCH NEXT FROM student_cursor
    INTO @StudentID, @StudentName
    WHILE @@FETCH_STATUS = 0
    BEGIN
        PRINT 'StudentID: ' + CAST(@StudentID AS VARCHAR) + 
              '  StudentName: ' + @StudentName
        FETCH NEXT FROM student_cursor
        INTO @StudentID, @StudentName
    END
    CLOSE student_cursor
    DEALLOCATE student_cursor
END;

EXEC sp_DisplayStudentsCursor;

--2 Calculate Total Marks Per Student
CREATE PROCEDURE sp_CalculateStudentTotalMarks
AS
BEGIN
    DECLARE @StudentID INT
    DECLARE @StudentName VARCHAR(100)
    DECLARE @TotalMarks INT
    DECLARE student_cursor CURSOR FOR
    SELECT StudentID, FirstName + ' ' + LastName
    FROM Students
    OPEN student_cursor
    FETCH NEXT FROM student_cursor
    INTO @StudentID, @StudentName
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Calculate total marks for the student
        SELECT @TotalMarks = SUM(MarksObtained)
        FROM Marks
        WHERE StudentID = @StudentID
        PRINT 'StudentName: ' + @StudentName +
              '  TotalMarks: ' + CAST(ISNULL(@TotalMarks,0) AS VARCHAR)
        FETCH NEXT FROM student_cursor
        INTO @StudentID, @StudentName
    END
    CLOSE student_cursor
    DEALLOCATE student_cursor
END;

EXEC sp_CalculateStudentTotalMarks;

--3 Update Course Credits 
CREATE PROCEDURE sp_UpdateCourseCredits
AS
BEGIN
    DECLARE @CourseID INT
    DECLARE @Credits INT
    DECLARE course_cursor CURSOR FOR
    SELECT CourseID, Credits
    FROM Courses
    WHERE Credits < 3
    OPEN course_cursor
    FETCH NEXT FROM course_cursor
    INTO @CourseID, @Credits
    WHILE @@FETCH_STATUS = 0
    BEGIN
        UPDATE Courses
        SET Credits = @Credits + 1
        WHERE CourseID = @CourseID
        FETCH NEXT FROM course_cursor
        INTO @CourseID, @Credits
    END
    CLOSE course_cursor
    DEALLOCATE course_cursor
END;

EXEC sp_UpdateCourseCredits;
SELECT * FROM Courses;

--4.) Transactions Assignments 
--1 Student Enrollment Transaction
CREATE PROCEDURE sp_EnrollStudentTransaction
    @StudentID INT,
    @CourseID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
        INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate)
        VALUES (@StudentID, @CourseID, GETDATE());
        COMMIT TRANSACTION
        PRINT 'Enrollment successful'
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        PRINT 'Error occurred. Transaction rolled back'
        PRINT ERROR_MESSAGE()
    END CATCH
END;

EXEC sp_EnrollStudentTransaction 26, 6;
EXEC sp_EnrollStudentTransaction 999, 6;
SELECT * FROM Enrollments;

-- 2 Exam Marks Transaction
CREATE PROCEDURE sp_RecordExamMarks
    @StudentID INT,
    @ExamID INT,
    @MarksObtained INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
        -- Insert marks
        INSERT INTO Marks (StudentID, ExamID, MarksObtained)
        VALUES (@StudentID, @ExamID, @MarksObtained)
        -- Example: update exam record (for example updating total marks count)
        UPDATE Exams
        SET @MarksObtained = @MarksObtained + 1
        WHERE ExamID = @ExamID
        COMMIT TRANSACTION
        PRINT 'Marks recorded successfully'
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        PRINT 'Error occurred. Transaction rolled back'
        PRINT ERROR_MESSAGE()
    END CATCH
END;

EXEC sp_RecordExamMarks 5, 2, 88;
EXEC sp_RecordExamMarks 5, 999, 85;
SELECT * FROM Marks;

--3  Department Transfer Transaction 
CREATE PROCEDURE sp_TransferStudentDepartment
    @StudentID INT,
    @NewDepartmentID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
        -- Verify department exists
        IF NOT EXISTS (SELECT 1 FROM Departments WHERE DepartmentID = @NewDepartmentID)
        BEGIN
            RAISERROR('Department does not exist',16,1)
        END
        -- Update student's department
        UPDATE Students
        SET DepartmentID = @NewDepartmentID
        WHERE StudentID = @StudentID
        COMMIT TRANSACTION
        PRINT 'Student transferred successfully'
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        PRINT 'Error occurred. Transfer cancelled'
        PRINT ERROR_MESSAGE()
    END CATCH
END;

EXEC sp_TransferStudentDepartment 5, 3;
EXEC sp_TransferStudentDepartment 5, 99;
SELECT StudentID, FirstName, LastName, DepartmentID
FROM Students WHERE StudentID = 5;
