<%@ Page Title="Index" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default"%>

<script runat="server">

    
</script>
<head>
        <style type="text/css">
            #form1 {
                height: 323px;
            }
            .style1
            {
                width: 266px;
            }
            .style4
            {
                width: 3px;
                height: 57px;
            }
            .style5
            {
            }
            .style10
            {
                width: 266px;
                height: 12px;
            }
            .style11
            {
                height: 12px;
            }
            .style12
            {
                height: 12px;
                width: 3px;
            }
            .style13
            {
                width: 3px;
            }
            #Button4
            {}
            #Button5
            {}
            .style16
            {
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">

    <h1 align="center">
        Friend-list</h1>
    

        &nbsp;<table style="width:33%; height:100px" align="center">
            <tr>
                <td class="style10">
                    Recommand list:</td>
                <td class="style12">
                    </td>
                <td class="style11">
    Friend list</td>
            </tr>
            <tr>
                <td class="style1" rowspan="2">
    <asp:ListBox ID="List_recommand" runat="server" Height="162px" Width="177px" 
                        onselectedindexchanged="ListBox2_SelectedIndexChanged" 
                        SelectionMode="Multiple" style="margin-top: 0px">
    </asp:ListBox>
                </td>
                <td class="style4" align="center">
                    <asp:Button ID="Button1" runat="server" Text="&gt;&gt;" Width="65px" 
                        onclick="Button1_Click" />
                    <br />
                    <br />
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="&lt;&lt;" 
                        Width="65px" />
                </td>
                <td class="style5" rowspan="2">
                    <asp:ListBox ID="List_friends" runat="server" Height="156px" Width="191px" 
                        onselectedindexchanged="ListBox1_SelectedIndexChanged" 
                        SelectionMode="Multiple"></asp:ListBox>
                    </td>
            </tr>
            
            <tr>
                <td class="style13" align="center">
                    <br />
                    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="save" 
                        Width="63px" />
                </td>
            </tr>
            
        </table>
        <table style="width:38%;" align="center">
            <tr>
                <td align="center" class="style16">
                    <asp:Button ID="Button_Rco" runat="server" onclick="Button_Rco_Click" 
                        Text="show information" Width="136px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button_friend" runat="server" Text="show information" 
                        Width="136px" onclick="Button_friend_Click" />
                </td>
            </tr>
            <tr>
                <td align="center">
        <asp:Label ID="Label1" runat="server" Text="output information" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            
            
        </table>
    </form>
    <br><br><br>
    <p>
        How to play with this toy?<br>
        1. recommand list contains all potential friends you may know, friend list contains all friends you have added to your list.<br>
        2. select item(s) click the button &quot;&gt;&gt;&quot; or &quot;&lt;&lt;&quot; to remove or add friend(s).<br>
        3. select item, click &quot;show information&quot; to show detail information of this person 
        (each button for each list respectively).<br>
        4. click &quot;save&quot; to update the table in our database.</p>

    </body>