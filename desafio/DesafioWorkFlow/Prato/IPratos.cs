namespace DesafioWorkFlow;

public interface IPratos
{
    public List<string> ListaPratos { get; }

    public void InserirPrato(string pratoFavorito);

    public bool Sair(string sair);

    public void ListarPratosInseridos();
}