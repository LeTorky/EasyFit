using CoachingApp.Identity;
using CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoachingApp.Implementations
{
    public class ExerciseManager:IExerciseManager
    {
        private IdentityApplicationContext context { get; set; }
        public ExerciseManager(IdentityApplicationContext _context)
        {
            this.context = _context;
        }
        public List<Excercise> GetAllExcercises()
        {
            var GetCoachs = context.Excercises.ToList();
            return GetCoachs;
        }

        public Excercise UpdateExcersise(int id, Excercise excersise)
        {
          

            var OldExcercice = context.Excercises.FirstOrDefault(s => s.id == id);

            if (OldExcercice != null)
            {
                OldExcercice.link = excersise.link;
                OldExcercice.description = excersise.description;

                context.SaveChanges();
            }

              
            return OldExcercice;

        }
        public Excercise DeleteExcercice(int id)
        {
            var ExcerciceData = context.Excercises.Where(e=>e.id==id).SingleOrDefault();
            if(ExcerciceData!=null)
            context.Excercises.Remove(ExcerciceData);

            context.SaveChanges();
            return ExcerciceData;

        }

        public List<Excercise> GetAllExcercisesForCoach(Coach User)
        {
            var x = User;
            var excersies=context.Excercises.Where(s=>s.coachID==User.id).ToList();

            return excersies;
        }
        public Excercise AddExcersise( Excercise excersise, int coachid)
        {


            var OldExcercice = new Excercise();

            if (excersise != null)
            {
                OldExcercice.link = excersise.link;
                OldExcercice.description = excersise.description;
                OldExcercice.coachID = coachid;
                context.Excercises.Add(OldExcercice);
                context.SaveChanges();
            }


            return OldExcercice;

        }


        public List<Workout_Exercise> getExcerciseByWorkOutId(int ClientId, int WorkoutId, int SubId)
        {
            return context.Workout_Exercises.Where(WoEx => WoEx.workoutID == WorkoutId).Include(WoEx => WoEx.excercise).ToList();
        }
    }
}
