using System.Linq;
using System.Collections.Generic;

App.Run();

public class Pesquisador
{
    public IEnumerable<Colaborador> Search(
        IEnumerable<Colaborador> collab,
        string parametro)
    {
        // List<string> listaparametro = new List<string>(parametro.Split(' '));
        // foreach(var x in collab)
        // {
        //     if(listaparametro[0] == x.Nome)
        //     {
        //         return collab;
        //     }
        //     if(listaparametro[1] == x.Cargo)
        //     {
        //         return collab;
        //     }
        //     if(listaparametro[2] == x.Setor)
        //     {
        //         return collab;
        //     }
        // }
    return collab;
    }
}

public class Colaborador
{
    public Colaborador(string nome, string cargo, string setor, string edv)
    {
        this.Nome = nome;
        this.Cargo = cargo;
        this.Setor = setor;
        this.Edv = edv;
    }

    public string Nome { get; set; }
    public string Cargo { get; set; }
    public string Setor { get; set; }
    public string Edv { get; set; }
}