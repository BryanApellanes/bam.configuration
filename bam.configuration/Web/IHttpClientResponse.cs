namespace Bam.Web
{
    public interface IHttpClientResponse
    {
        Dictionary<string, string> Headers { get; }

        string Content { get; }
        int StatusCode { get; }
        string ContentType { get; }

        Uri Url { get; }
    }
}
