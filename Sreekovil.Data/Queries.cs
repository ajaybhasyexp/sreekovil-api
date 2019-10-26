namespace Sreekovil.Data
{
    /// <summary>
    /// The common file for queries.
    /// </summary>
    public static class Queries
    {
        public static readonly string GetUserById = "Select * from `Users` where UserId = {0}";

        public static readonly string GetUserByUname = @"SELECT u.id, u.email, u.templeid FROM   Users u 
                                                         WHERE  u.email = '{0}' AND u.password = '{1}' ";

        public static readonly string Branch_Save = @"INSERT INTO `branchs` 
                                                    ( 
                                                                `branchname`,
                                                                `branchaddress`,
                                                                `contactperson`,
                                                                `contactnumber`,
                                                                `branchemail`,
                                                                `adminid`,
                                                                `createddate`,
                                                                `updateddate` 
                                                    )
                                                    VALUES
                                                    ('{0}','{1}','{2}','{3}','{4}',{5},
                                                      now(),now());";

        public static readonly string BatchAssignment_get_filtered = @"select ba.id,ba.courseid,c.CourseName AS Course, 
                                                            ba.batchid, b.BatchName AS Batch, ba.Branchid, 
                                                            br.BranchName AS Branch, ba.id from batchassignments ba
                                                            INNER JOIN courses c
                                                            ON ba.courseid = c.id
                                                            INNER JOIN batchs b
                                                            ON ba.batchid = b.id
                                                            INNER JOIN branchs br
                                                            ON ba.Branchid = br.id
                                                        WHERE ba.branchid = {0}";

        public static readonly string BatchAssignment_get = @"select ba.id,ba.courseid,c.CourseName AS Course, 
                                                            ba.batchid, b.BatchName AS Batch, ba.Branchid, 
                                                            br.BranchName AS Branch, ba.id from batchassignments ba
                                                            INNER JOIN courses c
                                                            ON ba.courseid = c.id
                                                            INNER JOIN batchs b
                                                            ON ba.batchid = b.id
                                                            INNER JOIN branchs br
                                                            ON ba.Branchid = br.id";

        public static readonly string BatchAssignmentFetch = @"SELECT * from Batchassignments where CourseId = {0} AND BatchId = {1} AND BranchId={2}";

        public static readonly string GetUnpaidStudents = @"Select DISTINCT s.StudentName, s.Id from studentassignments sa 
                                                            INNER JOIN students s ON s.id = sa.studentid
                                                            where sa.ReceiptId IS null";

        public static readonly string GetTempleByUserId = @"Select * from Users u INNER JOIN Temples t 
                                                            on u.TempleId = t.Id where u.Id = {0}";

        public static readonly string GetOfferingsByTempleId = @"Select o.Id,OfferingName,Price,MaxPerDay,DeityId,o.TempleId,
                                                                IsBookable,OfferingCode,o.CreatedBy,o.CreatedDate,
                                                                o.UpdatedBy,o.UpdatedDate,d.DeityName from Offerings as o
                                                                INNER JOIN Deitys as d
                                                                ON o.DeityId = d.Id
                                                                where o.TempleId = {0}";
    }
}
