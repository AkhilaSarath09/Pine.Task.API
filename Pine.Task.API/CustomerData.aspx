<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerData.aspx.cs" Inherits="Pine.Task.API.CustomerData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Information</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Customer Name
            <asp:TextBox ID="customerName" runat="server"></asp:TextBox>
            Address
            <asp:TextBox ID="Address" runat="server"></asp:TextBox>
            City
            <asp:TextBox ID="city" runat="server"></asp:TextBox>
            Mobile
            <asp:TextBox ID="mobile" runat="server"></asp:TextBox>
            <asp:Button ID="CreateCustomer" runat="server" Text="Save" OnClick="CreateCustomer_Click" />
        </div>
        <div>

            <asp:GridView ID="customergrid" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="customergrid_RowDeleting">
                <Columns>
                    <asp:TemplateField>
                       
                        <ItemTemplate>
                            <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" />
                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Name" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Address" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Address" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:Label ID="lbl_City" runat="server" Text='<%#Eval("City") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_City" runat="server" Text='<%#Eval("City") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobile">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Mobile" runat="server" Text='<%#Eval("Mobile") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Mobile" runat="server" Text='<%#Eval("Mobile") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" HeaderText="Delete" />   
                </Columns>
                <HeaderStyle BackColor="#663300" ForeColor="#ffffff" />
                <RowStyle BackColor="#e7ceb6" />
            </asp:GridView>

            <%-- <asp:GridView ID="customergrid" runat="server" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>
                    </EditItemTemplate>
                </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Customer Name" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                </Columns>
            </asp:GridView>--%>
        </div>
    </form>
</body>
</html>
