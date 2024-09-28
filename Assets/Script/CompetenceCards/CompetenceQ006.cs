using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ006 : ICompetenceCard
{

    string number = "006";
    string questionText = "Sempre busco feedbacks das minhas entregas. Assim, posso melhorá-las constantemente.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.CentralidadeNoCliente;


    public string GetNumber() { return number; }
    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
