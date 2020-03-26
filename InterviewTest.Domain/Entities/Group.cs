using System.Collections.Generic;

namespace InterviewTest.Domain.Entities
{
    public class Group
    {
        public int GroupId { get; set; }

        public string Name { get; set; }

        public ICollection<Person> Persons { get; private set; }
    }
}