using CoachingApp.DTO;
using CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoachingApp.Implementations
{
    public class WorkoutSetsManager:IWorkoutSetsManager
    {
        private readonly IdentityApplicationContext _context;
        public WorkoutSetsManager(IdentityApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<WorkoutSet> getWorkoutsByCoachID(int cid)
        {
            var sets = _context.WorkoutSets.Where(w => w.coachID == cid).Select(ws=>ws).ToList();
            // or create a Dto object to exclude the navigational properties from sending it through the network
            return sets;
        }

        public async Task<WorkoutSet> addWorkoutSet(WorkoutSet workoutSet)
        {
            await _context.WorkoutSets.AddAsync(workoutSet);
            _context.SaveChanges();
            return workoutSet;
        }

        public bool setExists(int Setid)
        {
            return(_context.WorkoutSets.Any(ws=>ws.id == Setid));
        }
        public bool setExists(string name, int coachid)
        {
            return (_context.WorkoutSets.Any(ws => ws.name == name && ws.coachID == coachid));
        }
       
        public async Task<WorkoutSet> updateWorkoutSet(int Setid, WorkoutSet workoutSet)

        {
            WorkoutSet myWOset = await _context.WorkoutSets.FindAsync(Setid);
            if(myWOset != null)
            {
                myWOset.name = workoutSet.name;
                myWOset.coachID = workoutSet.coachID;//no need for it
                myWOset.Workout_WorkoutSets = workoutSet.Workout_WorkoutSets;
            }
            _context.SaveChanges();   
            return myWOset;
        }

        public async Task<WorkoutSet> deleteWorkoutSet(int Setid)
        {
            var set = await _context.WorkoutSets.FindAsync(Setid);
            _context.Remove(set);
            _context.SaveChanges();
            return set;
        }
        
        public async Task<WorkoutSet> getWorkoutSet(int setid)
        {
            return await _context.WorkoutSets.FindAsync(setid);
        }
        
        public IEnumerable<Client_Workout_WSub> assignWorkoutsToClient(int coachid, int clientid, int subid, IEnumerable<WorkoutWithDateDto> workouts)
        {
            Client_Workout_WSub newClientWorkoutSub;
            List<Client_Workout_WSub> returnList = new();
            foreach(var workout in workouts)
            {
                newClientWorkoutSub = new Client_Workout_WSub();
                newClientWorkoutSub.clientID = clientid;
                newClientWorkoutSub.subID = subid;
                newClientWorkoutSub.workoutID = workout.workout.id;
                newClientWorkoutSub.date = workout.workoutDate;
                _context.Client_Workout_WSubs.Add(newClientWorkoutSub);
                returnList.Add(newClientWorkoutSub);
            }
            _context.SaveChanges();
            return returnList;
        }
    
    }
}
