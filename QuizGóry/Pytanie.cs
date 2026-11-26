namespace QuizGóry;

public class Pytanie
{
    public string Tresc { get; set; } = string.Empty;

    public List<string> Odpowiedzi { get; set; } = new();

    public string PoprawnaOdpowiedz { get; set; } = string.Empty;

    public string Obraz { get; set; } = string.Empty;
}