<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaIcons.ascx.cs" Inherits="CreateModals.MediaIcons" %>
<link rel="stylesheet" href='/umbraco/plugins/CreateModals/MediaLargeIcons.css'/>
<script src='/umbraco/plugins/CreateModals/MediaIcons.js'></script>
 
<div id="header" class="header" runat="server">
    <label>Name</label><input class='namr' type="text" id="name" runat="server" />
    <div>Select a Media Type:</div>
</div>

<div id="mediaTypeWrapper" class='mediaTypeWrapper' runat="server"></div>

<div class="footer">
    <input id="mediaTypeID" class="mediaTypeID" type="text" runat="server"/>
    <input id="createButton" class="createButton" type="button" value="Create" runat="server" />
</div>
