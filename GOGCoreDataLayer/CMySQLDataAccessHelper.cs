/*
 * Program Name     :   DataAccessHelperImpl
 * Description      :   Used for implementimg database operations
 * 	
 * Namespace		:	GOGCoreDataLayer
 * Type             :   
 * Date             :   8 October 2009
 * Tables Used      :   Nill
 *
 * @author          :   Vinod Sasi
 * @version         :   1.0
 *-----------------------------------------------------------------------------------------------
 *                       Modification Log
 *-----------------------------------------------------------------------------------------------
 *     Ver No:      Author		               Date           Function				Description
 *-----------------------------------------------------------------------------------------------
 *     1.0		    Vinod Sasi                 08-10-2009                           Created	   						  
 *-----------------------------------------------------------------------------------------------
 */

namespace GOGCoreDataLayer
{
    class CMySQLDataAccessHelper : IGOGDataAccessHelper, System.IDisposable
    {
        /// <summary>
        /// declaring a string for getting the error messgae
        /// </summary>
        private string _sErrorString = null;

        /// <summary>
        /// declaring a long variable for getting the error number. Mainly meant for SQL Exceptions
        /// </summary>
        private long _nErrorNumber = 0;

        /// <summary>
        /// declaring enum EnumErrorTypes
        /// </summary>
        private EnumErrorTypes _enCustomErrorType = EnumErrorTypes.NOTSET;
        /// <summary>
        /// <summary>
        /// Declaring connection object
        /// </summary>
        private MySql.Data.MySqlClient.MySqlConnection _oConnection = null;

        /// <summary>
        /// Declaring transaction object
        /// </summary>
        private MySql.Data.MySqlClient.MySqlTransaction _oTransaction = null;

        /// <summary>
        /// creating DatabaseFactoryImpl object
        /// </summary>
        //private IGOGDatabaseFactory _oDataFactory = DatabaseFactoryImpl.CreateObject( ) ;

        /// <summary>
        /// creating DataLayerImpl object
        /// </summary>
        private CDataLayer _oDataLayer = CDataLayer.CreateObject();

        /// <summary>
        /// Stores the Datareader member object. 
        /// Only one datareader can exist in one connection object. 
        /// So the data reader object is maintained as a member variable.
        /// </summary>
        private MySql.Data.MySqlClient.MySqlDataReader _oDataReader = null;

        #region IDataAccessHelper Members

        /// <summary>
        /// Provides interface for ErrorMessage property.        
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public string ErrorString
        {
            get { return _sErrorString; }
        }

        /// <summary>
        /// Provides interface for ErrorNumber property. Meant for handling SQL Exceptions        
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public long ErrorNumber
        {
            get { return _nErrorNumber; }
        }

