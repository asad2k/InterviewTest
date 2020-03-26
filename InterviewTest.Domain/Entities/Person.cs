using System;

namespace InterviewTest.Domain.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Fullname { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public DateTime DateTimeAdded { get; set; }
    }
}