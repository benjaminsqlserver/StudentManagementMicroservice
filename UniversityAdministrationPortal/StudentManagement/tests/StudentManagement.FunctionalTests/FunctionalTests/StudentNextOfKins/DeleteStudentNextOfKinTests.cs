namespace StudentManagement.FunctionalTests.FunctionalTests.StudentNextOfKins;

using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteStudentNextOfKinTests : TestBase
{
    [Fact]
    public async Task delete_studentnextofkin_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var studentNextOfKin = new FakeStudentNextOfKinBuilder().Build();
        await InsertAsync(studentNextOfKin);

        // Act
        var route = ApiRoutes.StudentNextOfKins.Delete(studentNextOfKin.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}