﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Models
{
    public class BusinessApplicant
    {
        public string  Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress{ get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }
    }
}
