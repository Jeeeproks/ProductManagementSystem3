using ProjectManagementSystem.Model;
using ProjectManagementSystem.pages;

namespace ProjectManagementSystem;

public partial class MainPage : ContentPage
{
	Users user = new Users();
    

    public MainPage()
	{
		InitializeComponent();
	}

	

    private async void txtcncel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

	private async void txtregister_Clicked(object sender, EventArgs e)
	{
        progressLoading.IsVisible = true;
        var result = await user.AddUser(txtfname.Text, txtlname.Text, txtmail.Text, txtpass.Text);
       
        if (result == true)
        {
            
            await DisplayAlert("Alert!", "Successfully Registered!", "Ok");
            progressLoading.IsVisible = false;
            
        }
        await Navigation.PushAsync(new pages.login());
        if(result == false)  
        {
            
            await DisplayAlert("Error", "There's an error to your inputs", "Ok");
            progressLoading.IsVisible = false;
        }
       
    }
}


