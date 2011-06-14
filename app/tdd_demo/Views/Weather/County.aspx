<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>County</title>
    <script type="text/javascript" src="../../Scripts/jquery-1.5.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#show_when_odd').hide();
            $('#btnHello').attr('disabled', 'disabled');

            $('#btnHello').click(function () { alert('hello world'); });

            $('#get_json').click(
                function () {
                    $('#show_when_odd').hide();
                    $('#btnHello').attr('disabled', 'disabled');

                    var county = $('#txtCounty').val();
                    if ($.trim(county).length === 0) {
                        county = 'Montgomery';
                    }

                    $.getJSON('/Weather/CountyJSON/' + county,
                              function (data) {
                                  html_str = data.Description;
                                  html_str += '<br />' + data.Seconds;
                                  html_str += '<br />' + data.SecondsAreOdd;
                                  $('#json_results').html(html_str);

                                  if (data.SecondsAreOdd) {
                                      $('#show_when_odd').show();
                                  }
                                  else {
                                      console.log('got to here');
                                      $('#btnHello').removeAttr('disabled');
                                  }
                              });
                });
        });
    
    </script>
</head>
<body>
    <h4>Weather/County</h4>
    <div>

        <form action="#"><input type="text" id="txtCounty" /></form>
        <div id="get_json">get json</div>

        <hr />
        <div id="json_results" style="background-color: Silver; color: Navy; margin: 5px; width: 250px;">
            json results
        </div>

        <div id="show_when_odd" style="border: 1px solid black; margin: 5px; width: 250px;">
            only show this when the seconds are odd
        </div>

        <div>
        enable when seconds are even
        <form action="#">
            <input type="button" id="btnHello" value="hello" />
        </form>
        </div>
    </div>
</body>
</html>
