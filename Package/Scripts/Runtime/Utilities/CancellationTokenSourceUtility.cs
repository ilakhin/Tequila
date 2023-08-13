using System.Threading;

namespace Tequila.Utilities
{
    public static class CancellationTokenSourceUtility
    {
        public static bool TryCancelAndDispose(ref CancellationTokenSource cancellationTokenSource)
        {
            if (cancellationTokenSource == null)
            {
                return false;
            }

            if (!cancellationTokenSource.IsCancellationRequested)
            {
                cancellationTokenSource.Cancel();
            }

            return DisposableUtility.TryDispose(ref cancellationTokenSource);
        }

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
