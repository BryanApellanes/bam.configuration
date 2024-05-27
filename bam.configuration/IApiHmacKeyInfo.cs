/*
	Copyright © Bryan Apellanes 2015  
*/
using Bam.CoreServices.ApplicationRegistration.Data;

namespace Bam.ServiceProxy.Encryption
{
    public interface IApiHmacKeyInfo
    {
        string ApiHmacKey { get; set; }
        string ApplicationClientId { get; set; }
        string ApplicationName { get; set; }

        IApiHmacKey ToApiSigningKey();
    }
}