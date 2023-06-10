using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Edigama.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

}





