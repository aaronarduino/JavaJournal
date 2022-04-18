using System;
using System.Collections.Generic;
using JavaJournal.Enums;

namespace JavaJournal.Models
{
    public class BeanPreset
    {
        public uint BeanPresetId { get; set; }
        public string PresetName { get; set; }
        public string Name { get; set; }
        public string Roastery { get; set; }
        public string Origin { get; set; }
        public BeanTypes BeanType { get; set; }
        public List<Variety> Variety { get; set; }
        public List<Process> Process { get; set; }
        public int Roast { get; set; }
        public int Grind { get; set; }
    }
}
