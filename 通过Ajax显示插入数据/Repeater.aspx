<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repeater.aspx.cs" Inherits="通过Ajax显示插入数据.Repeater的使用" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Repeater ID="Repeater1" runat="server">
      <%--  <HeaderTemplate>
        <p>-------------------头头头----------------</p>
        <ul>
        </HeaderTemplate>
        <ItemTemplate>
        <li>
        <%#Eval("ContactName")%>
        <%#Eval("CellPhone")%>
        <%#Eval("Email") %>
        </li>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <li style="background-color:Red">
        <%#Eval("ContactName")%>
        <%#Eval("CellPhone")%>
        <%#Eval("Email") %></li>
        </AlternatingItemTemplate>
        <SeparatorTemplate>
        <li>----------------------------------------------------</li>
        </SeparatorTemplate>
        <FooterTemplate>
        </ul>
        <p>
        -------------------尾尾尾----------------------
        </p>
       
        </FooterTemplate>--%>

        <HeaderTemplate>
            <table border="1" cellpadding="2" cellspacing="2">
               <thead>
               <tr>
               <th>标号</th>
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
          <td>
              <asp:HyperLink ID="HyperLink1" runat="server">编辑</asp:HyperLink> </td>
          <td>
              <asp:LinkButton ID="LinkButton2" runat="server">删除</asp:LinkButton></td>
          </tr>
         
        </ItemTemplate>
        <AlternatingItemTemplate>
         
          <tr style="background-color:Yellow">
          <td><%#Eval("ContactId")%></td>
          <td><%#Eval("ContactName")%></td>
          <td><%#Eval("CellPhone")%></td>
          <td><%#Eval("Email")%></td>
          <td><a href="#">  <asp:HyperLink ID="HyperLink1" runat="server">编辑</asp:HyperLink></a></td>
          <td>
              <asp:LinkButton ID="LinkButton1" runat="server">删除</asp:LinkButton></td>
          </tr>
          
        </AlternatingItemTemplate>
        <FooterTemplate>
         </table>
        </FooterTemplate>
        </asp:Repeater>
    
    </div>
    <p>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </p>
    </form>
</body>
</html>
