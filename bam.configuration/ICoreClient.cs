using Bam.Configuration.CoreServices;
using Bam.Net.CoreServices;
using Bam.Net.CoreServices.ApplicationRegistration.Data;
//using Bam.Net.CoreServices.ApplicationRegistration.Data.Dao.Repository;
using Bam.Net.CoreServices.Auth;
using Bam.Net.Logging;
using Bam.Net.ServiceProxy;
using Bam.Net.ServiceProxy.Encryption;
//using Bam.Net.UserAccounts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bam.Net.Services.Clients
{
    public interface ICoreClient
    {
        IApiArgumentEncoder ApiArgumentEncoder { get; set; }
        string ApiKeyFilePath { get; }
        string ApplicationName { get; set; }
        HashAlgorithms HashAlgorithm { get; set; }
        string HostName { get; }
        dynamic LocalCoreRegistryRepository { get; set; } // TODO: rename this to LocalApplicationRegistrationRepository
        ILogger Logger { get; set; }
        string Message { get; set; }
        string OrganizationName { get; set; }
        int Port { get; }
        IProcessDescriptor ProcessDescriptor { get; }
        IUserRegistry UserRegistry { get; set; }
        bool UseServiceSubdomains { get; set; }
        string WorkspaceDirectory { get; }

        event EventHandler ApiKeyFileNotFound;
        event EventHandler ApiKeyFileSaved;
        event EventHandler InitializationFailed;
        event EventHandler Initialized;
        event EventHandler Initializing;
        event EventHandler InvocationExceptionThrown;
        event EventHandler MethodInvoked;
        event EventHandler OAuthSettingsLoaded;
        event EventHandler OAuthSettingsNotFound;
        event EventHandler OAuthSettingsWritten;
        event EventHandler WritingApiKeyFile;
        event EventHandler WroteApiKeyFile;

        IApiHmacKeyInfo AddApiKey();
        ICoreServiceResponse Connect();
        IApiHmacKeyInfo GetApiHmacKeyInfo(IApplicationNameProvider nameProvider);
        string GetApplicationApiHmacKey(string applicationClientId, int index);
        string GetApplicationClientId();
        string GetApplicationClientId(IApplicationNameProvider nameProvider);
        string GetApplicationName();
        string GetCurrentApiHmacKey();
        IApiHmacKeyInfo GetCurrentApplicationApiKeyInfo();
        string GetHmac(string stringToHash);
        List<LogEntry> GetLogEntries(DateTime from, DateTime to);
        T GetProxy<T>();
        ISupportedAuthProviders GetSupportedOAuthProviders();
        bool IsValidHmac(string stringToHash, string token);
        ILoginResponse Login(string userName, string passHash);
        IApplication RegisterApplication(string applicationName);
        ICoreServiceResponse RegisterClient();
        void SaveProxyAssemblies(string directory = null);
        void SaveProxySource(string directory = null);
        IApiHmacKeyInfo SetActiveApiKeyIndex(int index);
        ISignUpResponse SignUp(string emailAddress, string password, string userName = null);
    }
}