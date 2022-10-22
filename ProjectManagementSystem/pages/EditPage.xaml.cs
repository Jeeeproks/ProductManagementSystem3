
using ProjectManagementSystem.Model;
using static ProjectManagementSystem.App;
namespace ProjectManagementSystem.pages;

public partial class EditPage : ContentPage
{
	private Products product = new();
	public EditPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {

        base.OnAppearing();
        txtprdid.Text = productid;
        txtprdname.Text = productname;
        txtorg.Text = origin;  
        

    }
    private async void txtmdy_Clicked(object sender, EventArgs e)
	{
        if (!string.IsNullOrEmpty(txtprdid.Text) || string.IsNullOrEmpty(txtprdname.Text))
        {
            var a = await product.EditData(txtprdname.Text, txtprdid.Text,txtorg.Text);
            if (!a)
            await DisplayAlert("Modify", "Data Successfully Updated", "OK");
            await Navigation.PopAsync();
            return;
        }
        await DisplayAlert("Modify", "Data Not Successfully Updated", "OK");
    }

    private async void txtcncel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();    
    }
}


