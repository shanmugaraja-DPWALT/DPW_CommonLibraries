/*
 * Program Name     :   IFileTransferHelper
 * Description      :   
 * 	
 * Namespace		:	GOGCoreDataTransferLibrary
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

namespace GOGCoreDataTransferLibrary
{
    public class CFTPDataTransferHelper : IDataTransferHelper
    {

        #region [ Public Functions for File Transfer ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mamnifests"></param>
        /// <returns></returns>
        public bool TransferData(DPWEntityLibrary.Common.CManifestEntity mamnifest)
        {
            bool bSuccess = false;

            return bSuccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mamnifest"></param>
        /// <returns></returns>
        public bool TransferData(DPWEntityLibrary.Common.CBOLEntity mamnifest)
        {
            bool bSuccess = false;

            return bSuccess;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <returns></returns>
        public bool TransferData(string sFileData, string sDataFormat)
        {
            bool bSuccess = false;
            try
            {
                //IGOGFile
            }
            catch
            {

            }
            return bSuccess;
        }

        public void Dispose()
        {
        }

        #endregion

        /// <summary>
        /// Provides get ans set method for ErrorMessage property.        
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        public string ErrorString 
        { get; set;  }

        /// <summary>
        /// Provides get and set method for ErrorNumber property.        
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        public long ErrorNumber
        { get; set;  }

        /// <summary>
        /// Provides get and set method for Exception property
        /// </summary>
        public System.Exception Exception { get; set;  }
    }
}
