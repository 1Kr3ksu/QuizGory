namespace QuizGóry;

public partial class MainPage : ContentPage
{
    private readonly List<Pytanie> pytania = new()
    {
        new Pytanie
        {
            Tresc = "Które to schronisko?",
            Odpowiedzi = new List<string>
            {
                "Na Rysiance.",
                "Na Wielkiej Raczy.",
                "Na Wielkiej Rycerzowej."
            },
            PoprawnaOdpowiedz = "Na Wielkiej Raczy.",
            Obraz = "zad1.jpg"
        },

        new Pytanie
        {
            Tresc = "Zwierzę na zdjęciu to",
            Odpowiedzi = new List<string>
            {
                "owczarek.",
                "wilk.",
                "kozica."
            },
            PoprawnaOdpowiedz = "owczarek.",
            Obraz = "zad2.jpg"
        },

        new Pytanie
        {
            Tresc = "W oddali są widoczne",
            Odpowiedzi = new List<string>
            {
                "Himalaje.",
                "Alpy.",
                "Tatry."
            },
            PoprawnaOdpowiedz = "Tatry.",
            Obraz = "zad3.jpg"
        },

        new Pytanie
        {
            Tresc = "Jak nazywa się najwyższy szczyt Polski?",
            Odpowiedzi = new List<string>
            {
                "Giewont.",
                "Rysy.",
                "Śnieżka."
            },
            PoprawnaOdpowiedz = "Rysy.",
            Obraz = "zad3.jpg"
        }
    };

    private int numerPytania = 0;
    private int punkty = 0;

    public MainPage()
    {
        InitializeComponent();
        WyswietlPytanie();
    }

    private void WyswietlPytanie()
    {
        Pytanie aktualnePytanie = pytania[numerPytania];

        ObrazPytania.Source = aktualnePytanie.Obraz;
        TrescPytania.Text = aktualnePytanie.Tresc;
        TrescPytania.FontSize = 24;

        OdpowiedzPierwsza.Content = aktualnePytanie.Odpowiedzi[0];
        OdpowiedzDruga.Content = aktualnePytanie.Odpowiedzi[1];
        OdpowiedzTrzecia.Content = aktualnePytanie.Odpowiedzi[2];

        OdpowiedzPierwsza.IsChecked = false;
        OdpowiedzDruga.IsChecked = false;
        OdpowiedzTrzecia.IsChecked = false;

        PunktyLabel.Text = $"Punkty: {punkty}";
    }

    private async void OnNextClicked(object sender, EventArgs e)
    {
        string? wybranaOdpowiedz = null;

        if (OdpowiedzPierwsza.IsChecked)
        {
            wybranaOdpowiedz = OdpowiedzPierwsza.Content?.ToString();
        }
        else if (OdpowiedzDruga.IsChecked)
        {
            wybranaOdpowiedz = OdpowiedzDruga.Content?.ToString();
        }
        else if (OdpowiedzTrzecia.IsChecked)
        {
            wybranaOdpowiedz = OdpowiedzTrzecia.Content?.ToString();
        }

        if (wybranaOdpowiedz == null)
        {
            await DisplayAlert(
                "Brak odpowiedzi",
                "Wybierz jedną odpowiedź.",
                "OK");

            return;
        }

        Pytanie aktualnePytanie = pytania[numerPytania];

        if (wybranaOdpowiedz == aktualnePytanie.PoprawnaOdpowiedz)
        {
            punkty++;
        }

        numerPytania++;

        if (numerPytania >= pytania.Count)
        {
            numerPytania = 0;
        }

        WyswietlPytanie();
    }
}