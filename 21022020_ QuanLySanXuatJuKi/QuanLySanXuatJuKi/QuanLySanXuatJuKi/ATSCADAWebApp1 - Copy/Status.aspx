<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="ATSCADAWebApp.Status" %>

<%@ Register Assembly="iTools.Web" Namespace="ATSCADA.iWebTools" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Status</title>
    <style type="text/css">
        /* A scrolable div */
        .GridViewContainer
        {         
            overflow: auto;
        }
        /* to freeze column cells and its respecitve header*/
        .FrozenCell
        {
            background-color:Gray;
            position: relative;
            cursor: default;
            left: expression(document.getElementById("GridViewContainer").scrollLeft-2);
        }
        /* for freezing column header*/
        .FrozenHeader
        {
         background-color:Gray;
            position: relative;
            cursor: default;          
            top: expression(document.getElementById("GridViewContainer").scrollTop-2);
            z-index: 10;
        }
        /*for the locked columns header to stay on top*/
        .FrozenHeader.locked
        {
            z-index: 99;
        }
      
    </style>
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
        .FixedHeader {
            position: relative;
            /*font-weight: bold;*/
        }   
    </style>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
</head>
<body onload="init()">
    <form id="form1" runat="server">
        <div>
            <table class="main-colunm">
                <tr>
                    <td>
                        <!-- THESE LINES ARE FROM ATPROCORP, SHOULD NOT BE DELETED -->
                        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </ajaxToolkit:ToolkitScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick1">
                                </asp:Timer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
<%--                        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                        </asp:Timer>--%>
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
                                                        <td style="width: 33%; text-align: center; border: 4px solid fuchsia">
                                                            <table style="width: 100%; text-align: center;">

                                                                <tr>
                                                                    <td style="text-align: center; width: 100%; background-color: #FFFFFF;" colspan="9">
                                                                        <%--                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                                                                            <ContentTemplate>
                                                                        --%>
                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        </asp:UpdatePanel>
                                                                        <%--                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>--%>
                                                                    </td>
                                                                </tr>


                                                                <tr>
                                                                    <td style="text-align: center; width: 100%; background-color: #FFFFFF;" colspan="9">
                                                                        <%--                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                                                                            <ContentTemplate>
                                                                        --%>
                                                                        <asp:Label ID="Label1" runat="server" Text="Trạng Thái Các Sản Phẩm" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:GridView  style=" overflow:auto;" AutoGenerateColumns ="false" ID="GridView2" runat="server" Font-Bold="False" Font-Size="Large" HeaderStyle-CssClass ="FixedHeader" OnRowDataBound="GridView2_RowDataBound" Width="100%"  HeaderStyle-BackColor="YellowGreen">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="MaSanPham" HeaderText="Mã SP" />
                                                                                         <asp:BoundField DataField="MaLot" HeaderText="Mã Lot" />
                                                                                         <asp:BoundField DataField="TenSanPham" HeaderText=" Tên SP" />
                                                                                         <asp:BoundField DataField="SoCot" HeaderText="Số Cột" />
                                                                                         <asp:BoundField DataField="SoXe" HeaderText="Số Xe" />
                                                                                         <asp:BoundField DataField="TenCatNhungHienTai" HeaderText="Tên Cát Nhúng Hiện Tại" />
                                                                                         <asp:BoundField DataField="TenCatNhungTiepTheo" HeaderText="Tên Cát Nhúng Tiếp Theo" />
                                                                                         <asp:BoundField DataField="LopHienTai" HeaderText="Lớp Hiện Tại" />
                                                                                         <asp:BoundField DataField="LopTieuChuan" HeaderText="Lớp Tiêu Chuẩn" />
                                                                                         <asp:BoundField DataField="TG_KhoTieuChuan" HeaderText="Thời Gian Khô Tiêu Chuẩn" />
                                                                                         <asp:BoundField DataField="ThoiGianKho" HeaderText="Thời Gian Khô" />
                                                                                        <asp:BoundField DataField="NguoiPhuTrach" HeaderText="Người Phụ Trách" />
                                                                                        <asp:BoundField DataField="TrangThai" HeaderText="Trạng Thái" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                        <%--                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>--%>
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

    <%--    <script type="text/javascript" >
        function init() {

            setInterval(function () {
                 document.getElementById("Button1).click();
            }, 5000);

        }

    </script>--%>
</body>
     
<script type="text/javascript">
    //function scrollDown(el) {
    //    el.animate({
    //        scrollTop: el[0].scrollHeight
    //    }, 10000, function() {
    //        scrollUp(el)
    //    });
    //};

    //function scrollUp(el) {
    //    el.animate({
    //        scrollTop: 0
    //    }, 10000, function() {
    //        scrollDown(el);
    //    });
    //};
       // $(document).ready(function () {
            //    scrollDown($("html,body"));
            //});

    //.......................................................................................
    //$("html, body").animate({ scrollTop: $(document).height() }, 10000);
    $("#GridView2").animate({ scrollTop: $(document).height() }, 100000);
    setTimeout(function () {
        $('html, body').animate({ scrollTop: 0 }, 100000);
    }, 100000);


    setInterval(function () {
        // 4000 - it will take 4 secound in total from the top of the page to the bottom
        $("html, body").animate({ scrollTop: $(document).height() }, 100000);
        setTimeout(function () {
            $('html, body').animate({ scrollTop: 0 }, 100000);
        }, 100000);

    }, 100000);


    $('html, body').mouseover(function (e) {
        $(this).stop(true);

    }).mouseout(function () {
        $(this).stop(false);
    });
      //
   
   </script>

</html>

<style type="text/css">

table {
  text-align: left;
  position: relative;
  border-collapse: collapse; 
}
th, td {
  padding: 0.25rem;
}
tr.red th {
  background: red;
  color: white;
}
tr.green th {
  background: green;
  color: white;
}
tr.purple th {
  background: purple;
  color: white;
}
th {
  background: white;
  position: sticky;
  top: 0;
  box-shadow: 0 2px 2px -1px rgba(0, 0, 0, 0.4);
}
    </style>

