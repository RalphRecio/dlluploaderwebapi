﻿using System;
using System.Collections.Generic;

namespace dlluploaderwebapi.Models;

public partial class User
{
    public long Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Type { get; set; }

    public string? Lastname { get; set; }

    public string? Firstname { get; set; }

    public string? Middlename { get; set; }

    public string? Nickname { get; set; }

    public string? EmailAddress { get; set; }

    public string? ContactNumber { get; set; }

    public string? HashCode { get; set; }

    public byte Status { get; set; }

    public byte IsDeactivated { get; set; }

    public string? DeactivateReason { get; set; }

    public byte IsRegistered { get; set; }

    public byte IsVerified { get; set; }

    public int? VerifiedBy { get; set; }

    public DateTime? VerifiedDate { get; set; }

    public long CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? ModifiedByUserId { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
