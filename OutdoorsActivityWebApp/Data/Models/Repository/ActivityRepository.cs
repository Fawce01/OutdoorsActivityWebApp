using Microsoft.EntityFrameworkCore;
using OutdoorsActivityWebApp.Data.Models.Repository.IRepository;

namespace OutdoorsActivityWebApp.Data.Models.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _db;

        public ActivityRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Activity> CreateAsync(Activity obj)
        {
            if (obj is not null)
            {
                await _db.Activities.AddAsync(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            return new Activity();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var activityToDelete = await _db.Activities
                .Include(a => a.Instructor)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (activityToDelete != null)
            {
                // activity to delete was found
                _db.Activities.Remove(activityToDelete);
                return await _db.SaveChangesAsync() > 0;   
            }
            return false;
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _db.Activities
                .AsNoTracking()
                .Include(a=>a.Instructor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetAllFromInstructorAsync(string instructorId)
        {
            return await _db.Activities
                .AsNoTracking()
                .Where(u => u.InstructorUserId == instructorId)
                .Include(a => a.Instructor)
                .ToListAsync();
        }

        public async Task<Activity> GetAsync(int id)
        {
            var activityFetched = await _db.Activities
                .Include(a => a.Instructor)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (activityFetched != null)
            {
                // activity was fetched successfully
                return activityFetched;
            }
            return new Activity();
        }

        public async Task<Activity> UpdateAsync(Activity obj)
        {
            var activityFromDb = await _db.Activities.FirstOrDefaultAsync(u => u.Id == obj.Id);

            if (activityFromDb != null)
            {
                // activity was fetched from db successfully

                activityFromDb.Title = obj.Title;
                activityFromDb.Desc = obj.Desc;
                activityFromDb.Type = obj.Type;
                activityFromDb.OtherTypeName = obj.OtherTypeName;

                _db.Activities.Update(activityFromDb);
                await _db.SaveChangesAsync();
                return activityFromDb;
            }
            return obj;
        }
    }
}
