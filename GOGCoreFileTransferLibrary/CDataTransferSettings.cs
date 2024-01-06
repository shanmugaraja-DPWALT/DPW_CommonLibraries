/*
 * Program Name     :   CDataTransferSettings
 * Description      :   Implementation of IGOGDataLayer used for calling general data layer functions like 
 *                      getting and setting the datalayer properties and so.
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
 *     1.0      Vinod Sasi      06-10-2009                          Created
 *-----------------------------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace GOGCoreDataTransferLibrary
{
    public class CDataTransferSettings
    {
        #region [Singleton Implementation ]
        /// <summary>
        /// The private static object used for locking critical section implementation in singleton object creation.
        /// </summary>
        private static object st_oLockObject = new object();

        /// <summary>
        /// create a static object of this class. Its a singleton class. 
        /// </summary>
        private static CDataTransferSettings st_oThis = null;

        /// <summary>
        /// Static function for accessing the singleton object reference.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns> Singleton object of DataLayerImpl class </returns>
        ///  
        /// <created by="Vinod Sasi" on="06-10-2009" />
        /// <modified by="" on="" />
        static public CDataTransferSettings DataTransferSettings
        {
            get
            {
                if (null == st_oThis)
                {
                    lock (st_oLockObject)
                    {
                        if (null == st_oThis)
                        {
                            st_oThis = new CDataTransferSettings( ) ;
                            st_oThis.Protocol = EnumProtocols.HTTPS;
                            st_oThis.UserName = "DARUAT02";
                            st_oThis.Password = "Welcom@1";
                        }
                    }
                }
                return st_oThis;
            }
        }
        #endregion

        #region [ Member Variables ]

        /// <summary>
        /// Declaring a property for storing User Name string.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Declaring a property for storing Password string.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Protocol Used in the File Transfer
        /// </summary>
        public EnumProtocols Protocol { get; set; }

        public string SProtocol 
        {  
            set
            {
                if ("HTTPS" == value)
                {
                    Protocol = EnumProtocols.HTTPS;
                }
                else if ("FTP" == value)
                {
                    Protocol = EnumProtocols.FTP;
                }
            } 
        }

        /// <summary>
        /// Stores the Configuration object to get the configurations in Helper classes 
        /// </summary>
        public IConfiguration Configuration { get; set; }

        #endregion
    }
}
