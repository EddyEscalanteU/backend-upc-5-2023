// Ignore Spelling: Categoria

namespace backend_upc_5_2023.Dominio
{
    /// <summary>
    /// Dominio de la tabla Producto
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the identifier categoría.
        /// </summary>
        /// <value>
        /// The identifier categoría.
        /// </value>
        public int IdCategoria { get; set; }

        /// <summary>
        /// Gets or sets the categoria.
        /// </summary>
        /// <value>
        /// The categoria.
        /// </value>
        public Categoria? Categoria { get; set; }
    }
}
