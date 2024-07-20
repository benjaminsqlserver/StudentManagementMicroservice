namespace StudentManagement.FunctionalTests.TestUtilities;
public class ApiRoutes
{
    public const string Base = "api";
    public const string Health = Base + "/health";

    // new api route marker - do not delete

    public static class Relationships
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/relationships";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/relationships/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/relationships/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/relationships/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/relationships/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/relationships";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/relationships/batch";
    }

    public static class Countries
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/countries";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/countries/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/countries/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/countries/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/countries/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/countries";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/countries/batch";
    }

    public static class Genders
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/genders";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/genders/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/genders/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/genders/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/genders/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/genders";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/genders/batch";
    }

    public static class NextOfKinContactInformations
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/nextOfKinContactInformations";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/nextOfKinContactInformations/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/nextOfKinContactInformations/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/nextOfKinContactInformations/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/nextOfKinContactInformations/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/nextOfKinContactInformations";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/nextOfKinContactInformations/batch";
    }

    public static class StudentNextOfKins
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/studentNextOfKins";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/studentNextOfKins/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/studentNextOfKins/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/studentNextOfKins/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/studentNextOfKins/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/studentNextOfKins";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/studentNextOfKins/batch";
    }

    public static class StudentContactInformations
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/studentContactInformations";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/studentContactInformations/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/studentContactInformations/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/studentContactInformations/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/studentContactInformations/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/studentContactInformations";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/studentContactInformations/batch";
    }

    public static class Students
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/students";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/students/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/students/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/students/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/students/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/students";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/students/batch";
    }
}
