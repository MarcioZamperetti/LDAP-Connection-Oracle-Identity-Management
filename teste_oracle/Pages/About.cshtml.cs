using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace teste_oracle.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string user { get; set; }
        [BindProperty]
        public string passwd { get; set; }
        [BindProperty]
        public string ldap { get; set; }
        public string PostedMessage { get; set; }
        public bool passed { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Validator(user, passwd, ldap);
            //if the login pass is open a page of success
            if (passed)
             return Redirect("sucess");
            else
             return Redirect("error");
        }

        public void OnGet(int id)
        {
        }

        public void Validator(string username, string password, string ldap)
        {
            using (var ldapserver = new LdapConnection(ldap))
            {
                // make sure to pass the username as a distinguishedName
                var dn = string.Format("cn=read-only-admin,dc=example,dc=com", username);

                // passing null for the domain worked for me
                var credentials = new System.Net.NetworkCredential(dn, password, null);
                ldapserver.AuthType = AuthType.Basic;
                try
                {
                    ldapserver.Bind(credentials);
                    passed = true;
                }
                catch (LdapException ex)
                {
                    ErrorModel.error = ex.Message;
                    passed = false;
                }
            }
        }
    }  
}
