<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="3" cellspacing="4" class="style1">
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        QuestionID :
                        <asp:Label ID="txtQuestionID" runat="server"></asp:Label>
                        <br />
                        Question :
                        <asp:Label ID="txtQuestion" runat="server"></asp:Label>
                        &nbsp;(<asp:Label ID="txtQuestionType" runat="server"></asp:Label>
                        )</td>
                </tr>
                <tr>
                    <td>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View3" runat="server">
                                Blank Answer :<asp:TextBox ID="txtBlankAsnwer" runat="server"></asp:TextBox>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <asp:RadioButtonList ID="txtBoolAnswer" runat="server">
                                </asp:RadioButtonList>
                            </asp:View>
                            <asp:View ID="View1" runat="server">
                                <asp:CheckBoxList ID="txtMcqAnswer" runat="server">
                                </asp:CheckBoxList>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Next" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
