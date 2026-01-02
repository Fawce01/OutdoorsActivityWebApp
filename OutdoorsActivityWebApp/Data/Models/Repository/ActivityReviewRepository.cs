using Microsoft.EntityFrameworkCore;
using OutdoorsActivityWebApp.Data.Models.Repository.IRepository;

namespace OutdoorsActivityWebApp.Data.Models.Repository
{
    public class ActivityReviewRepository : IActivityReviewRepository
    {
        private readonly ApplicationDbContext _db;

        public ActivityReviewRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ActivityReview> CreateAsync(ActivityReview obj)
        {
            if (obj == null)
            {
                return obj;
            }

            await _db.Review.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reviewFromDb = _db.Review.FirstOrDefault(u => u.Id == id);

            if (reviewFromDb != null)
            {
                _db.Review.Remove(reviewFromDb);
                return await _db.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<IEnumerable<ActivityReview>> GetAllAsync()
        {
            return await _db.Review
                .OfType<ActivityReview>()
                .Include(ar => ar.Activity)
                .Include(ar => ar.Customer)
                .ToListAsync();
        }

        public async Task<IEnumerable<ActivityReview>> GetAllForActivity(int id)
        {
            return await _db.Review
                .OfType<ActivityReview>()
                .Include(ar => ar.Activity)
                .Include(ar => ar.Customer)
                .Where(u=>u.ActivityId == id)
                .ToListAsync();
        }

        public async Task<ActivityReview> GetAsync(int id)
        {
            var activityFetched = await _db.Review
                .OfType<ActivityReview>()
                .Include(ar => ar.Activity)
                .Include(ar => ar.Customer)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (activityFetched != null)
            {
                // activity review  was fetched successfully
                return activityFetched;
            }
            return new ActivityReview();
        }

        public Task<ActivityReview> UpdateAsync(ActivityReview obj)
        {
            throw new NotImplementedException();
        }
    }
}
