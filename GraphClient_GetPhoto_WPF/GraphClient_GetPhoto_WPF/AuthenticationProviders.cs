using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphClient_GetPhoto_WPF
{
    class AuthenticationProviders
    {
        public static class InteractiveAuthentication
        {
            private static IPublicClientApplication _pca = null;
            private static IPublicClientApplication Pca
            {
                get
                {
                    if ( _pca == null )
                    {
                        _pca = PublicClientApplicationBuilder
                            .Create( AuthSettings.client_id )
                            .WithTenantId( AuthSettings.tenant_id )
                            .WithRedirectUri( AuthSettings.redirect_uri )
                            .Build();
                    }
                    return _pca;
                }
            }

            private static InteractiveAuthenticationProvider _authenticationProvider = null;
            public static InteractiveAuthenticationProvider AuthenticationProvider
            {
                get
                {
                    if ( _authenticationProvider == null )
                    {
                        _authenticationProvider = new InteractiveAuthenticationProvider( Pca, AuthSettings.scopes, AuthSettings.prompt );
                    }
                    return _authenticationProvider;
                }
            }
        }

    }


}



