namespace ECommerce.API.Helper
{
    public class GeneralResultAdd<T> : IGeneralResult<T>
    {
        public string Message { get; set; } 
        public bool isSucces { get; set; }
        public List<string> ValidationError { get; set; } = new List<string>();
    }
    public interface IGeneralResult<T>
    {
        bool isSucces { get; set; }
        string Message { get; set; }
        List<string> ValidationError { get; set; }
    }
}
