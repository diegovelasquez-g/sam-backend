using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAM.Application.DTOS.Request;
using SAM.Application.Interfaces;
using SAM.Utilities.Static;

namespace SAM.Test.Category
{
    [TestClass]
    public class CategoryApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext _testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();

        }

        [TestMethod]
        public async Task CreateCategory_WhenSendingNullValuesOrEmpty_ValidationErrors()
        {
            using var scope = _scopeFactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<ICategoryApplication>();

            //Arange
            var name = "";
            var description = "";
            var isActive = true;
            var expected = ReplyMessage.MESSAGE_VALIDATE;

            //Act
            var result = await context!.CreateCategory(new CategoryRequestDTO()
            {
                CategoryName = name,
                Description = description,
                IsActive = isActive
            });
            var current = result.Message;

            //Assert
            Assert.AreEqual(expected, current);
        }
    }
}
