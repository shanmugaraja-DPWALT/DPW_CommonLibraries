/*
 * Program Name     :   
 * Description      :   This file defines types like enums and structures used in GOGCoreGeneralHelperLibrary namespace.
 * 	
 * Namespace		:	GOGCoreGeneralHelperLibrary
 * Type             :   C# Code File
 * Date             :   31 October 2009
 * Tables Used      :   Nill
 *
 * @author          :   Vinod Sasi
 * @version         :   1.0
 * @Note            :   
 *-----------------------------------------------------------------------------------------------
 *                       Modification Log
 *-----------------------------------------------------------------------------------------------
 *     Ver No:      Author		               Date           Function				Description
 *-----------------------------------------------------------------------------------------------
 *     1.0          Vinod Sasi.                31-10-2009                           Created
 *-----------------------------------------------------------------------------------------------
 */

namespace GOGCoreGeneralHelperLibrary
{
    /// <summary>
    /// This is the enumeration to store the log type.
    /// Log type can be ERR - Error, WAR - Warning , or INF - Information 
    /// UND - Undefined
    /// </summary>
    public enum EnumLogType 
    {
        UND  = 0 ,
        INF  = 1 ,
        WAR  = 2 ,
        ERR  = 3 
    } ;

    /// <summary>
    /// Enumeration to define the Exception type.
    /// </summary>
    public enum EnumExceptionTypes
    {
        NOTSET                = 0 ,
        INVALID_VARIABLE      = 1 ,
        MISSING_VARIABLE      = 2 ,
        INVALID_VARIABBLE_TYPE= 3 ,
        INVALID_FORMAT        = 4 ,
        DATALAYER_EXCEPTION   = 5
    } ;
}
