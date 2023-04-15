<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baocao.aspx.cs" Inherits="ATSCADAWebApp.baocao" %>

<%@ Register Assembly="iTools.Web" Namespace="ATSCADA.iWebTools" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>
    <style type="text/css">
        html, body {
            margin: 0;
            padding: 0;
            height: 100%;
            width: 100%;
        }

        .main-colunm {
            width: 100%;
        }

        .colunm1 {
            width: 90%;
        }

        .colunm2 {
            width: 5%;
        }

        .textarea {
            width: 100%;
            text-align: center;
            font-family: Arial;
            font-size: xx-large;
        }

        .rightjustified {
            text-align: right;
        }

        .auto-style1 {
            font-size: xx-large;
            color: #FFFFFF;
        }

        .auto-style2 {
            font-weight: bold;
        }

        .auto-style3 {
            font-size: x-large;
        }

        .auto-style4 {
            margin-left: 0px;
        }

        .auto-style5 {
            width: 2%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button19">
        <div>
            <table class="main-colunm">
                <tr>
                    <td>
                        <!-- THESE LINES ARE FROM ATPROCORP, SHOULD NOT BE DELETED -->
                        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </ajaxToolkit:ToolkitScriptManager>
                        <!--------------------END----------------------->
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFFFFF; text-align: center; border: 0px solid #FFFFFF">
                        <table class="main-colunm">
                            <tr>
                                <td style="text-align: center; background-color: #FFFFFF" class="auto-style5"></td>
                                <td style="border: thin solid #0000FF; width: 22%; text-align: center; background-color: #FFFFFF">
                                    <asp:Image ID="Image1" runat="server" Height="46px" ImageUrl="~/img/JUKI_logo.png" Width="251px" BorderStyle="None" CssClass="auto-style4" />
                                </td>
                                <td style="width: 70%; text-align: center; background-color: #0000FF;" class="auto-style1"><strong>DỮ LIỆU VÀ BÁO CÁO</strong></td>

                                <td style="width: 4%; text-align: center; background-color: #FFFFFF"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFFFFF; text-align: center; border: 0px solid #FFFFFF">
                        <table class="main-colunm">
                            <tr style="background-color: #66CCFF">

                                <td class="colunm2" style="width: 4%; text-align: center; background-color: #FFFFFF;"></td>
                                <td class="auto-style3" style="width: 16%; background-color: #FFFFFF;"></td>
                                <td class="auto-style2" style="width: 16%; text-align: center; background-color: #3399FF;">
                                    <asp:Button ID="Button66" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" Font-Bold="True" ForeColor="#0000CC" Height="100%" PostBackUrl="~/Status.aspx" Text="STATUS" Width="98%" CssClass="auto-style3" />

                                </td>
                                <td class="auto-style2" style="width: 16%; text-align: center; background-color: #3399FF;">
                                    <asp:Button ID="Button77" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" Font-Bold="True" ForeColor="#0000CC" Height="100%" PostBackUrl="~/home.aspx" Text="VIEW " Width="98%" CssClass="auto-style3" />

                                </td>
                                <td class="auto-style2" style="width: 16%; text-align: center; background-color: #3399FF;">

                                    <asp:Button ID="Button88" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" Font-Bold="True" ForeColor="#0000CC" Height="100%" PostBackUrl="~/baocao.aspx" Text="REPORT" Width="98%" CssClass="auto-style3" />

                                </td>
                                <td class="auto-style2" style="width: 12%; text-align: center; background-color: #3399FF;">

                                    <cc1:iLogout ID="iLogout1" runat="server" BackColor="White" BorderStyle="None" Font-Bold="True" ForeColor="Red" Height="100%" PostBackUrl="~/Default.aspx" Width="98%" CssClass="auto-style3" Text="LOG OUT" />

                                </td>
                                <td class="colunm2" style="width: 4%; text-align: center; background-color: #FFFFFF"></td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="align-items: center">
                        <table style="width: 100%; height: 100%; border: 10px solid Navy">
                            <tr>
                                <td>
                                    <table style="width: 100%; height: 100%; background-color: LightCyan">
                                        <tr>
                                            <td style="width: 100%; height: 100%;">
                                                <table style="width: 100%; height: 100%; background-color: LightCyan">
                                                    <tr>
                                                        <td style="width: 100%; text-align: center; border: 4px solid fuchsia">
                                                            <table style="width: 100%; text-align: center;">

                                                                <tr>
                                                                    <td style="width: 5%; text-align: center; border: 2px solid navy" class="auto-style2">BarCode</td>

                                                                    <td style="width: 15%; text-align: center; font-weight: bold; border: 2px solid navy">
                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="TextBox3" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="100%" Height="100%" Style="text-align: center" TabIndex="2" Width="98%"></asp:TextBox>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="width: 5%; text-align: center; border: 2px solid navy" class="auto-style2">FROM</td>
                                                                    <td style="width: 15%; text-align: center; font-weight: bold; border: 2px solid navy">

                                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="100%" Height="100%" Style="text-align: center" TabIndex="2" Width="98%"></asp:TextBox>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td style="width: 5%; text-align: center; font-weight: bold; border: 2px solid navy">
                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:ImageButton ID="ImageButton1" runat="server" Height="39px" ImageUrl="~/img/calendar_year.ico" Width="45px" OnClick="ImageButton1_Click" TabIndex="3" />

                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="width: 5%; text-align: center; border: 2px solid navy" class="auto-style2">TO</td>
                                                                    <td style="width: 15%; text-align: center; border: 2px solid navy">
                                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="100%" Height="100%" Style="text-align: center" TabIndex="4" Width="98%"></asp:TextBox>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td style="width: 5%; text-align: center; font-weight: bold; border: 2px solid navy">
                                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:ImageButton ID="ImageButton3" runat="server" Height="39px" ImageUrl="~/img/calendar_year.ico" OnClick="ImageButton3_Click" TabIndex="5" Width="45px" />
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td style="width: 12%; text-align: center; font-weight: bold; border: 2px solid navy">
                                                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button19" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="120%" ForeColor="Red" Height="100%" OnClick="Button19_Click" Style="text-align: center" TabIndex="4" Text="VIEW" Width="95%" />
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td style="width: 13%; text-align: center; font-weight: bold; border: 2px solid navy">

                                                                        <asp:Button ID="Button80" runat="server" Style="text-align: center" Font-Bold="True" Font-Size="120%" ForeColor="Red" Height="100%" Text="DOWLOAD" Width="95%" OnClick="Button80_Click" TabIndex="6" Font-Names="Times New Roman" />

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 5%; text-align: center; border: 2px solid navy" class="auto-style2">Lọc</td>

                                                                    <td style="width: 15%; text-align: center; font-weight: bold; border: 2px solid navy">
                                                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" Width="100%" Height="39px" Font-Bold="True">
                                                                                    <asp:ListItem>ALL</asp:ListItem>
                                                                                    <asp:ListItem>Lọc Theo Mã Sản Phẩm</asp:ListItem>
                                                                                    <asp:ListItem>Lọc Theo Mã LOT</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="text-align: center; font-weight: bold">&nbsp;</td>
                                                                    <td style="text-align: center; font-weight: bold">&nbsp;</td>

                                                                    <td style="text-align: center; font-weight: bold">&nbsp;</td>
                                                                    <td style="text-align: center; font-weight: bold">

                                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="221px" OnSelectionChanged="Calendar1_SelectionChanged" ShowGridLines="True" Visible="False" Width="100%">
                                                                                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                                    <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                                                                    <SelectorStyle BackColor="#FFCC66" />
                                                                                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                                                                </asp:Calendar>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>



                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold">&nbsp;</td>
                                                                    <td style="text-align: center;">&nbsp;</td>
                                                                    <td style="text-align: center;">
                                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="221px" OnSelectionChanged="Calendar2_SelectionChanged" ShowGridLines="True" Visible="False" Width="100%">
                                                                                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                                    <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                                                                    <SelectorStyle BackColor="#FFCC66" />
                                                                                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                                                                </asp:Calendar>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold"></td>
                                                                    <td style="text-align: center; font-weight: bold"></td>
                                                                    <td style="text-align: center; font-weight: bold"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: center; width: 100%; background-color: #FFFFFF;" colspan="10">
                                                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:GridView ID="GridView1" runat="server" Width="100%">
                                                                                    <%--                                                                                    <HeaderStyle Width="100px" />--%>
                                                                                </asp:GridView>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
