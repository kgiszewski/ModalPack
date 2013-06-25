<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentIcons.ascx.cs" Inherits="CreateModals.ContentIcons" %>
<link rel="stylesheet" href='/umbraco/plugins/CreateModals/ContentLargeIcons.css'/>
<script src='/umbraco/plugins/CreateModals/ContentIcons.js'></script>
 
<div id="header" class="header" runat="server">
    <label>Name</label><input class='name' type="text" id="name" runat="server" />
    <div>Select a Document Type:</div>
</div>

<div id="docTypeWrapper" class='docTypeWrapper' runat="server"></div>

<div class="footer">
    <input id="docTypeID" class="docTypeID" type="text" runat="server"/>
    <input id="createButton" class="createButton" type="button" value="Create" runat="server" />
</div>
