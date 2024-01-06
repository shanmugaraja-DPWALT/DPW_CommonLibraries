/*
 * Program Name     :   IGOGLogWriter
 * Description      :   This is the interface for all logger helper classes. 
 *                      All log writer concrete classes should implement this interface.
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
    interface IGOGLogWriter
    {
        /// <summary>
        /// Function to write error/message logs in to log file.
        /// </summary>
        ///
        /// <param name="oCustomException"> 
        /// CustomException type parameter containing the exception to be logged. </param>
        /// <returns> Success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="31-10-2009" />
        /// <modified by="" on="" />
        bool WriteLog( CGOGCustomException oCustomException ) ;

        /// <summary>
        /// Function to write error/message logs in to log file.
        /// </summary>
        ///
        /// <param name="oException"> 
        /// Exception type parameter containing the exception to be logged. </param>
        /// <returns> Success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="31-10-2009" />
        /// <modified by="" on="" />
        bool WriteLog( System.Exception oException ) ;

        /// <summary>
        /// Function to write error/message logs in to log file.
        /// </summary>
        ///
        /// <param name="oGOGErrorLogEntity"> 
        /// CGOGErrorEntity type parameter containing the error/message and
        /// other details to be logged. </param>
        /// <returns> Success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="31-10-2009" />
        /// <modified by="" on="" />
        bool WriteLog( CGOGErrorLogEntity oGOGErrorLogEntity ) ;

        /// <summary>
        /// Function to write error/message logs in to log file.
        /// </summary>
        ///
        /// <param name="oCustomException"> 
        /// CustomException type parameter containing the exception to be logged. </param>
        /// <returns> Success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="31-10-2009" />
        /// <modified by="" on="" />
        bool WriteLog( string sMessage, string sClass, string sFunction, string sLine, EnumLogType enLogType ) ;
    }
}
