using ProjectManagementSystem.Model;

namespace ProjectManagementSystem.pages;

public partial class login : ContentPage
{
    private Users user = new();
    public login()
	{
		InitializeComponent();
	}

	private async void txtlogin_Clicked(object sender, EventArgs e)
	{
        var a = await user.UserLogin(txtemail.Text, txtpass.Text);

        progressLoading.IsVisible = true;
        if (a)
        {

            await DisplayAlert("Alert", "Access Granted", "ok!");

            Application.Current!.MainPage = new AppShell();
            progressLoading.IsVisible = false;
            return;
        }
    }

    private async void txtcncel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
