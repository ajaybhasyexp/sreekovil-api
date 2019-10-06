USE `heroku_b33cb002ba86bd2`;
DROP procedure IF EXISTS `getcourses`;

DELIMITER $$
USE `heroku_b33cb002ba86bd2`$$
CREATE PROCEDURE `getcourses` (IN branchid INT)
begin
  IF ( branchid <> 0 ) THEN
    SELECT distinct c.id,c.CourseName,c.Description,c.UpdatedBy,c.UpdatedDate,c.CreatedBy,c.CreatedDate
    FROM   courses c           
           INNER JOIN batchassignments ba
                   ON ba.courseid = c.id
    WHERE  ba.branchid = branchid;
  ELSE
       SELECT distinct c.id,c.CourseName,c.Description,c.UpdatedBy,c.UpdatedDate,c.CreatedBy,c.CreatedDate
    FROM   courses c           
           INNER JOIN batchassignments ba
                   ON ba.courseid = c.id;    
  end IF;
end$$

DELIMITER ;

