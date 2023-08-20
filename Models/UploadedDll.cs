using System;
using System.Collections.Generic;

namespace dlluploaderwebapi.Models;

public partial class UploadedDll
{
    public int Id { get; set; }

    public byte[]? FileUploaded { get; set; }

    public string? FileName { get; set; }

    public string? FileType { get; set; }

    public int? IsDelete { get; set; }

    public int? UploadedBy { get; set; }

    public DateTime UploadedDate { get; set; }
}
