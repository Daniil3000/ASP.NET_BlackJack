<%@ Page Title="Play Black Jack" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BlackJack.aspx.cs" Inherits="BJTest.BlackJack" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div id="GameTable" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblAccount" runat="server" Text="Account" ForeColor="White" Font-Size="X-Large"></asp:Label>
            &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtAccount" runat="server" Width="60px" Font-Size="X-Large" BackColor="Magenta" ForeColor="White"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;
               <asp:DropDownList ID="ddlBetAmount" runat="server" Font-Size="X-Large" CssClass="auto-style3">
                   <asp:ListItem>2</asp:ListItem>
                   <asp:ListItem>10</asp:ListItem>
                   <asp:ListItem>20</asp:ListItem>
                   <asp:ListItem>40</asp:ListItem>
                   <asp:ListItem>80</asp:ListItem>
                   <asp:ListItem>100</asp:ListItem>
               </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBet" runat="server" Font-Size="X-Large" Text="Bet" BackColor="Black" ForeColor="White" OnClick="btnBet_Click" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <div id="DivDealerHand" runat="server">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="imgDealerCard1" runat="server" Height="240px" Width="160px" />
                <asp:Image ID="imgDealerCard2" runat="server" Height="240px" Width="160px" />
                <asp:Image ID="imgDealerCard3" runat="server" Height="240px" Width="160px" />
                <asp:Image ID="imgDealerCard4" runat="server" Height="240px" Width="160px" />
                <asp:Image ID="imgDealerCard5" runat="server" Height="240px" Width="160px" />
                <br />
            </div>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblDealerScore" runat="server" Text="Dealer Score" ForeColor="White" Font-Size="X-Large" Visible="false"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDealerScore" runat="server" Visible="false" Font-Size="X-Large" BackColor="Navy" ForeColor="White" Width="80px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblResult" runat="server" Text="Result" Font-Size="X-Large" BackColor="Red" ForeColor="White" Visible="false"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="txtResult" runat="server" Visible="false" ForeColor="Black" BackColor="Yellow" Font-Size="X-Large"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnNewHand" runat="server" Text="New Hand" Font-Size="X-Large" BackColor="Black" ForeColor="White" OnClick="btnNewHand_Click" CssClass="auto-style1" Height="40px" Width="170px" />
            &nbsp;&nbsp;
            <asp:Button ID="btnNewGame" runat="server" Font-Size="X-Large" BackColor="Black" ForeColor="Red" Height="40px" Text="New Game" Width="170px" Visibility="False" OnClick="btnNewGame_Click" />
            <br />
            <br />
            <div id="DivPlayerHand" runat="server">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Image ID="imgPlayerCard1" runat="server" Height="240px" Width="160px" />
                <asp:Image ID="imgPlayerCard2" runat="server" Height="240px" Width="160px" />
                <asp:Image ID="imgPlayerCard3" runat="server" Height="240px" Width="160px" />
                <asp:Image ID="imgPlayerCard4" runat="server" Height="240px" Width="160px" />
                <asp:Image ID="imgPlayerCard5" runat="server" Height="240px" Width="160px" />
                <br />
                <br />
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnHit" runat="server" BackColor="Yellow" ForeColor="Purple" Text="Hit Me!" Font-Size="X-Large" OnClick="btnHit_Click" Width="160px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPlayerScore" runat="server" Text="Player Score" ForeColor="White" Font-Size="X-Large"></asp:Label>


            &nbsp;&nbsp;
            <asp:TextBox ID="txtPlayerScore" Font-Size="X-Large" BackColor="Navy" ForeColor="White" runat="server" Width="60px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnStand" runat="server" BackColor="Red" ForeColor="White" Text="Stand" Font-Size="X-Large" OnClick="btnStand_Click" Width="160px" CssClass="auto-style2" Height="40px" />

            <br />
            <br />
            &nbsp;<br />
            <br />
       
    </div>
</asp:Content>