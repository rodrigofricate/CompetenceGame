using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ046 : ICompetenceCard
{

    string questionText = "Reuni um time multidisciplinar e rodamos um design sprint para a concep��o de uma nova solu��o ou produto.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Inova��o;
    string number = "046";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
