/*
 * Program Name     :   CGOGErrorEntity
 * Description      :   This the entity class used to store and pass the error/exception details between layers 
 *                      and used for logging operation.
 * 	
 * Namespace		:	GOGCoreGeneralHelperLibrary
 * Type             :   C# Code File
 * Date             :   28 October 2009
 * Tables Used      :   Nill
 *
 * @author          :   Vinod Sasi
 * @version         :   1.0
 * @Note            :   Can add the client id, name space name or the dll name in the entity 
 *                      if needed in future.
 *-----------------------------------------------------------------------------------------------
 *                       Modification Log
 *-----------------------------------------------------------------------------------------------
 *     Ver No:      Author		               Date           Function				Description
 *-----------------------------------------------------------------------------------------------
 *     1.0          Vinod Sasi.                28-10-2009                           Created
 *-----------------------------------------------------------------------------------------------
 */

namespace GOGCoreGeneralHelperLibrary
{
    [System.Serializable]
    public class CGOGErrorLogEntity : System.Exception, System.Runtime.Serialization.ISerializable  
    {
        /// <summary>
        /// This is the variable to store the log type.
        /// </summary>
        private EnumLogType _enLogType = EnumLogType.ERR ;

        /// <summary>
        /// This is the variable to store the error message to log.
        /// </summary>
        private string _sErrorMessage = "Function Success" ;

        /// <summary>
        /// This is the variable to store the error message to be shown to the end user.
        /// </summary>
        private string _sUserMessage = "Function Success" ;

        /// <summary>
        /// This is the variable to store the name of the function where the error occured.
        /// </summary>
        private string _sFunctionName = string.Empty ;

        /// <summary>
        /// This is the variable to store the name of the class where the error occured. 
        /// </summary>
        private string _sClassName = string.Empty ;

        /// <summary>
        /// This is the variable to store the line number where the error occured.
        /// </summary>
        private int _nLine = -1 ;

        /// <summary>
        /// Provides interface for ErrorMessage property.        
        /// </summary>
        /// 
        /// <created by="Vinod Sasi" on="29-10-2009" />
        /// <modified by="" on="" />
        public string ErrorMessage 
        {
            get { return _sErrorMessage  ; }
            set { _sErrorMessage = value ; }
        }

        /// <summary>
        /// Provides interface for UserMessage property.        
        /// </summary>
        /// 
        /// <created by="Vinod Sasi" on="29-10-2009" />
        /// <modified by="" on="" />
        public string UserMessage
        {
            get { return _sUserMessage  ; }
            set { _sUserMessage = value ; }
        }

        /// <summary>
        /// Provides interface for ClassName property.        
        /// </summary>
        /// 
        /// <created by="Vinod Sasi" on="29-10-2009" />
        /// <modified by="" on="" />
        public string ClassName
        {
            get { return _sClassName  ; }
            set { _sClassName = value ; }
        }

        /// <summary>
        /// Provides interface for FunctionName property.        
        /// </summary>
        /// 
        /// <created by="Vinod Sasi" on="29-10-2009" />
        /// <modified by="" on="" />
        public string FunctionName 
        {
            get { return _sFunctionName  ; }
            set { _sFunctionName = value ; }
        }

        /// <summary>
        /// Provides interface for Line property.        
        /// </summary>
        /// 
        /// <created by="Vinod Sasi" on="29-10-2009" />
        /// <modified by="" on="" />
        public int Line
        {
            get { return _nLine  ; }
            set { _nLine = value ; }
        }

        /// <summary>
        /// Provides interface for Log Type property.        
        /// </summary>
        /// 
        /// <created by="Vinod Sasi" on="29-10-2009" />
        /// <modified by="" on="" />
        public EnumLogType LogType
        {
            get { return _enLogType  ; }
            set { _enLogType = value ; }
        }

        /// <summary>
        /// Constructor function for CGOGErrorEntity class.
        /// </summary>
        ///
        /// <param name="sErrorString" > 
        /// String type parameter to pass the error string. </param>
        /// <param name="sUserMessage" > 
        /// String type parameter to pass the user message. </param>
        /// <param name="enLogType">
        /// EnumLogType type parameter to pass the message type, is it a warning,
        /// error message or an informative message </param>
        /// <returns> void </returns>
        /// 
        /// <created by="Vinod Sasi" on="28-10-2009" />
        /// <modified by="" on="" />
        public CGOGErrorLogEntity(string sErrorString, string sUserMessage, EnumLogType enLogType)
        {
            _sErrorMessage  = sErrorString ;
            _sUserMessage   = sUserMessage ;
            _enLogType      = enLogType ;
        }

        /// <summary>
        /// Constructor function for CGOGErrorEntity class.
        /// </summary>
        ///
        /// <param name="sErrorString" > 
        /// String type parameter to pass the error string. </param>
        /// <param name="sUserMessage" > 
        /// String type parameter to pass the user message. </param>
        /// <returns> void </returns>
        /// 
        /// <created by="Vinod Sasi" on="28-10-2009" />
        /// <modified by="" on="" />
        public CGOGErrorLogEntity( string sErrorString, string sUserMessage )
        {
            _sErrorMessage = sErrorString;
            _sUserMessage = sUserMessage;
            _enLogType = EnumLogType.ERR ;
        }

