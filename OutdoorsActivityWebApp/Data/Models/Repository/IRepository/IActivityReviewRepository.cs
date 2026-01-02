namespace OutdoorsActivityWebApp.Data.Models.Repository.IRepository
{
    public interface IActivityReviewRepository
    {
        public Task<ActivityReview> CreateAsync(ActivityReview obj);
        public Task<bool> DeleteAsync(int id);
        public Task<ActivityReview> GetAsync(int id);
        public Task<IEnumerable<ActivityReview>> GetAllAsync();
        public Task<IEnumerable<ActivityReview>> GetAllForActivity(int id);
        // todo update
    }
}
