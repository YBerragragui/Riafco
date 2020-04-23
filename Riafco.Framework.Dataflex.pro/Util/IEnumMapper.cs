namespace Riafco.Framework.Dataflex.pro.Util
{
    /// <summary>
    /// Provides contract for Enums mapper.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    public interface IEnumMapper<TSource, TTarget>
        where TSource : struct
        where TTarget : struct
    {
        /// <summary>
        /// Maps the specified Enum value to another Enum.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// An instance of <seealso cref="TTarget"/> representing the mapped value.
        /// </returns>
        TTarget Map(TSource value);
    }
}
