using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    Random rnd = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        ExamDbModel.ExamDbEntities x = new ExamDbModel.ExamDbEntities();
      
        var chaps = x.Questions.Select(p => new
        {
            ChapterID = p.ChapterID,
            QuestionID = p.QuestionID,
            QuestionType = p.QuestionBlank != null ? "Blank" : p.QuestionBool != null ? "Bool" : "MCQ",
            Question = p
        }).GroupBy(p => new { p.ChapterID, p.QuestionType });


        List<Object > list = new List<Object>();

        foreach (var t in chaps)
        {
           /* list.Add(new  
            {
                ChapterID=t.Key.ChapterID,
                QuestionType=t.Key.QuestionType,
                Count = t.Count()
            });*/
            
            foreach (var k in t.OrderBy(p=>p.QuestionID*rnd.Next()).Take(3))
            {
                list.Add(k);
            }
        }

         GridView1.DataSource = list; //chaps.ToList();
         GridView1.DataBind();

        

        
    }
}