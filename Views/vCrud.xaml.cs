using squispeS6.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace squispeS6.Views;

public partial class vCrud : ContentPage
{
    private const string URL = "http://localhost:8080/api/bookings";
    private HttpClient cliente = new HttpClient();
    private ObservableCollection<Booking> temporal;
    public vCrud()
    {
        InitializeComponent();
        mostrarBooking();
    }

    public async void mostrarBooking()
    {
        var content = await cliente.GetStringAsync(URL);
        List<Booking> lista = JsonConvert.DeserializeObject<List<Booking>>(content);
        temporal = new ObservableCollection<Booking>(lista);
        lvBooking.ItemsSource = temporal;
    }
}