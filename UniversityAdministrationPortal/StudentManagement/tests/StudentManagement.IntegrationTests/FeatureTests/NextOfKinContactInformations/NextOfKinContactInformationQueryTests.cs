namespace StudentManagement.IntegrationTests.FeatureTests.NextOfKinContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using StudentManagement.Domain.NextOfKinContactInformations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class NextOfKinContactInformationQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_nextofkincontactinformation_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var nextOfKinContactInformationOne = new FakeNextOfKinContactInformationBuilder().Build();
        await testingServiceScope.InsertAsync(nextOfKinContactInformationOne);

        // Act
        var query = new GetNextOfKinContactInformation.Query(nextOfKinContactInformationOne.Id);
        var nextOfKinContactInformation = await testingServiceScope.SendAsync(query);

        // Assert
        nextOfKinContactInformation.HouseAddress.Should().Be(nextOfKinContactInformationOne.HouseAddress);
        nextOfKinContactInformation.City.Should().Be(nextOfKinContactInformationOne.City);
        nextOfKinContactInformation.State.Should().Be(nextOfKinContactInformationOne.State);
        nextOfKinContactInformation.ZipCode.Should().Be(nextOfKinContactInformationOne.ZipCode);
        nextOfKinContactInformation.CountryID.Should().Be(nextOfKinContactInformationOne.CountryID);
        nextOfKinContactInformation.NextOfKinID.Should().Be(nextOfKinContactInformationOne.NextOfKinID);
    }

    [Fact]
    public async Task get_nextofkincontactinformation_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetNextOfKinContactInformation.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}