using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

 
public class RndQue
{
    public int QuestionID { get; set; }
    public int ChapterID { get; set; }
    public string QuestionType { get; set; }
    public ExamDbModel.Question Question { get; set; }
    public string UserAnswer { get; set; }
    public string CorrectAnswer { get; set; }
}