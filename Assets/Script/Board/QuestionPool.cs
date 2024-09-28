using Assets.Script.ChallangeCards;
using Assets.Script.Interfaces;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPool 
{
    List<ICompetenceCard> competencePile = new List<ICompetenceCard>();
    List<IChallangeCard> challangePile = new List<IChallangeCard>();

    public QuestionPool()
    {
        FillCompetencePille();
        FillChallangePille();
    }


    //[***********Método privados***********]
    void FillCompetencePille()
    {
        competencePile.Add(new CompetenceQ002());
        competencePile.Add(new CompetenceQ004());
        competencePile.Add(new CompetenceQ006());
        competencePile.Add(new CompetenceQ008());
        competencePile.Add(new CompetenceQ010());
        //
        competencePile.Add(new CompetenceQ012());
        competencePile.Add(new CompetenceQ014());
        competencePile.Add(new CompetenceQ016());
        competencePile.Add(new CompetenceQ018());
        competencePile.Add(new CompetenceQ020());
        //
        competencePile.Add(new CompetenceQ022());
        competencePile.Add(new CompetenceQ024());
        competencePile.Add(new CompetenceQ026());
        competencePile.Add(new CompetenceQ028());
        competencePile.Add(new CompetenceQ030());
        //
        competencePile.Add(new CompetenceQ032());
        competencePile.Add(new CompetenceQ034());
        competencePile.Add(new CompetenceQ036());
        competencePile.Add(new CompetenceQ038());
        competencePile.Add(new CompetenceQ040());
        //
        competencePile.Add(new CompetenceQ042());
        competencePile.Add(new CompetenceQ044());
        competencePile.Add(new CompetenceQ046());
        competencePile.Add(new CompetenceQ048());
        competencePile.Add(new CompetenceQ050());
        //
        competencePile.Add(new CompetenceQ052());
        competencePile.Add(new CompetenceQ054());
        competencePile.Add(new CompetenceQ056());
        competencePile.Add(new CompetenceQ058());
        competencePile.Add(new CompetenceQ060());
        //
        competencePile.Add(new CompetenceQ062());
        competencePile.Add(new CompetenceQ064());
       
    }
    void FillChallangePille()
    {
        challangePile.Add(new ChallangeQ001());
        challangePile.Add(new ChallangeQ005());
        challangePile.Add(new ChallangeQ009());
        //
        challangePile.Add(new ChallangeQ013());
        //
        challangePile.Add(new ChallangeQ021());
        challangePile.Add(new ChallangeQ025());
        challangePile.Add(new ChallangeQ029());
        //
        challangePile.Add(new ChallangeQ033());
        challangePile.Add(new ChallangeQ037());
        //
        challangePile.Add(new ChallangeQ041());
        challangePile.Add(new ChallangeQ045());
        //
        challangePile.Add(new ChallangeQ053());
        challangePile.Add(new ChallangeQ057());
        //
        challangePile.Add(new ChallangeQ061());
        challangePile.Add(new ChallangeQ065());
        challangePile.Add(new ChallangeQ067());
        //
        challangePile.Add(new ChallangeQ083());
        challangePile.Add(new ChallangeQ087());
        //
        challangePile.Add(new ChallangeQ093());


    }


    //[***********Método públicos***********]
    public ICompetenceCard DrawRandomCompetenceCard()
    {
        int _Random = Random.Range(0,competencePile.Count);
        ICompetenceCard competenceCard = competencePile[_Random];
        competencePile.Remove(competenceCard);

        if (competencePile.Count == 0) { FillCompetencePille(); }

        return competenceCard;
    }
    public IChallangeCard DrawRandomChallangeCard()
    {
        int _Random = Random.Range(0, challangePile.Count);
        IChallangeCard challangeCard = challangePile[_Random];
        challangePile.Remove(challangeCard);

        if (challangePile.Count == 0) { FillChallangePille(); }

        return challangeCard;
    }
}
