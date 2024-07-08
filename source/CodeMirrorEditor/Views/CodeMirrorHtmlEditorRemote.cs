using Contensive.BaseClasses;
using Contensive.CodeMirrorEditor.Controllers;
using System;

namespace Contensive.CodeMirrorEditor.Views {
    public class CodeMirrorHtmlEditorRemote : AddonBaseClass {
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
                cp.Doc.AddHeadJavascriptLink("/codemirror-5.52.0/mode/xml/xml.js");
                cp.Doc.AddHeadJavascriptLink("/codemirror-5.52.0/mode/javascript/javascript.js");
                cp.Doc.AddHeadJavascriptLink("/codemirror-5.52.0/mode/css/css.js");
                cp.Doc.AddHeadJavascriptLink("/codemirror-5.52.0/mode/htmlmixed/htmlmixed.js");
                //
                string result = "" +
                    $"<div class=codeMirrorEditor>" +
                    $"<textarea id=\"{editorId}\" name=\"{editorName}\" rows=\"5\">{editorValue}</textarea>" +
                    $"</div>" +
                    $"<script type=\"text/javascript\">" +
                    $"document.addEventListener(\"DOMContentLoaded\", function(event){{" +
                        $"initCodeMirrorHtmlEditor(\"{editorId}\",{(readOnly ? "true" : "false")});" +
                    $"}});" +
                    $"</script>";
                return result;
            } catch (Exception ex) {
                cp.Site.ErrorReport(ex);
                throw;
            }
        }
    }
}
