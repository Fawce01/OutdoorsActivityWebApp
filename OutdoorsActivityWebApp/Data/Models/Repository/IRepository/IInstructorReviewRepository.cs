namespace OutdoorsActivityWebApp.Data.Models.Repository.IRepository
{
    public interface IInstructorReviewRepository
    {
        public Task<InstructorReview> CreateAsync(InstructorReview obj);
        public Task<InstructorReview> UpdateAsync(InstructorReview obj);
        public Task<bool> DeleteAsync(int id);
        public Task<InstructorReview> GetAsync(int id);
        public Task<IEnumerable<InstructorReview>> GetAllAsync();
        public Task<IEnumerable<InstructorReview>> GetAllFromInstructorAsync(string InstructorId);
        public Task<IEnumerable<InstructorReview>> GetAllFromCustomerAsync(string CustomerId);
    }
}
