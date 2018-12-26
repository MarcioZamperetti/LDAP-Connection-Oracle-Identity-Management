using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Threading.Tasks;

namespace teste_oracle
{
    public class Validador
    {
        public bool validar()
        {
            using (var ldap = new LdapConnection("ldap.company.com:3060"))
            {
                string username = "colombia";
                string password = "1234";
                // make sure to pass the username as a distinguishedName
                var dn = string.Format("cn={0},cn=users,dc=company,dc=com", username);

                // passing null for the domain worked for me
                var credentials = new System.Net.NetworkCredential(dn, password, null);
                ldap.AuthType = AuthType.Basic;

                try
                {
                    ldap.Bind(credentials);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
