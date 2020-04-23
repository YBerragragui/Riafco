using System;

namespace Riafco.Framework.Dataflex.pro.Util
{
    /// <summary>
    /// Represents the enum mapper static facade.
    /// </summary>
    public static class EnumMapper
    {
        /// <summary>
        /// Maps the specified value to a value from the target enum.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="value">The source value.</param>
        /// <returns>
        /// An instance of <seealso cref="TTarget"/> representing the target value.
        /// </returns>
        /// <exception cref="System.InvalidCastException"> TSource and TTarget must be Enum.</exception>
        public static TTarget Map<TSource, TTarget>(TSource value)
            where TSource : struct
            where TTarget : struct
        {
            if (!typeof(TSource).IsEnum) { throw new InvalidCastException("TSource must be an Enum"); }
            if (!typeof(TTarget).IsEnum) { throw new InvalidCastException("TTarget must be an Enum"); }

            return EnumMapperGenerator<TSource, TTarget>.GetOrCreateMethod()(value);
        }

        /// <summary>
        /// Gets the mapper from TSource to TTarget.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <returns>
        /// An instance of <seealso cref="IEnumMapper{TSource, TTarget}"/> representing the enum mapper.
        /// </returns>
        /// <exception cref="System.InvalidCastException"> TSource and TTarget must be Enum.</exception>
        public static IEnumMapper<TSource, TTarget> GetMapper<TSource, TTarget>()
            where TSource : struct
            where TTarget : struct
        {
            if (!typeof(TSource).IsEnum) { throw new InvalidCastException("TSource must be an Enum"); }
            if (!typeof(TTarget).IsEnum) { throw new InvalidCastException("TTarget must be an Enum"); }

            return EnumMapperGenerator<TSource, TTarget>.GetOrCreate();
        }
    }
}
