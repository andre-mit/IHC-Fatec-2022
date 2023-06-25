namespace Venda.Shared.ViewModel.CorViewModels;

public class ListaCorViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string RGB { get; set; }

    public ListaCorViewModel()
    {
        
    }

    public ListaCorViewModel(int id, string nome, string rgb)
    {
        Id = id;
        Nome = nome;
        RGB = rgb;
    }
}