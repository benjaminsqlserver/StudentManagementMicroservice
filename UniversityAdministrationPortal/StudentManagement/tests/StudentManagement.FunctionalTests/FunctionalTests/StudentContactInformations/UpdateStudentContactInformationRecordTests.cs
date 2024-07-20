namespace StudentManagement.FunctionalTests.FunctionalTests.StudentContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateStudentContactInformationRecordTests : TestBase
{
    [Fact]
    public async Task put_studentcontactinformation_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var studentContactInformation = new FakeStudentContactInformationBuilder().Build();
        var updatedStudentContactInformationDto = new FakeStudentContactInformationForUpdateDto().Generate();
        await InsertAsync(studentContactInformation);

        // Act
        var route = ApiRoutes.StudentContactInformations.Put(studentContactInformation.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedStudentContactInformationDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}