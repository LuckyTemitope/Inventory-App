<%@ Page Title="" Language="C#" MasterPageFile="~/HOME.Master" AutoEventWireup="true" CodeBehind="Storage.aspx.cs" Inherits="Lab_03.Storage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 260px;
        }

        .auto-style3 {
            width: 201px;
        }

       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="storage-container">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Product ID</td>
                <td class="auto-style3">
                    <asp:TextBox ID="idTxt" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="loadBtn" runat="server" OnClick="loadBtn_Click" Text="Load" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Name</td>
                <td class="auto-style3">
                    <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Product Price</td>
                <td class="auto-style3">
                    <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="priceTxt" ErrorMessage="Enter a valid price!" ForeColor="Red" Type="Double"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Quantity</td>
                <td class="auto-style3">
                    <asp:TextBox ID="quantityTxt" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="quantityTxt" ErrorMessage="Invalid Quantity!" ForeColor="Red" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="insertBtn" runat="server" Text="Insert" OnClick="insertBtn_Click" />
                    &nbsp;<asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />
                    &nbsp;<asp:Button ID="deleteBtn" runat="server" Text="Delete" OnClick="deleteBtn_Click" />
                    <br />
                    <asp:Button ID="clearBtn" runat="server" OnClick="clearBtn_Click" Text="Clear" />
                    &nbsp;<asp:Button ID="viewBtn" runat="server" OnClick="viewBtn_Click" Text="View Inventory" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="messageLbl" runat="server" Text="Message"></asp:Label>
        <br />
        <br />
        <br />
        <asp:GridView ID="inventoryList" runat="server">
        </asp:GridView>
        <br />
        <br />
    </div>

</asp:Content>
