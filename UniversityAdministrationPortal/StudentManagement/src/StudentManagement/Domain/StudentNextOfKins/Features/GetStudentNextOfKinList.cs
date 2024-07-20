namespace StudentManagement.Domain.StudentNextOfKins.Features;

using StudentManagement.Domain.StudentNextOfKins.Dtos;
using StudentManagement.Domain.StudentNextOfKins.Services;
using StudentManagement.Exceptions;
using StudentManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetStudentNextOfKinList
{
    public sealed record Query(StudentNextOfKinParametersDto QueryParameters) : IRequest<PagedList<StudentNextOfKinDto>>;

    public sealed class Handler(IStudentNextOfKinRepository studentNextOfKinRepository)
        : IRequestHandler<Query, PagedList<StudentNextOfKinDto>>
    {
        public async Task<PagedList<StudentNextOfKinDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = studentNextOfKinRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToStudentNextOfKinDtoQueryable();

            return await PagedList<StudentNextOfKinDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}