/*
	Copyright © Bryan Apellanes 2015  
*/

namespace Bam.ServiceProxy
{
    /// <summary>
    /// When implemented, determines who the current user is.
    /// </summary>
    /// <seealso cref="Bam.ServiceProxy.IRequiresHttpContext" />
    public interface IUserResolver: IRequiresHttpContext
    {
        string GetCurrentUser();

        string GetUser(IHttpContext context);
    }
}
