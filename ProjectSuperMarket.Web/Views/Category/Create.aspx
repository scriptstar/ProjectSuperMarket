<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset class="fields">
            <legend>Create New Category</legend>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name") %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            
            <%--<% var categories = (IEnumerable<ProjectSuperMarket.Data.ICategory>)ViewData["categories"]; %>
            <%=Html.DropDownList(
                    "Partitionkey",
                    categories.Select(c => new SelectListItem { Text = c.Name, Value = c.PartitionKey}),
                    new { style = "width: 240px" })
                %>--%>
           <p>
           <label for="Name">Parent Category:</label>
              <%= Html.DropDownList("lstCategories", new SelectList((IEnumerable)Model, "Name", "Name"), string.Empty, new { style = "width: 240px" })%>
           </p>
           
            <p class="submit">
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
    
 <div class="divContactList-bottom">&nbsp;</div>

</asp:Content>

