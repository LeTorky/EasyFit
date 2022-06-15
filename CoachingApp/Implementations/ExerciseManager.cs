using CoachingApp.Interfaces;
using CoachingApp.Models;

namespace CoachingApp.Implementations
{

    public class ExerciseManager : IExerciseManager
    {
        private  IdentityApplicationContext _context;
        public ExerciseManager(IdentityApplicationContext identityApplicationContext)
        {
            _context = identityApplicationContext;    
        }
        public async Task CreateExcercise(Excercise obj)
        {
            if(obj == null)
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            
        }
    }
}
