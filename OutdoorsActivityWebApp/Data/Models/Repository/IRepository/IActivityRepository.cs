using Microsoft.AspNetCore.Routing.Constraints;

namespace OutdoorsActivityWebApp.Data.Models.Repository.IRepository
{
    public interface IActivityRepository
    {
        public Task<Activity> CreateAsync(Activity obj);
        public Task<Activity> UpdateAsync(Activity obj);
        public Task<bool> DeleteAsync(int id);
        public Task<Activity> GetAsync(int id);
        public Task<IEnumerable<Activity>> GetAllAsync();
        public Task<IEnumerable<Activity>> GetAllFromInstructorAsync(string InstructorId);

    }
}
