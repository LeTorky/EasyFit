using CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoachingApp.Implementations
{
    public class WorkoutManager : IWorkoutManager
    {
        private readonly IdentityApplicationContext _context;
        public WorkoutManager(IdentityApplicationContext context)
        {
            _context = context;
        }
        public async Task<Workout> addWorkout(Workout workout)
        {
            await _context.Workouts.AddAsync(workout);
            _context.SaveChanges();
            return workout;
        }

        public Workout updateWorkout(int id, Workout workout)
        {
            Workout myWO = _context.Workouts.Where(w => w.id == id).Include(w=>w.Workout_Exercises).FirstOrDefault();
            if (myWO != null)
            {
                myWO.name = workout.name;
                myWO.coachID = workout.coachID;//no need for it
                myWO.notes = workout.notes;
                myWO.Workout_Exercises = workout.Workout_Exercises;
            }
            _context.SaveChanges();
            return myWO;
        }

        public Client_Workout_WSub updateWorkoutStatus(int workoutID, int clientID, int subID, DateTime woDate, int status, string clientNotes)
        {
            Client_Workout_WSub clientWorkoutSub = _context.Client_Workout_WSubs.Where(w => w.workoutID == workoutID && w.clientID == clientID && w.subID == subID).FirstOrDefault();
            if (clientWorkoutSub != null)
            {
                clientWorkoutSub.status = status == 0 ? false : true;
                clientWorkoutSub.clientNotes = clientNotes;
            }
            _context.SaveChanges();
            return clientWorkoutSub;
        }

        public bool workoutExists(int workoutID)
        {
            return _context.Workouts.Any(w=>w.id == workoutID);
        }

        public bool workoutExists(string name, int coachid)
        {
            return (_context.Workouts.Any(w => w.name == name && w.coachID == coachid));
        }
        public List<Workout> getWorkoutsByCoachId(int coachId)
        {
            return (_context.Workouts.Include(w=>w.Workout_Exercises).ThenInclude(w=>w.excercise).Where(w => w.coach.id == coachId).ToList());
        }
        public bool deleteWorkOut(int coachId, int workoutId)
        {
            if (!_context.Client_Workout_WSubs.Where(wo => (wo.workoutID == workoutId) && (wo.workout.coach.id == coachId)).Any()
                && !_context.Workout_WorkoutSets.Where(WoS => WoS.workout.id == workoutId).Any())
            {
                Workout Workout = _context.Workouts.Where(wo => wo.id == workoutId).FirstOrDefault();
                if(Workout != null)
                {
                    _context.Workouts.Remove( Workout );
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }

    }
}
