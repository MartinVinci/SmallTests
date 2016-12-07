using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace SmallTestsConsole
{
    public static class ManoBranchApiAppServiceExtensions
    {
        public static ManoBranchApi CreateManoBranchApi(this IAppServiceClient client)
        {
            return new ManoBranchApi(client.CreateHandler());
        }

        public static ManoBranchApi CreateManoBranchApi(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new ManoBranchApi(client.CreateHandler(handlers));
        }

        public static ManoBranchApi CreateManoBranchApi(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new ManoBranchApi(uri, client.CreateHandler(handlers));
        }

        public static ManoBranchApi CreateManoBranchApi(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new ManoBranchApi(rootHandler, client.CreateHandler(handlers));
        }
    }
}
