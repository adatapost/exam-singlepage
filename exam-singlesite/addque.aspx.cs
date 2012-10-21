using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addque : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ExamDbModel.ExamDbEntities x = new ExamDbModel.ExamDbEntities();

            txtSubject.DataSource = x.Subjects;
            txtSubject.DataTextField = "SubjectName";
            txtSubject.DataValueField = "SubjectID";
            txtSubject.DataBind();

            txtSubject.Items.Insert(0, new ListItem("select", "0"));

        }
    }
    protected void txtSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        ExamDbModel.ExamDbEntities x = new ExamDbModel.ExamDbEntities();
        int subjectId=int.Parse(txtSubject.SelectedValue);
        var result = x.Chapters.Where(p => p.SubjectID == subjectId).ToList();
        txtChapter.DataSource = result;
        txtChapter.DataTextField = "ChapterName";
        txtChapter.DataValueField = "ChapterID";
        txtChapter.DataBind();
        txtChapter.Items.Insert(0, new ListItem("select", "0"));

        
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = int.Parse(RadioButtonList1.SelectedValue);

        if (index == 0)
            BindBlanks();
        else
            if (index == 1)
                BindBool();
            else
                if (index == 2)
                    BindMCQ();
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }

        MultiView1.ActiveViewIndex = index;

    }

    //Blanks
    public void BindBlanks()
    {
        int chapId = int.Parse(txtChapter.SelectedValue);
        ExamDbModel.ExamDbEntities x = new ExamDbModel.ExamDbEntities();

        var result = x.Questions.Where(p => p.ChapterID == chapId).Select(p => new {
          QuestionID=p.QuestionID,
          Text= p.QuestionText,
          CorrectAnswer=p.QuestionBlank.CorrectAnswer
        }).Where(k=> !string.IsNullOrEmpty(k.CorrectAnswer));

        GridView1.DataSource = result.ToList();
        GridView1.DataBind();

    }

    //Bool
    public void BindBool()
    {
        int chapId = int.Parse(txtChapter.SelectedValue);
        ExamDbModel.ExamDbEntities x = new ExamDbModel.ExamDbEntities();

        var result = x.Questions.Where(p => p.ChapterID == chapId).Select(p => new
        {
            QuestionID = p.QuestionID,
            Text = p.QuestionText,
            Answer1=p.QuestionBool.Answer1,
            Answer2=p.QuestionBool.Answer2,
            CorrectAnswer = p.QuestionBool.CorrectAnswer
        }).Where(k => !string.IsNullOrEmpty(k.Answer1));

        GridView1.DataSource = result.ToList();
        GridView1.DataBind();

    }

    //MCQ
    public void BindMCQ()
    {
        int chapId = int.Parse(txtChapter.SelectedValue);
        ExamDbModel.ExamDbEntities x = new ExamDbModel.ExamDbEntities();

        var result = x.Questions.Where(p => p.ChapterID == chapId).Select(p => new
        {
            QuestionID = p.QuestionID,
            Text = p.QuestionText,
            Answer1 = p.QuestionMcq.Answer1,
            Answer2 = p.QuestionMcq.Answer2,
            Answer3=p.QuestionMcq.Answer3,
            Answer4=p.QuestionMcq.Answer4,
            CorrectAnswer = p.QuestionMcq.CorrectAnswer
        }).Where(k => !string.IsNullOrEmpty(k.CorrectAnswer)); ;

        GridView1.DataSource = result.ToList();
        GridView1.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExamDbModel.ExamDbEntities x = new ExamDbModel.ExamDbEntities();

        int index = int.Parse(RadioButtonList1.SelectedValue);
        ExamDbModel.Question que=new ExamDbModel.Question();
        que.QuestionText= txtQuestion.Text;
        que.ChapterID= int.Parse(txtChapter.SelectedValue);
        x.AddToQuestions(que);
        x.SaveChanges();
        switch (index)
        {
            case 0:
                //Blank
                ExamDbModel.QuestionBlank blank = new ExamDbModel.QuestionBlank();

                blank.CorrectAnswer = BlankAns.Text;
                blank.QuestionID = que.QuestionID;
                x.AddToQuestionBlanks(blank);
                x.SaveChanges();
                Label1.Text = "BlankRequestion is added";

                //Fill the grid
                BindBlanks();
                break;
            case 1: 
                //Bool

                ExamDbModel.QuestionBool boool = new ExamDbModel.QuestionBool();
                boool.QuestionID = que.QuestionID;
                boool.Answer1 = BoolAns1.Text;
                boool.Answer2 = BoolAns2.Text;
                boool.CorrectAnswer = BoolAns.Checked;
                x.AddToQuestionBools(boool);
                x.SaveChanges();

                Label1.Text = "BoolQequestion is added";
                BindBool();
                break;
            case 2: 
                //MCQ


                ExamDbModel.QuestionMcq mcq = new ExamDbModel.QuestionMcq();
                mcq.QuestionID = que.QuestionID;
                mcq.Answer1 = McaA1.Text;
                mcq.Answer2 = McqA2.Text;
                mcq.Answer3 = McqA3.Text;
                mcq.Answer4 = McqA4.Text;
                mcq.CorrectAnswer = McqCorrect.Text;

                x.AddToQuestionMcqs(mcq);
                x.SaveChanges();

                Label1.Text = "MCQQuestion is added";
                BindMCQ();
                break;

        }
    }
}