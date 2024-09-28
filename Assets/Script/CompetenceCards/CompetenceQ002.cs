using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ002 : ICompetenceCard
{
    string number = "002";
    string questionText = "A escuta ativa das necessidades e expectativas do público-alvo é realizada de forma constante, antes, durante e após o lançamento de uma solução.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.CentralidadeNoCliente;




    public string GetNumber(){ return number; }
    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }

 
}
