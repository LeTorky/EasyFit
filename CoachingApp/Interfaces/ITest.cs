
using Microsoft.AspNetCore.Mvc;

namespace CoachingApp.Interfaces
{
    public interface ITest
    {
        Task<ActionResult> TestMethod();
    }
}
