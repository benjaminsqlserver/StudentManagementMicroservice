namespace StudentManagement.FunctionalTests.FunctionalTests.StudentNextOfKins;

using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateStudentNextOfKinRecordTests : TestBase
{
    [Fact]
    public async Task put_studentnextofkin_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var studentNextOfKin = new FakeStudentNextOfKinBuilder().Build();
        var updatedStudentNextOfKinDto = new FakeStudentNextOfKinForUpdateDto().Generate();
        await InsertAsync(studentNextOfKin);

        // Act
        var route = ApiRoutes.StudentNextOfKins.Put(studentNextOfKin.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedStudentNextOfKinDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}