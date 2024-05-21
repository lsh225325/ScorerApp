namespace ScorerApp;

public class XiaochengxuInfo
{
    //小程序
    public const string appID = "wxdee19002357e1477";
    public const string appsecret = "d0459c3d711f8c92b3b42b995a6143fa";
    public const string redirect_uri = "https://rvfk4jdm-5700.inc1.devtunnels.ms/account/loginbyweixin";
    public const string state = "scorer";

    //使用wx.login()获取的code,x.login()获取的code只能使用一次
    //用code换取session_key
    //返回的数据包括session_key,unionid,errmsg,openid,errcode
    /*
     {
        "openid":"xxxxxx",
        "session_key":"xxxxx",
        "unionid":"xxxxx",
        "errcode":0,
        "errmsg":"xxxxx"
      }
     */
    public static string GetCode2SessionUrl(string code)
    {
        return $"https://api.weixin.qq.com/sns/jscode2session?appid={appID}&secret={appsecret}&js_code={code}&grant_type=authorization_code";
    }

}
