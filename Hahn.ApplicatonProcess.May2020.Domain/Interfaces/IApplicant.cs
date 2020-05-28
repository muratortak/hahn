using Hahn.ApplicatonProcess.May2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Interfaces
{
    public interface IApplicant
    {
        BusinessApplicant GetApplicant(int id);
        int CreateApplicant(BusinessApplicant applicant);

        void UpdateApplicant(int id, BusinessApplicant applicant);

        void DeleteApplicant(int id);
    }
}
