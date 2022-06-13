namespace CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.AspNetCore.Mvc;

public interface INSubscriptionManager
{
    public  Task<Nutrition_Subscription> GetNSubByID(int id);
    public  Task<bool> NewNutritionSubs(Nutrition_Subscription nutrition_Subscription);
    public void EditNutritionSubs(Nutrition_Subscription nutrition_Subscription);
    public  void DeleteNutritionSub(int id);

}
