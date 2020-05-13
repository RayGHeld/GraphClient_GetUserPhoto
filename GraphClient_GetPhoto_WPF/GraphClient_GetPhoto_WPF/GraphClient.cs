using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphClient_GetPhoto_WPF
{
    class GraphClient
    {
        private static GraphServiceClient _serviceClient = null;
        public static GraphServiceClient ServiceClient( IAuthenticationProvider authProvider )
        {
            if ( _serviceClient == null )
            {
                _serviceClient = new GraphServiceClient( authProvider );
            }
            return _serviceClient;
        }
    }
}
