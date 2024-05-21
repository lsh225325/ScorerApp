namespace ScorerApp;

public class JsCode2Session
{
    /// <summary>
    /// 用户唯一标识
    /// </summary>
    public string? openid { get; set; }
    /// <summary>
    /// 会话密钥
    /// </summary>
    public string? session_key { get; set; }

    /// <summary>
    /// 用户在开放平台的唯一标识符，若当前小程序已绑定到微信开放平台帐号下会返回，详见 UnionID 机制说明。
    /// </summary>
    public string? unionid { get; set; }
    /// <summary>
    /// 错误码
    /// </summary>
    public int errcode { get; set; }
    /// <summary>
    ///  错误信息
    /// </summary>
    public string? errmsg { get; set; }

}
