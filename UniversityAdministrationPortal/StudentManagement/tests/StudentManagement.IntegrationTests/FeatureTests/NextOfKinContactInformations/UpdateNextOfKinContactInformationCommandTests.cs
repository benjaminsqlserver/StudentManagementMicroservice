namespace StudentManagement.IntegrationTests.FeatureTests.NextOfKinContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using StudentManagement.Domain.NextOfKinContactInformations.Dtos;
using StudentManagement.Domain.NextOfKinContactInformations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateNextOfKinContactInformationCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_nextofkincontactinformation_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var nextOfKinContactInformation = new FakeNextOfKinContactInformationBuilder().Build();
        await testingServiceScope.InsertAsync(nextOfKinContactInformation);
        var updatedNextOfKinContactInformationDto = new FakeNextOfKinContactInformationForUpdateDto().Generate();

        // Act
        var command = new UpdateNextOfKinContactInformation.Command(nextOfKinContactInformation.Id, updatedNextOfKinContactInformationDto);
        await testingServiceScope.SendAsync(command);
        var updatedNextOfKinContactInformation = await testingServiceScope
            .ExecuteDbContextAsync(db => db.NextOfKinContactInformations
                .FirstOrDefaultAsync(n => n.Id == nextOfKinContactInformation.Id));

        // Assert
        updatedNextOfKinContactInformation.HouseAddress.Should().Be(updatedNextOfKinContactInformationDto.HouseAddress);
        updatedNextOfKinContactInformation.City.Should().Be(updatedNextOfKinContactInformationDto.City);
        updatedNextOfKinContactInformation.State.Should().Be(updatedNextOfKinContactInformationDto.State);
        updatedNextOfKinContactInformation.ZipCode.Should().Be(updatedNextOfKinContactInformationDto.ZipCode);
        updatedNextOfKinContactInformation.CountryID.Should().Be(updatedNextOfKinContactInformationDto.CountryID);
        updatedNextOfKinContactInformation.NextOfKinID.Should().Be(updatedNextOfKinContactInformationDto.NextOfKinID);
    }
}