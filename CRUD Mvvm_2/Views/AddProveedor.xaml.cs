using CRUD_Mvvm_2.Models;
using CRUD_Mvvm_2.ViewModels;

namespace CRUD_Mvvm_2.Views;

public partial class AddProveedor : ContentPage
{
    private AddProveedorViewModel ViewModels;
    public AddProveedor()
	{
		InitializeComponent();
        ViewModels = new AddProveedorViewModel();
        this.BindingContext = ViewModels;     
    }
    public AddProveedor(Proveedor proveedor)
    {
        InitializeComponent();
        ViewModels = new AddProveedorViewModel(proveedor);
        this.BindingContext = ViewModels;
    }
}