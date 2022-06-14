namespace CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.AspNetCore.Mvc;

public interface INSubscriptionManager
{
    public  Task<Nutrition_Subscription> GetNSubByID(int id);
    public  Task<Nutrition_Subscription> NewNutritionSubs(int ID, int Duration, int Price, int CoachId);
    public Task<Nutrition_Subscription>  EditNutritionSubs(int ID, int Duration, int Price, int CoachId);
    public  void DeleteNutritionSub(int id);
    public  Task<bool> GetNSubByCoachID(int id, int CoachId);

}
