using System;
using System.Collections.Generic;

public class Veiculo
{
    private List<string> id = new List<string>();
    private List<string> nome = new List<string>();
    private List<string> cpf = new List<string>();
    private List<string> cnh = new List<string>();
    private List<string> placa = new List<string>();
    private List<string> senha = new List<string>();
    private List<int> plano = new List<int>();

    public List<string> Id
    {
        get { return id; }
        set { id = value; }
    }

    public List<string> Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public List<string> CPF
    {
        get { return cpf; }
        set { cpf = value; }
    }

    public List<string> CNH
    {
        get { return cnh; }
        set { cnh = value; }
    }

    public List<string> Placa
    {
        get { return placa; }
        set { placa = value; }
    }

    public List<string> Senha
    {
        get { return senha; }
        set { senha = value; }
    }

    public List<int> Plano
    {
        get { return plano; }
        set { plano = value; }
    }

    public Veiculo()
    {
       
       
    }
}