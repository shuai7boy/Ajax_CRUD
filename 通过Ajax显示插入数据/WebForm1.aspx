<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="通过Ajax显示插入数据.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table border="1" cellpadding="2" cellspacing="2">
              <thead>
              <tr>
              <th>编号</th>
              <th>姓名</th>
              <th>电话</th>
              <th>邮箱</th>
              <th>分组</th>
              <th colspan="2">操作</th>             
              </tr>
              </thead>           
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td><%#Eval("ContactId")%></td>
        <td><%#Eval("ContactName")%></td>
        <td><%#Eval("CellPhone")%></td>
        <td><%#Eval("Email")%></td>
        <td><%#Eval("GroupId")%></td>
        <td>
            <asp:HyperLink ID="HyperLink1" runat="server">编辑</asp:HyperLink>
        </td>
        <td>
            <asp:LinkButton ID="LinkButton1" runat="server">删除</asp:LinkButton>
        </td>
        </tr>
        </ItemTemplate>       
        <AlternatingItemTemplate>
         <tr style="background-color:Yellow">
        <td><%#Eval("ContactId")%></td>
        <td><%#Eval("ContactName")%></td>
        <td><%#Eval("CellPhone")%></td>
        <td><%#Eval("Email")%></td>
        <td><%#Eval("GroupId")%></td>
        <td>
            <asp:HyperLink ID="HyperLink1" runat="server">编辑</asp:HyperLink>
        </td>
        <td>
            <asp:LinkButton ID="LinkButton1" runat="server">删除</asp:LinkButton>
        </td>
        </tr>
        </AlternatingItemTemplate><%-- AlternatingItemTemplate 类似于 ItemTemplate 元素，但在 DataList 控件中隔行（交替行）呈现。通过设置 AlternatingItemTemplate 元素的样式属性，可以为其指定不同的外观。--%>
        <FooterTemplate>
         </table>
        </FooterTemplate>
        </asp:Repeater>
    
    </div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</body>
</html>
