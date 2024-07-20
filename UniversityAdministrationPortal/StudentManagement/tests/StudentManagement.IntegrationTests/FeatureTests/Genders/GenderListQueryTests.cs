namespace StudentManagement.IntegrationTests.FeatureTests.Genders;

using StudentManagement.Domain.Genders.Dtos;
using StudentManagement.SharedTestHelpers.Fakes.Gender;
using StudentManagement.Domain.Genders.Features;
using Domain;
using System.Threading.Tasks;

public class GenderListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_gender_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var genderOne = new FakeGenderBuilder().Build();
        var genderTwo = new FakeGenderBuilder().Build();
        var queryParameters = new GenderParametersDto();

        await testingServiceScope.InsertAsync(genderOne, genderTwo);

        // Act
        var query = new GetGenderList.Query(queryParameters);
        var genders = await testingServiceScope.SendAsync(query);

        // Assert
        genders.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}