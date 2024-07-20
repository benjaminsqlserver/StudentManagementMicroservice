namespace StudentManagement.IntegrationTests.FeatureTests.Countries;

using StudentManagement.SharedTestHelpers.Fakes.Country;
using StudentManagement.Domain.Countries.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteCountryCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_country_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var country = new FakeCountryBuilder().Build();
        await testingServiceScope.InsertAsync(country);

        // Act
        var command = new DeleteCountry.Command(country.Id);
        await testingServiceScope.SendAsync(command);
        var countryResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Countries
                .CountAsync(c => c.Id == country.Id));

        // Assert
        countryResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_country_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteCountry.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_country_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var country = new FakeCountryBuilder().Build();
        await testingServiceScope.InsertAsync(country);

        // Act
        var command = new DeleteCountry.Command(country.Id);
        await testingServiceScope.SendAsync(command);
        var deletedCountry = await testingServiceScope.ExecuteDbContextAsync(db => db.Countries
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == country.Id));

        // Assert
        deletedCountry?.IsDeleted.Should().BeTrue();
    }
}