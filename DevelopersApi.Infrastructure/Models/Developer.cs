﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopersApi.Infrastructure.Models
{
    public class Developer
    {
        public Developer()
        {
            Skills = new HashSet<Skill>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<Skill> Skills { get; private set; }
    }
}