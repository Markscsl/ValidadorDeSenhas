using System.Text;
using System.Text.RegularExpressions;

namespace ValidadorDeSenhas;

public class ValidadorSenha
{
    public string ValidarSenha(string senha)
    {
        StringBuilder sb = new StringBuilder();
        if (string.IsNullOrWhiteSpace(senha))
            return "Senha não pode ser nula ou vazia.";
        
        ValidarMaiusculasMinusculasEBlock(senha, sb);
        ValidarMaximoCaracteres(senha, sb);
        ValidarMinimoCaracteres(senha, sb);
        
        if (sb.Length <= 0)
            return "Senha permitida";
        else
            return sb.ToString(); 
    }

    private void ValidarMaiusculasMinusculasEBlock(string senha, StringBuilder sb)
    {
        List<string> senhasBlock = new List<string>();
        senhasBlock.Add("abc");
        senhasBlock.Add("123");
        senhasBlock.Add("senha");
        
        var padrao = @"[!@#$.%&+=*^()_-]";
        bool temMaiuscula = false;
        bool temMinuscula = false;
        bool temNumerico = false;
        
        foreach (var c in senha)
        {
            if (char.IsUpper(c)) temMaiuscula = true;
            if (char.IsLower(c)) temMinuscula = true;
            if (char.IsDigit(c)) temNumerico = true;
        }

        foreach (string s in senhasBlock)
        {
            if (senha.Contains(s, StringComparison.OrdinalIgnoreCase))
                sb.AppendLine($"Senha não pode conter os caracteres '{s}'.");
        }

        if (senha.Contains(' ')) sb.AppendLine("A senha não deve possuir espaços em branco.");
        if (!Regex.IsMatch(senha, padrao)) sb.AppendLine("A senha deve conter ao menos 1 caractere especial.");
        if (!temMaiuscula) sb.AppendLine("A senha deve conter ao menos 1 caractere maiúsculo.");
        if (!temMinuscula) sb.AppendLine("A senha deve conter ao menos 1 caractere minúsculo.");
        if (!temNumerico) sb.AppendLine("A senha deve conter ao menos 1 número.");
    }

    private void ValidarMaximoCaracteres(string senha, StringBuilder sb)
    {
        var tamanhoMaximo = 20;
            if (senha.Length > tamanhoMaximo) sb.AppendLine("Senha deve conter no máximo 20 caracteres.");
    }

    private void ValidarMinimoCaracteres(string senha, StringBuilder sb)
    {
        var tamanhoMinimo = 8;
        if (senha.Length < tamanhoMinimo) sb.AppendLine("Senha deve conter ao menos 8 caracteres.");
    }
}