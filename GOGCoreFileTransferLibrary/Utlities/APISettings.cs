using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOGCoreDataTransferLibrary.Utlities
{
    public class CAPISettings
    {
        #region [Singleton Implementation ]
        /// <summary>
        /// The private static object used for locking critical section implementation in singleton object creation.
        /// </summary>
        private static object st_oLockObject = new object();

        /// <summary>
        /// create a static object of this class. Its a singleton class. 
        /// </summary>
        private static CAPISettings st_oThis = null;

        /// <summary>
        /// Static function for accessing the singleton object reference.
        /// </summary>
        ///
        /// <param> void </param>
        /// <returns> Singleton object of DataLayerImpl class </returns>
        ///  
        /// <created by="Vinod Sasi" on="06-10-2009" />
        /// <modified by="" on="" />
        static public CAPISettings APISettings
        {
            get
            {
                if (null == st_oThis)
                {
                    lock (st_oLockObject)
                    {
                        if ( null == st_oThis )
                        {
                            st_oThis = new CAPISettings();
                            st_oThis.SettingValueSaved = false ;
                            //st_oThis.UserName = "DARUAT02";
                            //st_oThis.Password = "Welcome@1";
                            //st_oThis.APIKey = "85F75FDCDC64419B56FE634A1B9EEB0";
                            //st_oThis.SessionToken = string.Empty ;
                            //st_oThis.BaseUrl = "https://zodiacappuat.dar.zodiac-cloud.com/zodiac/core/api/v1/";
                        }
                    }
                }
                return st_oThis;
            }
        }
        #endregion

        /// <summary>
        ///
        /// </summary>
        public string BaseUrl { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string SessionToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string APIKey { get; set; }

        /// <summary>
        /// Declaring a property for storing User Name string.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Declaring a property for storing Password string.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AuthenticationURL = "auth" ;

        /// <summary>
        /// 
        /// </summary>
        public string ManifestURL = "bol/create?replaceOption=N" ;

        /// <summary>
        /// 
        /// </summary>
        public bool SettingValueSaved { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string JsonFilePath { get; set; }
    }
}
