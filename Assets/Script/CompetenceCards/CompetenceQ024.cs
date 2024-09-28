using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ024 : ICompetenceCard
{

    string questionText = "Utilizei uma metodologia ágil para atingir os objetivos propostos para minha área.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.HabilidadeDigital;
    string number = "024";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
