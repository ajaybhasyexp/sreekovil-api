USE `heroku_b33cb002ba86bd2`;

DROP PROCEDURE

IF EXISTS `getfeestructureforbranchcourse`;
	DELIMITER $$

USE `heroku_b33cb002ba86bd2`$$

CREATE PROCEDURE `getfeestructureforbranchcourse` (
	IN branchid INT
	,IN courseid INT
	)

BEGIN
	IF (branchid <> 0) THEN
		SELECT DISTINCT cf.*
		FROM coursefees cf
		INNER JOIN courses c ON cf.CourseId = c.id
        INNER JOIN branchs b ON cf.branchid = b.id
		WHERE cf.branchid = branchid
			AND cf.courseid = courseid;
	ELSE
		SELECT DISTINCT cf.*
		FROM coursefees cf
		INNER JOIN courses c ON cf.CourseId = c.id        
		WHERE  cf.courseid = courseid;
END

IF ;
	end$$ 

DELIMITER ;
