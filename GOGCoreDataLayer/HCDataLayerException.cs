/*
 * Program Name     :   DataLayerException
 * Description      :   Used for handling custom exceptions.
 * 	
 * Namespace		:	GOGCoreDataLayer
 * Type             :   C# Code file.
 * Date             :   07 October 2009
 * Tables Used      :   Nill
 *
 * @author          :   Vinod Sasi.
 * @version         :   1.0
 *-----------------------------------------------------------------------------------------------
 *                       Modification Log
 *-----------------------------------------------------------------------------------------------
 *     Ver No:      Author		               Date           Function				Description
 *-----------------------------------------------------------------------------------------------
 *     1.0		    Vinod Sasi.                07-10-2009	   						Created  
 *-----------------------------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace GOGCoreDataLayer
{
    class HCDataLayerException : Exception 
    {
        /// <summary>
        /// Stores the custom error message.
        /// </summary>
        private string _sErrorString = "Error Success." ;

        /// <summary>
        /// Provides interface for ErrorString property.        
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        /// <remarks>Provides setter and getter methods. </remarks>
        public string ErrorString
        {
            get { return _sErrorString  ; }
            set { _sErrorString = value ; }
        }

        /// <summary>
        /// Stores the custom error type.
        /// </summary>
        private EnumErrorTypes _enErrorType ;

        /// <summary>
        /// Provides interface for ErrorType property.        
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        /// <remarks>Provides setter and getter methods. </remarks>
        public EnumErrorTypes ErrorType
        {
            get { return _enErrorType  ; }
            set { _enErrorType = value ;  }
        }

        /// <summary>
        /// DataLayerException Constructor.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns> void </returns>
        /// 
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        public HCDataLayerException( string sErrorString, EnumErrorTypes enErrorType )
        {
            _sErrorString = sErrorString ;
            _enErrorType = enErrorType ;
        }
    }
}
