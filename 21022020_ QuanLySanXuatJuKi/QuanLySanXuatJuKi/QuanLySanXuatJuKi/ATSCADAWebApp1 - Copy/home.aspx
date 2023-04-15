<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="ATSCADAWebApp.home" %>

<%@ Register Assembly="iTools.Web" Namespace="ATSCADA.iWebTools" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
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

        .wrap {
            word-wrap: break-word;
            width: 90px;
        }

        .auto-style4 {
            width: 6.6%;
            height: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="main-colunm">
                <tr>
                    <td>
                        <!-- THESE LINES ARE FROM ATPROCORP, SHOULD NOT BE DELETED -->
                        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </ajaxToolkit:ToolkitScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="5000" Enabled="False">
                                </asp:Timer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
                                <td class="auto-style3" style="width: 16%; background-color: #FFFFFF;">
                                    &nbsp;</td>
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
                                                                    <td style="text-align: center; font-weight: bold" width: 0.5%;>
                                                                        </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button001" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button002" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button003" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button004" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button005" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button006" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button007" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button008" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button009" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button010" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button011" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button012" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button013" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button014" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button015" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold" width: 0.5%;>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: center; font-weight: bold" width: 0.5%;>
                                                                        </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button016" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button017" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button018" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button019" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button020" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button021" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button022" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button023" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button024" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button025" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button026" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button027" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button028" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button029" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button030" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold" width: 0.5%;>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: center; font-weight: bold" width: 0.5%;>
                                                                        </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button031" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button032" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button033" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button034" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button035" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button036" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button037" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button038" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button039" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button040" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button041" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button042" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button043" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button044" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button045" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold" width: 0.5%;>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: center; font-weight: bold" width: 0.5%;>
                                                                        </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button046" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button047" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button048" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button049" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button050" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                     <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel53" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button051" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel54" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button052" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel55" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button053" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel56" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button054" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel57" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button055" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel58" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button056" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel59" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button057" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel60" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button058" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button059" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel62" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button060" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold" width: 0.5%;>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: center; font-weight: bold" width: 0.5%;>
                                                                        </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel63" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button061" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel64" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button062" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel65" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button063" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel66" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button064" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel67" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button065" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel68" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button066" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>


                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel69" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button067" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel70" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button068" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        <asp:UpdatePanel ID="UpdatePanel71" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="Button069" runat="server" Text="Button" Height="100px" Width="100%" BackColor="Silver" OnClick="Button1_Click1" />
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">
                                                                        &nbsp;</td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold; border: 2px solid navy" class="auto-style4">

                                                                    </td>
                                                                    <td style="text-align: center; font-weight: bold" width: 0.5%;>
                                                                        </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="text-align: center; width: 100%; background-color: #FFFFFF;" colspan="17">
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
