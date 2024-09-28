using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ062 : ICompetenceCard
{

    string questionText = "Propus uma solução diferente daquela que o grupo de trabalho havia sugerido e estimulei a reflexão sobre essa mudança.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Coragem;
    string number = "062";

    public string GetNumber() { return number; }

    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
