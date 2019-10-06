using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using COSMO.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class StudentAssignmentService : IStudentAssignmentService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IStudentAssignmentRepository _studentAssignmentRepository { get; set; }

        public IRecieptRepository _recieptRepository { get; set; }

        #endregion

        public StudentAssignmentService(IStudentAssignmentRepository studentAssignmentRepository, IRecieptRepository recieptRepository)
        {
            _studentAssignmentRepository = studentAssignmentRepository;
            _recieptRepository = recieptRepository;

        }

        /// <summary>
        /// Gets a list of students whose fees are not paid.
        /// </summary>
        /// <returns>A list of students.</returns>
        public List<StudentCourse> GetUnpaidStudents(int branchId)
        {
            return _studentAssignmentRepository.GetUnpaidStudents(branchId);
        }

        public List<StudentAssignment> GetAllVM(int branchId)
        {
            return _studentAssignmentRepository.GetAllVM(branchId);
        }

        public StudentAssignment Save(StudentAssignment studentAssignment)
        {
            return _studentAssignmentRepository.Save(studentAssignment);
        }

        public void Delete(StudentAssignment assign)
        {
            _studentAssignmentRepository.Delete(assign);
        }

        public void PayFees(FeePayment feePayment, int branchId)
        {
            var receipt = new Receipt()
            {
                AmountPaid = feePayment.Amount,
                BranchId = branchId,
                CreatedBy = feePayment.UserId,
                UpdatedBy = feePayment.UserId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PaymentMethodId = feePayment.PaymentModeId,
                ReceiptDate = feePayment.ReceiptDate,
                Reference = feePayment.Reference
            };
            receipt = _recieptRepository.Save(receipt);
            var studentAssign = _studentAssignmentRepository.Get(feePayment.StudentAssignmentId);
            studentAssign.ReceiptId = receipt.Id;
            _studentAssignmentRepository.Save(studentAssign);

        }
    }
}
