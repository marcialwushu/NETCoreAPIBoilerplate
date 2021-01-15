using JDPI.Common.Util;

namespace JDPI.Platform.Util.Providers
{
    public class ConfigProvider : IConfigProvider
    {
        public string DbName {get; set;}
        public string DbUrl {get; set; }
        public string DbUsername {get; set; }
        public string DbPwd {get; set;}
    }
}