USE `heroku_b33cb002ba86bd2`;

DROP PROCEDURE

IF EXISTS `getusers`;
	DELIMITER $$

USE `heroku_b33cb002ba86bd2`$$

CREATE PROCEDURE `getusers` (IN branchid INT)

BEGIN
	IF (branchid <> 0) THEN
		SELECT u.*,b.branchname,ur.role
		FROM users u
		INNER JOIN userroles ur ON u.userroleid = ur.id
		INNER JOIN branchs b ON u.branchid = b.id
		WHERE u.branchid = branchid;
	ELSE
		SELECT u.*,b.branchname,ur.role
		FROM users u
		INNER JOIN userroles ur ON u.userroleid = ur.id
		INNER JOIN branchs b ON u.branchid = b.id;
END

IF ;
	end$$ 

DELIMITER ;
