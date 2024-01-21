namespace DesafioWorkFlow;

public class Pratos : IPratos
{
    public List<string> ListaPratos { get; } = new List<string> { "Lasanha", "Bolo de Chocolate" };

    public void InserirPrato(string pratoFavorito)
    {
        if (Validar(pratoFavorito))
            ListaPratos.Insert(ListaPratos.Count - 1 , pratoFavorito);
    }

    private bool Validar(string prato)
    {
        if (!string.IsNullOrEmpty(prato) 
            && !string.IsNullOrWhiteSpace(prato)
            && prato.Length > 2)
            return true;

        Console.WriteLine("O nome do prato não pode ser nulo ou vazio e deve conter mais de 2 caracteres !!");
        return false;
    }
    
    public bool Sair(string sair)
    {
        if (string.Equals(sair, "sair", StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }
    
    public void ListarPratosInseridos()
    {
        Console.WriteLine("\nPalavras inseridas:");

        foreach (var prato in ListaPratos)
            Console.WriteLine(prato);
    }
}