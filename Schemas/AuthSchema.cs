namespace Lifekeys.Schemas
{
    public class AuthSchema
    {
        public string Token { get; set; }

        public AuthSchema(string token)
        {
            Token = token;
        }
    }
}
