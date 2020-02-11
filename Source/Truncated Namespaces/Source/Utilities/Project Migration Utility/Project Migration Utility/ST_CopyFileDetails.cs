using System;

namespace ProjectMigrationUtility
{
    public struct ST_CopyFileDetails
    {

        String OriginalURI;
        String NewURI;

        // Constructor
        public ST_CopyFileDetails(String FromURI, String ToURI)
        {
            OriginalURI = FromURI;
            NewURI = ToURI;
        }

    }
}