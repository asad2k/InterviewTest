using System;
using System.Collections.Generic;
using System.Text;
using InterviewTest.Application.DTO.Person;

namespace InterviewTest.Application.ViewModels.Persons
{
    public class PersonsListViewModel
    {
        public IEnumerable<PersonDTO> Persons { get; set; }

    }
}
