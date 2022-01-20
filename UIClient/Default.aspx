﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UIClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignalR Simple Chat</title>
    <style type="text/css">
        .container {
            background-color: #99CCFF;
            border: thick solid #808080;
            padding: 20px;
            margin: 20px;
        }
    </style>
</head>
<body>
    <div class="container">
        <label for="dealid">Enter deal id</label>
        <input id="dealid" type="text" />
        <button id="subsribefordeal">Enter</button>
        <br />

        <label id="subscription"></label>
        <ul id="discussion">
        </ul>
    </div>
    <!--Script references. -->
    <!--Reference the jQuery library. -->
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <!--Reference the SignalR library. -->
    <script src="Scripts/jquery.signalR-2.4.2.min.js"></script>
    <!--Reference the autogenerated SignalR hub script. -->
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
    <!--Add script to update the page and send messages.-->
    <script type="text/javascript">
        $(function () {
            // Declare a proxy to reference the hub.
            var chat = $.connection.chatHub;
            // Create a function that the hub can call to broadcast messages.
            chat.client.broadcastMessage = function (message) {
                // Html encode display name and message.

                var encodedMsg = $('<div />').text(message).html();
                // Add the message to the page.
                $('#discussion').append('<li><strong>' + encodedMsg + '</li>');
            };
            // Get the user name and store it to prepend to messages.

            // Set initial focus to message input box.
            $('#message').focus();
            // Start the connection.
            $.connection.hub.start().done(function () {
                $('#subsribefordeal').click(function () {
                    // Call the Send method on the hub.
                    var deslid = $('#dealid').val()

                    $("#subscription").text("subscribed messages from deal" + deslid);
                    chat.server.subscribeToDealAlert(deslid);
                    // Clear text box and reset focus for next comment.
                });
            });
        });
    </script>
    <form id="default" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
