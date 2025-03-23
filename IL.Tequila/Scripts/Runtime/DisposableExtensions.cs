using System;
using System.Threading;

namespace IL.Tequila
{
    public static class DisposableExtensions
    {
        public static CancellationTokenRegistration RegisterTo(this IDisposable disposable, CancellationToken cancellationToken)
        {
            if (cancellationToken is { CanBeCanceled: true, IsCancellationRequested: false })
            {
                return cancellationToken.Register(static state => (state as IDisposable)!.Dispose(), disposable, false);
            }

            disposable.Dispose();

            return new CancellationTokenRegistration();
        }
    }
}
