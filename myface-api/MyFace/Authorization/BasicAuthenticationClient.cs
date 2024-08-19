using System.Security.Principal;

namespace MyFace.Authorization
{
    public class BasicAuthenticationClient : IIdentity
    {
        public string? AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Name { get; set; }
    }
}