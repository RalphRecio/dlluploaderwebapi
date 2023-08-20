using System;
using System.Collections.Generic;

namespace dlluploaderwebapi.Models;

public partial class Version
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public byte[]? Object { get; set; }

    public string? Number { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedByUserId { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
