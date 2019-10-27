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

        public static readonly string GetOfferingsByTempleId = @"Select OfferingName,Price,MaxPerDay,DeityId,
                                                                IsBookable,OfferingCode,o.CreatedBy,o.CreatedDate,
                                                                o.UpdatedBy,o.UpdatedDate,d.DeityName from Offerings as o
                                                                INNER JOIN Deitys as d
                                                                ON o.DeityId = d.Id
                                                                where o.TempleId = {0}";

        public static readonly string GetDeityByDietyId = @"select DeityName,IsMain,Description,TempleId from Deitys Where TempleId = {0}";

        public static readonly string GetOfferingTransactionByFilters = @"SELECT OFT.Name
	                                                                    ,OFT.Remarks
	                                                                    ,OFT.`Date`
	                                                                    ,o.OfferingName
	                                                                    ,ss.StarSignName
	                                                                    ,d.DeityName
                                                                        FROM OfferingTransactions OFT
                                                                        INNER JOIN Offerings o ON OFT.OfferingId = o.Id
                                                                        INNER JOIN Deitys d ON o.DeityId = d.Id
                                                                        INNER JOIN StarSigns ss ON OFT.StarSignId = ss.Id
                                                                        WHERE OFT.TempleId = {0} DATE(OFT.`Date`) BETWEEN '{1}' and '{2}'";
    }
}
