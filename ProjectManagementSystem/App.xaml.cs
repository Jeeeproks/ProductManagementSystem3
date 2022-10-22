using Firebase.Database;
using ProjectManagementSystem.pages;

namespace ProjectManagementSystem;

public partial class App : Application
{
    public static FirebaseClient client = new("https://myfirstdb-91176-default-rtdb.asia-southeast1.firebasedatabase.app/");
    public static string productid,productname,origin, key;
    public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new pages.welcome());
	}
}
