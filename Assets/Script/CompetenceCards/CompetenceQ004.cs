using Assets.Script.Enums;
using Assets.Script.Interfaces;
using Unity.VisualScripting;


public class CompetenceQ004 : ICompetenceCard
{

    string number = "004";
    string questionText = "Diante da necessidade de construir uma nova solução, escutei e apliquei os feedbacks fornecidos pelos clientes.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.CentralidadeNoCliente;


    public string GetNumber() { return number; }

    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
