namespace OutdoorsActivityWebApp.Data.Models.Repository.IRepository
{
    public interface IActivityReviewRespository
    {
        public Task<ActivityReview> CreateAsync(ActivityReview obj);
        public Task<ActivityReview> UpdateAsync(ActivityReview obj);
        public Task<bool> DeleteAsync(int id);
        public Task<ActivityReview> GetAsync(int id);
        public Task<IEnumerable<ActivityReview>> GetAllAsync();
        public Task<IEnumerable<ActivityReview>> GetAllFromActivityAsync(int ActivityId);
        public Task<IEnumerable<ActivityReview>> GetAllFromCustomerAsync(string CustomerId);
    }
}
