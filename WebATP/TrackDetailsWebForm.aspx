<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrackDetailsWebForm.aspx.cs" Inherits="WebATP.TrackDetailsWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table {
            border-collapse: collapse;
            width: 200px;
            height:100px;
        }

        th, td {
            text-align: left;
            padding: 8px;
        }

        tr:nth-child(even) {
            background-color: #f2f2f2
        }

        th {
            background-color: #4CAF50;
            color: white;
        }
    </style>
</head>
<body>
    <form id="TrackDataForm" runat="server" style=" width: 200px">
        <table>
            <tr>
                <th colspan="6">Track Details</th>
            </tr>
            <tr>
                <td>Name:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>flag</td>
                <td>
                    <asp:TextBox ID="txtFlag" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Callsign:</td>
                <td>
                    <asp:TextBox ID="txtCallsign" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>MMSI:</td>
                <td>
                    <asp:TextBox ID="txtMMSI" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>IMO</td>
                <td>
                    <asp:TextBox ID="txtIMO" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Length:</td>
                <td>
                    <asp:TextBox ID="txtLength" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>Width:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtWidth" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>Draught:</td>
                <td>
                    <asp:TextBox ID="txtDraught" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Speed:</td>
                <td>
                    <asp:TextBox ID="txtSpeed" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>Course:</td>
                <td>
                    <asp:TextBox ID="txtCourse" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>Heading:</td>
                <td>
                    <asp:TextBox ID="txtHeading" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Destination:</td>
                <td>
                    <asp:TextBox ID="txtDestination" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>ETA:</td>
                <td>
                    <asp:TextBox ID="txtETA" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Type:</td>
                <td>
                    <asp:TextBox ID="txtType" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>Status:</td>
                <td>
                    <asp:TextBox ID="txtStatus" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Cargo Type:</td>
                <td>
                    <asp:TextBox ID="txtCargoType" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>
