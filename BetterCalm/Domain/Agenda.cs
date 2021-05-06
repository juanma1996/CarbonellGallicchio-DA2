using System;

namespace Domain
{
    public class Agenda
    {
        public int Id { get; set; }
        public Psychologist Psychologist { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public bool IsAvaible { get; set; }
    }
}
