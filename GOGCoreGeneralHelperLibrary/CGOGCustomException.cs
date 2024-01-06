/*
 * Program Name     :   CGOGCustomException
 * Description      :   This is the custom exception class used to manage exceptional flow in functions.
 * 	
 * Namespace		:	GOGCoreGeneralHelperLibrary
 * Type             :   C# Code File
 * Date             :   02 November 2009
 * Tables Used      :   Nill
 *
 * @author          :   Vinod Sasi
 * @version         :   1.0
 * @Note            :   
 * 
 *-----------------------------------------------------------------------------------------------
 *                       Modification Log
 *-----------------------------------------------------------------------------------------------
 *     Ver No:      Author		               Date           Function				Description
 *-----------------------------------------------------------------------------------------------
 *     1.0          Vinod Sasi.                02-11-2009                           Created
 *-----------------------------------------------------------------------------------------------
 */

namespace GOGCoreGeneralHelperLibrary
{
    [System.Serializable]
    public class CGOGCustomException : System.Exception, System.Runtime.Serialization.ISerializable
    {
        /// <summary>
        /// Stores the custom error message.
        /// </summary>
        private string _sErrorString = "Function Success." ;
        
        /// <summary>
        /// Stores the function name
        /// </summary>
        private string _sFunctionName = string.Empty ;

        /// <summary>
        /// Stores the Class name
        /// </summary>
        private string _sClassName = string.Empty ;

        /// <summary>
        /// Variable to store the message for the end user.
        /// </summary>
        private string _sUserMessage = string.Empty ;

        /// <summary>
        /// This is the variable to store the line number where the error occured.
        /// </summary>
        private int _nLine = -1 ;

        /// <summary>
        /// Variable to store the Log type
        /// </summary>
        private EnumLogType _enLogType = EnumLogType.ERR ;

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
        /// Provides interface for FunctionName property.        
        /// </summary>
        /// 
        /// <created by="Vinod Sasi" on="29-10-2009" />
        /// <modified by="" on="" />
        public string FunctionName
        {
            get { return _sFunctionName; }
            set { _sFunctionName = value; }
        }

        /// <summary>
        /// Property to expose the end user message
        /// </summary>
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
        /// Provides interface for ErrorString property.        
        /// </summary>
        /// 
        /// <created by="Vinod Sasi" on="29-10-2009" />
        /// <modified by="" on="" />
        public string ErrorString
        {
            get { return _sErrorString  ; }
            set { _sErrorString = value ; }
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

        public CGOGCustomException( )
        {
        }

        /// <summary>
        /// Constructor function for CGOGCustomException class.
        /// </summary>
        ///
        /// <param name="sErrorString" > 
        /// String type parameter to pass the error string. </param>
        /// <param name="enExceptionType">
        /// EnumExceptionTypes type object to store the exception type.
        /// <returns> void </returns>
        /// 
        /// <created by="Vinod Sasi" on="28-10-2009" />
        /// <modified by="" on="" />
        public CGOGCustomException( string sErrorString )
        {
            _sErrorString = sErrorString ;
        }

        /// <summary>
        /// Constructor function for CGOGCustomException
        /// </summary>
        /// <param name="sErrorString"></param>
        /// <param name="sUserMessage"></param>
        /// <param name="enLogType"></param>
        public CGOGCustomException( string sErrorString, string sUserMessage, EnumLogType enLogType )
        {
            _enLogType      = enLogType ;
            _sErrorString   = sErrorString ;
            _sUserMessage   = sUserMessage ;
        }

        /// <summary>
        /// Constructor function for CGOGCustomException
        /// </summary>
        /// <param name="sErrorString"></param>
        /// <param name="sUserMessage"></param>
        public CGOGCustomException( string sErrorString, string sUserMessage )
        {
            _sErrorString = sErrorString;
            _sUserMessage = sUserMessage;
        }

        /// <summary>
        /// Constructor function for CGOGCustomException class.
        /// </summary>
        /// <param name="sErrorString"></param>
        /// <param name="sUserMessage"></param>
        /// <param name="sClassName"></param>
        /// <param name="sFunctionName"></param>
        /// <param name="enLogType"></param>
        public CGOGCustomException(string sErrorString, string sUserMessage, string sClassName, string sFunctionName, EnumLogType enLogType)
        {
            _enLogType = enLogType ;
            _sErrorString = sErrorString ;
            _sUserMessage = sUserMessage ;
            _sClassName = sClassName ;
            _sFunctionName = sFunctionName ;
        }

        /// <summary>
        /// Constructor function for CGOGCustomException class.
        /// </summary>
        /// <param name="sErrorString"></param>
        /// <param name="sUserMessage"></param>
        /// <param name="sClassName"></param>
        /// <param name="sFunctionName"></param>
        public CGOGCustomException(string sErrorString, string sUserMessage, string sClassName, string sFunctionName)
        {
            _sErrorString = sErrorString ;
            _sUserMessage = sUserMessage ;
            _sClassName = sClassName ;
            _sFunctionName = sFunctionName ;
        }       
        
        /// <summary>
        /// Constructor function for CGOGCustomException class.
        /// </summary>
        ///
        /// <param name="sClassName" > 
        /// String type parameter to pass class name. </param>
        /// <param name="sErrorString" > 
        /// String type parameter to pass the error string. </param>
        /// <param name="sFunctionName"> 
        /// String type parameter to pass the function name. </param>
        /// <param param name="nLine">
        /// Int type parameter to pass the line number where the error occured</param>
        /// <param name="enExceptionType">
        /// EnumExceptionTypes type object to store the exception type. </param>
        /// <returns> void </returns>
        /// 
        /// <created by="Vinod Sasi" on="28-10-2009" />
        /// <modified by="" on="" />
        public CGOGCustomException( string sErrorString, 
                string sUserMessage, string sClassName, string sFunctionName, int nLine )
        {
            _sErrorString       = sErrorString ;
            _sUserMessage       = sUserMessage ;
            _sClassName         = sClassName ;
            _sFunctionName      = sFunctionName ;
            _nLine              = nLine ;
        }
    }
}
   