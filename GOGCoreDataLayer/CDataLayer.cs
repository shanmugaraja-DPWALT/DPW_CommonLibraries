/*
 * Program Name     :   CGOGDataLayerImpl
 * Description      :   Implementation of IGOGDataLayer used for calling general data layer functions like 
 *                      getting and setting the datalayer properties and so.
 * 	
 * Namespace		:	GOGCoreDataLayer
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

namespace GOGCoreDataLayer
{
    public class CDataLayer : IGOGDataLayer
    {
        /// <summary>
        /// The private static object used for locking critical section implementation in singleton object creation.
        /// </summary>
        private static object st_oLockObject = new object ( ) ;

        /// <summary>
        /// Declaring a variable for storing connection string.
        /// </summary>
        string _sConnection = null ; 

        /// <summary>
        /// Declare a enum data type object and by default set as NOTSET
        /// </summary>
        private EnumDatabaseTypes _enDatabaseType = EnumDatabaseTypes.NOTSET ;       

        /// <summary>
        /// create a static object of this class. Its a singleton class. 
        /// </summary>
        private static CDataLayer st_oThis = null ;
        
        /// <summary>
        /// Static function for accessing the singleton object reference.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns> Singleton object of DataLayerImpl class </returns>
        ///  
        /// <created by="Vinod Sasi" on="06-10-2009" />
        /// <modified by="" on="" />
        static public CDataLayer CreateObject ( )
        {
            if ( null == st_oThis )
            {
                lock ( st_oLockObject )
                {
                    if ( null == st_oThis ) st_oThis = new CDataLayer( ) ;
                }
            }
            return st_oThis ; 
        }

        /// <summary>
        /// Property for accessing the Connection string .
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="06-10-2009" />
        /// <modified by="" on="" />
        public string ConnectionString
        {
            set { _sConnection = value ; }
            get { return _sConnection  ; }
        }

        /// <summary>
        /// Property for getting and setting database type.
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="06-10-2009" />
        /// <modified by="" on="" />
        public EnumDatabaseTypes DataBaseType
        {
            set{ _enDatabaseType = value ;  }
            get{ return _enDatabaseType  ;  }
        }
    }
}
