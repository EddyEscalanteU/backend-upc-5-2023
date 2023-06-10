namespace backend_upc_5_2023.Dominio
{
    /// <summary>
    /// Dominio de la tabla HProducto
    /// </summary>
    public class HProducto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>m
        /// Gets or sets the cantidad.
        /// </summary>
        /// <value>
        /// The cantidad.
        /// </value>
        public int Cantidad { get; set; }

        /// <summary>
        /// Gets or sets the identifier producto.
        /// </summary>
        /// <value>
        /// The identifier producto.
        /// </value>
        public int IdProducto { get; set; }
        public int IdCarritoCompra { get; set; }
    }
}
