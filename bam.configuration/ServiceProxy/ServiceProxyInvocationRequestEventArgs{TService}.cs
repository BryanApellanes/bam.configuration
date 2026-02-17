/*
	Copyright © Bryan Apellanes 2015  
*/

namespace Bam.ServiceProxy
{
    public class ServiceProxyInvocationRequestEventArgs<TService> : ServiceProxyInvocationRequestEventArgs
    {
        public ServiceProxyInvocationRequestEventArgs(IServiceProxyInvocationRequest serviceProxyInvokeRequest) : base(serviceProxyInvokeRequest)
        {
            this.InvocationRequest = serviceProxyInvokeRequest;
            this.Cuid = Bam.Cuid.Generate();
        }

        public ServiceProxyInvocationRequestEventArgs(IServiceProxyInvocationRequest serviceProxyInvokeRequest, bool cancelInvoke = false) : this(serviceProxyInvokeRequest)
        {
            this.CancelInvoke = cancelInvoke;
        }

        public new IServiceProxyClient Client
        {
            get;
            set;
        } = null!;
    }
}
