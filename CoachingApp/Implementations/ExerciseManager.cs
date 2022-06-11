using CoachingApp.Interfaces;
using CoachingApp.Models;

namespace CoachingApp.Implementations
{
    public class ExerciseManager:IExerciseManager
    {
        private IdentityApplicationContext context { get; set; }
        public ExerciseManager(IdentityApplicationContext _context)
        {
            this.context = _context;
        }
        public Excercise UpdateExcersise(int id, Excercise excersise)
        {
            var OldExcercice = context.Excercises.Where(e=>e.id==id).SingleOrDefault();

            OldExcercice.coachID = excersise.coachID;
            OldExcercice.link = excersise.link;
            OldExcercice.description = excersise.description;

            context.SaveChanges();
            return OldExcercice;

        }
        public Excercise DeleteExcercice(int id)
        {
            var ExcerciceData = context.Excercises.Where(e=>e.id==id).SingleOrDefault();
            context.Excercises.Remove(ExcerciceData);

            context.SaveChanges();
            return ExcerciceData;

        }
    }
}
