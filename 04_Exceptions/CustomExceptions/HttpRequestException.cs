class HttpRequestException : Exception
{
    public HttpRequestException()
    {

    }

    public HttpRequestException(string message) : base(message)
    {

    }

    public HttpRequestException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}