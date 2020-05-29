using Hahn.ApplicatonProcess.May2020.Data;
using Hahn.ApplicatonProcess.May2020.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Web
{
    public static class ApplicantGenerator
    {
        public static void GenerateApplicant(ApiContext context)
        {
            var applicant = new Applicant
            {
                Name = "Murat",
                FamilyName = "Ortak",
                Address = "Toronto",
                CountryOfOrigin = "Turkey",
                EmailAddress = "mrtortak@email.com",
                Age = 29,
                Hired = true
            };

            context.Applicants.Add(applicant);
            context.SaveChanges();
        }
    }
}
