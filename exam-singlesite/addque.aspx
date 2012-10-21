<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addque.aspx.cs" Inherits="addque" %>

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
    
        <table cellpadding="3" cellspacing="4" class="style1">
            <tr>
                <td>
                    Subject<asp:DropDownList ID="txtSubject" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="txtSubject_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Chapter<asp:DropDownList ID="txtChapter" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">Blank</asp:ListItem>
                        <asp:ListItem Value="1">Boolean</asp:ListItem>
                        <asp:ListItem Value="2">MCQ</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    Question</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View3" runat="server">
                            Answer<br />
                            <br />
                            <asp:TextBox ID="BlankAns" runat="server"></asp:TextBox>
                            <br />
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            Ans1<br />
                            <br />
                            <asp:TextBox ID="BoolAns1" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            Ans2<br />
                            <br />
                            <asp:TextBox ID="BoolAns2" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            Correct Answer<br />
                            <br />
                            <asp:CheckBox ID="BoolAns" runat="server" />
                            <br />
                        </asp:View>
                        <asp:View ID="View1" runat="server">
                            A1<br />
                            <asp:TextBox ID="McaA1" runat="server"></asp:TextBox>
                            <br />
                            A2<br />
                            <asp:TextBox ID="McqA2" runat="server"></asp:TextBox>
                            <br />
                            A3<br />
                            <asp:TextBox ID="McqA3" runat="server"></asp:TextBox>
                            <br />
                            A4<br />
                            <asp:TextBox ID="McqA4" runat="server"></asp:TextBox>
                            <br />
                            Correct<br />
                            <asp:TextBox ID="McqCorrect" runat="server"></asp:TextBox>
                            <br />
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
    
    </div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Add" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    </form>
</body>
</html>
