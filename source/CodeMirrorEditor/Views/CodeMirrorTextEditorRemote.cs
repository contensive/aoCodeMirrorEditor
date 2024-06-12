using Contensive.BaseClasses;
using Contensive.CodeMirrorEditor.Controllers;
using System;

namespace Contensive.CodeMirrorEditor.Views {
    public class CodeMirrorTextEditorRemote : AddonBaseClass {
        public override object Execute(CPBaseClass cp) {
            try {
                string editorName = cp.Doc.GetText("editorName");
                string editorValue = cp.Utils.EncodeHTML(cp.Doc.GetText("editorValue"));
                bool readOnly = cp.Doc.GetBoolean("editorReadOnly");
                string editorId = cp.Doc.GetText("editorId");
                if (string.IsNullOrEmpty(editorId)) { editorId = GenericController.getRandomString(8); }
                cp.Doc.AddHeadStyleLink("/codemirror-5.52.0/lib/codemirror.css");
                cp.Doc.AddHeadStyleLink("/codemirror-5.52.0/addon/display/fullscreen.css");
                cp.Doc.AddHeadStyleLink("/codemirror-5.52.0/theme/idea.css");
                cp.Doc.AddHeadJavascriptLink("/codemirror-5.52.0/lib/codemirror.js");
                cp.Doc.AddHeadJavascriptLink("/codemirror-5.52.0/addon/display/fullscreen.js");
                cp.Doc.AddHeadJavascriptLink("/codemirror-5.52.0/addon/display/autorefresh.js");
                //
                string result = "" +
                    $"<div class=codeMirrorEditor>" +
                    $"<textarea id=\"{editorId}\" name=\"{editorName}\" rows=\"30\">{editorValue}</textarea>" +
                    $"</div>" +
                    $"<script type=\"text/javascript\">" +
                    $"document.addEventListener(\"DOMContentLoaded\", function(event){{" +
                        $"initCodeMirrorHtmlEditor(\"{editorId}\",{(readOnly ? "true" : "false")});" +
                    $"}});" +
                    $"</script>";
                //string result = "" +
                //    $"<div class=codeMirrorEditor>" +
                //    $"<textarea id=\"{editorId}\" name=\"{editorName}\" rows=\"30\">{editorValue}</textarea>" +
                //    $"</div>";
                //string resultJs = "" +
                //    $"document.addEventListener(\"DOMContentLoaded\", function(event){{" +
                //        $"initCodeMirrorHtmlEditor(\"{editorId}\",{(readOnly ? "true" : "false")});" +
                //    $"}});";
                //cp.Doc.AddHeadJavascript(resultJs);
                return result;
            } catch (Exception ex) {
                cp.Site.ErrorReport(ex);
                throw;
            }
        }
    }
}
