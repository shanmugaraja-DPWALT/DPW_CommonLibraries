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


using System.Text;
using GOGCoreDataTransferLibrary.Utlities;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GOGCoreDataTransferLibrary
{   
    public class CHTTPSDataTransferHelper : IDataTransferHelper
    {
        public CHTTPSDataTransferHelper(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public CHTTPSDataTransferHelper()
        {
        }

        #region[ Class and Interface Properties]

        private IHttpClientFactory _clientFactory;

        /// <summary>
        /// 
        /// </summary>
        public IHttpClientFactory HttpClientFactory
        {
            set
            {
                _clientFactory = value ;
            }
        }

        /// <summary>
        /// Provides get ans set method for ErrorMessage property.        
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        public string ErrorString
        { get; set; }

        /// <summary>
        /// Provides get and set method for ErrorNumber property.        
        /// </summary>
        ///
        /// <created by="Vinod Sasi" on="07-10-2009" />
        /// <modified by="" on="" />
        public long ErrorNumber
        { get; set; }

        /// <summary>
        /// Provides get and set method for Exception property
        /// </summary>
        public System.Exception Exception { get; set; }
        #endregion

        #region [ Public Interface Functions ]


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mamnifests"></param>
        /// <returns></returns>
        public bool TransferData(DPWEntityLibrary.Common.CBOLEntity bolEntity )
        {
            bool bSuccess = false;
            if (!CAPISettings.APISettings.SettingValueSaved)
            {
                CAPISettings.APISettings.UserName =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:UserNane"] as string;

                CAPISettings.APISettings.Password =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:Password"] as string;

                CAPISettings.APISettings.APIKey =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:APIKey"] as string;

                CAPISettings.APISettings.BaseUrl =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:BaseURL"] as string;


                CAPISettings.APISettings.AuthenticationURL =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:AuthenticationAPI"] as string;

                CAPISettings.APISettings.ManifestURL =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:ManifestInsertAPI"] as string;

                CAPISettings.APISettings.JsonFilePath =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:JsonFilePath"] as string;
            }
            bSuccess = AuthenticateAPICall();

            if (bSuccess) CallBOLAPI(bolEntity);

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
            return bSuccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mamnifests"></param>
        /// <returns></returns>
        public bool TransferData( DPWEntityLibrary.Common.CManifestEntity manifest )
        {
            bool bSuccess = false ;
            if (!CAPISettings.APISettings.SettingValueSaved)
            {
                CAPISettings.APISettings.UserName = 
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:UserNane"] as string;

                CAPISettings.APISettings.Password =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:Password"] as string;

                CAPISettings.APISettings.APIKey=
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:APIKey"] as string;
                
                CAPISettings.APISettings.BaseUrl =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:BaseURL"] as string;


                CAPISettings.APISettings.AuthenticationURL =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:AuthenticationAPI"] as string;

                CAPISettings.APISettings.ManifestURL =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:ManifestInsertAPI"] as string;

                CAPISettings.APISettings.JsonFilePath =
                    GOGCoreDataTransferLibrary.CDataTransferSettings.
                    DataTransferSettings.Configuration["DataTransferSettings:JsonFilePath"] as string;
            }
            bSuccess = AuthenticateAPICall( ) ;

            if ( bSuccess ) CallManifestAPI ( manifest ) ;

            return bSuccess;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
        }

        #endregion

        #region [ Transfer Support Functions  ]

        public bool AuthenticateAPICall()
        {
            //HttpClient client = _clientFactory.CreateClient();
            HttpClient client = new HttpClient( ) ;
            bool bSuccess = false ;

            try
            {
                client.DefaultRequestHeaders.Add("User-Agent", "AfriLogiTech");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                client.DefaultRequestHeaders.Add("z.userid", CAPISettings.APISettings.UserName);
                client.DefaultRequestHeaders.Add("z.password", CAPISettings.APISettings.Password);
                client.DefaultRequestHeaders.Add("z.apikey",CAPISettings.APISettings.APIKey);
                client.DefaultRequestHeaders.Add("z.currentDataScope", "DAR");
                client.DefaultRequestHeaders.Add("z.locale", "en-US" ) ;

                var content = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(string.Empty), Encoding.UTF8, "application/json");

                var response = client.PostAsync(
                    CAPISettings.APISettings.BaseUrl + CAPISettings.APISettings.AuthenticationURL, content).Result; // Synchronous wait

                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result; // Synchronous wait
                    AuthenticationRoot root = JsonConvert.DeserializeObject<AuthenticationRoot>(responseString);

                    string token = root.content.token ;

                    if ( !string.IsNullOrEmpty ( token ))
                    {
                        CAPISettings.APISettings.SessionToken = token ;
                        bSuccess = true ;
                    }
                }
                else
                {
                    var errorResponse = response.Content.ReadAsStringAsync().Result; // Synchronous wait
                }
            }
            catch ( HttpRequestException exHttpRequest )
            {
                Exception = exHttpRequest ;
            }
            catch (Exception ex)
            {
                Exception = ex ;
            }
            return bSuccess ;
        }

        public bool CallManifestAPI( DPWEntityLibrary.Common.CManifestEntity manifest )
        {

            //HttpClient client = _clientFactory.CreateClient();
            HttpClient client = new HttpClient();
            bool bSuccess = false ;
            
            try
            {
                client.DefaultRequestHeaders.Add("User-Agent", "AfriLogiTech");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                client.DefaultRequestHeaders.Add("z.locale", "en-US");
                client.DefaultRequestHeaders.Add("z.sessionToken", CAPISettings.APISettings.SessionToken);

                //var requestBody =  manifestList.FirstOrDefault() ;

                var content = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(manifest), Encoding.UTF8, "application/json");

                //string sURL = CAPISettings.APISettings.BaseUrl + CAPISettings.APISettings.ManifestURL ; // Synchronous wait

                string sURL = "https://zodiacappuat.dar.zodiac-cloud.com/zodiac/api/v1/bol/create?replaceOption=N"; // Synchronous wait

                var response = client.PostAsync(sURL, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result; // Synchronous wait
                    AuthenticationRoot root = JsonConvert.DeserializeObject<AuthenticationRoot>(responseString);

                    string token = root.content.token;

                    if (!string.IsNullOrEmpty(token))
                    {
                        CAPISettings.APISettings.SessionToken = token;
                        bSuccess = true;
                    }
                }
                else
                {
                    var errorResponse = response.Content.ReadAsStringAsync().Result; // Synchronous wait
                }
            }
            catch (HttpRequestException exHttpRequest )
            {
                Exception = exHttpRequest ;
            }
            catch ( Exception ex )
            {
                Exception = Exception ;
            }
            return false;
        }

        public bool CallBOLAPI( DPWEntityLibrary.Common.CBOLEntity bolEntity )
        {

            //HttpClient client = _clientFactory.CreateClient();
            HttpClient client = new HttpClient();
            bool bSuccess = false;

            try
            {
                client.DefaultRequestHeaders.Add("User-Agent", "AfriLogiTech");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                client.DefaultRequestHeaders.Add("z.locale", "en-US");
                client.DefaultRequestHeaders.Add("z.sessionToken", CAPISettings.APISettings.SessionToken);

                //var requestBody =  manifestList.FirstOrDefault() ;

                var content = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(bolEntity), Encoding.UTF8, "application/json");

                //string sURL = CAPISettings.APISettings.BaseUrl + CAPISettings.APISettings.ManifestURL ; // Synchronous wait

                string sURL = "https://zodiacappuat.dar.zodiac-cloud.com/zodiac/api/v1/bol/create?replaceOption=N"; // Synchronous wait

                var response = client.PostAsync(sURL, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result; // Synchronous wait
                    BOLErrorResponse errorResponse = JsonConvert.DeserializeObject<BOLErrorResponse>(responseString);

                    //foreach ( var validationDetail in errorResponse.ResponseDetail.ValidationDetail )
                    //{
                    //}
                }
                else
                {
                    var errorResponse = response.Content.ReadAsStringAsync().Result; // Synchronous wait
                }
            }
            catch (HttpRequestException exHttpRequest )
            {
                Exception = exHttpRequest ; 
            }
            catch ( Exception ex )
            {
                Exception = Exception ;
            }
            return false ;
        }
        #endregion
    }

    public class Content
    {
        public string token { get; set; }
    }

    public class AuthenticationRoot
    {
        public int status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Content content { get; set; }
    }

    public class BOLErrorResponse
    {
        public int Status { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        [JsonPropertyName("responseDetail")]
        public BOLResponseDetail ResponseDetail { get; set; }
    }

    public class BOLResponseDetail
    {
        public ValidationDetail[] ValidationDetail { get; set; }
        public string TraceId { get; set; }
    }

    public class ValidationDetail
    {
        public string Message { get; set; }
        public string Code { get; set; }
    }
}
