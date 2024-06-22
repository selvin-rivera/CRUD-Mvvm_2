using CRUD_Mvvm_2.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Mvvm_2.Models
{
    public class Proveedor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nombre { get; set; }

        public string RTN { get; set; }

        public string Ciudad { get; set; }

        public string Direccion { get; set;}

    }
}
