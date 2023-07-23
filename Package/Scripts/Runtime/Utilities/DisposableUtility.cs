using JetBrains.Annotations;
using System;
using UnityEngine;

namespace Tequila.Utilities
{
    public static class DisposableUtility
    {
        public static bool TryDispose<T>([CanBeNull] ref T disposable)
            where T : class, IDisposable
        {
            if (disposable == null)
            {
                return false;
            }

            try
            {
                disposable.Dispose();

                return true;
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                
                return false;
            }
            finally
            {
                disposable = null;
            }
        }
    }
}
