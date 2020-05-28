using Hahn.ApplicatonProcess.May2020.Data;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using System;
using System.Linq;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.May2020.Data.Models;

namespace Hahn.ApplicatonProcess.May2020.Domain.Services
{
    public class ApplicantService : IApplicant
    {
        private readonly ApiContext _context;
        public ApplicantService(ApiContext context)
        {
            _context = context;
        }
        public int CreateApplicant(BusinessApplicant applicant)
        {
            try
            {
                Applicant newApplicant = new Applicant
                {
                    Name = applicant.Name,
                    FamilyName = applicant.FamilyName,
                    Address = applicant.Address,
                    Age = applicant.Age,
                    CountryOfOrigin = applicant.CountryOfOrigin,
                    EmailAddress = applicant.EmailAddress,
                    Hired = applicant.Hired
                };
                _context.Add(newApplicant);
                _context.SaveChanges();
                return newApplicant.ID;

            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteApplicant(int id)
        {
            try
            {
                var applicant = _context.Applicants.FirstOrDefault(applicant => applicant.ID == id);
                _context.Applicants.Remove(applicant);
            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public BusinessApplicant GetApplicant(int id)
        {
            try
            {
                BusinessApplicant applicant = _context.Applicants.Where(applicant => applicant.ID == id)
               .Select(applicant => new BusinessApplicant
               {
                   Name = applicant.Name,
                   FamilyName = applicant.FamilyName,
                   EmailAddress = applicant.EmailAddress,
                   Address = applicant.Address,
                   CountryOfOrigin = applicant.CountryOfOrigin,
                   Age = applicant.Age,
                   Hired = applicant.Hired
               }).FirstOrDefault();

                return applicant;
            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void UpdateApplicant(int id, BusinessApplicant updatedApplicant)
        {
            try
            {
                var applicant = _context.Applicants.FirstOrDefault(applicant => applicant.ID == id);
                _context.Update(applicant);
            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
