#if IL_TEQUILA_LOCALIZATION_SUPPORT
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Localization;

namespace IL.Tequila
{
    public static class LocalizedStringExtensions
    {
        private static readonly List<object> TempArguments = new(4);

        public static void SetArguments(this LocalizedString localizedString, object argument0)
        {
            try
            {
                TempArguments.Add(argument0);

                SetArguments(localizedString, TempArguments);
            }
            finally
            {
                TempArguments.Clear();
            }
        }

        public static void SetArguments(this LocalizedString localizedString, object argument0, object argument1)
        {
            try
            {
                TempArguments.Add(argument0);
                TempArguments.Add(argument1);

                SetArguments(localizedString, TempArguments);
            }
            finally
            {
                TempArguments.Clear();
            }
        }

        public static void SetArguments(this LocalizedString localizedString, object argument0, object argument1, object argument2)
        {
            try
            {
                TempArguments.Add(argument0);
                TempArguments.Add(argument1);
                TempArguments.Add(argument2);

                SetArguments(localizedString, TempArguments);
            }
            finally
            {
                TempArguments.Clear();
            }
        }

        public static void SetArguments(this LocalizedString localizedString, object argument0, object argument1, object argument2, object argument3)
        {
            try
            {
                TempArguments.Add(argument0);
                TempArguments.Add(argument1);
                TempArguments.Add(argument2);
                TempArguments.Add(argument3);

                SetArguments(localizedString, TempArguments);
            }
            finally
            {
                TempArguments.Clear();
            }
        }

        public static void SetArguments(this LocalizedString localizedString, IEnumerable<object> arguments)
        {
            if (arguments is IReadOnlyList<object> readOnlyList)
            {
                SetArguments(localizedString, readOnlyList);

                return;
            }

            try
            {
                TempArguments.AddRange(arguments);

                SetArguments(localizedString, TempArguments);
            }
            finally
            {
                TempArguments.Clear();
            }
        }

        public static void SetArguments(this LocalizedString localizedString, IReadOnlyList<object> arguments)
        {
            if (!TryReplaceArguments(localizedString, arguments))
            {
                localizedString.Arguments = arguments.ToArray();
            }
        }

        public static bool TryReplaceArguments(this LocalizedString localizedString, IReadOnlyList<object> arguments)
        {
            var currentArguments = localizedString.Arguments;

            switch (currentArguments)
            {
                case null:
                {
                    return false;
                }
                case object[] array:
                {
                    var count = arguments.Count;

                    if (array.Length < count)
                    {
                        return false;
                    }

                    for (var i = 0; i < count; i++)
                    {
                        array[i] = arguments[i];
                    }

                    return true;
                }
                default:
                {
                    if (currentArguments.IsReadOnly)
                    {
                        return false;
                    }

                    currentArguments.Clear();
                    currentArguments.AddRange(arguments);

                    return true;
                }
            }
        }
    }
}
#endif
