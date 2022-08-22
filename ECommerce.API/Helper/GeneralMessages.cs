namespace ECommerce.API.Helper
{
    public class GeneralMessages
    {
        public const string ConstString = "ConstString";
        public Create Create { get; set; } = new Create();
        public ApiName ApiName { get; set; }
        public Update Update { get; set; }
        public Delete Delete { get; set; }
        public ListData ListData { get; set; }
        public ServerError ServerError { get; set; }
        public Already Already { get; set; }
    }
    public class Create
    {
        public string? Success { get; set; }
        public string? NotSuccess { get; set; }
    }
    public class ApiName
    {
        public string Category { get; set; }
        public string Product { get; set; }
        public string Order { get; set; }
        public string Customer { get; set; }
    }
    public class Update
    {
        public string NotExit { get; set; }
        public string Updated { get; set; }
        public string NotUpdated { get; set; }
    }
    public class Delete
    {
        public string Deleted { get; set; }
        public string NotDeleted { get; set; }
    }
    public class ListData
    {
        public string SuccessList { get; set; }
        public string UnSuccessList { get; set; }
    }
    public class ServerError
    {
        public string Error { get; set; }
    }
    public class Already
    {
        public string AlreadyExit { get; set; }
    }
}
