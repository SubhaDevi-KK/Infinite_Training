using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Login_WithValidCredentials_ShouldReturnTrue()
        {
            string username = "subha";
            string password = "subha@1929";

            bool result = CustomerAuth.Login(username, password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Login_WithInvalidCredentials_ShouldReturnFalse()
        {

            string username = "testuser";
            string password = "testpass";

            // Act
            bool result = CustomerAuth.Login(username, password);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
