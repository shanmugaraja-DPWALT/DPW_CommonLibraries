/*
 * Program Name     :   IGOGDataAccessHelperFactory
 * Description      :   Used to creat the required Data Access Helper object based on the database.
 *  	
 * Namespace		:	GOGDataLayer
 * Type             :   
 * Date             :   06 October 2009
 * Tables Used      :   Nill
 *
 * @author          :   Vinod Sasi
 * @version         :   1.0
 *-----------------------------------------------------------------------------------------------
 *                       Modification Log
 *-----------------------------------------------------------------------------------------------
 *     Ver No:  Author		    Date           Function				Description
 *-----------------------------------------------------------------------------------------------
 *     1.0		Vinod Sasi      06-10-2009	   						Created  
 *-----------------------------------------------------------------------------------------------
 */

namespace GOGCoreDataLayer
{
    public class SGOGDataAccessHelperFactory
    {
        /// <summary>
        /// Private static variable to store the datalayer object reference.
        /// </summary>
        private static IGOGDataLayer st_oGOGDataLayer = CDataLayer.CreateObject( ) ;

        /// <summary>
        /// Creates and returs the required data access helper object based on the databse type.
        /// </summary>
        ///
        /// <param name="nClasId"> 
        /// Rserved for future. It can be used if same database has different implementations. 
        /// </param>
        /// <param name="sErroString">
        /// Returns the error string if the function cannot create requested object.
        /// </param>
        /// 
        /// <returns> Data access helper object based on the database type and class id. </returns>
        /// 
        /// <created by="Vinod Sasi" on="06-10-2009" />
        /// <modified by="" on="" />
        public static IGOGDataAccessHelper GetDataAccessHelper( )
        {
            IGOGDataAccessHelper oGOGDataAccessHelper = null ;

            switch ( st_oGOGDataLayer.DataBaseType )
            {
                case EnumDatabaseTypes.MSSQLSERVER :
                    oGOGDataAccessHelper = new CMSSQLDataAccessHelper( ) ;
                    break ;

                case EnumDatabaseTypes.MYSQLSERVER:
                    oGOGDataAccessHelper = new CMySQLDataAccessHelper();
                    break;

                case EnumDatabaseTypes.ORACLESERVER:
                case EnumDatabaseTypes.ODBCDRIVER :
                    break ;

                case EnumDatabaseTypes.POSTGRESSQL :
                    oGOGDataAccessHelper = new CPostgresSQLDataAccessHelper( ) ;
                    break;

                case EnumDatabaseTypes.NOTSET :
                    break ;
            }
            return oGOGDataAccessHelper ;
        }


        public static IGOGDataAccessHelper GetDataAccessHelper( EnumDatabaseTypes enDataBaseType )
        {
            IGOGDataAccessHelper oGOGDataAccessHelper = null ;

            switch( enDataBaseType )
            {
                case EnumDatabaseTypes.MSSQLSERVER :
                    oGOGDataAccessHelper = new CMSSQLDataAccessHelper( );
                    break ;

                case EnumDatabaseTypes.MYSQLSERVER :
                    oGOGDataAccessHelper = new CMySQLDataAccessHelper( );
                    break;

                case EnumDatabaseTypes.MSSQLCOMPACTIBLE :
                    oGOGDataAccessHelper = new CMSSQLCompactDataAccessHelper( ) ;
                    break ;

                case EnumDatabaseTypes.ORACLESERVER :
                case EnumDatabaseTypes.ODBCDRIVER :
                    break ;

                case EnumDatabaseTypes.NOTSET :
                    break;
            }
            return oGOGDataAccessHelper ;
        }
    }
}
