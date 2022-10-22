using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectManagementSystem.App;
namespace ProjectManagementSystem.Model
{  
    public class Products
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Origin { get; set; }
        
        

        public async Task<bool> AddPrd(string p_id, string pname, string origin)
        {
            try
            {
                var prdadd = (await client
                    .Child("Products")
                    .OnceAsync<Products>())
                    .FirstOrDefault
                    (b => b.Object.ProductName == pname );
                if (prdadd == null)
                {
                    var product = new Products()
                    {
                        ProductId = p_id,
                        ProductName = pname,
                        Origin = origin,
                       
                    };
                    await client.Child("Products").PostAsync(product);
                    client.Dispose();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                return false;

            }
            

            }
        public async Task<string> GetProductKey(string prdname)
        {
            try
            {
                var getuserkey = (await client.Child("Products").OnceAsync<Products>()).
                    FirstOrDefault(a => a.Object.ProductName == prdname);
                if (getuserkey == null) return null;

                productid = getuserkey.Object.ProductId;
                productname = getuserkey.Object.ProductName;
                origin = getuserkey.Object.Origin;
               
                return getuserkey?.Key;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<bool> EditData(string prdname, string prdid,string origin)
        {
            try
            {
                var evalutePrd = (await client
                    .Child("Products")
                    .OnceAsync<Products>())
                    .FirstOrDefault
                    (a => a.Object.ProductName == productname );
                if (evalutePrd != null)
                {
                    Products product = new Products
                    {
                        ProductId = prdid,
                        ProductName = prdname,
                        Origin = origin
                        
                    };
                    await client.Child("Products").Child(key).PatchAsync(product);
                    client.Dispose();
                }
                client.Dispose();
                return false;
            }
            catch (Exception ex)
            {
                client.Dispose();
                return false;
            }
        }
        public async Task<string> DeleteData()
        {
            try
            {
                await client
                    .Child($"Products/{key}")
                    .DeleteAsync();
                return "removed";
            }
            catch (Exception ex)
            {
                return " error";
            }
        }
        //Getting All data
        public async Task<List<Products>> GetAllProducts()
        {

            return (await client
                .Child("Products")
                .OnceAsync<Products>()).Select(item => new Products
                {
                    ProductId = item.Object.ProductId,
                    ProductName = item.Object.ProductName,
                    Origin = item.Object.Origin
                }).ToList();
        }

        //Actual query of the data
        public async Task<List<Products>> FindProduct(string prdname)
        {
            var queryProducts = await GetAllProducts();
            await client
                .Child("Products")
                .OnceAsync<Products>();
            return queryProducts.Where(a => string.Equals(a.ProductName, prdname, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
        public ObservableCollection<Products> GetProductList()
        {
            var prdlist = client
                 .Child("Products")
                .AsObservable<Products>()
                .AsObservableCollection();
            return prdlist;

        }
        
    }
    }

