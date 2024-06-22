using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD_Mvvm_2.Models;
using CRUD_Mvvm_2.Services;
using CRUD_Mvvm_2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRUD_Mvvm_2.ViewModels
{
    public partial class ProveedorMainViewModel: ObservableObject
    {
        // Coleccion de datos para interactuar con la vista
        [ObservableProperty]
        //private ObservableCollection<Proveedor> productoCollection = new ObservableCollection<Proveedor>();
        private ObservableCollection<Proveedor> proveedorCollection = new ObservableCollection<Proveedor>();

        // Llamamos a la clase en donde configuramos la base de datos
        private readonly ProveedorService proveedorService;

        // Constructor
        public ProveedorMainViewModel()
        {
            proveedorService = new ProveedorService();
        }

        /// <summary>
        /// Muestra el listado de proveedor
        /// </summary>
            public void GetAll()
        {
                 var getAll = proveedorService.getAll();

            // Valido si la lista contiene registros
            if (getAll?.Count() > 0)
            {
                ProveedorCollection.Clear();
                
                foreach (var proveedor in getAll)
                {
                    ProveedorCollection.Add(proveedor);
                }
            }
        }

        /// <summary>
        /// Redirecciona a la vista de agregar producto
        /// </summary>
        /// <returns>Vista de agregar producto</returns>
        [RelayCommand]
        private async Task goToAddProvedor ()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddProveedor());
        }

        /// <summary>
        /// Muestra las opciones al seleccionar un registro de proveedor
        /// </summary>
        /// <param name="proveedor">Objeto seleccionado para actualizar o eliminar</param>
        /// <returns></returns>
        [RelayCommand]
        private async Task SelectProducto(Proveedor proveedor)
        {
            try
            {
                string res = await App.Current!.MainPage!.DisplayActionSheet("Opciones", "Cancelar", null, "Actualizar", "Eliminar");

                switch (res)
                {
                    case "Actualizar":
                        //TODO descomentar cuando se cree el view model para addProveedor
                        await App.Current.MainPage.Navigation.PushAsync(new AddProveedor(proveedor));
                        break;
                    case "Eliminar":
                        bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR PROVEEDOR", "¿Desea eliminar el registro de proveedor?", "Si", "No");

                        if (respuesta)
                        {
                            int del = proveedorService.Delete(proveedor);

                            if (del > 0)
                            {
                                ProveedorCollection.Remove(proveedor);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        /// <summary>
        /// Muestra un mensaje de alerta personalizado
        /// </summary>
        /// <param name="Titulo">Titulo de la alerta, por ejemplo, ERROR, ADVERTENCIA, etc</param>
        /// <param name="Mensaje">Mensaje a mostrar en la alerta</param>
        private void Alerta(String Titulo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }
    }
}
