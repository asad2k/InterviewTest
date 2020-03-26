using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTest.Application.DTO.Person
{
    public class PersonDTO
    {
        public int PersonId { get; set; }

        public string Fullname { get; set; }

        public string GroupName { get; set; }

        public DateTime DateTimeAdded { get; set; }
    }
}
