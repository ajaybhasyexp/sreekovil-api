USE `heroku_b33cb002ba86bd2`;

DROP PROCEDURE

IF EXISTS `getbatches`;
	DELIMITER $$

USE `heroku_b33cb002ba86bd2`$$

CREATE PROCEDURE `getbatches` (
	IN branchid INT
	,IN courseid INT
	)

BEGIN
	IF (branchid <> 0) THEN
		SELECT DISTINCT b.*
		FROM batchs b
		INNER JOIN batchassignments ba ON ba.batchid = b.id
		WHERE ba.branchid = branchid
			AND ba.courseid = courseid;
	ELSE
		SELECT DISTINCT b.*
		FROM batchs b
		INNER JOIN batchassignments ba ON ba.batchid = b.id
		WHERE ba.courseid = courseid;
END

IF ;
	end$$ 

DELIMITER ;
