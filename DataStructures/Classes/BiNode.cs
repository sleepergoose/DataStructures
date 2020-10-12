using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Classes
{
    /// <summary>
    /// Node class for other data structures
    /// </summary>
    /// <typeparam name="T">Generic parameter</typeparam>
    class BiNode<T>
    {
        /// <summary>
        /// T-type node parameter 
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Reference to the next node
        /// </summary>
        public BiNode<T> Next { get; set; }

        /// <summary>
        /// Reference to the previous node
        /// </summary>
        public BiNode<T> Previous { get; set; }

        // Class constructor 
        public BiNode(T data)
        {
            this.Data = data;
        }
    }
}
