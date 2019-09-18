<%@ Page Title="" Language="C#" MasterPageFile="~/MainLayout.Master" AutoEventWireup="true" CodeBehind="rTiposAnalisis.aspx.cs" Inherits="SistemaAnalisisAplicada2.UI.Registros.rTipoAnalisis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel runat="server">
		<ContentTemplate>
			<div class="panel panel-primary">
				<div class="panel-heading">Registro de Tipos de Analisis</div>




				<div class="panel-body">
					<div class="form-horizontal col-md-12" role="form">
						<div class="form-group">
							<div class="row">
								<label for="IdTextBox" class="col-md-3 control-label input-sm">Id: </label>
								<div class="col-md-1 col-sm-2 col-xs-4">
									<asp:TextBox ID="IdTextBox" runat="server" ReadOnly="True" placeholder="0" class="form-control input-sm"></asp:TextBox>
								</div>
								<div class="col-md-1 col-sm-2 col-xs-4">
									<a href="/UI/Consultas/cTiposAnalisis.aspx"><i class="fa fa-search"></i></a>
								</div>
							</div>
						</div>


						<div class="form-group">
							<label for="Nombre" class="col-md-3 control-label input-sm">Nombre</label>
							<div class="col-md-8">
								<asp:TextBox ID="NombreTextBox" runat="server"
									class="form-control input-sm"></asp:TextBox>
								<asp:RequiredFieldValidator ValidationGroup="grupoValidar" ID="RFVNombre" runat="server" maxlength="200"
									ControlToValidate="NombreTextBox"
									ErrorMessage="Campo Nombres obligatorio" ForeColor="Red"
									Display="Dynamic" SetFocusOnError="True"
									ToolTip="Campo Nombre obligatorio">Por favor llenar el campo Nombre
								</asp:RequiredFieldValidator>
							</div>
						</div>

						<div class="form-group">
							<label for="Precio" class="col-md-3 control-label input-sm">Précio</label>
							<div class="col-md-8">
								<asp:TextBox TextMode="Number" ID="PrecioTextBox" runat="server"
									class="form-control input-sm"></asp:TextBox>
								<asp:RequiredFieldValidator ValidationGroup="grupoValidar" ID="RequiredFieldValidator1" runat="server" maxlength="200"
									ControlToValidate="PrecioTextBox"
									ErrorMessage="Campo Precio obligatorio" ForeColor="Red"
									Display="Dynamic" SetFocusOnError="True"
									ToolTip="Campo Precio obligatorio">Por favor llenar el campo Precio
								</asp:RequiredFieldValidator>
							</div>
						</div>
					</div>



					<asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
				</div>

				<div class="panel-footer">
					<div class="text-center">
						<div class="form-group" style="display: inline-block">

							<asp:Button Text="Nuevo" class="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
							<asp:Button Text="Guardar" ValidationGroup="grupoValidar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
							<asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

						</div>
					</div>


				</div>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
