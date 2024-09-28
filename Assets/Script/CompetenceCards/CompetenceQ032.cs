using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ032 : ICompetenceCard
{

    string questionText = "Estudei as ferramentas da Microsoft e encontrei, nos aplicativos dispon�veis, sugest�es que podem ajudar nos processos da minha �rea.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.HabilidadeDigital;
    string number = "032";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
