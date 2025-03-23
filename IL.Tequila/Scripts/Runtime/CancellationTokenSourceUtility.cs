using System.Threading;

namespace IL.Tequila
{
    public static class CancellationTokenSourceUtility
    {
        public static bool TryGetCancellationToken(CancellationTokenSource cancellationTokenSource, out CancellationToken cancellationToken)
        {
            if (cancellationTokenSource == null)
            {
                return false;
            }

            if (cancellationTokenSource.IsCancellationRequested)
            {
                return false;
            }

            cancellationToken = cancellationTokenSource.Token;

            return true;
        }
    }
}
