using CommunityToolkit.Mvvm.ComponentModel;
using CRUD_Mvvm_2.Models;
using SQLite;

namespace CRUD_Mvvm_2.Services
{
    public class ProveedorService
    {
        private readonly SQLiteConnection dbConnection;

        public ProveedorService()
        {
            // Construir ruta
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedor.db3");

            //Inicializamos el objeto
            dbConnection = new SQLiteConnection(dbPath);

            //Creamos la tabla Proveedor
            dbConnection.CreateTable<Proveedor>();
        }

        /// <summary>
        /// Lista todos los proveedores
        /// </summary>
        /// <returns>Una lista de proveedores</returns>
        public List<Proveedor> getAll()
        {
            var res = dbConnection.Table<Proveedor>().ToList();
            return res;
        }
        /// <summary>
        /// Guarda un proveedor a la base de datos
        /// </summary>
        /// <param name="proveedor">Objeto con datos del proveedor a guardar</param>
        /// <returns>Cantidad de registros ingresados</returns>
        public int Insert(Proveedor proveedor)
        {
            return dbConnection.Insert(proveedor);
        }
        /// <summary>
        /// Actualiza un proveedor seleccionado
        /// </summary>
        /// <param name="proveedor">Objeto con datos del proveedor a actualizar</param>
        /// <returns>Cantidad de resgistros actualizados</returns>
        public int Update(Proveedor proveedor)
        {
            return dbConnection.Update(proveedor);
        }
        /// <summary>
        /// Elimina un proveedor
        /// </summary>
        /// <param name="proveedor">Objeto con datos del proveedor a eliminar</param>
        /// <returns>Cantidad de resgistros eliminados</returns>
        public int Delete(Proveedor proveedor)
        {
            return dbConnection.Delete(proveedor);
        }
    }

}
