<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="SimpleCart.Cart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/vue@2"></script>
    <h2>My Shopping Cart</h2>
    <div id="app">
        <ul>
            <li v-for="p in products">
                {{p.title}} ${{p.price}} <button type="button" v-on:click="p.n--">-</button><input name="p{{p.id}}" v-model="p.n"/><button type="button" v-on:click="p.n++">+</button> <button type="button" v-on:click="remove(p.i)">Remove</button>
            </li>
        </ul>
        <button>Purchase</button>
    </div>
    <script>
        var app = new Vue({
            el: '#app',
            data: {
                products: []
            },
            created: function () {
                $.ajax({
                    type: "POST",
                    url: "Cart.aspx/GetProducts",
                    data: "{ids: '1'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        var response = JSON.parse(msg.d);
                        var cart = [{ id: 1, i: 0, n: 3, title: "Invalid Product", price: 0 }];
                        for (p of cart) {
                            for (pi of response) {
                                if (p.id == pi.id) {
                                    p.title = pi.title;
                                    p.price = pi.price;
                                    found = true;
                                    app.products.push(p);
                                    break;
                                }
                            }
                        }
                    }
                });
            },
            methods: {
                remove: function (index) {
                    this.products.splice(index,1);
                }
            }
        })
    </script>
</asp:Content>