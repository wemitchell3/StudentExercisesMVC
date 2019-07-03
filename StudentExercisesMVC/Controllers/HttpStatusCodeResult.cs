using Microsoft.AspNetCore.Mvc;

namespace StudentExercisesMVC.Controllers
{
    internal class HttpStatusCodeResult : ActionResult
    {
        private object badRequest;

        public HttpStatusCodeResult(object badRequest)
        {
            this.badRequest = badRequest;
        }
    }
}