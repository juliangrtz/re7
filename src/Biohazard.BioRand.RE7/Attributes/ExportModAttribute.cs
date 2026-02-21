using System;

namespace Biohazard.BioRand.RE7.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportModAttribute : Attribute
    {
        public string FileName { get; init; }
        public string Name { get; init; }
        public string? Description { get; set; }
        public string? Version { get; set; }
        public string? Author { get; set; }
    }
}