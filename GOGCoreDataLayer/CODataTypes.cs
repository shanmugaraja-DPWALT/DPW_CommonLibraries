using System;
using System.Collections.Generic;
using System.Text;


namespace GOGCoreDataLayer
{

    public enum EnumDatabaseTypes
    {
        NOTSET              = 0 ,
        MSSQLSERVER         = 1 ,
        MYSQLSERVER         = 2 ,
        ORACLESERVER        = 3 ,
        ODBCDRIVER          = 4 , 
        MSSQLCOMPACTIBLE    = 5 ,
        POSTGRESSQL         = 6 
    }

    public enum EnumDBLayerReturnTypes
    {
        TYPE_VOID         = 0 ,
        TYPE_DATASET      = 1 ,
        TYPE_DATATABLE    = 2 ,
        TYPE_DATAREADER   = 3 ,
        TYPE_DATAADAPTER  = 4 ,
        TYPE_COMMAND      = 5 ,
        TYPE_ROWCOUNT     = 6 ,
        TYPE_OBJECT       = 7
    }

    public enum EnumErrorTypes
    {
        NOTSET                     = 0 ,
        DATABASE_EXCEPTION         = 1 ,
        UNHANDLED_EXCEPTION        = 2 ,
        MISSING_DATABASETYPE       = 3 ,
        MISSING_CONNECTIONSTRING   = 4 ,
        FORMAT_EXCEPTION           = 5 ,
        ERROR_CONNECTIONOBJECT     = 6 ,
        ERROR_TRANSACTIONOBJECT    = 7 ,
        MISSING_TRANSACTIONOBJECT  = 8 ,
        MISSING_CONNECTIONOBJECT   = 9 ,
        SQL_EXCEPTION              = 10
    }
}
