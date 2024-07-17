using Microsoft.AspNetCore.DataProtection;

namespace TestWebApplication.Models
{
    public class MyCookieService
    {
        private readonly IDataProtector _protector;
        public MyCookieService(IDataProtectionProvider dataProtectionProvider)
        {
            //MyCookieProtector must be a unique string value for each Data Protection Provider
            _protector = dataProtectionProvider.CreateProtector("MyCookieProtector");
        }
        //This method will convert the Plain Data to Encrypted value
        public string Protect(string cookieValue)
        {
            return _protector.Protect(cookieValue);
        }
        //This method will convert the Encrypted Data to Plain value
        public string Unprotect(string protectedCookieValue)
        {
            return _protector.Unprotect(protectedCookieValue);
        }
    }
}
