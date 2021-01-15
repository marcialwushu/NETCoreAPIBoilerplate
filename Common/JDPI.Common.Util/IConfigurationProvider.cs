using System;

namespace JDPI.Common.Util
{
    public interface IConfigProvider
    {
        string DbName {get;}
        string DbUrl {get;}
    }
}
