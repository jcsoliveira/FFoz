<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AIS Tactical Picture</title>
    <link rel="stylesheet" href="https://openlayers.org/en/v4.6.5/css/ol.css" type="text/css"/>
    <!-- Openlayers CSS file-->
     <style type="text/css">
        #map{
            width:100%;
            height:600px;
         }
    </style>
    <!--Basic styling for map div, 
    if height is not defined the div will show up with 0 px height  -->
</head>
<body>
    <form id="formATP" runat="server">
        <div id="map">
                <!-- Your map will be shown inside this div-->
        </div>
    </form>
</body>
    <script src="https://openlayers.org/en/v4.6.5/build/ol.js" type="text/javascript"></script>
    <!-- Openlayers JS file -->
    <script type="text/javascript" src="map_example4.js"> </script>
    <!-- Our map file -->
</html>
