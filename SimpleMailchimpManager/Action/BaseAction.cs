using SimpleMailchimpManager.Entities.Response;
using SimpleMailchimpManager.Helper;
using SimpleMailchimpManager.Resource;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleMailchimpManager.Action
{
    public abstract class BaseAction
    {
        private readonly string _apiKey;
        private readonly string _datacenterCode;

        internal BaseAction(
            string apiKey,
            string datacenterCode)
        {
            _apiKey = apiKey;
            _datacenterCode = datacenterCode;
        }

        internal async Task<IApiResponse<TReponseModel>> PostActionAsync<TReponseModel>(
            string endpoint,
            byte[] payload)
            where TReponseModel : class, new()
        {
            var responseByteArray = await UseWebClientAsync(webClient => webClient.UploadDataTaskAsync(
                endpoint,
                HttpMethod.Post.ToString(),
                payload));

            var apiResponse = MapApiResponse<TReponseModel>(responseByteArray);

            return apiResponse;
        }

        internal IApiResponse<TResponseModel> PostAction<TResponseModel>(
            string endpoint,
            byte[] payload)
            where TResponseModel : class, new()
        {
            var responseByteArray = UseWebClient(webClient => webClient.UploadData(
                endpoint,
                HttpMethod.Post.ToString(),
                payload));

            var apiResponse = MapApiResponse<TResponseModel>(responseByteArray);

            return apiResponse;
        }

        internal async Task<byte[]> DeleteActionAsync(string endpoint)
        {
            return await UseWebClientAsync(webClient => webClient.DownloadDataTaskAsync(endpoint));
        }

        internal byte[] DeleteAction(string endpoint)
        {
            return UseWebClient(webClient => webClient.DownloadData(endpoint));
        }

        private static IApiResponse<TResponseModel> MapApiResponse<TResponseModel>(byte[] data)
            where TResponseModel : class, new()
        {
            var responseModel = JsonHelper.DeserializeTo<TResponseModel>(data);
            var apiResponse = ApiResponse<TResponseModel>.CreateSuccess(responseModel);

            return apiResponse;
        }

        private async Task<T> UseWebClientAsync<T>(Func<WebClient, Task<T>> action)
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = ContentType.ApplicationJson;
                webClient.Headers[HttpRequestHeader.Authorization] = AuthorizationHeader;
                return await action(webClient);
            }
        }

        private T UseWebClient<T>(Func<WebClient, T> action)
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = ContentType.ApplicationJson;
                webClient.Headers[HttpRequestHeader.Authorization] = AuthorizationHeader;
                return action(webClient);
            }
        }

        private string AuthorizationHeader => $"apiKey {_apiKey}";
        internal string BaseEndpoint => $"https://{_datacenterCode}.api.mailchimp.com/3.0";
    }
}