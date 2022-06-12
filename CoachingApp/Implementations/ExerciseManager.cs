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

        public List<Excercise> GetAllExcercisesForCoach(IdentityApplicationUser User)
        {
            var x = User.Coach.id;
            var excersies=context.Excercises.Where(s=>s.coachID==User.Coach.id).ToList();

            return excersies;
        }
    }
}
