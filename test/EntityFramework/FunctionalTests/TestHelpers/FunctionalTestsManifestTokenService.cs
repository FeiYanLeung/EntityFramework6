// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace FunctionalTests.TestHelpers
{
    using System.Data.Common;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;

    public class FunctionalTestsManifestTokenService : IManifestTokenService
    {
        private static readonly DefaultManifestTokenService _defaultManifestTokenService = new DefaultManifestTokenService();

        public string GetProviderManifestToken(DbConnection connection)
        {
            return !string.IsNullOrWhiteSpace(connection.Database) // Some negative cases require the provider to fail
                   && connection is SqlConnection
                       ? "2008"
                       : _defaultManifestTokenService.GetProviderManifestToken(connection);
        }
    }
}
