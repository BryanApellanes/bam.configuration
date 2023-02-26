namespace Bam.Net.CoreServices
{
    public interface ICoreServiceResponse
    {
        dynamic Data { get; set; }
        string Message { get; set; }
        bool Success { get; set; }
    }
}