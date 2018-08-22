namespace SimpleMailchimpManager.Entities.Response
{
    public interface IApiResponse<out T>
        where T : class, new()
    {
        T Response { get; }
        bool Success { get; }
        ErrorResponse ErrorResponse { get; }
    }
}