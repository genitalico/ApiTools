using ApiTools.Models;
using System.Web;
using System.Web.Http;

namespace ApiTools.Controllers
{
    [RoutePrefix("api/MyIp")]
    public class MyIpController : ApiController
    {
        #region PrivateVars

        #endregion

        #region Ctor
        public MyIpController()
        {

        }
        #endregion

        #region RESTMethods
        //Get api/MyIp
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public IHttpActionResult GetMyIp()
        {
            MyIP ip = new MyIP();

            if (Request.Properties.ContainsKey("MS_HttpContext"))
            {
                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];
                if (context.Request.ServerVariables["HTTP_VIA"] != null)
                {

                    ip.IP = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    ip.IP = context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                }
            }

            return Ok(ip);

        }
        #endregion
    }
}
