using ProjectManagementSystem.Model;

using static ProjectManagementSystem.App;
namespace ProjectManagementSystem.pages;

public partial class HomePage : ContentPage
{
    private Products prdlist = new();
    public HomePage()
	{
		InitializeComponent();
        ListProducts.ItemsSource = prdlist.GetProductList();
    }
   
  

    private async void ListProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        App.productname = (e.CurrentSelection.FirstOrDefault() as Products)?.ProductName;
        App.key = await prdlist.GetProductKey(App.productname);
    }

    private async void edititem_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(App.key))
        {
            await Navigation.PushAsync(new EditPage());
        }
        else
        {
            
            await DisplayAlert("Data", "Please Select a Data to modify! ", "Got it!");
            
        }
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new pages.addprd());
    }

    

    private async void deleteitem_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Alert", "Are You Sure to Delete", "YES", "NO");
        if (result)
        {
            await prdlist.DeleteData();
            return;

        }
        await DisplayAlert("Alert", "Deletion not Successfully", "YES");

    }

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        ListProducts.ItemsSource = await prdlist.FindProduct(SearchBar.Text);
       if (string.IsNullOrEmpty(SearchBar.Text))
        {
            ListProducts.ItemsSource = await prdlist.GetAllProducts();
        }
       
    }
}