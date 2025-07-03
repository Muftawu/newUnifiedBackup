using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Shared.Domain.Models;

public class User : IdentityUser
{
    public string? Surname { get; set; }

    public string? OtherNames { get; set; }

    public string? Gender { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? IndexNumber { get; set; }

    public string? CountryOfResidence { get; set; }

    public string? CountryCode { get; set; }

    public byte[]? PassportPicture { get; set; }

    public bool IsProfileVerified { get; set; } = false;

    public UserRoles? UserType { get; set; } 

    public DateTime? DateCreated { get; set; } =  DateTime.Now;

    public DateTime? DateOfBirth { get; set; } = DateTime.Now;

}
