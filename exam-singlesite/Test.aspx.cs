using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    Random rnd = new Random();

    public int Index
    {
        get
        {
            if (ViewState["Index"] == null)
                ViewState["Index"] = 0;
            return int.Parse(ViewState["Index"].ToString());

        }
        set
        {
            ViewState["Index"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ExamDbModel.ExamDbEntities x = new ExamDbModel.ExamDbEntities();

            var chaps = x.Questions.Select(p => new
            {
                ChapterID = p.ChapterID,
                QuestionID = p.QuestionID,
                QuestionType = p.QuestionBlank != null ? "Blank" : p.QuestionBool != null ? "Bool" : "MCQ",
                Question = p
            }).GroupBy(p => new { p.ChapterID, p.QuestionType });


            List<RndQue> list = new List<RndQue>();

            foreach (var t in chaps)
            {
                 

                foreach (var k in t.OrderBy(p => p.QuestionID * rnd.Next()).Take(2))
                {
                    list.Add(new RndQue
                    {
                        ChapterID = k.ChapterID.Value,
                        QuestionID = k.QuestionID,
                        QuestionType = k.QuestionType,
                        Question=k.Question,
                        CorrectAnswer = k.QuestionType=="Blank" ? k.Question.QuestionBlank.CorrectAnswer : k.QuestionType=="Bool" ? k.Question.QuestionBool.CorrectAnswer.Value.ToString() : k.Question.QuestionMcq.CorrectAnswer
                   });
                }
            }

            GridView1.DataSource = list;
            GridView1.DataBind();
            Session["list"] = list;

            ShowRecord();
        }

        
    }

    void ShowRecord()
    {
        List<RndQue> list = Session["list"] as List<RndQue>;
        if (Index >= list.Count)
        {
            Response.Redirect("Result.aspx");
        }

        RndQue que = list[Index];
        txtQuestion.Text = que.Question.QuestionText;
        txtQuestionType.Text = que.QuestionType;
        txtQuestionID.Text = que.QuestionID.ToString();

        switch (que.QuestionType)
        {
            case "Blank":
                MultiView1.ActiveViewIndex = 0;
                break;
            case "Bool":
                txtBoolAnswer.Items.Clear();
                txtBoolAnswer.Items.Add(que.Question.QuestionBool.Answer1);
                txtBoolAnswer.Items.Add(que.Question.QuestionBool.Answer2);
                MultiView1.ActiveViewIndex = 1;
                break;
            case "MCQ":
                txtMcqAnswer.Items.Clear();

                txtMcqAnswer.Items.Add(que.Question.QuestionMcq.Answer1);
                txtMcqAnswer.Items.Add(que.Question.QuestionMcq.Answer2);
                txtMcqAnswer.Items.Add(que.Question.QuestionMcq.Answer3);
                txtMcqAnswer.Items.Add(que.Question.QuestionMcq.Answer4);

                MultiView1.ActiveViewIndex = 2;
                break;
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        List<RndQue> list = Session["list"] as List<RndQue>;
        RndQue que = list[Index];
     
        switch (que.QuestionType)
        {
            case "Blank":
                que.UserAnswer = txtBlankAsnwer.Text.ToLower();
                txtBlankAsnwer.Text = "";
                break;
            case "Bool":
                que.UserAnswer = txtBoolAnswer.SelectedIndex.ToString();
                break;
            case "MCQ":
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (ListItem t in txtMcqAnswer.Items)
                {
                    sb.Append(t.Selected ? "1" : "0");
                }
                que.UserAnswer = sb.ToString();
                     
                break;
        }
        GridView1.DataSource = list;
        GridView1.DataBind();
        Index=Index+1;
        ShowRecord();

    }
}