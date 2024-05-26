using System;
using UnityEngine;

namespace CS.Utilities
{
    /// <summary>
    /// This class is a generic data container that can be used to store any type of data.
    /// Any changes to the data will trigger the OnValueChanged event passing the new value.
    /// Any data container of specific struct type (eg. int, float) that needs to store data should inherit from this class.
    /// </summary>
    public abstract class GenericDataContainerSO<T> : ScriptableObject where T : struct
    {
        /// <summary>
        /// Get the value stored in the container.
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// The event that will be triggered when the data is changed.
        /// </summary>
        public Action OnDataChanged;

        /// <summary>
        /// Store the data in the container and trigger the OnValueChanged event.
        /// </summary>
        public void SetData(T data)
        {
            Data = data;
            OnDataChanged?.Invoke();
        }
    }
}