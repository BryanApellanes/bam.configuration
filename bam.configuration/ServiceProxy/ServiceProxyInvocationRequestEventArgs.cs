/*
	Copyright © Bryan Apellanes 2015  
*/

namespace Bam.ServiceProxy
{
    public class ServiceProxyInvocationRequestEventArgs: EventArgs
    {
        public ServiceProxyInvocationRequestEventArgs(IServiceProxyInvocationRequest serviceProxyInvokeRequest)
        {
            this.InvocationRequest = serviceProxyInvokeRequest;
            this.Cuid = Bam.Cuid.Generate();
        }

        public IServiceProxyInvocationRequest InvocationRequest { get; set; }

        public IServiceProxyClient Client { get; set; } = null!;

        /// <summary>
        /// Gets or sets the request message.
        /// </summary>
        public HttpRequestMessage RequestMessage { get; set; } = null!;

        public HttpResponseMessage ResponseMessage { get; set; } = null!;

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        public Exception Exception { get; set; } = null!;

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; } = null!;

        /// <summary>
        /// Gets a value used to uniquely identify an invocation
        /// when executing event subscriptions.
        /// </summary>
        public string Cuid 
        {
            get => InvocationRequest.Cuid;
            internal set => InvocationRequest.Cuid = value;
        }

        public bool CancelInvoke
        {
            get;
            internal set;
        }

        public string BaseAddress
        {
            get => InvocationRequest.BaseAddress;
            internal set => InvocationRequest.BaseAddress = value;
        }

        public string ClassName
        {
            get => InvocationRequest.ClassName;
            internal set => InvocationRequest.ClassName = value;
        }

        public string MethodName
        {
            get => InvocationRequest.MethodName;
            internal set => InvocationRequest.MethodName = value;
        }

        public object[] Arguments
        {
            get => InvocationRequest.Arguments;
            internal set => InvocationRequest.Arguments = value;
        }
    }
}
