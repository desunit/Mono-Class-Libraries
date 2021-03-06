//
// System.Web.UI.WebControls.ButtonFieldBase.cs
//
// Authors:
//	Lluis Sanchez Gual (lluis@novell.com)
//
// (C) 2005 Novell, Inc (http://www.novell.com)
//

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#if NET_2_0
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;
using System.ComponentModel;
using System.Security.Permissions;

namespace System.Web.UI.WebControls {

	[AspNetHostingPermissionAttribute (SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	[AspNetHostingPermissionAttribute (SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public abstract class ButtonFieldBase : DataControlField
	{
		[DefaultValueAttribute (ButtonType.Link)]
		[WebSysDescription ("")]
		[WebCategoryAttribute ("Appearance")]
		public virtual ButtonType ButtonType {
			get { return (ButtonType) ViewState.GetInt ("ButtonType", (int) ButtonType.Link); }
			set {
				ViewState ["ButtonType"] = value;
				OnFieldChanged ();
			}
		}

		[DefaultValueAttribute (false)]
		[WebSysDescription ("")]
		[WebCategoryAttribute ("Behavior")]
		public virtual bool CausesValidation {
			get { return ViewState.GetBool ("CausesValidation", false); }
			set {
				ViewState ["CausesValidation"] = value;
				OnFieldChanged ();
			}
		}

		[DefaultValueAttribute (false)]
		[WebSysDescription ("")]
		[WebCategoryAttribute ("Behavior")]
		public override bool ShowHeader {
			get { return ViewState.GetBool ("showHeader", false); }
			set { 
				ViewState ["showHeader"] = value;
				OnFieldChanged ();
			}
		}

		[DefaultValueAttribute ("")]
		[WebSysDescription ("")]
		[WebCategoryAttribute ("Behavior")]
		public virtual string ValidationGroup {
			get { return ViewState.GetString ("ValidationGroup", ""); }
			set {
				ViewState ["ValidationGroup"] = value;
				OnFieldChanged ();
			}
		}
		
		protected override void CopyProperties (DataControlField newField)
		{
			base.CopyProperties (newField);
			ButtonFieldBase field = (ButtonFieldBase) newField;
			field.ButtonType = ButtonType;
			field.CausesValidation = CausesValidation;
			field.ShowHeader = ShowHeader;
			field.ValidationGroup = ValidationGroup;
		}
	}
}
#endif
