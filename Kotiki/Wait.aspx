<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wait.aspx.cs" Inherits="Kotiki.Wait" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Возьми кота. Публикация.</title>

</head>
<body style="background-color: #4eb5e7;">
    <form id="form1" runat="server">
    <div style="top:180px; left: 60px; width: 400px; height: 100px; position: absolute; color: white; font-family: 'arial'; font-size: 25px;">
        Подготовка публикации...
    </div>
    </form>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-50073208-1', 'kotavdom.ru');
        ga('send', 'pageview');

</script>
</body>
</html>
