using UnityEditor.Events;
using UnityEngine.Events;

namespace IL.Tequila
{
    public static class UnityEventExtensions
    {
        public static void AddPersistentListener(this UnityEvent unityEvent, UnityAction call)
        {
            UnityEventTools.AddPersistentListener(unityEvent, call);
        }

        public static void AddPersistentListener<T0>(this UnityEvent<T0> unityEvent, UnityAction<T0> call)
        {
            UnityEventTools.AddPersistentListener(unityEvent, call);
        }

        public static void AddPersistentListener<T0, T1>(this UnityEvent<T0, T1> unityEvent, UnityAction<T0, T1> call)
        {
            UnityEventTools.AddPersistentListener(unityEvent, call);
        }

        public static void AddPersistentListener<T0, T1, T2>(this UnityEvent<T0, T1, T2> unityEvent, UnityAction<T0, T1, T2> call)
        {
            UnityEventTools.AddPersistentListener(unityEvent, call);
        }

        public static void AddPersistentListener<T0, T1, T2, T3>(this UnityEvent<T0, T1, T2, T3> unityEvent, UnityAction<T0, T1, T2, T3> call)
        {
            UnityEventTools.AddPersistentListener(unityEvent, call);
        }

        public static void RegisterPersistentListener<T0, T1, T2, T3>(this UnityEvent<T0, T1, T2, T3> unityEvent, int index, UnityAction<T0, T1, T2, T3> call)
        {
            UnityEventTools.RegisterPersistentListener(unityEvent, index, call);
        }

        public static void RegisterPersistentListener<T0, T1, T2>(this UnityEvent<T0, T1, T2> unityEvent, int index, UnityAction<T0, T1, T2> call)
        {
            UnityEventTools.RegisterPersistentListener(unityEvent, index, call);
        }

        public static void RegisterPersistentListener<T0, T1>(this UnityEvent<T0, T1> unityEvent, int index, UnityAction<T0, T1> call)
        {
            UnityEventTools.RegisterPersistentListener(unityEvent, index, call);
        }

        public static void RegisterPersistentListener<T0>(this UnityEvent<T0> unityEvent, int index, UnityAction<T0> call)
        {
            UnityEventTools.RegisterPersistentListener(unityEvent, index, call);
        }

        public static void RegisterPersistentListener(this UnityEvent unityEvent, int index, UnityAction call)
        {
            UnityEventTools.RegisterPersistentListener(unityEvent, index, call);
        }
    }
}
