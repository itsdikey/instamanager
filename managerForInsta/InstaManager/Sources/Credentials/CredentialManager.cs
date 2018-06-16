using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InstaManager.Sources.Credentials
{
    public class CredentialManager
    {

        private const string FileName = "config.ini";

        private static string Protect(string str)
        {
            byte[] entropy = Encoding.ASCII.GetBytes(Assembly.GetExecutingAssembly().FullName);
            byte[] data = Encoding.ASCII.GetBytes(str);
            string protectedData = Convert.ToBase64String(ProtectedData.Protect(data, entropy, DataProtectionScope.CurrentUser));
            return protectedData;
        }

        private static string Unprotect(string str)
        {
            byte[] protectedData = Convert.FromBase64String(str);
            byte[] entropy = Encoding.ASCII.GetBytes(Assembly.GetExecutingAssembly().FullName);
            string data = Encoding.ASCII.GetString(ProtectedData.Unprotect(protectedData, entropy, DataProtectionScope.CurrentUser));
            return data;
        }

        public static bool SaveCredentials(Credential credentials)
        {
            //if (File.Exists(FileName))
            //{
                
            //}
            try
            {
                var encrypted = Protect(credentials.GetStringRepresentation());
                File.WriteAllText(FileName, encrypted);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
       
        }

        public static Credential GetCredentials()
        {
            if (!File.Exists(FileName))
            {
                return Credential.Empty;
            }
            try
            {
              return Credential.FromString(Unprotect(File.ReadAllText(FileName)));
            }
            catch (Exception e)
            {
                return Credential.Empty;
            }

        }
    }

    public class Credential
    {
        public string UserName { get; set; } = "";

        public string Password { get; set; } = "";

        public static Credential Empty = new Credential();

        internal string GetStringRepresentation()
        {
            return UserName + "\n" + Password;
        }

        internal static Credential FromString(string str)
        {
            var parts = str.Split('\n');
            return new Credential()
            {
                Password = parts[1],
                UserName = parts[0]
            };
        }

    }
}
