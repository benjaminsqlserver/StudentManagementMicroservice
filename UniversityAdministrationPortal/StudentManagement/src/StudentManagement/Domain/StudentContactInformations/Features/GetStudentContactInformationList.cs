namespace StudentManagement.Domain.StudentContactInformations.Features;

using StudentManagement.Domain.StudentContactInformations.Dtos;
using StudentManagement.Domain.StudentContactInformations.Services;
using StudentManagement.Exceptions;
using StudentManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetStudentContactInformationList
{
    public sealed record Query(StudentContactInformationParametersDto QueryParameters) : IRequest<PagedList<StudentContactInformationDto>>;

    public sealed class Handler(IStudentContactInformationRepository studentContactInformationRepository)
        : IRequestHandler<Query, PagedList<StudentContactInformationDto>>
    {
        public async Task<PagedList<StudentContactInformationDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = studentContactInformationRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToStudentContactInformationDtoQueryable();

            return await PagedList<StudentContactInformationDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}