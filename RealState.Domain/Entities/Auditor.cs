﻿using RealState.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Domain.Entities
{
    public class Auditor
    {
        public int Id { get; set; }
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public int SSN { get; set; }
        public Nationality Nationality { get; set; }

        //NavProp
        public string UserId { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public List<Request> Requests = new List<Request>();

    }
}
