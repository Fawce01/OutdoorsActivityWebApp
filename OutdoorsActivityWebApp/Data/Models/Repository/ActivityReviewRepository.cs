using Microsoft.EntityFrameworkCore;
using OutdoorsActivityWebApp.Data.Models.Repository.IRepository;
using System.Runtime.Remoting;

namespace OutdoorsActivityWebApp.Data.Models.Repository
{
    public class ActivityReviewRepository : IActivityReviewRespository
    {
        private readonly ApplicationDbContext _db;
        public ActivityReviewRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ActivityReview> CreateAsync(ActivityReview obj)
        {
            if (obj != null)
            {
                await _db.ActivityReviews.AddAsync(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reviewToDelete = await _db.ActivityReviews.FirstOrDefaultAsync(u => u.Id == id);

            if (reviewToDelete != null)
            {
                _db.ActivityReviews.Remove(reviewToDelete);
                return await _db.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<ActivityReview>> GetAllAsync()
        {
            return await _db.ActivityReviews.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ActivityReview>> GetAllFromActivityAsync(int activityId)
        {
            return await _db.ActivityReviews
                .Where(u=>u.ActivityId == activityId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<ActivityReview>> GetAllFromCustomerAsync(string customerId)
        {
            return await _db.ActivityReviews
                .Where(u => u.CustomerId == customerId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ActivityReview> GetAsync(int id)
        {
            return await _db.ActivityReviews.FirstOrDefaultAsync(u=> u.Id == id);
        }

        public async Task<ActivityReview> UpdateAsync(ActivityReview obj)
        {
            var reviewFromDb = await _db.ActivityReviews.FirstOrDefaultAsync(u => u.Id == obj.Id);

            if (reviewFromDb != null)
            {
                reviewFromDb.Title = obj.Title;
                reviewFromDb.Body = obj.Body;
                reviewFromDb.Rating = obj.Rating;
                reviewFromDb.Anon = obj.Anon;

                _db.ActivityReviews.Update(reviewFromDb);
                await _db.SaveChangesAsync();
                return reviewFromDb;
            }
            return obj;
        }
    }
}