        /// <summary>
        /// Constructor function for CGOGErrorEntity class.
        /// </summary>
        ///
        /// <param name="sClassName" > 
        /// String type parameter to pass class name. </param>
        /// <param name="sErrorString" > 
        /// String type parameter to pass the error string. </param>
        /// <param name="sUserMessage" > 
        /// String type parameter to pass the user message. </param>
        /// <param name="sFunctionName"> 
        /// String type parameter to pass the function name. </param>
        /// <param param name="nLine">
        /// Int type parameter to pass the line number where the error occured</param>
        /// <param name="enLogType">
        /// EnumLogType type parameter to pass the message type, is it a warning,
        /// error message or an informative message </param>
        /// <returns> void </returns>
        /// 
        /// <created by="Vinod Sasi" on="28-10-2009" />
        /// <modified by="" on="" />
        public CGOGErrorLogEntity( string sClassName, string sFunctionName, 
                                int nLine, string sErrorString, string sUserMessage, EnumLogType enLogType )  
        {
            _sClassName     = sClassName ;
            _sFunctionName  = sFunctionName ;
            _nLine          = nLine ;
            _sErrorMessage  = sErrorString ;
            _sUserMessage   = sUserMessage ;
            _enLogType      = enLogType ;
        }

        /// <summary>
        /// Constructor function for CGOGErrorEntity class.
        /// </summary>
        /// <param name="sClassName"></param>
        /// <param name="sFunctionName"></param>
        /// <param name="nLine"></param>
        /// <param name="sErrorString"></param>
        /// <param name="sUserMessage"></param>
        /// <param name="enLogType"></param>
        public CGOGErrorLogEntity( string sClassName, 
                    string sFunctionName, int nLine, string sErrorString, string sUserMessage )
        {
            _sClassName = sClassName;
            _sFunctionName = sFunctionName;
            _nLine = nLine;
            _sErrorMessage = sErrorString;
            _sUserMessage = sUserMessage;
        }

        /// <summary>
        /// Constructor function for CGOGErrorEntity class.
        /// </summary>
        ///
        /// <param name="sClassName" > 
        /// String type parameter to pass class name. </param>
        /// <param name="sErrorString" > 
        /// String type parameter to pass the error string. </param>
        /// <param name="sUserMessage" > 
        /// String type parameter to pass the user message. </param>
        /// <param name="sFunctionName"> 
        /// String type parameter to pass the function name. </param>
        /// <param name="nLine">
        /// Int type parameter to pass the line number where the error occured</param>
        /// <param name="enLogType">
        /// EnumLogType type parameter to pass the message type, is it a warning,
        /// error message or an informative message </param>
        /// <returns> void </returns>
        /// 
        /// <created by="Vinod Sasi" on="28-10-2009" />
        /// <modified by="" on="" />
        public CGOGErrorLogEntity( string sClassName, string sFunctionName, 
                    string sErrorString, string sUserMessage, EnumLogType enLogType )
        {
            _sClassName     = sClassName ;
            _sFunctionName  = sFunctionName ;
            _sErrorMessage  = sErrorString ;
            _sUserMessage   = sUserMessage ; 
            _enLogType      = enLogType ;
        }

        /// <summary>
        /// Constructor function for CGOGErrorEntity class.
        /// </summary>
        /// <param name="sClassName"></param>
        /// <param name="sFunctionName"></param>
        /// <param name="sErrorString"></param>
        /// <param name="sUserMessage"></param>
        /// <param name="enLogType"></param>
        public CGOGErrorLogEntity(string sClassName, string sFunctionName, string sErrorString, string sUserMessage )
        {
            _sClassName     = sClassName ;
            _sFunctionName  = sFunctionName ;
            _sErrorMessage  = sErrorString ;
            _sUserMessage   = sUserMessage ;
        }

        /// <summary>
        /// Constructor function for CGOGErrorEntity class.
        /// </summary>
        ///
        /// <param name="oGOGCustomException" > 
        /// CGOGCustomException type parameter to which include 
        /// the ClassName, FunctionName, Line number and error string . </param>
        /// <param name="enLogType">
        /// EnumLogType type parameter to pass the message type, is it a warning,
        /// error message or an informative message </param>
        /// <returns> void </returns>
        /// 
        /// <created by="Vinod Sasi" on="28-10-2009" />
        /// <modified by="" on="" />
        public CGOGErrorLogEntity( CGOGCustomException oGOGCustomException )
        {
            _sClassName     = oGOGCustomException.ClassName ;
            _sFunctionName  = oGOGCustomException.FunctionName ;
            _sErrorMessage  = oGOGCustomException.ErrorString ;
            _nLine          = oGOGCustomException.Line ;
            _sUserMessage   = oGOGCustomException.UserMessage ;
        }

        /// <summary>
        /// Constructor function for CGOGErrorEntity class.
        /// </summary>
        ///
        /// <param name="oGOGCustomException" > 
        /// CGOGCustomException type parameter to which include 
        /// the ClassName, FunctionName, Line number and error string . </param>
        /// <param name="enLogType">
        /// EnumLogType type parameter to pass the message type, is it a warning,
        /// error message or an informative message </param>
        /// <returns> void </returns>
        /// 
        /// <created by="Vinod Sasi" on="28-10-2009" />
        /// <modified by="" on="" />
        public CGOGErrorLogEntity( string sClass, System.Exception oException, string sUserMessage )
        {
            _sClassName = sClass ; 
            _sFunctionName  = oException.TargetSite.Name ;
            _sErrorMessage  = oException.Message ;
            _sUserMessage   = sUserMessage ;
        }

        public CGOGErrorLogEntity( string sClass, System.Exception oException )
        {
            _sClassName = sClass;
            _sFunctionName = oException.TargetSite.Name ;
            _sErrorMessage = oException.Message ;
            _sUserMessage = oException.Message ;
        }
    }
}
