namespace StudentManagement.FunctionalTests.FunctionalTests.StudentNextOfKins;

using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetStudentNextOfKinListTests : TestBase
{
    [Fact]
    public async Task get_studentnextofkin_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.StudentNextOfKins.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}