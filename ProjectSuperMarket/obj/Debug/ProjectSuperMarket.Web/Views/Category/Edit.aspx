<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProjectSuperMarket.Data.Azure.Category>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Name">Category Name:</label>
                <%= Html.TextBox("Name", Model.Name) %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="PartitionKey">Parent Category:</label>
                  <%--<%= Html.DropDownList("category", new SelectList((IEnumerable)ViewData["category"], "Name", "Name", Model.PartitionKey), new { style = "width: 240px" })%>--%>
                  <%--<%= Html.DropDownList("category", new SelectList((IEnumerable)ViewData["category"], "Name", "Name", ViewData["partitionKey"]), string.Empty, new { style = "width: 240px" })%>--%>
                  <%= Html.DropDownList("category", String.Empty) %>
                  <%= Html.ValidationMessage("category", "*")%>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

