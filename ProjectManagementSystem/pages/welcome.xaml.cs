namespace ProjectManagementSystem.pages;

public partial class welcome : ContentPage
{
	public welcome()
	{
		InitializeComponent();
	}

	private async void txtstart_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new MainPage());
    }

	private async void txtacct_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new pages.login());
	}
}