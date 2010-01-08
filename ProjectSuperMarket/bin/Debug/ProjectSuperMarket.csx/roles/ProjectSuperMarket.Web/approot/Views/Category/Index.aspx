<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProjectSuperMarket.Data.Azure.Category>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Index</h2>
  <table class="data-table" cellpadding="0" cellspacing="0">
      <thead>
        <tr>
            <th class="actions edit">
               Edit
            </th>
            <th class="actions edit">
               Delete
            </th>
            <th>
                Sub Category
            </th>
            <th>
                Parent Category
            </th>
         </tr>
      </thead>
    <tbody>
      <% foreach (var item in Model) { %>
        <tr>
            <td class="actions edit">
                <a href='<%= Url.Action("Edit", new {partitionKey = item.PartitionKey, rowKey =item.RowKey}) %>'><img src="../../Content/Edit.png" alt="Edit" /></a>
            </td>
            <td class="actions delete">
                <a href='<%= Url.Action("Delete", new {partitionKey = item.PartitionKey, rowKey = item.RowKey}) %>'><img src="../../Content/Delete.png" alt="Delete" /></a>
            </td>
            <th>
                <%= Html.Encode(item.Name) %>
            </th>
            <td>
                <%= Html.Encode(item.PartitionKey) %>
            </td>
        </tr>
      <% } %>
    </tbody>
  </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

