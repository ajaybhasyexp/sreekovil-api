USE `heroku_b33cb002ba86bd2`;

DROP PROCEDURE

IF EXISTS `getunpaidstudents`;
	DELIMITER $$

USE `heroku_b33cb002ba86bd2`$$

CREATE PROCEDURE `getunpaidstudents` (
	IN branchid INT
	)

BEGIN
	IF (branchid <> 0) THEN
		SELECT sa.id
			,s.StudentName
			,s.id AS StudentId
			,c.CourseName
			,c.Id AS CourseId
			,cf.Amount
		FROM studentassignments sa
		INNER JOIN Students S ON sa.studentid = s.id
		INNER JOIN coursefees cf ON cf.id = sa.coursefeeid
			AND cf.branchid = branchid
		INNER JOIN courses c ON c.id = cf.courseid
		WHERE ReceiptId IS NULL;
	ELSE
		SELECT sa.id
			,s.StudentName
			,s.id AS StudentId
			,c.CourseName
			,c.Id AS CourseId
			,cf.Amount
		FROM studentassignments sa
		INNER JOIN Students S ON sa.studentid = s.id
		INNER JOIN coursefees cf ON cf.id = sa.coursefeeid
		INNER JOIN courses c ON c.id = cf.courseid
		WHERE ReceiptId IS NULL;
END

IF ;
	end$$ 

DELIMITER ;
