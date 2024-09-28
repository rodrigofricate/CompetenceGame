using Assets.Script.Enums;
using Assets.Script.Interfaces;


using Unity.VisualScripting;
public class CompetenceQ014 : ICompetenceCard
{
    string number = "014";
    string questionText = "Convidei um grupo de clientes para participar de testes na concepção de um novo produto."; 
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.CentralidadeNoCliente;
    public string GetNumber()
    {
        return number;
    }
    public string GetTitle()
    {
        return questionText;
    }
    public EnumCompetenceAnsware GetRigthAnsware()
    {
        return rigthAnsware;
    }
}
