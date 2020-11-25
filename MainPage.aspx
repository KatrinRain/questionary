<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Questionnaire.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Система опросов</title>

    <style>
            body { background:#E1F5F9; }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server" Width="1352px">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Left" Width="450px">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Properties/2.png" Height="150" />
                    </asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Top">
                        <asp:Label runat="server" Text="СИСТЕМА ОПРОСОВ" Font-Size="XX-Large" Font-Italic="True" Font-Bold="True"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Right" Width="450px" VerticalAlign="Top">
                        Логин  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> <br />
                        Пароль  <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br /><br />
                        <asp:Button ID="Button1" runat="server" Text="Войти как респондент" OnClick="Button1_Click" Width="220" /><br />
                        <asp:Button ID="Button2" runat="server" Text="Войти как сотрудник" OnClick="Button2_Click"  Width="220"/>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Justify">
                        <br /><br /><br />
                        ~Описание сайта, что-то интересное~
                        <br /><br />
                        Для того, чтобы начать прохождение опроса, пожалуйста, авторизируйтесь на сайте.
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Left" Width="450px"></asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        <br /><br /><br /><br /><br /><br /><br /><br /><br />
                        <br /><br /><br />
                        По вопросам, пишите на почту:
                        <br /><br />
                        Разработчик сайта:
                        <br />
                        2020 г.
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        
    </form>
</body>
</html>
