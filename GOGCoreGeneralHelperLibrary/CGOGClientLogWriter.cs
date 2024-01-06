/*
 * Program Name     :   CGOGClientLogWriter
 * Description      :   This is the common class for logging application exceptions and errors. 
 *                      This can be used to file log application specific informations also.
 * 	
 * Namespace		:	GOGCoreGeneralHelperLibrary
 * Type             :   C# Code File
 * Date             :   28 October 2009
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
 *     1.0          Vinod S.                   28-10-2009                           Created
 *-----------------------------------------------------------------------------------------------
 */

namespace GOGCoreGeneralHelperLibrary
{

    public class CGOGClientLogWriter 
    {
        /// <summary>
        /// Variable to store the Log Folder Path
        /// </summary>
        private string _sLogFolderPath = string.Empty ;

        /// <summary>
        /// Variable to store the Log File Name
        /// </summary>
        private string _sLogFileName = "ErrorLog.txt" ;

        /// <summary>
        /// Variable to store the single ton instance of the Logger object.
        /// </summary>
        private static CGOGClientLogWriter _logWriterInstance = null ;

        /// <summary>
        /// Property to expose the Log Folder Path
        /// </summary>
        public string LogFolderPath
        {
            get { return _sLogFolderPath  ; }
            set 
            { 
                _sLogFolderPath = value ;
                try
                {
                    if ( !System.IO.Directory.Exists( LogFolderPath ))
                            System.IO.Directory.CreateDirectory( LogFolderPath ) ;
                }
                catch ( System.Exception ex )
                {
                }
            }
        }

        /// <summary>
        /// Property to expose the Log Folder Path
        /// </summary>
        public string LogFileName
        {
            get { return _sLogFileName; }
            set { _sLogFileName = value; }
        }

        /// <summary>
        /// Private Constructor function to avoid public creation of CGOGClientLogWriter.
        /// </summary>
        /// <returns> void </returns>
        /// <created by="Vinod Sasi" on="28-10-2009" />
        /// <modified by="" on="" />
        private CGOGClientLogWriter(  )
        {
        }      
        
        /// <summary>
        /// Property to expose the single ton error logger class.
        /// </summary>
        public static CGOGClientLogWriter ClientLogWriter
        {
            get
            {
                if (null == _logWriterInstance)
                {
                    lock (new object())
                    {
                        if (null == _logWriterInstance)
                        {
                            _logWriterInstance = new CGOGClientLogWriter( ) ;
                        }
                    }
                }
                return _logWriterInstance ;
            }
        }      

        /// <summary>
        /// Function to write log by taking Custom Exception Object as input.
        /// </summary>
        /// <param name="oCustomException"></param>
        /// <returns></returns>
        public bool WriteLog( CGOGCustomException oCustomException )
        {
            return WriteLog( "ERR", oCustomException.ErrorString, 
                    oCustomException.ClassName, oCustomException.FunctionName, oCustomException.Line.ToString( ))  ; 
        }

        /// <summary>
        /// Function to write log by taking General Exception Object as input.
        /// </summary>
        /// <param name="oException"></param>
        /// <returns></returns>
        public bool WriteLog( System.Exception exp )
        {
            string Message = exp.Message;
            System.Exception Exp = exp;

            while (Exp.InnerException != null)
            {
                Message += System.Environment.NewLine;
                Exp = Exp.InnerException;
                Message += Exp.Message;
            }
            return WriteLog( "ERR", Message, exp.TargetSite.Name, exp.StackTrace, "" )  ; 
        }

        /// <summary>
        /// Function to write log by taking CGOGErrorLogEntity Object as input.
        /// </summary>
        /// <param name="oGOGErrorLogEntity"></param>
        /// <returns></returns>
        public bool WriteLog( CGOGErrorLogEntity oGOGErrorLogEntity )
        {
            return WriteLog( oGOGErrorLogEntity.LogType.ToString( ), oGOGErrorLogEntity.ErrorMessage, 
                    oGOGErrorLogEntity.ClassName, oGOGErrorLogEntity.FunctionName, oGOGErrorLogEntity.Line.ToString( ))  ; 
        }

        /// <summary>
        /// Function to write log.
        /// </summary>
        /// <param name="sMessage"></param>
        /// <param name="enLogType"></param>
        /// <returns></returns>
        public bool WriteLog(string sMessage,
                string sClass, string sFunction, string sLine )
        {
            return WriteLog(EnumLogType.ERR.ToString(), sMessage, sClass, sFunction, sLine ) ;
        }

        /// <summary>
        /// Function to write log.
        /// </summary>
        /// <param name="sMessage"></param>
        /// <param name="enLogType"></param>
        /// <returns></returns>
        public bool WriteLog( string sMessage, 
                string sClass, string sFunction, string sLine, EnumLogType enLogType )
        {
            return WriteLog( enLogType.ToString(), sMessage, sClass, sFunction, sLine ) ; 
        }
        
        /// <summary>
        /// Function to write log.
        /// </summary>
        /// <param name="sMessage"></param>
        /// <param name="enLogType"></param>
        /// <returns></returns>
        public bool WriteLog(string sMessageType, string sMessage, string sClass, string sFunction, string sLine)
        {
            bool bSuccess = false;
            try
            {
                using (System.IO.StreamWriter Writer = new System.IO.StreamWriter(_sLogFolderPath + @"\" + _sLogFileName, true))
                {
                    Writer.WriteLine("");
                    Writer.WriteLine("<----------------------------------------------------------Log start----------------------------------------------------------------->");
                    Writer.WriteLine("Date    : " + System.DateTime.Now.ToString());
                    Writer.WriteLine(sMessageType + "     : " + sMessage);
                    Writer.WriteLine("Class   : " + sClass);
                    Writer.WriteLine("Function: " + sFunction);
                    Writer.WriteLine("Line    : " + sLine);
                    Writer.WriteLine("<----------------------------------------------------------Log end------------------------------------------------------------------->");
                    Writer.Flush();
                    Writer.Close();
                }
                bSuccess = true;
            }
            catch (System.Exception ex)
            {
            }
            return bSuccess;
        }
    }
}


