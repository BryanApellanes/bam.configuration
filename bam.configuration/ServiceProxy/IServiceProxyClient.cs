/*
	Copyright © Bryan Apellanes 2015  
*/
using Bam.Net.Logging;
using Bam.Net.Web;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bam.Net.ServiceProxy
{
    public interface IServiceProxyClient
    {
        IApiArgumentEncoder ApiArgumentEncoder { get; set; }
        string BaseAddress { get; set; }
        ILogger Logger { get; set; }
        Type ServiceType { get; }
        string UserAgent { get; set; }

        event EventHandler<ServiceProxyInvocationRequestEventArgs> GetCanceled;
        event EventHandler<ServiceProxyInvocationRequestEventArgs> GetComplete;
        event EventHandler<ServiceProxyInvocationRequestEventArgs> GetStarted;
        event EventHandler<ServiceProxyInvocationRequestEventArgs> InvocationException;
        event EventHandler<ServiceProxyInvocationRequestEventArgs> InvocationCanceled;
        event EventHandler<ServiceProxyInvocationRequestEventArgs> InvocationComplete;
        event EventHandler<ServiceProxyInvocationRequestEventArgs> InvocationStarted;
        event EventHandler<ServiceProxyInvocationRequestEventArgs> PostCanceled;
        event EventHandler<ServiceProxyInvocationRequestEventArgs> PostComplete;
        event EventHandler<ServiceProxyInvocationRequestEventArgs> PostStarted;

        Task<HttpRequestMessage> CreateServiceProxyInvocationRequestMessageAsync(IServiceProxyInvocationRequest serviceProxyInvocationRequest);

        IHttpClientResponse InvokeServiceMethod(string methodName, params object[] parameters);
        Task<IHttpClientResponse> InvokeServiceMethodAsync(string methodName, object[] arguments);
        Task<IHttpClientResponse> InvokeServiceMethodAsync(string className, string methodName, object[] arguments);
        Task<IHttpClientResponse> InvokeServiceMethodAsync(string baseAddress, string className, string methodName, object[] arguments);
        Task<IHttpClientResponse> ReceiveGetResponseAsync(IServiceProxyInvocationRequest request);
        Task<IHttpClientResponse> ReceiveGetResponseAsync(string methodName, params object[] arguments);
        Task<IHttpClientResponse> ReceivePostResponseAsync(IServiceProxyInvocationRequest serviceProxyInvocationRequest);
        Task<IHttpClientResponse> ReceivePostResponseAsync(string methodName, params object[] arguments);
    }
}