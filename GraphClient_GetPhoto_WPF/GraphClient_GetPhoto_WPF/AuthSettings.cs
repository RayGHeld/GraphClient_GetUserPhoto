using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphClient_GetPhoto_WPF
{
    class AuthSettings
    {
        public static String client_id = "<client_id>";
        public static String tenant_id = "<tenant_id>";
        public static String[] scopes = { "https://graph.microsoft.com/.default" };
        public static String redirect_uri = "<redirect_uri>"; // needed for non-confidential client providers
        public static String authority = $"https://login.microsoftonline.com/{tenant_id}";
        public static Prompt? prompt = Prompt.SelectAccount;

    }
}
