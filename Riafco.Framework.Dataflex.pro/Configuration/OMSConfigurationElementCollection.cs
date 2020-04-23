using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Riafco.Framework.Dataflex.pro.Configuration
{
    /// <summary>
    /// The OMS Configuration Element Collection class
    /// </summary>
    public abstract class OmsConfigurationElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OmsConfigurationElementCollection"/> class.
        /// </summary>
        protected OmsConfigurationElementCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OmsConfigurationElementCollection"/> class.
        /// </summary>
        /// <param name="comparer">The <see cref="T:System.Collections.IComparer" /> comparer to use.</param>
        protected OmsConfigurationElementCollection(IComparer comparer)
            : base(comparer)
        {
        }
    }

    /// <summary>
    /// The Neotech configuration element collection override.
    /// </summary>
    /// <typeparam name="T">ConfigurationElement type.</typeparam>
    public abstract class OmsConfigurationElementCollection<T> : OmsConfigurationElementCollection, ICollection<T>
        where T : ConfigurationElement
    {
        /// <summary>
        /// Gets the <see cref="T"/> with the specified name.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="name">The name.</param>
        /// <returns>The specified item.</returns>
        public new T this[string name] => (T)BaseGet(name);

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        public void Add(T item)
        {
            BaseAdd(item);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public void Clear()
        {
            BaseClear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        /// true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.
        /// </returns>
        public bool Contains(T item)
        {
            return BaseIndexOf(item) >= 0;
        }

        /// <summary>
        /// Copies the elements of the OMSConfigurationElementCollection{T} to an <see cref="System.Array">array</see>.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            int index = 0;
            foreach (var item in this)
            {
                array[index] = item;
                ++index;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        bool ICollection<T>.IsReadOnly => IsReadOnly();

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        /// true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public bool Remove(T item)
        {
            if (!Contains(item)) return false;
            BaseRemove(item);
            return true;
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.IEnumerator" /> which is used to iterate through the <see cref="T:System.Configuration.ConfigurationElementCollection" />.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> which is used to iterate through the <see cref="T:System.Configuration.ConfigurationElementCollection" />
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return base.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public new IEnumerator<T> GetEnumerator()
        {
            return new GenericEnumeratorWrapper<T>(base.GetEnumerator());
        }
    }

    /// <summary>
    /// Generic wrapper from IEnumerator to IEnumerator&lt;T&gt;.
    /// </summary>
    /// <typeparam name="T">Type of the Enumerator.</typeparam>
    public sealed class GenericEnumeratorWrapper<T> : IEnumerator<T>
    {
        /// <summary>
        /// Enumerator wrapped.
        /// </summary>
        private IEnumerator _wrappedEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericEnumeratorWrapper&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="wrappedEnumerator">The wrapped enumerator.</param>
        public GenericEnumeratorWrapper(IEnumerator wrappedEnumerator)
        {
            _wrappedEnumerator = wrappedEnumerator;
        }

        /// <inheritdoc />
        T IEnumerator<T>.Current => (T)_wrappedEnumerator.Current;

        /// <inheritdoc />
        object IEnumerator.Current => _wrappedEnumerator.Current;

        /// <inheritdoc />
        void IDisposable.Dispose()
        {
            _wrappedEnumerator = null;
        }

        /// <inheritdoc />
        bool IEnumerator.MoveNext()
        {
            return _wrappedEnumerator.MoveNext();
        }

        /// <inheritdoc />
        void IEnumerator.Reset()
        {
            _wrappedEnumerator.Reset();
        }
    }
}
