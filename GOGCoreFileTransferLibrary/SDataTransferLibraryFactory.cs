/*
 * Program Name     :   SGOGDataAccessHelperFactory
 * Description      :   Used to creat the required Data Access Helper object based on the database.
 *  	
 * Namespace		:	GOGCoreDataTransferLibrary
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

namespace GOGCoreDataTransferLibrary
{
    public class SGOGDataAccessHelperFactory
    {
        /// <summary>
        /// Private static variable to store the FileTransferSettings object reference.
        /// </summary>
        private static CDataTransferSettings 
                            st_oDataTransferSettings = CDataTransferSettings.DataTransferSettings ;

        /// <summary>
        /// Creates and returs the required File Transfer helper object based on the databse type.
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="06-10-2009" />
        /// <modified by="" on="" />
        public static IDataTransferHelper GetDataTransferHelper( )
        {
            IDataTransferHelper oDataTransferHelper = null ;

            switch ( st_oDataTransferSettings.Protocol )
            {
                case EnumProtocols.FTP :
                    oDataTransferHelper = new CFTPDataTransferHelper( ) ;
                    break ;

                case EnumProtocols.HTTPS :
                    oDataTransferHelper = new CHTTPSDataTransferHelper( ) ;
                    break;

                default:
                    oDataTransferHelper = new CHTTPSDataTransferHelper( ) ;
                    break ;
            }
            return oDataTransferHelper ;
        }

   }
}
