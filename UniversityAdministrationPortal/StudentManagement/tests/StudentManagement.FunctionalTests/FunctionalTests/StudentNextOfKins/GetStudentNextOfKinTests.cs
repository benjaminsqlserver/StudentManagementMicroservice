namespace StudentManagement.FunctionalTests.FunctionalTests.StudentNextOfKins;

using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetStudentNextOfKinTests : TestBase
{
    [Fact]
    public async Task get_studentnextofkin_returns_success_when_entity_exists()
    {
        // Arrange
        var studentNextOfKin = new FakeStudentNextOfKinBuilder().Build();
        await InsertAsync(studentNextOfKin);

        // Act
        var route = ApiRoutes.StudentNextOfKins.GetRecord(studentNextOfKin.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}