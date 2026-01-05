using System;

namespace Phetolo.Math28.Core.Entities;

public class User
{
    public long Id { get; set; }
    public Guid RowGuid { get; set; }
    public required string Name { get; set; }
    public string Surname { get; set; }=null!;
    public required string Email { get; set; }
    public required string IPAdress { get; set; }
}
