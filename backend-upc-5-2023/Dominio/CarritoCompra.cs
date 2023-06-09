// Ignore Spelling: Carrito

namespace backend_upc_5_2023.Dominio
{
    /// <summary>
    /// Dominio de la tabla CarritoCompra
    /// </summary>
    public class CarritoCompra
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier h producto.
        /// </summary>
        /// <value>
        /// The identifier h producto.
        /// </value>
        public int IdHProducto { get; set; }

        /// <summary>
        /// Gets or sets the identifier usuario.
        /// </summary>
        /// <value>
        /// The identifier usuario.
        /// </value>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Gets or sets the fecha.
        /// </summary>
        /// <value>
        /// The fecha.
        /// </value>
        public DateTime Fecha { get; set; }
    }
}
