using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ002 : ICompetenceCard
{
    string number = "002";
    string questionText = "A escuta ativa das necessidades e expectativas do p�blico-alvo � realizada de forma constante, antes, durante e ap�s o lan�amento de uma solu��o.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.CentralidadeNoCliente;




    public string GetNumber(){ return number; }
    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }

 
}
