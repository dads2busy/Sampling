<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SuperSimpleSampler._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script language="javascript" type="text/javascript">
        function proportional()
        {
            document.getElementById('<%= minRangeValue.ClientID %>').value = '0';
            document.getElementById('<%= minRangeValue.ClientID %>').disabled = true;
            document.getElementById('<%= maxRangeValue.ClientID %>').value = '1';
            document.getElementById('<%= maxRangeValue.ClientID %>').disabled = true;
            document.getElementById('<%= standardDeviation.ClientID %>').value = '.5';
            document.getElementById('<%= standardDeviation.ClientID %>').disabled = true;
            document.getElementById('<%= population_N.ClientID %>').value = '500000';
            document.getElementById('<%= confidence.ClientID %>').value = '.95';
            document.getElementById('<%= error.ClientID %>').value = '.05';
            document.getElementById('<%= sample_n.ClientID %>').value = '384';
            if (document.getElementById('<%= HiddenField1.ClientID %>').value == 'SampleSize') {
                document.getElementById('<%= sample_n.ClientID %>').value = '';
            }
            if (document.getElementById('<%= HiddenField1.ClientID %>').value == 'MarginOfError') {
                document.getElementById('<%= error.ClientID %>').value = '';
            }
                 
        }
        function point() {
            document.getElementById('<%= minRangeValue.ClientID %>').value = '0';
            document.getElementById('<%= minRangeValue.ClientID %>').disabled = false;
            document.getElementById('<%= maxRangeValue.ClientID %>').value = '100';
            document.getElementById('<%= maxRangeValue.ClientID %>').disabled = false;
            document.getElementById('<%= standardDeviation.ClientID %>').value = '50';
            document.getElementById('<%= standardDeviation.ClientID %>').disabled = false;
            document.getElementById('<%= confidence.ClientID %>').value = '.95';         
            document.getElementById('<%= population_N.ClientID %>').value = '500000';
            document.getElementById('<%= error.ClientID %>').value = '5';
            document.getElementById('<%= error.ClientID %>').disabled = false;
            document.getElementById('<%= sample_n.ClientID %>').value = '384';
            if (document.getElementById('<%= HiddenField1.ClientID %>').value == 'SampleSize') {
                document.getElementById('<%= sample_n.ClientID %>').value = '';
            }
            if (document.getElementById('<%= HiddenField1.ClientID %>').value == 'MarginOfError') {
                document.getElementById('<%= error.ClientID %>').value = '';
            }
        }

        function selected(value) {
            document.getElementById('<%= HiddenField1.ClientID %>').value = value;
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Random Sample Size and Margin of Error Calculator
    </h2>
    
    <table>
    <tr>
        <td valign="top" width="175px"><asp:Label ID="Label8" runat="server" Text="Solve for: " /></td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Text="Sample Size" Value="SampleSize" onclick="selected('SampleSize')" />
                <asp:ListItem Text="Margin of Error" Value="MarginOfError" onclick="selected('MarginOfError')" />
            </asp:RadioButtonList>
        </td>
        <td></td>
    </tr>
    <tr>
        <td valign="top"><asp:Label ID="Label10" runat="server" Text="Type of Question: " /></td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                <asp:ListItem Text="Proportional (Yes/No)" Value="proportional" onclick="proportional()" />
                <asp:ListItem Text="Point (Mean, Median)" Value="point" onclick="point()" />
            </asp:RadioButtonList>
        </td>
        <td></td>
    </tr>
    <tr>
        <td><asp:Label ID="minRangeVal" runat="server" Text="Question Range Min Value: " /></td>
        <td><asp:TextBox ID="minRangeValue" runat="server"></asp:TextBox></td>
        <td style="font-size:x-small">Minimum value of scale being measured (e.g. 0 for a 100 point test). For proportional estimation this number is set to 0.</td>
    </tr>
    <tr>
        <td><asp:Label ID="maxRangeVal" runat="server" Text="Question Range Max Value: " /></td>
        <td><asp:TextBox ID="maxRangeValue" runat="server"></asp:TextBox></td>
        <td style="font-size:x-small">Maximum value of scale being measured (e.g. 100 for a 100 point test). For proportional estimation this number is set to 1.</td>
    </tr>
    <tr>
        <td><asp:Label ID="Label1" runat="server" Text="Confidence: " /></td>
        <td><asp:TextBox ID="confidence" runat="server"></asp:TextBox></td>
        <td style="font-size:x-small">Needs to be expressed in decimal percentage form (e.g. .95 = 95%)</td>
    </tr>
    <tr>
        <td><asp:Label ID="Label2" runat="server" Text="Margin of Error: " /></td>
        <td><asp:TextBox ID="error" runat="server"></asp:TextBox></td>
        <td style="font-size:x-small">For point estimation (e.g. for means), needs to be in the units being measured. For proportional estimation (e.g. either/or, yes/no), needs to be in standardized form (e.g. .05 means +-5%).</td>
    </tr>
    <tr>
        <td><asp:Label ID="Label3" runat="server" Text="Standard Deviation: " /></td>
        <td><asp:TextBox ID="standardDeviation" runat="server"></asp:TextBox></td>
        <td style="font-size:x-small">For point estimation (e.g. for means), needs to be in the units being measured. For proportional estimation (e.g. either/or, yes/no), sd is standardized and set at the most conservative "50-50" setting 0.5.</td>
    </tr>
    <tr>
        <td><asp:Label ID="Label4" runat="server" Text="Population N: " /></td>
        <td><asp:TextBox ID="population_N" runat="server"></asp:TextBox></td>
        <td style="font-size:x-small">Really only begins to matter below 5,000. Default is 500,000.</td>
    </tr>
    <tr>
        <td><asp:Label ID="Label5" runat="server" Text="Sample n: " /></td>
        <td><asp:TextBox ID="sample_n" runat="server"></asp:TextBox></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="Calculate" runat="server" Text="Calculate" onclick="Calculate_Click" /></td>
        <td></td>
    </tr>
    </table>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
