/*
 * Program Name     :   IGOGDataLayer
 * Description      :   Used for calling general data layer functions like 
 *                      getting and setting the datalayer properties.
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
 *     1.0		Vinod Sasi      06-10-2009	   						Created  
 *-----------------------------------------------------------------------------------------------
 */

namespace GOGCoreDataLayer
{    
    public interface IGOGDataLayer
    {
        /// <summary>
        /// Property for getting and setting connection string.
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="06-10-2009" />
        /// <modified by="" on="" />
        string ConnectionString
        {   set ;    get ;    }


        /// <summary>
        /// Property for getting and setting database type.
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="06-10-2009" />
        /// <modified by="" on="" />
        EnumDatabaseTypes DataBaseType
        {   set ;    get ;    }        
    }
}
