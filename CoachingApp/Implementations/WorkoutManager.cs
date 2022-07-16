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
            return (_context.Workouts.Include(w => w.Workout_Exercises).ThenInclude(w => w.excercise).Where(w => w.coach.id == coachId).ToList());
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

        public List<Workout> getWorkoutByClientSub(int ClientId, int subId)
        {
            return _context.Client_Workout_WSubs.Where(wo => wo.clientID == ClientId && wo.subID == subId).Select(wo => wo.workout).ToList();
        }
        public List<Workout> getWorkoutByClientSubCoach(int CoachId, int ClientId, int subId)
        {
            return _context.Client_Workout_WSubs.Where(wo => wo.subID == subId && wo.workout.coachID == CoachId && wo.clientID == ClientId).Select(wo=>wo.workout).ToList();
        }
        public bool addWorkOutToClientSub(int WorkoutId, int ClientId, int subId, int CoachId, string Notes)
        {
            if (!_context.Workouts.Where(wo => wo.id == WorkoutId && wo.coachID == CoachId).Any())
                return false;
            if (!_context.Client_WSubs.Where(sub => sub.subID == subId && sub.clientID == ClientId && sub.coachID == CoachId).Any())
                return false;
            _context.Client_Workout_WSubs.Add(new Client_Workout_WSub() { clientID = ClientId, workoutID = WorkoutId, subID = subId, date = DateTime.Today });
            _context.SaveChanges();
            return true;
        }
        public bool removeWorkOutFromClientSub(int WorkoutId, int ClientId, int subId, int CoachId)
        {
            if (!_context.Workouts.Where(wo => wo.id == WorkoutId && wo.coachID == CoachId).Any())
                return false;
            var Workout = _context.Client_Workout_WSubs.Where(sub => sub.subID == subId && sub.clientID == ClientId && sub.sub.coachID == CoachId);
            if (!Workout.Any())
                return false;
            _context.Client_Workout_WSubs.Remove(Workout.FirstOrDefault());
            return true;
        }

    }
}
