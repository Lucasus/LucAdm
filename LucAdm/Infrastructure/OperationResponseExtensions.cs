namespace LucAdm
{
    public static class OperationResponseExtensions
    {
        public static OperationResponse<T> AsOperationResponse<T>(this T result)
        {
            return new OperationResponse<T>(result);
        }
    }
}