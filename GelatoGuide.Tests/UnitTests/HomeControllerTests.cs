using GelatoGuide.Areas.Administration.Controllers;
using GelatoGuide.Services.Blog;
using GelatoGuide.Services.Places;
using GelatoGuide.Services.Shop;
using GelatoGuide.Services.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace GelatoGuide.Tests.UnitTests;

[TestClass]
public class HomeControllerTests
{
    [TestMethod]
    public async Task HomeIndex_ShouldReturnViewResult()
    {
        //arrange
        var userServiceMock = new Mock<IUserService>().Object;
        var placeServiceMock = new Mock<IPlaceService>().Object;
        var blofServiceMock = new Mock<IBlogService>().Object;
        var shopServiceMock = new Mock<IShopService>().Object;
        var homeController = new HomeController(userServiceMock, placeServiceMock, blofServiceMock, shopServiceMock);

        //act 
        //var result = await

        //assert
    }
}
