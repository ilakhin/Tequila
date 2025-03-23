using System.Threading;

namespace IL.Tequila
{
    public static class CancellationTokenUtility
    {
        public static readonly CancellationToken CancelledCancellationToken;

        static CancellationTokenUtility()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            CancelledCancellationToken = cancellationTokenSource.Token;

            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }
    }
}
