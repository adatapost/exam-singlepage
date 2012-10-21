using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<RndQue> list = Session["list"] as List<RndQue>;

        if (list != null)
        {
            foreach (RndQue q in list)
            {
                Response.Write("<br/> Question : " + q.Question.QuestionText + "  : " + ( q.UserAnswer==q.CorrectAnswer));
                
            }
        }

    }
}