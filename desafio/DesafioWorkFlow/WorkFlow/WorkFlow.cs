using DesafioWorkFlow;

public class WorkFlow : IWorkFlow
{
    private readonly IPratos _pratos;
    private bool acerteiResposta = false;

    private const string SIM = "s";

    public WorkFlow(IPratos pratos)
    {
        _pratos = pratos ?? throw new ArgumentNullException(nameof(pratos));
    }

    public void ExecutarWorkFlow()
    {
        while (true)
        {
            if (IniciarJogo(out acerteiResposta))
                break;

            Console.Write("O prato que você pensou é uma massa? (s / n) \n");
            var resposta = Console.ReadLine();

            if (string.Equals(resposta, SIM, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write($"O prato que você pensou é {_pratos.ListaPratos.FirstOrDefault()}? (s / n) \n");
                resposta = Console.ReadLine();
                if (RespostaEhSim(resposta))
                {
                    Acertei();
                }
            }

            if (!acerteiResposta)
            {
                for (var i = 1; i < _pratos.ListaPratos.Count; i++)
                {
                    Console.Write($"O prato que você pensou é {_pratos.ListaPratos[i]}? (s / n) \n");
                    resposta = Console.ReadLine();
                    if (RespostaEhSim(resposta))
                    {
                        Acertei();
                        break;
                    }

                    if (_pratos.ListaPratos[i] == "Bolo de Chocolate" && resposta != SIM)
                    {
                        Errei(_pratos);
                        break;
                    }
                }
            }

            Console.Write("Tecle 'enter' para continuar ou digite 'sair' para encerrar  \n");
            resposta = Console.ReadLine();

            if (_pratos.Sair(resposta))
                break;
        }
    }

    private bool RespostaEhSim(string resposta)
    {
        return string.Equals(resposta, SIM, StringComparison.OrdinalIgnoreCase);
    }

    private void Acertei()
    {
        acerteiResposta = true;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nAcertei de novo ! \n\n");
        Console.ResetColor();
    }

    private void Errei(IPratos prato)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Qual prato você pensou? \n");
        var resposta = Console.ReadLine();
        _pratos.InserirPrato(resposta);
        Console.ResetColor();
    }

    private bool IniciarJogo(out bool acerteiResposta)
    {
        acerteiResposta = false;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Pense em um prato que gosta \n");
        Console.Write("Digite 'ok' para continuar ou tecle enter para encerrar \n");
        var continuar = Console.ReadLine();
        if (!string.Equals(continuar, "ok", StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }
}
