namespace ECommerce.API.Helper
{
    public class GeneralResultList<T> : IGeneralResultlist<T>
    {
        public bool isSuccess { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
    }
    public interface IGeneralResultlist<T>
    {
        bool isSuccess { get; set; }
        T Result { get; set; }
        string Message { get; set; }
    }
}
