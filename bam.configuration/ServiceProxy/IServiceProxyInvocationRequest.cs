using System;
using System.Collections.Generic;

namespace Bam.ServiceProxy
{
    public interface IServiceProxyInvocationRequest
    {
        object[] Arguments { get; set; }
        string BaseAddress { get; set; }
        string ClassName { get; set; }
        string Cuid { get; internal set; }
        string MethodName { get; set; }
        HashSet<string> Methods { get; }
        string MethodUrlFormat { get; set; }
        IServiceProxyClient ServiceProxyClient { get; set; }
        IServiceProxyInvocationRequestArgumentWriter ServiceProxyInvocationRequestArgumentWriter { get; }
        Type ServiceType { get; set; }
        ServiceProxyVerbs Verb { get; set; }

        string GetInvocationUrl(bool includeQueryString = true, IServiceProxyClient serviceProxyClient = null);
    }
}