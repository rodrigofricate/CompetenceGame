using Assets.Script.Enums;
using Assets.Script.Interfaces;
using Unity.VisualScripting;


public class CompetenceQ008 : ICompetenceCard
{
    string number = "008";
    string questionText = "O(a) diretor(a) sugeriu a aplica��o de novas pesquisas de mercado para aprofundar a nossa compreens�o sobre os anseios do p�blico-alvo.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.CentralidadeNoCliente;


    public string GetNumber() { return number; }
    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
