using System;
using FluentAssertions;
using Phetolo.Math28.Core.Entities;

namespace Phetolo.Math28.Core.XUnitTest;

public class UserTest
{
    public void Test_PocoModel()
    {
        User user = new User
        {
            Id = 1,
            RowGuid = Guid.NewGuid(),
            Name = "John",
            Surname = "Doe",
            Email = "johndoe@test.com",
            IPAdress = "127.0.0.1"
        };

        user.Id.Should().Be(1);
        user.Name.Should().Be("John");
        user.Surname.Should().Be("Doe");
        user.Email.Should().Be("johndoe@test.com");
        user.IPAdress.Should().Be("127.0.0.1");
    }
}
