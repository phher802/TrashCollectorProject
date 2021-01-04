using Microsoft.AspNetCore.Mvc;

namespace TrashCollectorInc.ActionFilters
{
    internal class RedicrectToActionResult : IActionResult
    {
        private string v1;
        private string v2;
        private object p;

        public RedicrectToActionResult(string v1, string v2, object p)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.p = p;
        }
    }
}