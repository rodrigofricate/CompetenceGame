using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ062 : ICompetenceCard
{

    string questionText = "Propus uma solu��o diferente daquela que o grupo de trabalho havia sugerido e estimulei a reflex�o sobre essa mudan�a.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Coragem;
    string number = "062";

    public string GetNumber() { return number; }

    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
