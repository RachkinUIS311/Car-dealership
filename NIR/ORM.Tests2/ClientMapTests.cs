using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Tests
{
    using FluentNHibernate.Testing;
    using Core;
    using NUnit.Framework;

    [TestFixture]
    internal class ClientMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var client = new Client(1, "89622461234", "Дмитрий", "Антонов", "Игоревич", "М");

            // act & assert
            new PersistenceSpecification<Client>(this.Session)
                .VerifyTheMappings(client);
        }
    }
}
