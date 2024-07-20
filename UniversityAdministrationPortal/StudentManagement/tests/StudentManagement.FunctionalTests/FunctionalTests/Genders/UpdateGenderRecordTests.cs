namespace StudentManagement.FunctionalTests.FunctionalTests.Genders;

using StudentManagement.SharedTestHelpers.Fakes.Gender;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateGenderRecordTests : TestBase
{
    [Fact]
    public async Task put_gender_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var gender = new FakeGenderBuilder().Build();
        var updatedGenderDto = new FakeGenderForUpdateDto().Generate();
        await InsertAsync(gender);

        // Act
        var route = ApiRoutes.Genders.Put(gender.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedGenderDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}