<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID,Mess_ID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Mess_ID" HeaderText="Mess_ID" ReadOnly="True" SortExpression="Mess_ID" />
                    <asp:BoundField DataField="MMSI" HeaderText="MMSI" SortExpression="MMSI" />
                    <asp:BoundField DataField="Latitude" HeaderText="Latitude" SortExpression="Latitude" />
                    <asp:BoundField DataField="Longitude" HeaderText="Longitude" SortExpression="Longitude" />
                    <asp:BoundField DataField="SOG" HeaderText="SOG" SortExpression="SOG" />
                    <asp:BoundField DataField="COG" HeaderText="COG" SortExpression="COG" />
                    <asp:BoundField DataField="Mess_time" HeaderText="Mess_time" SortExpression="Mess_time" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FFoz_SeaTrialConnectionString %>" SelectCommand="SELECT [ID], [Mess_ID], [MMSI], [Latitude], [Longitude], [SOG], [COG], [Mess_time] FROM [BS_AIS]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
