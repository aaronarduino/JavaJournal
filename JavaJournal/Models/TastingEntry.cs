using System;

namespace JavaJournal.Models
{
    public class TastingEntry
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public BeanPreset BeanPreset { get; set; }
    }
}
