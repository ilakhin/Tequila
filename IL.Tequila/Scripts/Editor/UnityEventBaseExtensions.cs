using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;

namespace IL.Tequila
{
    public static class UnityEventBaseExtensions
    {
        public static void AddPersistentListener(this UnityEventBase unityEventBase)
        {
            UnityEventTools.AddPersistentListener(unityEventBase);
        }

        public static void AddPersistentListener(this UnityEventBase unityEventBase, UnityAction unityAction)
        {
            UnityEventTools.AddVoidPersistentListener(unityEventBase, unityAction);
        }

        public static void AddPersistentListener(this UnityEventBase unityEventBase, UnityAction<bool> unityAction, bool argument)
        {
            UnityEventTools.AddBoolPersistentListener(unityEventBase, unityAction, argument);
        }

        public static void AddPersistentListener(this UnityEventBase unityEventBase, UnityAction<float> unityAction, float argument)
        {
            UnityEventTools.AddFloatPersistentListener(unityEventBase, unityAction, argument);
        }

        public static void AddPersistentListener(this UnityEventBase unityEventBase, UnityAction<int> unityAction, int argument)
        {
            UnityEventTools.AddIntPersistentListener(unityEventBase, unityAction, argument);
        }

        public static void AddPersistentListener<T>(this UnityEventBase unityEventBase, UnityAction<T> unityAction, T argument)
            where T : Object
        {
            UnityEventTools.AddObjectPersistentListener(unityEventBase, unityAction, argument);
        }

        public static void AddPersistentListener(this UnityEventBase unityEventBase, UnityAction<string> unityAction, string argument)
        {
            UnityEventTools.AddStringPersistentListener(unityEventBase, unityAction, argument);
        }

        public static void RegisterPersistentListener(this UnityEventBase unityEventBase, int index, UnityAction unityAction)
        {
            UnityEventTools.RegisterVoidPersistentListener(unityEventBase, index, unityAction);
        }

        public static void RegisterPersistentListener(this UnityEventBase unityEventBase, int index, UnityAction<bool> unityAction, bool argument)
        {
            UnityEventTools.RegisterBoolPersistentListener(unityEventBase, index, unityAction, argument);
        }

        public static void RegisterPersistentListener<T>(this UnityEventBase unityEventBase, int index, UnityAction<T> unityAction, T argument)
            where T : Object
        {
            UnityEventTools.RegisterObjectPersistentListener(unityEventBase, index, unityAction, argument);
        }

        public static void RegisterPersistentListener(this UnityEventBase unityEventBase, int index, UnityAction<int> unityAction, int argument)
        {
            UnityEventTools.RegisterIntPersistentListener(unityEventBase, index, unityAction, argument);
        }

        public static void RegisterPersistentListener(this UnityEventBase unityEventBase, int index, UnityAction<string> unityAction, string argument)
        {
            UnityEventTools.RegisterStringPersistentListener(unityEventBase, index, unityAction, argument);
        }

        public static void RegisterPersistentListener(this UnityEventBase unityEventBase, int index, UnityAction<float> unityAction, float argument)
        {
            UnityEventTools.RegisterFloatPersistentListener(unityEventBase, index, unityAction, argument);
        }

        public static void RemovePersistentListener<T0>(this UnityEventBase self, UnityAction<T0> unityAction)
        {
            UnityEventTools.RemovePersistentListener(self, unityAction);
        }

        public static void RemovePersistentListener(this UnityEventBase self, int index)
        {
            UnityEventTools.RemovePersistentListener(self, index);
        }

        public static void RemovePersistentListener(this UnityEventBase self, UnityAction unityAction)
        {
            UnityEventTools.RemovePersistentListener(self, unityAction);
        }

        public static void RemovePersistentListener<T0, T1>(this UnityEventBase self, UnityAction<T0, T1> unityAction)
        {
            UnityEventTools.RemovePersistentListener(self, unityAction);
        }

        public static void RemovePersistentListener<T0, T1, T2>(this UnityEventBase self, UnityAction<T0, T1, T2> unityAction)
        {
            UnityEventTools.RemovePersistentListener(self, unityAction);
        }

        public static void RemovePersistentListener<T0, T1, T2, T3>(this UnityEventBase self, UnityAction<T0, T1, T2, T3> unityAction)
        {
            UnityEventTools.RemovePersistentListener(self, unityAction);
        }

        public static void RemoveAllPersistentListeners(this UnityEventBase self)
        {
            var count = self.GetPersistentEventCount();

            for (var i = 0; i < count; ++i)
            {
                UnityEventTools.RemovePersistentListener(self, 0);
            }
        }

        public static void UnregisterPersistentListener(this UnityEventBase self, int index)
        {
            UnityEventTools.UnregisterPersistentListener(self, index);
        }

        public static void UnregisterPersistentListeners(this UnityEventBase self)
        {
            var count = self.GetPersistentEventCount();

            for (var i = 0; i < count; ++i)
            {
                UnityEventTools.UnregisterPersistentListener(self, i);
            }
        }
    }
}
