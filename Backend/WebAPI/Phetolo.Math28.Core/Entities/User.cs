using System;

namespace Phetolo.Math28.Core.Entities;

public class User
{
    public required long Id { get; set; }
    public required Guid RowGuid { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string IPAdress { get; set; }

}
