namespace StudentManagement.FunctionalTests.FunctionalTests.StudentContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteStudentContactInformationTests : TestBase
{
    [Fact]
    public async Task delete_studentcontactinformation_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var studentContactInformation = new FakeStudentContactInformationBuilder().Build();
        await InsertAsync(studentContactInformation);

        // Act
        var route = ApiRoutes.StudentContactInformations.Delete(studentContactInformation.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}