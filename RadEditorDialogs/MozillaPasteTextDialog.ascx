<%@ Control Language="C#" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI.Editor" TagPrefix="tools" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI.Widgets" TagPrefix="widgets" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI.Dialogs" TagPrefix="dialogs" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<script type="text/javascript">
	Type.registerNamespace("Telerik.Web.UI.Widgets");

	Telerik.Web.UI.Widgets.MozillaPasteTextDialog=function(element) {
		Telerik.Web.UI.Widgets.MozillaPasteTextDialog.initializeBase(this,[element]);
		this._document=null;
		this._container=null;
		this._confirmButton=null;
		this._cancelButton=null;
		this._messageContaner=null;
	}

	Telerik.Web.UI.Widgets.MozillaPasteTextDialog.prototype={
		initialize: function() {
			Telerik.Web.UI.Widgets.MozillaPasteTextDialog.callBaseMethod(this,"initialize");

			this._initChildren();
		},

		_initChildren: function() {
			this._container=$get("holder");

			this._confirmButton=$get("InsertButton");
			this._confirmButton.title=localization["Paste"];
			this._cancelButton=$get("CancelButton");
			this._cancelButton.title=localization["Cancel"];
			this._messageContaner=$get("MessageContaner");

			$addHandlers(this._confirmButton,{ "click": this._confirmButtonClickHandler },this);
			$addHandlers(this._cancelButton,{ "click": this._cancelButtonClickHandler },this);
		},

		clientInit: function(cilentParameters) {
			var container=this._container;
			container.value="";
			setTimeout(function() {
				container.focus();
			},50);

			this._messageContaner.innerHTML=this.get_commandTip(cilentParameters.commandName);
		},

		get_commandTip: function(commandName) {
			var tipHtml="";
			switch(commandName) {
				case "PasteHtml":
					tipHtml=localization["PasteHtmlMessage"];
					break;
				case "PasteMarkdown":
					tipHtml=localization["PasteMarkdownMessage"];
					break;
				default:
					tipHtml=localization["UseControlVMessage"]
					break;
			}
			return tipHtml;
		},

		_confirmButtonClickHandler: function(e) {
			var eventArgs=new Sys.EventArgs();
			eventArgs._content=this._container.value;
			eventArgs.get_content=function() { return this._content; };
			Telerik.Web.UI.Dialogs.CommonDialogScript.get_windowReference().close(eventArgs);
		},

		_cancelButtonClickHandler: function(e) {
			Telerik.Web.UI.Dialogs.CommonDialogScript.get_windowReference().close();
		},

		dispose: function() {
			$clearHandlers(this._confirmButton);
			$clearHandlers(this._cancelButton);
			this._container=null;
			this._document=null;
			this._confirmButton=null;
			this._cancelButton=null;

			Telerik.Web.UI.Widgets.MozillaPasteTextDialog.callBaseMethod(this,"dispose");
		}
	}

	Telerik.Web.UI.Widgets.MozillaPasteTextDialog.registerClass("Telerik.Web.UI.Widgets.MozillaPasteTextDialog",Telerik.Web.UI.RadWebControl,Telerik.Web.IParameterConsumer);
</script>
<div class="redMainContainer">
	<div class="redMozillaPasteTextDialog">
		<div class="redWrapper">
			<table  class="reDialog" style="width: 99%; height: 250px; margin-left: 2px; margin-bottom: 4px;">
				<tr>
					<td>
						<div id="MessageContaner">&nbsp;</div>
						<textarea id="holder" rows="12" style="width: 100%;" class="TextAreaWidth"></textarea>
					</td>
				</tr>
			</table>
		</div>
		<div class="redActionButtonsWrapper redActionButtonsAbsoluteWrapper redActionButtonsWrapperExternal" runat="server">
				<button type="button" id="InsertButton" class="rfdPrimaryButton rfdFlatButton">
					<script type="text/javascript">
						setInnerHtml("InsertButton",localization["Paste"]);
					</script>
				</button>
				<button type="button" id="CancelButton" class="rfdFlatButton">
					<script type="text/javascript">
						setInnerHtml("CancelButton",localization["Cancel"]);
					</script>
				</button>
			</div>
	</div>
</div>
