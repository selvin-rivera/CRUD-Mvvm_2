using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD_Mvvm_2.Models;
using CRUD_Mvvm_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Mvvm_2.ViewModels
{
    public partial class AddProveedorViewModel: ObservableObject
    {  
        [ObservableProperty]
         private int id;
        [ObservableProperty]
        private string nombre;
        [ObservableProperty]
        private string rtn;
        [ObservableProperty]
        private string ciudad;
        [ObservableProperty]
        private string direccion;
    
        private readonly ProveedorService service;

    public AddProveedorViewModel()
    {
        this.service = new ProveedorService();
    }

        public AddProveedorViewModel(Proveedor proveedor)
    {
        this.id = proveedor.Id;
        this.nombre = proveedor.Nombre;
        this.rtn = proveedor.RTN;
        this.ciudad = proveedor.Ciudad;
        this.direccion = proveedor.Direccion;
        service = new ProveedorService();
    }

    private void Alerta(String Titulo, String Mensaje)
    {
        MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
    }

     [RelayCommand]
    private async Task AddUpdate()
    {
        try
        {
                Proveedor proveedor = new Proveedor()
            {
                Id = id,
                Nombre = nombre,
                RTN = rtn,
                Ciudad = ciudad,
                Direccion = direccion
            };

            if (proveedor.Nombre != null || proveedor.Nombre != "")
            {
                if (Id == 0)
                {
                    service.Insert(proveedor);
                }
                else
                {
                    service.Update(proveedor);
                }
                await App.Current!.MainPage!.Navigation.PopAsync();
            }
            else
            {
                Alerta("ADVERTENCI", "Ingrese el nombre completo");
            }
        }
        catch (Exception ex)
        {
            Alerta("ERROR", ex.Message);
        }

    }
}
}
