using Microsoft.EntityFrameworkCore;
using OutdoorsActivityWebApp.Data.Models.Repository.IRepository;

namespace OutdoorsActivityWebApp.Data.Models.Repository
{
    public class InstructorReviewRepository : IInstructorReviewRepository
    {
        private readonly ApplicationDbContext _db;
        public InstructorReviewRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<InstructorReview> CreateAsync(InstructorReview obj)
        {
            if (obj != null)
            {
                await _db.InstructorReviews.AddAsync(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reviewToDelete = await _db.InstructorReviews.FirstOrDefaultAsync(u => u.Id == id);

            if (reviewToDelete != null)
            {
                _db.InstructorReviews.Remove(reviewToDelete);
                return await _db.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<InstructorReview>> GetAllAsync()
        {
            return await _db.InstructorReviews
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<InstructorReview>> GetAllFromCustomerAsync(string customerId)
        {
            return await _db.InstructorReviews
                .AsNoTracking()
                .Where(u => u.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<InstructorReview>> GetAllFromInstructorAsync(string instructorId)
        {
            return await _db.InstructorReviews
                .AsNoTracking()
                .Where(u => u.InstructorId == instructorId)
                .ToListAsync();
        }

        public async Task<InstructorReview> GetAsync(int id)
        {
            return await _db.InstructorReviews.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<InstructorReview> UpdateAsync(InstructorReview obj)
        {
            var reviewFromDb = await _db.InstructorReviews.FirstOrDefaultAsync(u => u.Id == obj.Id);

            if (reviewFromDb != null)
            {
                reviewFromDb.Title = obj.Title;
                reviewFromDb.Body = obj.Body;
                reviewFromDb.Rating = obj.Rating;
                reviewFromDb.Anon = obj.Anon;

                _db.InstructorReviews.Update(reviewFromDb);
                await _db.SaveChangesAsync();
                return reviewFromDb;
            }
            return obj;
        }
    }
}
