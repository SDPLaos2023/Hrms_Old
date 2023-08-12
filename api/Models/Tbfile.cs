using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbfile
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int? FileSize { get; set; }
        public string Owner { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
