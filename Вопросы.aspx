<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Вопросы.aspx.cs" Inherits="Questionnaire.Вопросы" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Создание опроса</title>
    <style>
            body { background:#E1F5F9; }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <asp:Table ID="Table1" runat="server" Width="1352px">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Left" Width="450px">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Properties/2.png" Width="150" />
                    
</asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Top">
                        <asp:Label runat="server" Text="СИСТЕМА ОПРОСОВ" Font-Size="XX-Large" Font-Italic="True" Font-Bold="True"></asp:Label>
                    
</asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Right" Width="450px" VerticalAlign="Top">
                        Добро пожаловать,  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>!<br /><br />
                        <asp:Button ID="Button1" runat="server" Text="Изменить данные" OnClick="Button1_Click" Width="220" /> 
 <br />
                        <asp:Button ID="Button2" runat="server" Text="Выйти из аккаунта" OnClick="Button2_Click" Width="220" /> 
 <br />
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Left" Width="450px"></asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Center">    
                        <br /> <br />
                        <asp:Label ID="Label2" runat="server" Text="Введите вопрос:"></asp:Label>
<br />
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<br /> <br />
                        <asp:Button ID="Button3" runat="server" Text="Добавить еще вопрос" OnClick="Button3_Click" />
                        
<asp:Button ID="Button4" runat="server" Text="Готово" OnClick="Button4_Click" />
                    
</asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Right" Width="450px">
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
        </div>
    </form>
</body>
</html>