        /// <summary>
        /// Provides interface for CustomErrorMessage property.        
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns> custom error string </returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public string CustomErrorString
        {
            get
            {
                string sCustomErrorString = null;
                switch (_enCustomErrorType)
                {
                    case EnumErrorTypes.DATABASE_EXCEPTION:
                        sCustomErrorString = "Database exception occured.";
                        break;
                    case EnumErrorTypes.SQL_EXCEPTION:
                        sCustomErrorString = SetErrorString(_nErrorNumber); ;
                        break;
                    case EnumErrorTypes.UNHANDLED_EXCEPTION:
                        sCustomErrorString = "Unhandled exception occured.";
                        break;
                    case EnumErrorTypes.MISSING_DATABASETYPE:
                        sCustomErrorString =
                            "Database type is not set for creating database objects.";
                        break;
                    case EnumErrorTypes.MISSING_CONNECTIONSTRING:
                        sCustomErrorString = "Connection string is not initialized.";
                        break;
                    case EnumErrorTypes.FORMAT_EXCEPTION:
                        sCustomErrorString =
                            "Format of an argument does not meet the parameter specification.";
                        break;
                    case EnumErrorTypes.ERROR_CONNECTIONOBJECT:
                        sCustomErrorString = "Failed to create connection object.";
                        break;
                    case EnumErrorTypes.ERROR_TRANSACTIONOBJECT:
                        sCustomErrorString = "Failed to create transaction object.";
                        break;
                    case EnumErrorTypes.MISSING_CONNECTIONOBJECT:
                        sCustomErrorString = "Connection object not found.";
                        break;
                    case EnumErrorTypes.MISSING_TRANSACTIONOBJECT:
                        sCustomErrorString = "Transaction object not found.";
                        break;
                    case EnumErrorTypes.NOTSET:
                        sCustomErrorString = "Error Success.";
                        break;
                }
                return sCustomErrorString;
            }
        }


        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="srParamValue">
        ///     String containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi." on="08-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter(string srParamName,
                            string srParamValue, System.Data.ParameterDirection enParamDirection)
        {
            System.Data.Common.DbParameter oDbParameter = null;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter(srParamName, srParamValue);
                if (null == oDbParameter)
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oDbParameter;
        }


        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="srParamValue">
        ///     String containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter(string srParamName,
                            byte[] barParamValue, System.Data.ParameterDirection enParamDirection)
        {
            System.Data.Common.DbParameter oDbParameter = null;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter (srParamName, barParamValue);
                if (null == oDbParameter)
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oDbParameter;
        }

        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="srParamValue">
        ///     Double containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter(string srParamName,
                            float fParamValue, System.Data.ParameterDirection enParamDirection)
        {
            System.Data.Common.DbParameter oDbParameter = null;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter(srParamName, fParamValue);
                if (null == oDbParameter)
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oDbParameter;
        }


        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="srParamValue">
        ///     Double containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter(string srParamName,
                            double dbParamValue, System.Data.ParameterDirection enParamDirection)
        {
            System.Data.Common.DbParameter oDbParameter = null;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter(srParamName, dbParamValue);
                if (null == oDbParameter)
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oDbParameter;
        }

        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="lParamValue">
        ///     Integer containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter(string srParamName,
                            int nParamValue, System.Data.ParameterDirection enParamDirection)
        {
            System.Data.Common.DbParameter oDbParameter = null;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter(srParamName, nParamValue);
                if (null == oDbParameter)
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oDbParameter;
        }

        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="lParamValue">
        ///     Long containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter(string srParamName,
                            long lParamValue, System.Data.ParameterDirection enParamDirection)
        {
            System.Data.Common.DbParameter oDbParameter = null;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter(srParamName, lParamValue);
                if (null == oDbParameter)
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oDbParameter;
        }

        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="bParamValue">
        ///     Boolean containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter(string srParamName,
                            bool bParamValue, System.Data.ParameterDirection enParamDirection)
        {
            System.Data.Common.DbParameter oDbParameter = null;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter(srParamName, bParamValue);
                if (null == oDbParameter)
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oDbParameter;
        }

        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="bParamValue">
        ///     nullable Boolean containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter(string srParamName,
                            bool? bParamValue, System.Data.ParameterDirection enParamDirection)
        {
            System.Data.Common.DbParameter oDbParameter = null;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter(srParamName, bParamValue);
                if (null == oDbParameter)
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oDbParameter;
        }

        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="bParamValue">
        ///     Datetime containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter(string srParamName,
                            System.DateTime dtParamValue, System.Data.ParameterDirection enParamDirection)
        {
            System.Data.Common.DbParameter oDbParameter = null;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter(srParamName, dtParamValue);
                if (null == oDbParameter)
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oDbParameter;
        }

        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="bParamValue">
        ///     Datetime containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter( string srParamName,
                            System.DateTimeOffset dtParamValue, System.Data.ParameterDirection enParamDirection )
        {
            System.Data.Common.DbParameter oDbParameter = null;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter( srParamName, dtParamValue );
                if( null == oDbParameter )
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION );
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch( HCDataLayerException dlEx )
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch( System.Data.Common.DbException dbEx )
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString( );
            }
            catch( System.Exception ex )
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString( );
            }
            return oDbParameter;
        }

        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="deParamValue">
        ///     Decimal containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter(string srParamName,
                       decimal deParamValue, System.Data.ParameterDirection enParamDirection)
        {

            System.Data.Common.DbParameter oDbParameter = null;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter(srParamName, deParamValue);
                if (null == oDbParameter)
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oDbParameter;
        }

        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="tblParamValue">
        ///     Table object containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        public System.Data.Common.DbParameter CreateDBParameter(string srParamName,
                        System.Data.DataTable tblParamValue, System.Data.ParameterDirection enParamDirection)
        {
           
            System.Data.Common.DbParameter oDbParameter = null ;
            try
            {
                oDbParameter = new MySql.Data.MySqlClient.MySqlParameter(srParamName, tblParamValue);
                if (null == oDbParameter)
                {
                    throw new HCDataLayerException(
                        "Cannot create DB parameter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                oDbParameter.Direction = enParamDirection;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oDbParameter;
        }


        /// <summary>
        /// Executes a query string for handling table operations like
        /// create table, drop table , or alter table etc.
        /// </summary>
        ///
        /// <param name="srQuery">Query string to be executed.</param>
        /// <returns> bool -> Success of the function as boolean.</returns>
        /// 
        /// <created by="Vinod Sasi" on="08-10-2009" />
        /// <modified by="" on="" />
        public bool ExecuteTableOperations(string srQuery)
        {
            System.Data.Common.DbCommand oCommand = null;

            try
            {
                //CHECK THE CONNECTION STATUS AND CREATE CONNECTION IF NOT OPEND YET
                if (!OpenConnection())
                {
                    throw new HCDataLayerException(_sErrorString, _enCustomErrorType);
                }

                oCommand = new MySql.Data.MySqlClient.MySqlCommand();
                if (null == oCommand)
                {
                    throw new HCDataLayerException(
                        "Cannot create command object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }

                oCommand.Connection = _oConnection;

                //SET THE TRANSACTION OBJECT IF TRANSACTION ALLREADY OPEND
                if (null != _oTransaction)
                    oCommand.Transaction = _oTransaction;

                oCommand.CommandText = srQuery;
                oCommand.CommandType = System.Data.CommandType.Text;
                oCommand.ExecuteNonQuery();
                oCommand.Dispose();
                return true;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException dbEx)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = dbEx.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }

            if (null != oCommand) oCommand.Dispose();
            return false;
        }

        /// <summary>
        /// Creates a connection object and opens a connection with the default database.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns> bool -> Success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        public bool OpenConnection()
        {
            try
            {
                // IF CONNECTION ALREADY OPEND RETURN TRUE.
                if (null != _oConnection && System.Data.ConnectionState.Open == _oConnection.State)
                {
                    return true;
                }

                //HANDLE INTERMEDIATE STATES OF CONNECTION OBJECT.
                //THIS STATES ARE RESERVED FOR FUTURE USE. NOT IMPLEMENTED IN .NET VERSION 2.0
                if (null != _oConnection && (
                        System.Data.ConnectionState.Broken == _oConnection.State ||
                        System.Data.ConnectionState.Connecting == _oConnection.State ||
                        System.Data.ConnectionState.Fetching == _oConnection.State ||
                        System.Data.ConnectionState.Executing == _oConnection.State))
                {
                    //DISPOSE CONNECTION FOR THE TIME BEING, THIS CAN BE MODIFIED LATTER
                    //TO HANDLE THESE STAGES EFICIENTLY IN CONNECTION POOL SENARIO.
                    _oConnection.Close();
                    _oConnection.Dispose();
                    _oConnection = null;
                }

                //NORMAL FUNCTION FLOW, CREATE NEW CONNECTION AND PROCEED.
                if (null == _oConnection)
                {
                    _oConnection = new MySql.Data.MySqlClient.MySqlConnection();
                    if (null == _oConnection)
                    {
                        throw new HCDataLayerException(
                            "Cannot create connection object.", EnumErrorTypes.DATABASE_EXCEPTION);
                    }
                }

                //OPEN NEW CONNECTION WITH THE DATABASE USING DEFAULT CONNECTION STRING.
                _oConnection.ConnectionString = _oDataLayer.ConnectionString;
                _oConnection.Open();

                return true;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException exDb)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = exDb.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return false;
        }

        /// <summary>
        /// Creates a connection object and opens connection with a new database.
        /// This function can be used to connect to a different database at runtime.
        /// Internaly this function will free the connection object if its taken from pool.
        /// Else if connection object is created in the same instant then closses the connection.
        /// </summary>
        ///
        /// <param name = "srConnectionString">  Connection string to the new database</param>
        /// <returns>success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        public bool OpenConnection(string srConnectionString)
        {
            try
            {
                // IF CONNECTION ALREADY OPEND RETURN TRUE.
                if (null != _oConnection && System.Data.ConnectionState.Open == _oConnection.State)
                {
                    _oConnection.Close();
                    _oConnection.Dispose();
                    _oConnection = null;
                }

                //HANDLE INTERMEDIATE STATES OF CONNECTION OBJECT.
                //THIS STATES ARE RESERVED FOR FUTURE USE. NOT IMPLEMENTED IN .NET VERSION 2.0
                if (null != _oConnection && (
                        System.Data.ConnectionState.Broken == _oConnection.State ||
                        System.Data.ConnectionState.Connecting == _oConnection.State ||
                        System.Data.ConnectionState.Fetching == _oConnection.State ||
                        System.Data.ConnectionState.Executing == _oConnection.State))
                {
                    //DISPOSE CONNECTION FOR THE TIME BEING, THIS CAN BE MODIFIED LATTER
                    //TO HANDLE THESE STAGES EFICIENTLY IN CONNECTION POOL SENARIO.
                    _oConnection.Close();
                    _oConnection.Dispose();
                    _oConnection = null;
                }

                if (null == _oConnection)
                {
                    _oConnection = new MySql.Data.MySqlClient.MySqlConnection();
                    if (null == _oConnection)
                    {
                        throw new HCDataLayerException(
                            "Cannot create connection object.", EnumErrorTypes.DATABASE_EXCEPTION);
                    }
                }

                _oConnection.ConnectionString = srConnectionString;
                _oConnection.Open();

                return true;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException exDb)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = exDb.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return false;
        }

        /// <summary>
        /// Closes the already opend connection, 
        /// Call this function when u manualy open a database connection.
        /// Internaly this function will free the connection object if its taken from pool.
        /// Else if connection object is created in the same instant then closses the connection.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns>success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        public bool CloseConnection()
        {
            if (null == _oConnection) return true;

            try
            {
                //HANDLE INTERMEDIATE STATES OF CONNECTION OBJECT.
                //THIS STATES ARE RESERVED FOR FUTURE USE. NOT IMPLEMENTED IN .NET VERSION 2.0
                if (null != _oConnection && (
                        System.Data.ConnectionState.Broken == _oConnection.State ||
                        System.Data.ConnectionState.Connecting == _oConnection.State ||
                        System.Data.ConnectionState.Fetching == _oConnection.State ||
                        System.Data.ConnectionState.Executing == _oConnection.State ||
                        System.Data.ConnectionState.Open == _oConnection.State))
                {
                    //DISPOSE CONNECTION FOR THE TIME BEING, THIS CAN BE MODIFIED LATTER
                    //TO HANDLE THESE STAGES EFICIENTLY IN CONNECTION POOL SENARIO.
                    _oConnection.Close();
                }

                //DISPOSE FUNCTION WILL INTERNALY CALL THE CLOSE FUNCTION.
                _oConnection.Dispose();
                _oConnection = null;
                return true;
            }
            catch (System.Data.Common.DbException exDb)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = exDb.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return false;
        }

        /// <summary>
        /// Function commits the changes occured in the scope of the connection to the database.
        /// User has to call this function must, if he/she opens a transaction.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns>success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        public bool OpenTransaction()
        {
            try
            {
                //IF TRANSACTION ALREADY OPEND - RETURN TRUE
                if (null != _oTransaction) return true;

                //CHECK THE CONNECTION STATUS AND CREATE CONNECTION IF NOT OPEND YET.
                if (!OpenConnection())
                {
                    throw new HCDataLayerException(_sErrorString, _enCustomErrorType);
                }

                _oTransaction = _oConnection.BeginTransaction();

                return true;
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException exDb)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = exDb.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return false;
        }

        /// <summary>
        /// Function commits the changes occured in the scope of the connection to the database.
        /// User has to call this function must, if he/she opens a transaction.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns>success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        public bool CommitTransaction()
        {
            try
            {
                if (null == _oTransaction)
                {
                    throw new HCDataLayerException(
                        "Transaction not opened for the connection.",
                        EnumErrorTypes.MISSING_TRANSACTIONOBJECT);
                }
                _oTransaction.Commit();
                _oTransaction.Dispose();
                _oTransaction = null;
                return true;
            }
            catch (System.Data.Common.DbException exDb)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = exDb.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return false;
        }

        /// <summary>
        /// Function rollbacks the changes done with in the scope of transaction.
        /// Call this function in case of any logical error in between a trasaction.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns>success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        public bool RollbackTransaction()
        {
            try
            {

                if (null == _oTransaction)
                {
                    throw new HCDataLayerException(
                        "Transaction not opened for the connection.",
                        EnumErrorTypes.ERROR_TRANSACTIONOBJECT);
                }
                _oTransaction.Rollback();
                _oTransaction.Dispose();
                _oTransaction = null;
                return true;
            }
            catch (System.Data.Common.DbException exDb)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = exDb.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return false;
        }

        /// <summary>
        /// Executes a standard query for Add, Update, Delete and Select queries.
        /// Used to execute normal query strings.
        /// User can specify the return type he/she expects from the query.
        /// 
        /// If user specifies ROWCOUNT as return type, function will execute, ExecuteNonQuery.
        /// If user specifies Object as return type, function will execute, ExecuteScalar.
        /// If user specifies any selection objects as return type, function will execute selection as per the return type.
        /// </summary>
        ///
        /// <param name="srQuery">Query string to be executed.</param>
        /// <param name="enReturnType">Enum type to specify how the result should be returned.</param>
        /// 
        /// <returns>  If success it returns reader or adapter or dataset or datatable or command object.
        ///             otherwise null </returns>        
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        public object ExecuteQuery(string srQuery, EnumDBLayerReturnTypes enReturnType)
        {
            _sErrorString = "Error Success" ;
            _enCustomErrorType = EnumErrorTypes.NOTSET ;

            object oResult = null;
            MySql.Data.MySqlClient.MySqlCommand oCommand = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                if (null == oCommand)
                {
                    throw new HCDataLayerException(
                        "Cannot create command object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }

                System.Data.DataSet ds = new System.Data.DataSet();

                //CHECK THE CONNECTION STATUS AND CREATE CONNECTION IF NOT OPEND YET
                if (!OpenConnection())
                {
                    throw new HCDataLayerException(_sErrorString, _enCustomErrorType);
                }

                oCommand.CommandText = srQuery;
                oCommand.Connection = _oConnection;
                oCommand.Transaction = _oTransaction;
                oCommand.CommandType = System.Data.CommandType.Text;

                oResult = ExecuteCommand(oCommand, enReturnType);
            }
            catch (HCDataLayerException dlEx)
            {
                _sErrorString = dlEx.ErrorString;
                _enCustomErrorType = dlEx.ErrorType;
            }
            return oResult;
        }

        /// <summary>
        /// Executes a procedure for Add, Update, Delete, Select or a business logic implementation.
        /// User can specify the return type he/she expects from the procedure.
        /// 
        /// If user specifies ROWCOUNT as return type, function will execute, ExecuteNonQuery.
        /// If user specifies Object as return type, function will execute, ExecuteScalar.
        /// If user specifies any selection objects as return type, function will execute selection as per the return type.
        /// </summary>
        ///
        /// <param name="srProcedureName">StoredProcedure to be executed.</param>
        /// <param name="enReturnType">Enum type to specify how the result should be returned.</param>
        /// <param name="alInputParams">List of input parameters to set to the storedprocedure.</param>     
        /// <returns>  If success it returns reader or adapter or dataset or datatable or command object.
        ///             otherwise null </returns>
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        public object ExecuteProcedure(string srProcedureName,
                        EnumDBLayerReturnTypes enReturnType, System.Collections.ArrayList alInputParams)
        {
            _sErrorString = "Error Success" ;
            _enCustomErrorType = EnumErrorTypes.NOTSET ;

            object oResult = null;
            MySql.Data.MySqlClient.MySqlCommand oCommand = new MySql.Data.MySqlClient.MySqlCommand();

            try
            {
                if (null == oCommand)
                {
                    throw new HCDataLayerException(
                        "Cannot create command object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }

                System.Data.Common.DbDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter();
                System.Data.DataSet ds = new System.Data.DataSet();

                //CHECK THE CONNECTION STATUS AND CREATE CONNECTION IF NOT OPEND YET
                if (!OpenConnection())
                {
                    throw new HCDataLayerException(_sErrorString, _enCustomErrorType);
                }

                oCommand.CommandText = srProcedureName;
                oCommand.Connection = _oConnection;
                oCommand.Transaction = _oTransaction;
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;

                if (null != alInputParams)
                {
                    foreach (System.Data.Common.DbParameter oParam in alInputParams)
                    {
                        oCommand.Parameters.Add(oParam);
                    }
                }
                oResult = ExecuteCommand(oCommand, enReturnType);
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }

            return oResult;
        }

        /// <summary>
        /// Executes a procedure for Add, Update, Delete, Select or a business logic implementation.
        /// User can specify the return type he/she expects from the procedure.
        /// 
        /// If user specifies ROWCOUNT as return type, function will execute, ExecuteNonQuery.
        /// If user specifies Object as return type, function will execute, ExecuteScalar.
        /// If user specifies any selection objects as return type, function will execute selection as per the return type.
        /// </summary>
        ///
        /// <param name="srProcedureName">StoredProcedure to be executed.</param>
        /// <param name="enReturnType">Enum type to specify how the result should be returned.</param>
        /// <param name="alInputParams">List of input parameters to set to the storedprocedure.</param>  
        /// <param name="alOutputParams">List of output parameters to get result from the storedprocedure.</param>
        /// <returns>  If success it returns reader or adapter or dataset or datatable or command object.
        ///             otherwise null </returns>
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        public object ExecuteProcedure(
                        string srProcedureName, EnumDBLayerReturnTypes enReturnType,
                            System.Collections.ArrayList alInputParams, out System.Collections.ArrayList alOutputParams)
        {
            _sErrorString = "Error Success" ;
            _enCustomErrorType = EnumErrorTypes.NOTSET ;
            
            object oResult = null;
            alOutputParams = null;
            MySql.Data.MySqlClient.MySqlCommand oCommand = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                if (null == oCommand)
                {
                    throw new HCDataLayerException(
                        "Cannot create command object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }

                System.Data.DataSet ds = new System.Data.DataSet();

                //CHECK THE CONNECTION STATUS AND CREATE CONNECTION IF NOT OPEND YET
                if (!OpenConnection())
                {
                    throw new HCDataLayerException(_sErrorString, _enCustomErrorType);
                }

                oCommand.CommandText = srProcedureName;
                oCommand.Connection = _oConnection;
                oCommand.Transaction = _oTransaction;
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;

                if (null != alInputParams)
                {
                    foreach (System.Data.Common.DbParameter oParam in alInputParams)
                    {
                        oCommand.Parameters.Add(oParam);
                    }
                }
                oResult = ExecuteCommand(oCommand, enReturnType);

                if (null == oResult)
                {
                    throw new HCDataLayerException(_sErrorString, _enCustomErrorType);
                }

                System.Data.Common.DbDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter();
                if (null == da)
                {
                    throw new HCDataLayerException(
                        "Cannot create data adapter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                }
                da.SelectCommand = oCommand;
                alOutputParams = new System.Collections.ArrayList(da.SelectCommand.Parameters);
            }
            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
            }
            catch (System.Data.Common.DbException exDb)
            {
                _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
                _sErrorString = exDb.ToString();
            }
            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
            }
            return oResult;
        }
        #endregion

        /// <summary>
        /// Executes a command containing query string or stored proceedure and returns the result.
        /// User can specify the return type he/she expects from the procedure.
        /// 
        /// If user specifies ROWCOUNT as return type, function will execute, ExecuteNonQuery.
        /// If user specifies Object as return type, function will execute, ExecuteScalar.
        /// If user specifies any selection objects as return type, function will execute selection as per the return type.
        /// </summary>
        ///
        /// <param name="srProcedureName">StoredProcedure to be executed.</param>
        /// <param name="enReturnType">Enum type to specify how the result should be returned.</param>
        /// <param name="alInputParams">List of input parameters to set to the storedprocedure.</param>  
        /// <param name="alOutputParams">List of output parameters to get result from the storedprocedure.</param>
        /// <returns>  If success it returns reader or adapter or dataset or datatable or command object.
        ///             otherwise null </returns>
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        private object ExecuteCommand(
                MySql.Data.MySqlClient.MySqlCommand oCommand, EnumDBLayerReturnTypes enReturnType)
        {
            _sErrorString = "Error Success" ;
            _enCustomErrorType = EnumErrorTypes.NOTSET ;

            object oResult = null;
            System.Data.Common.DbDataAdapter da = null;
            System.Data.DataSet ds = new System.Data.DataSet();
            try
            {
                switch (enReturnType)
                {
                    case EnumDBLayerReturnTypes.TYPE_VOID:
                        oCommand.ExecuteNonQuery();
                        oResult = -1;
                        break;

                    case EnumDBLayerReturnTypes.TYPE_DATAREADER:
                        if (null != _oDataReader)
                        {
                            _oDataReader.Close();
                            _oDataReader = null;
                        }
                        _oDataReader = oCommand.ExecuteReader();
                        oResult = _oDataReader;
                        break;

                    case EnumDBLayerReturnTypes.TYPE_DATAADAPTER:
                        da = new MySql.Data.MySqlClient.MySqlDataAdapter();
                        if (null == da)
                        {
                            throw new HCDataLayerException(
                                 "Cannot create data adapter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                        }
                        da.SelectCommand = oCommand;
                        oResult = da;
                        break;

                    case EnumDBLayerReturnTypes.TYPE_DATASET:
                        da = new MySql.Data.MySqlClient.MySqlDataAdapter();
                        if (null == da)
                        {
                            throw new HCDataLayerException(
                                "Cannot create data adapter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                        }
                        da.SelectCommand = oCommand;
                        da.Fill(ds);
                        oResult = ds;
                        break;

                    case EnumDBLayerReturnTypes.TYPE_DATATABLE:
                        System.Data.DataTable dt = null;
                        da = new MySql.Data.MySqlClient.MySqlDataAdapter();
                        if (null == da)
                        {
                            throw new HCDataLayerException(
                                "Cannot create data adapter object.", EnumErrorTypes.DATABASE_EXCEPTION);
                        }
                        da.SelectCommand = oCommand;
                        da.Fill(ds);
                        dt = ds.Tables[0];
                        oResult = dt;
                        break;

                    case EnumDBLayerReturnTypes.TYPE_COMMAND:
                        oResult = oCommand;
                        break;

                    case EnumDBLayerReturnTypes.TYPE_ROWCOUNT:
                        oResult = oCommand.ExecuteNonQuery();
                        break;

                    case EnumDBLayerReturnTypes.TYPE_OBJECT:
                        oResult = oCommand.ExecuteScalar();
                        break;
                }
            }

            catch (HCDataLayerException dlEx)
            {
                _enCustomErrorType = dlEx.ErrorType;
                _sErrorString = dlEx.ErrorString;
                _nErrorNumber = 0;
            }

            catch (System.Data.Common.DbException exDb)
            {
                SetDBExceptionNumber(exDb);
                oResult = null;
            }
            catch (System.FormatException ftEx)
            {
                _enCustomErrorType = EnumErrorTypes.FORMAT_EXCEPTION;
                _sErrorString = ftEx.ToString();
                _nErrorNumber = 0;
                oResult = null;
            }

            catch (System.Exception ex)
            {
                _enCustomErrorType = EnumErrorTypes.UNHANDLED_EXCEPTION;
                _sErrorString = ex.ToString();
                _nErrorNumber = 0;
                oResult = null;
            }
            return oResult;
        }

        /// <summary>
        /// function for getting the SQL DB Exception number.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns> void </returns>
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        public void SetDBExceptionNumber(System.Data.Common.DbException exDb)
        {

            //switch (_oDataLayer.DataBaseType)
            //{
            //    case EnumDatabaseTypes.MSSQLSERVER:
            MySql.Data.MySqlClient.MySqlException ex = exDb as MySql.Data.MySqlClient.MySqlException;
            if (null != ex) _nErrorNumber = ex.Number;
            _enCustomErrorType = EnumErrorTypes.SQL_EXCEPTION;
            //        break;
            //    //Error number handling is done only for SQL Server
            //        //For all other DB types the error number is set as 0
            //    case EnumDatabaseTypes.ORACLESERVER:
            //        System.Data.OracleClient.OracleException exOracle =
            //                exDb as System.Data.OracleClient.OracleException;
            //        if (null != exOracle) _nErrorNumber = 0;
            //        _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
            //        break;

            //    case EnumDatabaseTypes.MYSQLSERVER:
            //        MySql.Data.MySqlClient.MySqlException exMySQL =
            //                exDb as MySql.Data.MySqlClient.MySqlException;
            //        if (null != exMySQL) _nErrorNumber = 0;
            //        _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
            //        break;

            //    case EnumDatabaseTypes.ODBCDRIVER:
            //        System.Data.Odbc.OdbcException exODBC = exDb as System.Data.Odbc.OdbcException;
            //        if (null != exODBC) _nErrorNumber = 0;
            //        _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
            //        break;

            //    case EnumDatabaseTypes.NOTSET:
            //        //CANNOT SET THE ERROR NUMBER
            //        _nErrorNumber = 0;
            //        _enCustomErrorType = EnumErrorTypes.DATABASE_EXCEPTION;
            //        break;
            //}
            _sErrorString = exDb.ToString();
        }

        /// <summary>
        /// function for setting up the respective SQL Exception user-friendly message.
        /// </summary>
        ///
        /// <param> long Error number </param>
        /// <returns> string error message </returns>
        /// 
        /// <created by="Vinod Sasi" on="09-10-2009" />
        /// <modified by="" on="" />
        public string SetErrorString(long nErrorNumber)
        {
            switch (nErrorNumber)
            {
                case 0:
                    return "Unknown error.";

                case 17:
                    return "Database server unavailable.";

                case 4060:
                    return "Database server unavailable.";

                case 18456:
                    return "Could not login to the Database server.";

                case 2627:
                    return "Duplicate entry. Saving failed.";

                case 2601:
                    return "Duplicate entry. Saving failed.";

                case 547:
                    return "Could not update/delete. Either the record may be used in other modules or Invalid Data";

                case 515:
                    return "Could not update/delete. Relational data is not available.";

                case 8152:
                    return "Field Length too long. Saving failed! Try again with valid data.";

                default:
                    return "Unknown error occured with the database server.";
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            CloseConnection();
        }
        #endregion
    }
}
