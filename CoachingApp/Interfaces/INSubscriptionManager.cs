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
    public Task<Client_NSub> NewNutrRequest(int ClientId, int SubId, DateTime date, int CoachId);
    public  Task<Client_NSub> NSubStatusChange(int ClientId, int SubId, DateTime Startdate, int CoachId, bool status, DateTime RequestDate);





}
