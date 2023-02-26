/*
	Copyright © Bryan Apellanes 2015  
*/
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace Bam.Net.ServiceProxy
{
    public interface IServiceProxyInvocationRequestArgumentWriter
    {
        IApiArgumentEncoder ApiArgumentEncoder { get; set; }
        object[] Arguments { get; set; }
        MethodInfo MethodInfo { get; set; }
        string MethodName { get; set; }
        Dictionary<string, object> NamedArguments { get; }
        string QueryStringArguments { get; }
        IServiceProxyInvocationRequest ServiceProxyInvocationRequest { get; }
        Type ServiceType { get; set; }

        string GetJsonArgsMember();
        string[] GetJsonArgumentsArray();
        MethodInfo GetMethodInfo();
        void WriteArgumentContent(HttpRequestMessage requestMessage);
        void WriteArgumentQueryString(HttpRequestMessage requestMessage);
        void WriteArguments(HttpRequestMessage requestMessage);
    }
}