using SimpleMailchimpManager.Entities.Request;
using SimpleMailchimpManager.Entities.Request.Builder;
using SimpleMailchimpManager.Entities.Response;
using SimpleMailchimpManager.Entities.Response.Subscriber;
using SimpleMailchimpManager.Helper;
using SimpleMailchimpManager.Resource;
using System.Threading.Tasks;

namespace SimpleMailchimpManager.Action
{
    public class ListAction : BaseAction
    {
        private readonly string _listId;

        public ListAction(
            string apiKey,
            string datacenterCode,
            string listId)
            : base(apiKey, datacenterCode)
        {
            _listId = listId;
        }

        public IApiResponse<AddSubscriberResponse> AddSubscriber(string email)
        {
            var subscriber = SubscriberBuilder.Build(email, SubscriberStatus.Subscribed);

            return AddSubscriber(subscriber);
        }

        public IApiResponse<AddSubscriberResponse> AddSubscriber(string email, MergeVar mergeVar)
        {
            var subscriber = SubscriberBuilder.Build(email, SubscriberStatus.Subscribed, mergeVar);

            return AddSubscriber(subscriber);
        }

        private IApiResponse<AddSubscriberResponse> AddSubscriber(Subscriber subscriber)
        {
            var serializedData = JsonHelper.Serialize(subscriber);

            return PostAction<AddSubscriberResponse>(ListSubscriberEndpoint, serializedData);
        }

        public async Task<IApiResponse<AddSubscriberResponse>> AddSubscriberAsync(string email)
        {
            var subscriber = SubscriberBuilder.Build(email, SubscriberStatus.Subscribed);

            return await AddSubscriberAsync(subscriber);
        }

        public async Task<IApiResponse<AddSubscriberResponse>> AddSubscriberAsync(string email, MergeVar mergeVar)
        {
            var subscriber = SubscriberBuilder.Build(email, SubscriberStatus.Subscribed, mergeVar);

            return await AddSubscriberAsync(subscriber);
        }

        private async Task<IApiResponse<AddSubscriberResponse>> AddSubscriberAsync(Subscriber subscriber)
        {
            var serializedData = JsonHelper.Serialize(subscriber);

            return await PostActionAsync<AddSubscriberResponse>(ListSubscriberEndpoint, serializedData);
        }

        public async Task<byte[]> RemoveSubscriber(string email)
        {
            var hashedEmail = email?.Trim().ToLower().ToMd5Hash() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(hashedEmail)) return new byte[0];

            var deleteSubscriberEndpoint = $"{ListSubscriberEndpoint}/{hashedEmail}";

            return await DeleteActionAsync(deleteSubscriberEndpoint);
        }

        private string ListSubscriberEndpoint => $"{BaseEndpoint}/lists/{_listId}/members";
    }
}