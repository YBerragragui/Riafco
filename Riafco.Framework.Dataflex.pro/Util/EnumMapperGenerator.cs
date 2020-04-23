using System;
using System.Collections.Concurrent;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace Riafco.Framework.Dataflex.pro.Util
{
    /// <summary>
    /// Represents the enum mapper generator.
    /// </summary>
    /// <typeparam name="TSource">The enum type of the source.</typeparam>
    /// <typeparam name="TTarget">The enum type of the target.</typeparam>
    public static class EnumMapperGenerator<TSource, TTarget>
        where TSource : struct
        where TTarget : struct
    {
        /// <summary>
        /// Gets or creates the map method as a <see cref="Func{TSource, TTarget}"/>.
        /// </summary>
        /// <returns>
        /// An instance of <seealso cref="Func{TSource, TTarget}"/> representing the map method.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Reviewed")]
        public static Func<TSource, TTarget> GetOrCreateMethod()
        {
            var key = typeof(TSource).GetHashCode() * 397 ^ typeof(TTarget).GetHashCode();
            return _MethodCache.GetOrAdd(key, k => EnumMapperGenerator<TSource, TTarget>.CreateLambda().Compile());
        }

        /// <summary>
        /// Gets or creates the mapper type.
        /// </summary>
        /// <returns>
        /// An instance of <seealso cref="IEnumMapper{TSource, TTarget}"/> representing the enum mapper.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Reviewed")]
        public static IEnumMapper<TSource, TTarget> GetOrCreate()
        {
            var key = typeof(TSource).GetHashCode() * 397 ^ typeof(TTarget).GetHashCode();
            return _TypeCache.GetOrAdd(key, k => EnumMapperGenerator<TSource, TTarget>.CreateInstance());
        }

        /// <summary>
        /// The Create Instance method
        /// </summary>
        /// <returns>IEnumMapper</returns>
        private static IEnumMapper<TSource, TTarget> CreateInstance()
        {
            var type = CreateType();
            return (IEnumMapper<TSource, TTarget>)Activator.CreateInstance(type);
        }

        /// <summary>
        /// The Create Map Method
        /// </summary>
        /// <returns>Func</returns>
        private static Func<TSource, TTarget> CreateMapMethod()
        {
            return CreateLambda().Compile();
        }

        /// <summary>
        /// The Get Or Create Module
        /// </summary>
        /// <returns>Module Builder</returns>
        private static ModuleBuilder GetOrCreateModule()
        {
            if (_ModuleBuilder != null) return _ModuleBuilder;
            lock (_ModuleLock)
            {
                if (_ModuleBuilder != null) return _ModuleBuilder;
                // Creates the assembly and the module.
                _AsmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(_Name, AssemblyBuilderAccess.RunAndSave);
                _ModuleBuilder = _AsmBuilder.DefineDynamicModule(_Name.Name + ".dll");
            }
            return _ModuleBuilder;
        }

        /// <summary>
        /// The create type method
        /// </summary>
        /// <returns></returns>
        private static Type CreateType()
        {
            // Gets or creates the module.
            var module = GetOrCreateModule();
            // Creates the new type.
            var type = module.DefineType(string.Format("{0}To{1}Mapper", typeof(TSource).Name, typeof(TTarget).Name));
            // Creates the static map method.
            var staticMapMethod = CreateStaticMapMethod(type);
            // Creates the map method (which call the static method).
            CreateMapMethod(type, staticMapMethod);
            // The type implements the IEnumMapper<,> interface.
            var intf = typeof(IEnumMapper<TSource, TTarget>);
            type.AddInterfaceImplementation(intf);
            // Compiles the type.
            var type0 = type.CreateType();
            // Persists the in-memory assembly to the disk.
            ////_AsmBuilder.Save(_Name.Name + ".dll"); // Uncomment to save to disk...
            return type0;
        }

        /// <summary>
        /// The Create Lambda method
        /// </summary>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Reviewed")]
        private static Expression<Func<TSource, TTarget>> CreateLambda()
        {
            //Call legacy Method
            MethodInfo genericEnumLegacy = _EnumToEnumLegacyMethod.MakeGenericMethod(typeof(TSource), typeof(TTarget));
            var parameterExpression = Expression.Parameter(typeof(TSource), "value");
            var expre = Expression.Call(genericEnumLegacy, parameterExpression);
            return Expression.Lambda<Func<TSource, TTarget>>(expre, parameterExpression);
        }

        /// <summary>
        /// The Create Static Map Method
        /// </summary>
        /// <param name="type">Type Builder</param>
        /// <returns>Method Builder</returns>
        private static MethodBuilder CreateStaticMapMethod(TypeBuilder type)
        {
            // Creates the method signature/definition.
            var method = type.DefineMethod(
                "StaticMap",
                MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.Static,
                CallingConventions.Standard,
                typeof(TTarget),
                new Type[] { typeof(TSource) });

            // Creates the lambda and compile it to the previous method.
            CreateLambda().CompileToMethod(method);

            return method;
        }

        /// <summary>
        /// The Create Map Method
        /// </summary>
        /// <param name="type">Type Builder</param>
        /// <param name="staticMapMethod">Method Builder</param>
        /// <returns>Method Builder</returns>
        private static MethodBuilder CreateMapMethod(TypeBuilder type, MethodBuilder staticMapMethod)
        {
            // Creates the method signature/definition.
            var method = type.DefineMethod(
                "Map",
                _Default,
                CallingConventions.HasThis,
                typeof(TTarget),
                new Type[] { typeof(TSource) });

            // Names the parameter.
            method.DefineParameter(1, ParameterAttributes.HasDefault, "value");

            // Creates the corresponding IL.
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_1);
            il.EmitCall(OpCodes.Call, staticMapMethod, null);
            il.Emit(OpCodes.Ret);

            return method;
        }

        /// <summary>
        /// Get Enum Values method
        /// </summary>
        /// <typeparam name="TEnum">TEnum</typeparam>
        /// <returns>EnumValue</returns>
        private static EnumValue[] GetEnumValues<TEnum>()
        {
            EnumValue[] values;
            GetEnumData<TEnum>(out values);
            return values;
        }

        // Gets all names and values of all enum members.
        // Method copied from .Net framework
        private static void GetEnumData<TEnum>(out EnumValue[] enumValues)
        {
            Contract.Ensures(Contract.ValueAtReturn<EnumValue[]>(out enumValues) != null);
            FieldInfo[] flds = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static);
            enumValues = new EnumValue[flds.Length];
            for (int i = 0; i < flds.Length; i++)
            {
                enumValues[i].Name = flds[i].Name;
                enumValues[i].Value = (TEnum)flds[i].GetRawConstantValue();
            }
        }

        private static readonly ConstructorInfo _InvalidCastExceptionMethod = typeof(InvalidCastException).GetConstructor(new Type[] { typeof(string) });
        private static readonly MethodInfo _StringFormatMethod = typeof(string).GetMethod("Format", new[] { typeof(IFormatProvider), typeof(string), typeof(object[]) });
        private static readonly MethodAttributes _Default = MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final;
        private static readonly MethodInfo _EnumToEnumLegacyMethod = typeof(Utility).GetMethod("EnumToEnumLegacy");
        private static readonly ConcurrentDictionary<int, IEnumMapper<TSource, TTarget>> _TypeCache = new ConcurrentDictionary<int, IEnumMapper<TSource, TTarget>>();
        private static readonly ConcurrentDictionary<int, Func<TSource, TTarget>> _MethodCache = new ConcurrentDictionary<int, Func<TSource, TTarget>>();

        // The name of the in-memory assembly.
        private static readonly AssemblyName _Name = new AssemblyName("OMS.Socle.Framework.Util");

        private static AssemblyBuilder _AsmBuilder;
        private static ModuleBuilder _ModuleBuilder;
        private static readonly object _ModuleLock = new object();

        // Structure to store name and value of an enum member.
        private struct EnumValue
        {
            public string Name;
            public object Value;
        }

        /// <summary>
        /// The clear cache method
        /// </summary>
        public static void ClearCache()
        {
            _TypeCache.Clear();
            _MethodCache.Clear();
        }
    }
}
