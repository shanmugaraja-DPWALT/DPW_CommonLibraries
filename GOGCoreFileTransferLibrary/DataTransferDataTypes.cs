
namespace GOGCoreDataTransferLibrary
{

    public enum EnumProtocols
    {
        NOTSET              = 0 ,
        FTP                 = 1 ,
        TCPIP               = 2 ,
        HTTPS               = 3 
    }

    public enum EnumErrorTypes
    {
        NOTSET                     = 0 ,
        UNHANDLED_EXCEPTION        = 2 ,
        MISSING_DATABASETYPE       = 3 ,
        MISSING_CONNECTIONSTRING   = 4 ,
        FORMAT_EXCEPTION           = 5 ,
        ERROR_CONNECTIONOBJECT     = 6 ,
        ERROR_TRANSACTIONOBJECT    = 7 ,
        MISSING_TRANSACTIONOBJECT  = 8 ,
        MISSING_CONNECTIONOBJECT   = 9 ,
    }
}
