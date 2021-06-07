using Raven.TestDriver;
using Xunit;

namespace RavenTests
{
    public class RavenTests : RavenTestDriver
    {
        [Fact]
        public void ExpectNullUser()
        {
            using var store = GetDocumentStore();

            using var session = store.OpenSession();

            string nullId = null;
            var user1 = session.Load<User>(nullId);
            Assert.Null(user1);

            var user2 = session.Load<User>("");
            Assert.Null(user2);
        }
    }

    public class User
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyId { get; set; }
    }

    public class Company
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
