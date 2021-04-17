using Microsoft.AspNetCore.Http;

namespace Lifekeys.Services
{
    public class AuthService
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        /*
        private bool SetSession(string token, string quizId)
        {
            try
            {
                
                if (_accessor.HttpContext.Session.IsAvailable)
                {
                    var sessionDetails = new SessionDetails(token, quizId);
                    _accessor.HttpContext.Session.SetString(token, sessionDetails);
                }
                
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.InnerException);
            }
        }
        */

    }
}
