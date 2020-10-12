namespace DataStructures.Classes
{
    /// <summary>
    /// Node class for other data structures
    /// </summary>
    /// <typeparam name="T">Generic parameter</typeparam>
    class Node<T>
    {
        /// <summary>
        /// T-type node parameter 
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Reference to the next node
        /// </summary>
        public Node<T> Next { get; set; }

        // Class constructor 
        public Node(T data)
        {
            this.Data = data;
        }
    }
}
