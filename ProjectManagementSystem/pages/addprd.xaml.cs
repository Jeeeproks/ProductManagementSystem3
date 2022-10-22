
using ProjectManagementSystem.Model;

namespace ProjectManagementSystem.pages;
public partial class addprd : ContentPage
{
    Products product = new Products();
	public addprd()
	{
		InitializeComponent();
	}

	private async void txtadd_Clicked(object sender, EventArgs e)
	{
        var result = await product.AddPrd(txtprdid.Text, txtpname.Text, txtorigin.Text);

        if (result == true)
        {

            await DisplayAlert("Alert!", "Successfully Added!", "Ok");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "There's an error to your inputs", "Ok");
            return;
        }
    }

    private async void txtcncel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}