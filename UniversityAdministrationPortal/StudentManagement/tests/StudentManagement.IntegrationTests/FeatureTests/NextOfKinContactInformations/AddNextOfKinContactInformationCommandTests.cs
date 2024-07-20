namespace StudentManagement.IntegrationTests.FeatureTests.NextOfKinContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StudentManagement.Domain.NextOfKinContactInformations.Features;

public class AddNextOfKinContactInformationCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_nextofkincontactinformation_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var nextOfKinContactInformationOne = new FakeNextOfKinContactInformationForCreationDto().Generate();

        // Act
        var command = new AddNextOfKinContactInformation.Command(nextOfKinContactInformationOne);
        var nextOfKinContactInformationReturned = await testingServiceScope.SendAsync(command);
        var nextOfKinContactInformationCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.NextOfKinContactInformations
            .FirstOrDefaultAsync(n => n.Id == nextOfKinContactInformationReturned.Id));

        // Assert
        nextOfKinContactInformationReturned.HouseAddress.Should().Be(nextOfKinContactInformationOne.HouseAddress);
        nextOfKinContactInformationReturned.City.Should().Be(nextOfKinContactInformationOne.City);
        nextOfKinContactInformationReturned.State.Should().Be(nextOfKinContactInformationOne.State);
        nextOfKinContactInformationReturned.ZipCode.Should().Be(nextOfKinContactInformationOne.ZipCode);
        nextOfKinContactInformationReturned.CountryID.Should().Be(nextOfKinContactInformationOne.CountryID);
        nextOfKinContactInformationReturned.NextOfKinID.Should().Be(nextOfKinContactInformationOne.NextOfKinID);

        nextOfKinContactInformationCreated.HouseAddress.Should().Be(nextOfKinContactInformationOne.HouseAddress);
        nextOfKinContactInformationCreated.City.Should().Be(nextOfKinContactInformationOne.City);
        nextOfKinContactInformationCreated.State.Should().Be(nextOfKinContactInformationOne.State);
        nextOfKinContactInformationCreated.ZipCode.Should().Be(nextOfKinContactInformationOne.ZipCode);
        nextOfKinContactInformationCreated.CountryID.Should().Be(nextOfKinContactInformationOne.CountryID);
        nextOfKinContactInformationCreated.NextOfKinID.Should().Be(nextOfKinContactInformationOne.NextOfKinID);
    }
}