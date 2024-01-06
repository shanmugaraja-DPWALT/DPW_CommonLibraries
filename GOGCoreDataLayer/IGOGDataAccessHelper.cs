/*
 * Program Name     :   IDataAccessHelper
 * Description      :   
 * 	
 * Namespace		:	GOGCoreDataLayer
 * Type             :   
 * Date             :   7 October 2009
 * Tables Used      :   Nill
 *
 * @author          :   Vinod Sasi
 * @version         :   1.0
 *-----------------------------------------------------------------------------------------------
 *                       Modification Log
 *-----------------------------------------------------------------------------------------------
 *     Ver No:  Author		    Date           Function				Description
 *-----------------------------------------------------------------------------------------------
 *     1.0		Vinod Sasi	   	07-10-2009				            Created  
 *-----------------------------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.Common;
using System.Data;

namespace GOGCoreDataLayer
{
    public interface IGOGDataAccessHelper: IDisposable
    {
        /// <summary>
        /// Provides get ans set method for ErrorMessage property.        
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        string ErrorString 
        { get; }

        /// <summary>
        /// Provides get and set method for ErrorNumber property.        
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        long ErrorNumber
        { get; }

        /// <summary>
        /// Provides get and set method for CustomErrorMessage property.        
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        string CustomErrorString
        { get; }

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        DbParameter CreateDBParameter( string srParamName,
                        string srParamValue, ParameterDirection enParamDirection ) ;

        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="fParamValue">
        ///     Float containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        DbParameter CreateDBParameter( string srParamName,
                        float fParamValue, ParameterDirection enParamDirection ) ;

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        DbParameter CreateDBParameter( string srParamName,
                        double dbParamValue, ParameterDirection enParamDirection ) ;

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        DbParameter CreateDBParameter( string srParamName,
                            int nParamValue, ParameterDirection enParamDirection ) ;

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        DbParameter CreateDBParameter( string srParamName, 
                        long lParamValue, ParameterDirection enParamDirection ) ;

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        DbParameter CreateDBParameter( string srParamName,
                            bool bParamValue, ParameterDirection enParamDirection ) ;

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        DbParameter CreateDBParameter( string srParamName,
                            DateTime bParamValue, ParameterDirection enParamDirection ) ;

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        DbParameter CreateDBParameter( string srParamName,
                            DateTimeOffset bParamValue, ParameterDirection enParamDirection ) ;

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
        //DbParameter CreateDBParameter(string srParamName,
        //                    object oParamValue, System.Data.ParameterDirection enParamDirection);


        /// <summary>
        /// Creates and returns the parameter object as per the database used.
        /// </summary>
        ///
        /// <param name="srParamName">
        ///     String containing the parameter name to set.</param>
        /// <param name="deParamValue">
        ///     decimal containing the value of the parameter to set.</param>
        /// <param name="enParamDirection">
        ///     Specifies the parameter direction,whether its in out bi directional or return.</param>
        /// <returns> The parameter object if creation success else false.</returns>
        /// 
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        DbParameter CreateDBParameter( string srParamName,
                        decimal deParamValue, ParameterDirection enParamDirection ) ;

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        DbParameter CreateDBParameter( string srParamName,
                        byte[] lParamValue, ParameterDirection enParamDirection ) ;


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
        DbParameter CreateDBParameter(string srParamName,
                        System.Data.DataTable tblParamValue, ParameterDirection enParamDirection);

        /// <summary>
        /// Executes a query string for handling table operations like
        /// create table, drop table , or alter table etc.
        /// </summary>
        ///
        /// <param name="srQuery">Query string to be executed.</param>
        /// <returns> bool -> Success of the function as boolean.</returns>
        /// 
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        bool ExecuteTableOperations( string sQuery ) ;

        /// <summary>
        /// Creates a connection object and opens a connection with the default database.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns> bool -> Success of the function as boolean. </returns>
        /// 
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        bool OpenConnection( ) ;

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        bool OpenConnection( string sConnectionString ) ;

        /// <summary>
        /// Function commits the changes occured in the scope of the connection to the database.
        /// User has to call this function must, if he/she opens a transaction.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns>success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        bool OpenTransaction( ) ;

        /// <summary>
        /// Function commits the changes occured in the scope of the connection to the database.
        /// User has to call this function must, if he/she opens a transaction.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns>success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        bool CommitTransaction( ) ;

        /// <summary>
        /// Function rollbacks the changes done with in the scope of transaction.
        /// Call this function in case of any logical error in between a trasaction.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns>success of the function as boolean </returns>
        /// 
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        bool RollbackTransaction( ) ;

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        bool CloseConnection();

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        object ExecuteQuery(string sQuery, EnumDBLayerReturnTypes enReturnType);

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        object ExecuteProcedure(string sProcedureName, EnumDBLayerReturnTypes enReturnType, ArrayList alInputParams);

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
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        object ExecuteProcedure( string sProcedureName, EnumDBLayerReturnTypes enReturnType, 
                                        ArrayList alInputParams, out ArrayList alOutputParams ) ;
    }
}
