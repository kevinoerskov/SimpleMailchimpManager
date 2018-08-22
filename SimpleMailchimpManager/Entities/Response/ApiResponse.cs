namespace SimpleMailchimpManager.Entities.Response
{
    internal class ApiResponse<T> : IApiResponse<T>
        where T : class, new()
    {
        private ApiResponse() { }

        public T Response { get; private set; }

        public bool Success { get; private set; }

        public ErrorResponse ErrorResponse { get; private set; }

        internal static IApiResponse<TReponse> CreateSuccess<TReponse>(TReponse response)
            where TReponse : class, new()
        {
            return new ApiResponse<TReponse>
            {
                Response = response,
                Success = true
            };
        }

        internal static IApiResponse<TReponse> CreateFailure<TReponse>(ErrorResponse errorResponse)
            where TReponse : class, new()
        {
            return new ApiResponse<TReponse>
            {
                Success = false,
                ErrorResponse = errorResponse
            };
        }
    }
}